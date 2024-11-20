namespace QuanLyKhachSan.Reporting
{
    partial class frmRptLuong
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
            this.rptViewLuong = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptViewLuong
            // 
            this.rptViewLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewLuong.LocalReport.ReportEmbeddedResource = "QuanLyKhachSan.Reporting.rptLuong.rdlc";
            this.rptViewLuong.Location = new System.Drawing.Point(0, 0);
            this.rptViewLuong.Name = "rptViewLuong";
            this.rptViewLuong.ServerReport.BearerToken = null;
            this.rptViewLuong.Size = new System.Drawing.Size(800, 450);
            this.rptViewLuong.TabIndex = 0;
            // 
            // frmRptLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rptViewLuong);
            this.Name = "frmRptLuong";
            this.Text = "frmRptLuong";
            this.Load += new System.EventHandler(this.frmRptLuong_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptViewLuong;
    }
}