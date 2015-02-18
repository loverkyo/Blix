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
using System.IO;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.WinExplorer;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPrinting;

namespace UI.Module.Frames
{
    public partial class FrmFrameMain : DevExpress.XtraEditors.XtraUserControl
    {
        public List<T_Frame> FrameList { get; set; }
        public MainForm MainForm { get; set; }       

        public FrmFrameMain()
        {
            InitializeComponent();

        }

        private void FrmFrameMain_Load(object sender, EventArgs e)
        {
           
            RefreshDataSource();
        }

        public void RefreshDataSource()
        {
            gridControl1.DataSource = null;
            BLL_Frame bll = new BLL_Frame();
            this.FrameList = bll.GetList();     
            gridControl1.DataSource = this.FrameList;
            
        }

        private byte[] getImageByte(string imagePath)
        {
            try
            {
                FileStream files = new FileStream(imagePath, FileMode.Open);
                byte[] imgByte = new byte[files.Length];
                files.Read(imgByte, 0, imgByte.Length);
                files.Close();
                return imgByte;
            }
            catch { return null; }
        }

        private void layoutView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            try
            {
                if (e.Column.Name == "layoutViewColumn4")
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
            catch { }
        }

        //双击进入详细列表      
        private void layoutView1_DoubleClick(object sender, EventArgs e)
        {        
            //双击进到详细编辑页
            FrmFrame frmFrame = new FrmFrame();
            int focusedRowHandle = layoutView1.GetDataSourceRowIndex(layoutView1.FocusedRowHandle);      
            frmFrame.MainForm = this.MainForm;
            frmFrame.FocuedFrameHandle = focusedRowHandle;
            frmFrame.DataSource = this.layoutView1;

            this.MainForm.FrmFrameMainCache = this;  //把当前页面加入缓存，以便关闭细节窗口后还能回到这个窗口
            this.MainForm.ShowFrame(frmFrame );
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            using (FileStream fs = new FileStream(@"F:\1.txt", FileMode.OpenOrCreate))
            {
                using (TextWriter tw = new StreamWriter(fs))
                {
                    List<T_Frame> list = layoutView1.DataSource as List<T_Frame>;
                    list = list.Where(a => a.IsPrepared == true).ToList();
                    foreach (T_Frame item in list)
                    {
                        tw.WriteLine(item.PictureFolderPath);
                    }
                    MessageBox.Show("导出完毕");
                }
            }
        }
       

        
     

     

       
    }
}
