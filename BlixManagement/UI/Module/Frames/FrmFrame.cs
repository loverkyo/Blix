using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MODEL;
using BLL;
using DevExpress.XtraEditors.Controls;
using System.Reflection;
using UI.Module.Frames;
using System.IO;

namespace UI.Module
{
    public partial class FrmFrame : DevExpress.XtraEditors.XtraUserControl
    {
        
        public List<T_Frame> FrameList { get; set; }
        //public T_Frame FocusFrame { get; set; }
        public MainForm MainForm { get; set; }
        public int FocuedFrameHandle { get; set; }
        public object DataSource { get; set; }

       

        public FrmFrame()
        {
            InitializeComponent();         
        }

        private void FrmFrame_Load(object sender, EventArgs e)
        {

            RefreshData();          
                myNewLayoutView.FocusedRowHandle=this.FocuedFrameHandle ;
               
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public void RefreshData()
        {
            BLL_Frame bll = new BLL_Frame();
            this.FrameList = bll.GetList();     
            gridControl1.DataSource = this.FrameList ;
            lookUpEdit_SN.DataSource = new BLL_FrameSN().GetList();
            lookUpEdit_Color.DataSource = new BLL_Color().GetList();
            lookUpEdit_Category.DataSource = new BLL_FrameCategory().GetList();
            lookUpEdit_Material.DataSource = new BLL_FrameMaterial().GetList();
            lookUpEdit_Gender.DataSource = new BLL_Gender().GetList();
            lookUpEdit_FrameSize.DataSource = new BLL_FrameSize().GetList();
            lookUpEdit_FrameShape.DataSource = new BLL_FrameShape().GetList();
            lookUpEdit_FrameType.DataSource = new BLL_FrameType().GetList();
            lookUpEdit_FrameStyle.DataSource = new BLL_FrameStyle().GetList();
            lookUpEdit_Brand.DataSource = new BLL_Brand().GetList();
            lookUpEdit_Supplier.DataSource = new BLL_Supplier().GetList();     
        }

   

       
        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "保存")
            {
                T_Frame frame = myNewLayoutView.GetFocusedRow() as T_Frame;                
                myNewLayoutView.UpdateCurrentRow();
                BLL_Frame bll = new BLL_Frame(); 
               int i= bll.Modify(myNewLayoutView.GetFocusedRow() as T_Frame);
               if (i > 0)
               {
                   gridControl1.RefreshDataSource();
                   MessageBox.Show("保存成功");
               }
               else
               {
                   MessageBox.Show("没有保存");
               }
            }
            else if (e.Button.Properties.Caption == "退出")
            {
                MainForm.FrmFrameMainCache.RefreshDataSource();
                MainForm.ShowFrame(MainForm.FrmFrameMainCache);
            }
            else if (e.Button.Properties.Caption == "批量更新该款式")
            {
                T_Frame frame = myNewLayoutView.GetFocusedRow() as T_Frame;
                BLL_Frame bll = new BLL_Frame();
                int i= bll.ModifySimilarFrames(frame);
                if (i > 0)
                {
                    MessageBox.Show("批量更新完毕");           
                    int currentrow = myNewLayoutView.GetFocusedDataSourceRowIndex();
                    RefreshData();
                    myNewLayoutView.RefreshData();
                    myNewLayoutView.FocusedRowHandle = currentrow;
                }
                else
                {
                    MessageBox.Show("没有更新");
                }
            }
           
        }

        private void myNewLayoutView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "CostRMB")
            {
                T_Frame f = myNewLayoutView.GetFocusedRow() as T_Frame;
                f.CostUSD =Convert.ToDecimal( e.Value) * 6;
            }
        }

        

        //展示可选内容的窗口
        private void myNewLayoutView_DoubleClick(object sender, EventArgs e)
        {
            string fieldname = myNewLayoutView.FocusedColumn.FieldName;
            if (fieldname=="X1")
            {
                 FrmShowPictures frm = new FrmShowPictures() { path = (myNewLayoutView.GetFocusedRow() as T_Frame).PictureFolderPath };
            frm.ShowDialog();
            }
            try
            {
                fieldname =  fieldname.Remove(fieldname.LastIndexOf("ID"));
                FrmEditField fef = new FrmEditField() { DataTypeName = fieldname };
                fef.ShowDialog();
            }
            catch (Exception ex) { }

        }

        //显示图片
        private void myNewLayoutView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.Name == "layoutViewCol_image1")
            {
                T_Frame frame = e.Row as T_Frame;
                string filename = @"F:\创业\BLIX\营销-广告\拍摄照片\第一批初稿的缩略图\tb" + frame.PictureFolderPath + @".jpg";
                //e.Value = getImageByte(filename);
                if (File.Exists(filename))
                {
                    e.Value = Image.FromFile(filename);
                }
            }
        }

       
       

    }
}
