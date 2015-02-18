using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;
using System.Data;

namespace BLL
{
    public class BLL_Color:BaseBLL<T_Color>
    {
        DAL_Color dal = new DAL_Color();
       
    }
}
