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
using System.IO;

namespace UI.Module.Frames
{
    public partial class FrmShowPictures : DevExpress.XtraEditors.XtraForm
    {
        public FrmShowPictures()
        {
            InitializeComponent();
        }

        public string path { get; set; }

        private void FrmShowPictures_Load(object sender, EventArgs e)
        {
            
            DirectoryInfo di = new DirectoryInfo(@"F:\创业\BLIX\营销-广告\拍摄照片\第一批初稿");
            DirectoryInfo picdir = di.GetDirectories(path, SearchOption.TopDirectoryOnly)[0];
            foreach (FileInfo file in picdir.GetFiles("*.jpg"))
            {
                listBoxControl1.Items.Add(file.FullName);
              
            } 
            
        }

        private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string filename = listBoxControl1.SelectedItem.ToString();
                pictureEdit1.Image = Image.FromFile(filename);
            }
            catch { }
            //using (FileStream fs=new FileStream(filename,FileMode.Open))
            //{
            //    pictureEdit1.Image = new Bitmap(Image.FromStream(fs));
            
            //}
            
        }
    }
}