namespace UI
{
    partial class FrmLoadFromExcel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.simpleBtnLoading = new DevExpress.XtraEditors.SimpleButton();
            this.simpleBtn_OpenFile = new DevExpress.XtraEditors.SimpleButton();
            this.textEditFilename = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditFilename.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleBtnLoading);
            this.layoutControl1.Controls.Add(this.simpleBtn_OpenFile);
            this.layoutControl1.Controls.Add(this.textEditFilename);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(696, 87);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // simpleBtnLoading
            // 
            this.simpleBtnLoading.Location = new System.Drawing.Point(582, 41);
            this.simpleBtnLoading.Name = "simpleBtnLoading";
            this.simpleBtnLoading.Size = new System.Drawing.Size(102, 25);
            this.simpleBtnLoading.StyleController = this.layoutControl1;
            this.simpleBtnLoading.TabIndex = 6;
            this.simpleBtnLoading.Text = "开始导入";
            this.simpleBtnLoading.Click += new System.EventHandler(this.simpleBtnLoading_Click);
            // 
            // simpleBtn_OpenFile
            // 
            this.simpleBtn_OpenFile.Location = new System.Drawing.Point(582, 12);
            this.simpleBtn_OpenFile.Name = "simpleBtn_OpenFile";
            this.simpleBtn_OpenFile.Size = new System.Drawing.Size(102, 25);
            this.simpleBtn_OpenFile.StyleController = this.layoutControl1;
            this.simpleBtn_OpenFile.TabIndex = 5;
            this.simpleBtn_OpenFile.Text = "打开文件";
            this.simpleBtn_OpenFile.Click += new System.EventHandler(this.simpleBtn_OpenFile_Click);
            // 
            // textEditFilename
            // 
            this.textEditFilename.EditValue = "F:\\创业\\BLIX\\营销-广告\\拍摄照片\\拍摄产品数据(new)(1).xls";
            this.textEditFilename.Location = new System.Drawing.Point(90, 12);
            this.textEditFilename.Name = "textEditFilename";
            this.textEditFilename.Size = new System.Drawing.Size(488, 24);
            this.textEditFilename.StyleController = this.layoutControl1;
            this.textEditFilename.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(696, 87);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textEditFilename;
            this.layoutControlItem1.CustomizationFormText = "文件位置：";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(570, 67);
            this.layoutControlItem1.Text = "文件位置：";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(75, 18);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.simpleBtn_OpenFile;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(570, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(106, 29);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.simpleBtnLoading;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(570, 29);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(106, 38);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmLoadFromExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 87);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmLoadFromExcel";
            this.Text = "FrmLoadFromExcel";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditFilename.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton simpleBtnLoading;
        private DevExpress.XtraEditors.SimpleButton simpleBtn_OpenFile;
        private DevExpress.XtraEditors.TextEdit textEditFilename;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}