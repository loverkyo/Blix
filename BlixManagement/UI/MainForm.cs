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
using UI.Module;
using UI.Module.Frames;

namespace UI
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {

        public T_Admin Admin { get; set; }
        public FrmFrameMain FrmFrameMainCache { get; set; } //保存页面状态，以便随时调用

        public MainForm()
        {
            InitializeComponent();         
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
          //  frm.ShowDialog();
            tileBarDropDownContainer1.BackColor = tileBarItem_Goods.AppearanceItem.Normal.BackColor;
        
        }

        private void navBtnExit_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            DialogResult dr= MessageBox.Show("确定要退出吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //打开镜架浏览页面
        private void tileBarItem_Frame_ItemClick(object sender, TileItemEventArgs e)
        {
            if (this.FrmFrameMainCache != null)
            {
                ShowFrame(this.FrmFrameMainCache);
            }
            else
            {
                ShowFrame(new FrmFrameMain() { MainForm = this });
            }
          
        }

        private void tileBarItem_Supplier_ItemClick(object sender, TileItemEventArgs e)
        {
            
            
        }

        public void ShowFrame(XtraUserControl frame)
        {            
            moduleContainer.Controls.Clear();
            moduleContainer.Controls.Add(frame);
            frame.Dock = DockStyle.Fill;        
            
        }

        private void navButton2_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            FrmLoadFromExcel fm = new FrmLoadFromExcel() ;
            fm.Show();
            
        }

        private void tileBar_Menu_Goods_ItemClick(object sender, TileItemEventArgs e)
        {
            tileBar_Menu.HideDropDownWindow();
        }
    }
}