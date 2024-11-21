namespace QuanLyKhachSan.Reporting
{
    partial class frmRptDichVu
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
            this.rptViewDichVu = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panelFilterOptions = new System.Windows.Forms.Panel();
            this.chkTheoGia = new System.Windows.Forms.CheckBox();
            this.chkTheoTenLoai = new System.Windows.Forms.CheckBox();
            this.btnTuyChon = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.lbTenLoaiDV = new System.Windows.Forms.Label();
            this.txtTenLoaiDV = new System.Windows.Forms.TextBox();
            this.lbGiaMax = new System.Windows.Forms.Label();
            this.lbGiaMin = new System.Windows.Forms.Label();
            this.txtGiaMax = new System.Windows.Forms.TextBox();
            this.txtGiaMin = new System.Windows.Forms.TextBox();
            this.panelFilterOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // rptViewDichVu
            // 
            this.rptViewDichVu.Location = new System.Drawing.Point(12, 293);
            this.rptViewDichVu.Name = "rptViewDichVu";
            this.rptViewDichVu.ServerReport.BearerToken = null;
            this.rptViewDichVu.Size = new System.Drawing.Size(135, 145);
            this.rptViewDichVu.TabIndex = 0;
            // 
            // panelFilterOptions
            // 
            this.panelFilterOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilterOptions.Controls.Add(this.chkTheoGia);
            this.panelFilterOptions.Controls.Add(this.chkTheoTenLoai);
            this.panelFilterOptions.Location = new System.Drawing.Point(153, 338);
            this.panelFilterOptions.Name = "panelFilterOptions";
            this.panelFilterOptions.Size = new System.Drawing.Size(200, 100);
            this.panelFilterOptions.TabIndex = 21;
            this.panelFilterOptions.Visible = false;
            // 
            // chkTheoGia
            // 
            this.chkTheoGia.AutoSize = true;
            this.chkTheoGia.Location = new System.Drawing.Point(3, 34);
            this.chkTheoGia.Name = "chkTheoGia";
            this.chkTheoGia.Size = new System.Drawing.Size(116, 17);
            this.chkTheoGia.TabIndex = 0;
            this.chkTheoGia.Text = "Tìm Kiếm Theo Giá";
            this.chkTheoGia.UseVisualStyleBackColor = true;
            this.chkTheoGia.CheckedChanged += new System.EventHandler(this.chkTheoLuong_CheckedChanged);
            // 
            // chkTheoTenLoai
            // 
            this.chkTheoTenLoai.AutoSize = true;
            this.chkTheoTenLoai.Location = new System.Drawing.Point(3, 12);
            this.chkTheoTenLoai.Name = "chkTheoTenLoai";
            this.chkTheoTenLoai.Size = new System.Drawing.Size(142, 17);
            this.chkTheoTenLoai.TabIndex = 0;
            this.chkTheoTenLoai.Text = "Tìm Kiếm Theo Tên Loại";
            this.chkTheoTenLoai.UseVisualStyleBackColor = true;
            this.chkTheoTenLoai.CheckedChanged += new System.EventHandler(this.chkTheoTenLoai_CheckedChanged);
            // 
            // btnTuyChon
            // 
            this.btnTuyChon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTuyChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuyChon.Location = new System.Drawing.Point(565, 26);
            this.btnTuyChon.Name = "btnTuyChon";
            this.btnTuyChon.Size = new System.Drawing.Size(96, 38);
            this.btnTuyChon.TabIndex = 24;
            this.btnTuyChon.Text = "Tùy Chọn";
            this.btnTuyChon.UseVisualStyleBackColor = true;
            this.btnTuyChon.Click += new System.EventHandler(this.btnTuyChon_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Location = new System.Drawing.Point(688, 26);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(96, 38);
            this.btnLamMoi.TabIndex = 25;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnTim
            // 
            this.btnTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Location = new System.Drawing.Point(447, 26);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(96, 38);
            this.btnTim.TabIndex = 26;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // lbTenLoaiDV
            // 
            this.lbTenLoaiDV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTenLoaiDV.AutoSize = true;
            this.lbTenLoaiDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenLoaiDV.Location = new System.Drawing.Point(47, 35);
            this.lbTenLoaiDV.Name = "lbTenLoaiDV";
            this.lbTenLoaiDV.Size = new System.Drawing.Size(130, 20);
            this.lbTenLoaiDV.TabIndex = 23;
            this.lbTenLoaiDV.Text = "Tên Loại Dịch Vụ";
            // 
            // txtTenLoaiDV
            // 
            this.txtTenLoaiDV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTenLoaiDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenLoaiDV.Location = new System.Drawing.Point(200, 32);
            this.txtTenLoaiDV.Name = "txtTenLoaiDV";
            this.txtTenLoaiDV.Size = new System.Drawing.Size(181, 26);
            this.txtTenLoaiDV.TabIndex = 22;
            // 
            // lbGiaMax
            // 
            this.lbGiaMax.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbGiaMax.AutoSize = true;
            this.lbGiaMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGiaMax.Location = new System.Drawing.Point(466, 111);
            this.lbGiaMax.Name = "lbGiaMax";
            this.lbGiaMax.Size = new System.Drawing.Size(39, 20);
            this.lbGiaMax.TabIndex = 29;
            this.lbGiaMax.Text = "Đến";
            // 
            // lbGiaMin
            // 
            this.lbGiaMin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbGiaMin.AutoSize = true;
            this.lbGiaMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGiaMin.Location = new System.Drawing.Point(66, 111);
            this.lbGiaMin.Name = "lbGiaMin";
            this.lbGiaMin.Size = new System.Drawing.Size(56, 20);
            this.lbGiaMin.TabIndex = 30;
            this.lbGiaMin.Text = "Giá Từ";
            // 
            // txtGiaMax
            // 
            this.txtGiaMax.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtGiaMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaMax.Location = new System.Drawing.Point(536, 108);
            this.txtGiaMax.Name = "txtGiaMax";
            this.txtGiaMax.Size = new System.Drawing.Size(181, 26);
            this.txtGiaMax.TabIndex = 27;
            // 
            // txtGiaMin
            // 
            this.txtGiaMin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtGiaMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaMin.Location = new System.Drawing.Point(172, 108);
            this.txtGiaMin.Name = "txtGiaMin";
            this.txtGiaMin.Size = new System.Drawing.Size(181, 26);
            this.txtGiaMin.TabIndex = 28;
            // 
            // frmRptDichVu
            // 
            this.AcceptButton = this.btnTim;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbGiaMax);
            this.Controls.Add(this.lbGiaMin);
            this.Controls.Add(this.txtGiaMax);
            this.Controls.Add(this.txtGiaMin);
            this.Controls.Add(this.btnTuyChon);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.lbTenLoaiDV);
            this.Controls.Add(this.txtTenLoaiDV);
            this.Controls.Add(this.panelFilterOptions);
            this.Controls.Add(this.rptViewDichVu);
            this.Name = "frmRptDichVu";
            this.Text = "frmRptDichVu";
            this.Load += new System.EventHandler(this.frmRptDichVu_Load);
            this.panelFilterOptions.ResumeLayout(false);
            this.panelFilterOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptViewDichVu;
        private System.Windows.Forms.Panel panelFilterOptions;
        private System.Windows.Forms.CheckBox chkTheoGia;
        private System.Windows.Forms.CheckBox chkTheoTenLoai;
        private System.Windows.Forms.Button btnTuyChon;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Label lbTenLoaiDV;
        private System.Windows.Forms.TextBox txtTenLoaiDV;
        private System.Windows.Forms.Label lbGiaMax;
        private System.Windows.Forms.Label lbGiaMin;
        private System.Windows.Forms.TextBox txtGiaMax;
        private System.Windows.Forms.TextBox txtGiaMin;
    }
}