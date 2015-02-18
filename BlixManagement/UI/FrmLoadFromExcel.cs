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
using BLL;
using UI.Module;

namespace UI
{
    public partial class FrmLoadFromExcel : DevExpress.XtraEditors.XtraForm
    {
        public FrmLoadFromExcel()
        {
            InitializeComponent();
        }

        public FrmFrame Frame { get; set; }

        private void simpleBtn_OpenFile_Click(object sender, EventArgs e)
        {           
            openFileDialog1.ShowDialog();   
            textEditFilename.Text = openFileDialog1.FileName;
        }

        private void simpleBtnLoading_Click(object sender, EventArgs e)
        {

            StartLoading(textEditFilename.Text);              
          
        }

        public void StartLoading(string filename)
        {
            ExcelHelper eh = new ExcelHelper();
            eh.AddFrameListToDataBase(filename);
          //  this.Frame.Refresh();
            this.Close();
        }
    }
}