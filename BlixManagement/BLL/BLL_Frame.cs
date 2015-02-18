using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;

namespace BLL
{
    public class BLL_Frame:BaseBLL<T_Frame>
    {
        DAL_Frame dal = new DAL_Frame();
        

        public int Modify(T_Frame frame)
        {
            return dal.Modify(frame);
        }

        public int ModifySimilarFrames(T_Frame frame)
        {
            return dal.ModifySimilarFrames(frame);
        }


    }
}
