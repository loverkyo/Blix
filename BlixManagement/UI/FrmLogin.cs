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

namespace UI
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        public FrmLogin()
        {
            InitializeComponent();
            txtMsg.TextVisible = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            T_Admin admin=ValidateLogin();
            if (admin != null)
            {
                MainForm mainform = this.Parent as MainForm;
                mainform.Admin = admin;
                this.Close();
            }
            txtMsg.Text = "用户名或密码错误，请重试";
          
            txtMsg.TextVisible = true;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        T_Admin ValidateLogin()
        {
            BLL_Admin bll = new BLL_Admin();
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            return bll.ValidateLogin(username, password);
        }

    }
}