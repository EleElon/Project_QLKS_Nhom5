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
            this.txtSoNgayLam = new System.Windows.Forms.TextBox();
            this.lbSoNgayLam = new System.Windows.Forms.Label();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTuyChon = new System.Windows.Forms.Button();
            this.panelFilterOptions = new System.Windows.Forms.Panel();
            this.chkTheoGia = new System.Windows.Forms.CheckBox();
            this.chkTheoSoNgayLam = new System.Windows.Forms.CheckBox();
            this.lbLuongMin = new System.Windows.Forms.Label();
            this.txtLuongMin = new System.Windows.Forms.TextBox();
            this.txtLuongMax = new System.Windows.Forms.TextBox();
            this.lbLuongMax = new System.Windows.Forms.Label();
            this.panelFilterOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // rptViewLuong
            // 
            this.rptViewLuong.LocalReport.ReportEmbeddedResource = "QuanLyKhachSan.Reporting.rptLuong.rdlc";
            this.rptViewLuong.Location = new System.Drawing.Point(12, 298);
            this.rptViewLuong.Name = "rptViewLuong";
            this.rptViewLuong.ServerReport.BearerToken = null;
            this.rptViewLuong.Size = new System.Drawing.Size(222, 140);
            this.rptViewLuong.TabIndex = 0;
            // 
            // txtSoNgayLam
            // 
            this.txtSoNgayLam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSoNgayLam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoNgayLam.Location = new System.Drawing.Point(204, 40);
            this.txtSoNgayLam.Name = "txtSoNgayLam";
            this.txtSoNgayLam.Size = new System.Drawing.Size(181, 26);
            this.txtSoNgayLam.TabIndex = 1;
            // 
            // lbSoNgayLam
            // 
            this.lbSoNgayLam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbSoNgayLam.AutoSize = true;
            this.lbSoNgayLam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoNgayLam.Location = new System.Drawing.Point(80, 43);
            this.lbSoNgayLam.Name = "lbSoNgayLam";
            this.lbSoNgayLam.Size = new System.Drawing.Size(104, 20);
            this.lbSoNgayLam.TabIndex = 2;
            this.lbSoNgayLam.Text = "Số Ngày Làm";
            // 
            // btnTim
            // 
            this.btnTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Location = new System.Drawing.Point(451, 34);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(96, 38);
            this.btnTim.TabIndex = 3;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Location = new System.Drawing.Point(692, 34);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(96, 38);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnTuyChon
            // 
            this.btnTuyChon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTuyChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuyChon.Location = new System.Drawing.Point(569, 34);
            this.btnTuyChon.Name = "btnTuyChon";
            this.btnTuyChon.Size = new System.Drawing.Size(96, 38);
            this.btnTuyChon.TabIndex = 3;
            this.btnTuyChon.Text = "Tùy Chọn";
            this.btnTuyChon.UseVisualStyleBackColor = true;
            this.btnTuyChon.Click += new System.EventHandler(this.btnTuyChon_Click);
            // 
            // panelFilterOptions
            // 
            this.panelFilterOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilterOptions.Controls.Add(this.chkTheoGia);
            this.panelFilterOptions.Controls.Add(this.chkTheoSoNgayLam);
            this.panelFilterOptions.Location = new System.Drawing.Point(252, 298);
            this.panelFilterOptions.Name = "panelFilterOptions";
            this.panelFilterOptions.Size = new System.Drawing.Size(200, 100);
            this.panelFilterOptions.TabIndex = 20;
            this.panelFilterOptions.Visible = false;
            // 
            // chkTheoGia
            // 
            this.chkTheoGia.AutoSize = true;
            this.chkTheoGia.Location = new System.Drawing.Point(3, 34);
            this.chkTheoGia.Name = "chkTheoGia";
            this.chkTheoGia.Size = new System.Drawing.Size(130, 17);
            this.chkTheoGia.TabIndex = 0;
            this.chkTheoGia.Text = "Tìm Kiếm Theo Lương";
            this.chkTheoGia.UseVisualStyleBackColor = true;
            this.chkTheoGia.CheckedChanged += new System.EventHandler(this.chkTheoLuong_CheckedChanged);
            // 
            // chkTheoSoNgayLam
            // 
            this.chkTheoSoNgayLam.AutoSize = true;
            this.chkTheoSoNgayLam.Location = new System.Drawing.Point(3, 12);
            this.chkTheoSoNgayLam.Name = "chkTheoSoNgayLam";
            this.chkTheoSoNgayLam.Size = new System.Drawing.Size(164, 17);
            this.chkTheoSoNgayLam.TabIndex = 0;
            this.chkTheoSoNgayLam.Text = "Tìm Kiếm Theo Số Ngày Làm";
            this.chkTheoSoNgayLam.UseVisualStyleBackColor = true;
            this.chkTheoSoNgayLam.CheckedChanged += new System.EventHandler(this.chkTheoSoNgayLam_CheckedChanged);
            // 
            // lbLuongMin
            // 
            this.lbLuongMin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbLuongMin.AutoSize = true;
            this.lbLuongMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLuongMin.Location = new System.Drawing.Point(51, 116);
            this.lbLuongMin.Name = "lbLuongMin";
            this.lbLuongMin.Size = new System.Drawing.Size(76, 20);
            this.lbLuongMin.TabIndex = 2;
            this.lbLuongMin.Text = "Lương Từ";
            // 
            // txtLuongMin
            // 
            this.txtLuongMin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLuongMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLuongMin.Location = new System.Drawing.Point(157, 113);
            this.txtLuongMin.Name = "txtLuongMin";
            this.txtLuongMin.Size = new System.Drawing.Size(181, 26);
            this.txtLuongMin.TabIndex = 1;
            // 
            // txtLuongMax
            // 
            this.txtLuongMax.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLuongMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLuongMax.Location = new System.Drawing.Point(521, 113);
            this.txtLuongMax.Name = "txtLuongMax";
            this.txtLuongMax.Size = new System.Drawing.Size(181, 26);
            this.txtLuongMax.TabIndex = 1;
            // 
            // lbLuongMax
            // 
            this.lbLuongMax.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbLuongMax.AutoSize = true;
            this.lbLuongMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLuongMax.Location = new System.Drawing.Point(451, 116);
            this.lbLuongMax.Name = "lbLuongMax";
            this.lbLuongMax.Size = new System.Drawing.Size(39, 20);
            this.lbLuongMax.TabIndex = 2;
            this.lbLuongMax.Text = "Đến";
            // 
            // frmRptLuong
            // 
            this.AcceptButton = this.btnTim;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelFilterOptions);
            this.Controls.Add(this.btnTuyChon);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.lbLuongMax);
            this.Controls.Add(this.lbLuongMin);
            this.Controls.Add(this.lbSoNgayLam);
            this.Controls.Add(this.txtLuongMax);
            this.Controls.Add(this.txtLuongMin);
            this.Controls.Add(this.txtSoNgayLam);
            this.Controls.Add(this.rptViewLuong);
            this.Name = "frmRptLuong";
            this.Text = "frmRptLuong";
            this.Load += new System.EventHandler(this.frmRptLuong_Load);
            this.panelFilterOptions.ResumeLayout(false);
            this.panelFilterOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptViewLuong;
        private System.Windows.Forms.TextBox txtSoNgayLam;
        private System.Windows.Forms.Label lbSoNgayLam;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTuyChon;
        private System.Windows.Forms.Panel panelFilterOptions;
        private System.Windows.Forms.CheckBox chkTheoGia;
        private System.Windows.Forms.CheckBox chkTheoSoNgayLam;
        private System.Windows.Forms.Label lbLuongMin;
        private System.Windows.Forms.TextBox txtLuongMin;
        private System.Windows.Forms.TextBox txtLuongMax;
        private System.Windows.Forms.Label lbLuongMax;
    }
}