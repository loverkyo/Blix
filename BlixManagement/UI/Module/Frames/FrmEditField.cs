using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MODEL;
using BLL;
using System.Reflection;
using DevExpress.XtraGrid.Columns;

namespace UI.Module.Frames
{
    public partial class FrmEditField : DevExpress.XtraEditors.XtraForm
    {
        public FrmEditField()
        {
            InitializeComponent();
        }

        public string DataTypeName { get; set; }
        

        private void FrmEditField_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        void RefreshData()
        {
                gridView1.Columns.Clear();
                //反射获取数据源
                string bllname = "BLL.BLL_" + DataTypeName;
                string bllpath = Application.StartupPath + @"\BLL.dll";
                Assembly bllass = Assembly.LoadFile(bllpath);
                Type blltype = bllass.GetType(bllname);
                object obj = bllass.CreateInstance(bllname);
                

                //动态加载列
                string modelname = "MODEL.T_" + DataTypeName;
                string modelpath = Application.StartupPath + @"\MODEL.dll";
                Assembly modelass = Assembly.LoadFile(modelpath);
                Type modeltype = modelass.GetType(modelname);
           
                foreach (PropertyInfo proInfo in modeltype.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {

                    if (!proInfo.Name.Contains("T_") && proInfo.Name != "ID")
                    {
                        GridColumn col = new GridColumn();
                        col.Name = proInfo.Name;
                        col.FieldName = proInfo.Name;
                        col.Visible = true;
                        gridView1.Columns.Add(col);
                    }
                }                 

                gridControl.DataSource =blltype.GetMethod("GetList").Invoke(obj, null);           
                dataNavigator1.DataSource = gridView1.DataSource;

             
        }

        private void FrmEditField_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void dataNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Edit)
            {
               
            }
        }
    }
}