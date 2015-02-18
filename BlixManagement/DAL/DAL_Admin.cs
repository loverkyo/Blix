using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Admin:BaseDAL<T_Admin>
    {
        
        public T_Admin ValidateLogin(string username, string password)
        {
            T_Admin admin= SelectBy(i=>(i.Username==username)&&(i.Password==password)).FirstOrDefault();
            return admin;
        }
    }
}
