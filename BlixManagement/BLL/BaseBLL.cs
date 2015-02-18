using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Linq.Expressions;

namespace BLL
{
    public class BaseBLL<T> where T : class
    {
        BaseDAL<T> baseDAL = new BaseDAL<T>();

        #region 返回所有该类集合
        /// <summary>
        /// 返回所有该类集合
        /// </summary>
        /// <param name="model">类名</param>
        /// <returns></returns>
        public List<T> GetList()
        {
            return baseDAL.GetAll();
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
            return baseDAL.Add(model);
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
            return baseDAL.Del(model);
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
            return baseDAL.DelBy(where);
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
            return baseDAL.Modify(model, proNames);
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
            return baseDAL.ModifyBy(model, where, proNames);
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
            return baseDAL.SelectBy(where);
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
            return baseDAL.SelectByOrderBy(where, orderlambda);
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
        public List<T> SelectByOrderBy<key>(Expression<Func<T, bool>> where, Expression<Func<T, key>> orderlambda, int pagesize, int pageindex)
        {
            return baseDAL.SelectByOrderBy(where, orderlambda, pagesize, pageindex);
        }

        #endregion

    }
}
