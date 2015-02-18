using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.Entity.Infrastructure;

namespace DAL
{
    public class DAL_Frame:BaseDAL<T_Frame>
    {
        

        public int Modify(T_Frame frame)
        {
            
            using (BlixManagementEntities entity = new BlixManagementEntities())
            {
                bool IsModify = false;
                T_Frame oldFrame = entity.T_Frame.Where(a => a.ID == frame.ID).SingleOrDefault();
                PropertyInfo[] pi = typeof(T_Frame).GetProperties(BindingFlags.Public | BindingFlags.Instance|BindingFlags.DeclaredOnly);
                foreach (PropertyInfo item in pi)
                {                   
                   if (item.PropertyType.Namespace!="MODEL")
                    {                       
                        object propertyValue = item.GetValue(frame);
                        object oldpropertyValue = item.GetValue(oldFrame);
                        if ((propertyValue!=null)||(oldpropertyValue!=null))
                        {
                            if (!propertyValue.Equals(oldpropertyValue))
                            {
                                item.SetValue(oldFrame, propertyValue);
                                IsModify = true;
                            }
                        }
                    }
                }
                if (IsModify)
                {
                    foreach (PropertyInfo item in pi)
                    {
                        if (((MemberInfo)(item)).Name == "UpdateDate")
                        {
                            item.SetValue(oldFrame, DateTime.Now);
                        }
                    }
                    return entity.SaveChanges();
                }
                return -1;
             
            }
        }


         public int ModifySimilarFrames(T_Frame frame)
        {
         using ( BlixManagementEntities entity=new BlixManagementEntities())
         {
            
            List<T_Frame> frames = entity.T_Frame.Where(a => a.FrameSNID == frame.FrameSNID).ToList();
            foreach (T_Frame item in frames)
            {
                item.FrameCategoryID = frame.FrameCategoryID;
                item.FrameMaterialID = frame.FrameMaterialID;
                item.FrameShapeID = frame.FrameShapeID;
                item.FrameSizeID = frame.FrameSizeID;
                item.FrameTypeID = frame.FrameTypeID;
                item.GenderID = frame.GenderID;
                item.IfSpring = frame.IfSpring;
                item.IfBiofocal = frame.IfBiofocal;
                item.Description = frame.Description;
                item.Description_CN = frame.Description_CN;
                item.CostRMB = frame.CostRMB;
                item.CostUSD = frame.CostUSD;
                item.PriceRMB = frame.PriceRMB;
                item.PriceUSD = frame.PriceUSD;
                item.SupplierID = frame.SupplierID;
                item.BrandID = frame.BrandID;
                item.UpdateDate = frame.UpdateDate;
                
            }
          return  entity.SaveChanges();
         }
             return -1;
        }
    }
}
