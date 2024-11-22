namespace QuanLyKhachSan.Reporting
{
    partial class frmRptHoaDonn
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.rdoMaHD = new System.Windows.Forms.RadioButton();
            this.rdoMaDP = new System.Windows.Forms.RadioButton();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(12, 111);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1194, 498);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(694, 26);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 40);
            this.btnTimKiem.TabIndex = 5;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(830, 28);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 40);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // rdoMaHD
            // 
            this.rdoMaHD.AutoSize = true;
            this.rdoMaHD.Checked = true;
            this.rdoMaHD.Location = new System.Drawing.Point(240, 28);
            this.rdoMaHD.Name = "rdoMaHD";
            this.rdoMaHD.Size = new System.Drawing.Size(103, 20);
            this.rdoMaHD.TabIndex = 6;
            this.rdoMaHD.TabStop = true;
            this.rdoMaHD.Text = "Mã Hóa Đơn";
            this.rdoMaHD.UseVisualStyleBackColor = true;
            // 
            // rdoMaDP
            // 
            this.rdoMaDP.AutoSize = true;
            this.rdoMaDP.Location = new System.Drawing.Point(383, 28);
            this.rdoMaDP.Name = "rdoMaDP";
            this.rdoMaDP.Size = new System.Drawing.Size(89, 20);
            this.rdoMaDP.TabIndex = 7;
            this.rdoMaDP.Text = "Mã Phòng";
            this.rdoMaDP.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(526, 26);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(117, 22);
            this.txtTimKiem.TabIndex = 8;
            // 
            // frmRptHoaDonn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 621);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.rdoMaDP);
            this.Controls.Add(this.rdoMaHD);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRptHoaDonn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRptHoaDonn";
            this.Load += new System.EventHandler(this.frmRptHoaDonn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.RadioButton rdoMaHD;
        private System.Windows.Forms.RadioButton rdoMaDP;
        private System.Windows.Forms.TextBox txtTimKiem;
    }
}