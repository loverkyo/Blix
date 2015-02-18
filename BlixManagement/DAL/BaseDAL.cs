using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.Reflection;

namespace DAL
{

    //所有EF类的父类，内含所有公共方法，增删改查
    public class BaseDAL<T> where T : class
    {

        BlixManagementEntities entity = new BlixManagementEntities();

        #region 返回所有该类集合
        /// <summary>
        /// 返回所有该类集合
        /// </summary>
        /// <param name="model">类名</param>
        /// <returns></returns>
        public List<T> GetAll()
        {
            return entity.Set<T>().ToList();
        }
        #endregion


        #region 增加单条数据
        /// <summary>
        /// 增加单条数据
        /// </summary>
        /// <param name="model">要增加的对象</param>
        /// <returns></returns>
        public int Add(T model)
        {
            entity.Set<T>().Add(model);
            return entity.SaveChanges();
        }
        #endregion


        #region 删除单条数据
        /// <summary>
        /// 删除单条数据
        /// </summary>
        /// <param name="model">要删除的对象，必须包含id</param>
        /// <returns></returns>
        public int Del(T model)
        {
            entity.Set<T>().Attach(model); //添加到EF容器
            entity.Set<T>().Remove(model); //标记为删除状态
            return entity.SaveChanges();
        }
        #endregion


        #region 根据条件批量删除数据
        /// <summary>
        /// 根据条件批量删除数据
        /// </summary>
        /// <param name="where">条件表达式</param>
        /// <returns></returns>
        public int DelBy(Expression<Func<T, bool>> where)
        {
            //根据条件查询到对象集合
            List<T> models = entity.Set<T>().Where(where).ToList();

            //遍历对象集合，逐个删除对象
            foreach (var item in models)
            {
                entity.Set<T>().Attach(item); //添加到EF容器
                entity.Set<T>().Remove(item); //标记为删除状态
            }

            return entity.SaveChanges();
        }
        #endregion


        #region 修改单条数据
        /// <summary>
        /// 修改单条数据
        /// </summary>
        /// <param name="model">要修改的对象</param>
        /// <param name="proNames">要修改的属性名称数组</param>
        /// <returns></returns>
        public int Modify(T model, params string[] proNames)
        {
            
            //把对象添加到EF中
            DbEntityEntry entry = entity.Entry<T>(model);
           
            //设置对象的状态为unchanged
            entry.State = EntityState.Unchanged;

            //循环需要修改的属性名称数组
            foreach (string proName in proNames)
            {
                //将需要修改的属性状态标记为已修改，方便后面只为该属性生成update语句
                entry.Property(proName).IsModified = true;
            }

            return entity.SaveChanges();
        }     

        #endregion
        

        #region 根据条件批量修改
        /// <summary>
        /// 按条件筛选出对象集合，把他们批量修改为model对象
        /// </summary>
        /// <param name="model">要修改成为的对象</param>
        /// <param name="where">条件查询</param>
        /// <param name="proNames">哪些属性要修改</param>
        /// <returns></returns>
        public int ModifyBy(T model, Expression<Func<T, bool>> where, params string[] proNames)
        {
            //查找出要修改的数据
            List<T> models = entity.Set<T>().Where(where).ToList();

            //通过反射获取实例对象
            Type t = typeof(T);

            //获取实例对象里面的所有属性对象
            PropertyInfo[] proinfos = t.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            //为方便查找，建立属性字典，把实例对象中的所有属性对象放入字典
            Dictionary<string, PropertyInfo> proDic = new Dictionary<string, PropertyInfo>();
            foreach (PropertyInfo proinfo in proinfos)
            {
                proDic.Add(proinfo.Name, proinfo);
            }

            //遍历需修改的属性名称，从字典中找出对应属性对象
            foreach (string proName in proNames)
            {
                //通过反射取值得到修改后的新值
                PropertyInfo pi = proDic[proName];
                object newValue = pi.GetValue(model);

                //遍历需要修改的对象集合
                foreach (T item in models)
                {
                    //把每个对象对应的属性值改成新值
                    pi.SetValue(item, newValue);
                }
            }

            return entity.SaveChanges();
        } 
        #endregion


        #region 根据条件查询
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public List<T> SelectBy(Expression<Func<T, bool>> where)
        {
       
            return entity.Set<T>().Where(where).ToList();
        }
        
        #endregion


        #region 根据条件查询并排序
        /// <summary>
        /// 根据条件查询并排序
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="orderlambda">排序字段</param>
        /// <returns></returns>
        public List<T> SelectByOrderBy<key>(Expression<Func<T, bool>> where, Expression<Func<T, key>> orderlambda)
        {
            return entity.Set<T>().Where(where).OrderBy(orderlambda).ToList();
        }

        #endregion


        #region 根据条件查询并排序和分页
        /// <summary>
        /// 根据条件查询并排序和分页
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="orderlambda">排序字段</param>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public List<T> SelectByOrderBy<key>(Expression<Func<T, bool>> where, Expression<Func<T, key>> orderlambda,int pagesize,int pageindex)
        {
            return entity.Set<T>().Where(where).OrderBy(orderlambda).Skip(pagesize*(pageindex-1)).Take(pagesize).ToList();
        }

        #endregion

    }
}
