using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace BLL
{
    public class ExcelHelper
    {
        BLL_Frame bll_frame = new BLL_Frame();
        BLL_FrameCategory bll_framcategory = new BLL_FrameCategory();
        BLL_FrameMaterial bll_framematerial = new BLL_FrameMaterial();
        BLL_FrameShape bll_frameshape = new BLL_FrameShape();
        BLL_FrameSize bll_framesize = new BLL_FrameSize();
        BLL_FrameSN bll_framesn = new BLL_FrameSN();
        BLL_FrameStyle bll_framestyle = new BLL_FrameStyle();
        BLL_FrameType bll_frametype = new BLL_FrameType();
        BLL_Color bll_color = new BLL_Color();

        #region 导入镜架数据，格式为SN，COLOR，CostRMB，Lens Height,Frame Width,Lens Width,NoseBridge,Temple length,material,Gender,Spring,Rim
        public List<T_Frame> LoadFrameDataFromExcel(string filename)
        {
           
                List<List<string>> listOfAllStr = new List<List<string>>();
                List<T_Frame> listOfAllFrames = new List<T_Frame>();

                #region 读取excel文件内容到List中
                //读取excel文件内容到List<List<string>> 中		  
                using (FileStream fs = File.OpenRead(filename))   //打开myxls.xls文件
                {
                    HSSFWorkbook wk = new HSSFWorkbook(fs);   //把xls文件中的数据写入wk中
                    ISheet sheet = wk.GetSheetAt(0);   //读取第一张表数据
                    for (int j = 1; j <= sheet.LastRowNum; j++)  //LastRowNum 是当前表的总行数，从第二行开始
                    {
                        List<string> oneRowStr = new List<string>();
                        IRow row = sheet.GetRow(j);  //读取当前行数据
                        if (row != null)
                        {
                            for (int i = 0; i < row.Cells.Count(); i++)
                            {
                                oneRowStr.Add(row.Cells[i].ToString());
                            }
                        }
                        listOfAllStr.Add(oneRowStr);
                    }
                }
                #endregion

                //处理list数据
                foreach (List<string> rowStr in listOfAllStr)
                {
                    T_Frame newframe = new T_Frame();
                    #region 处理第一列SN
                    //判断SN是否存在，否则新添，有则用现成的            
                    string strsn = rowStr[0].ToUpper();
                    T_FrameSN framesn = bll_framesn.SelectBy(a => a.SN == strsn).FirstOrDefault();
                    if (framesn != null)
                    {
                        newframe.FrameSNID = framesn.ID;
                    }
                    else
                    {
                        framesn = new T_FrameSN() { SN = strsn };
                        bll_framesn.Add(framesn);
                        newframe.FrameSNID = framesn.ID;
                    }
                    
                    #endregion

                    #region 读取第二列color
                    //判断color是否存在，否则新添，有则用现成的               
                    string strcolor = rowStr[1].ToUpper();
                    T_Color color = bll_color.SelectBy(a => a.Color == strcolor).FirstOrDefault();
                    if (color != null)
                    {
                        newframe.ColorID = color.ID;
                    }
                    else
                    {
                        color = new T_Color() { Color = strcolor };
                        bll_color.Add(color);
                        newframe.ColorID = color.ID;
                    }
                    

                    #endregion

                    #region 处理第三列costRMB
                    //处理第三列costRMB
                    decimal costrmb = Convert.ToDecimal(rowStr[2]);
                    newframe.CostRMB = costrmb;
                    #endregion

                    #region 处理第四-八列镜架参数
                    //处理第四-八列镜架参数
                    double LensHeight = Convert.ToDouble(rowStr[3]);
                    double framewidth = Convert.ToDouble(rowStr[4]);
                    double lenswidth = Convert.ToDouble(rowStr[5]);
                    double nosebridge = Convert.ToDouble(rowStr[6]);
                    double templelength = Convert.ToDouble(rowStr[7]);
                    newframe.LensHeight = LensHeight;
                    newframe.FrameWidth = framewidth;
                    newframe.LensWidth = lenswidth;
                    newframe.NoseBridge = nosebridge;
                    newframe.TempleLength = templelength;
                    #endregion

                    #region 处理后面的参数到other

                    //处理后面的参数到other
                    string other = "";
                    for (int i = 8; i < rowStr.Count(); i++)
                    {
                        other += rowStr[i] + "  |  ";

                    }
                    newframe.InitialInformation = other;
                    #endregion

                    #region 自动设置其他属性
                    //设置FrameSize
                    if (framewidth < 131)
                    {
                        newframe.FrameSizeID = 3;
                    }
                    else if (framewidth < 141)
                    {
                        newframe.FrameSizeID = 2;
                    }
                    else
                    {
                        newframe.FrameSizeID = 1;
                    }

                    //判断是否支持多焦点
                    if (newframe.LensHeight >= 30)
                    {
                        newframe.IfBiofocal = true;
                    }
                    else { newframe.IfBiofocal = false; }

                    //写入PictureFolderPath
                    newframe.PictureFolderPath = framesn.SN.Trim() + color.Color.Trim();

                    //写入创建时间和修改时间
                    newframe.CreatDate = DateTime.Now;
                    newframe.UpdateDate = DateTime.Now;

                    #endregion

                    listOfAllFrames.Add(newframe);
                }

                return listOfAllFrames;
            }     
        #endregion

        public int AddFrameListToDataBase(string filename)
        {
            int i = 0;
            foreach (T_Frame item in LoadFrameDataFromExcel(filename))
            {

                bll_frame.Add(item);
                i++;
            }
            return i;
        }

    }
      
}
