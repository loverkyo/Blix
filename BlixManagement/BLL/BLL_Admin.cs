using MODEL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Admin:BaseBLL<T_User>
    {
        DAL_Admin dalUser = new DAL_Admin();

        public T_Admin ValidateLogin(string username, string password)
        {
            return dalUser.ValidateLogin(username,password);
        }
    }
}
