namespace QuanLiKhachSan_Nhom5
{
    partial class frmHoaDon
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
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ccbGiamGia = new System.Windows.Forms.ComboBox();
            this.ccbMaSDDV = new System.Windows.Forms.ComboBox();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.cboPTTT = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.txtTienPhong = new System.Windows.Forms.TextBox();
            this.txtTienDichVu = new System.Windows.Forms.TextBox();
            this.txtPhuThu = new System.Windows.Forms.TextBox();
            this.txtSoNgayThue = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.btnTim = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ccbMaHD = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ccbMaDP = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ccbGiamGia);
            this.groupBox2.Controls.Add(this.ccbMaDP);
            this.groupBox2.Controls.Add(this.ccbMaSDDV);
            this.groupBox2.Controls.Add(this.dgvHoaDon);
            this.groupBox2.Controls.Add(this.cboPTTT);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtThanhTien);
            this.groupBox2.Controls.Add(this.txtTienPhong);
            this.groupBox2.Controls.Add(this.txtTienDichVu);
            this.groupBox2.Controls.Add(this.txtPhuThu);
            this.groupBox2.Controls.Add(this.txtSoNgayThue);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 150);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1111, 489);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Hóa Đơn";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // ccbGiamGia
            // 
            this.ccbGiamGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ccbGiamGia.FormattingEnabled = true;
            this.ccbGiamGia.Items.AddRange(new object[] {
            "0",
            "5",
            "10",
            "50"});
            this.ccbGiamGia.Location = new System.Drawing.Point(592, 93);
            this.ccbGiamGia.Name = "ccbGiamGia";
            this.ccbGiamGia.Size = new System.Drawing.Size(160, 30);
            this.ccbGiamGia.TabIndex = 4;
            this.ccbGiamGia.SelectedIndexChanged += new System.EventHandler(this.ccbMaSDDV_SelectedIndexChanged);
            // 
            // ccbMaSDDV
            // 
            this.ccbMaSDDV.FormattingEnabled = true;
            this.ccbMaSDDV.Location = new System.Drawing.Point(215, 94);
            this.ccbMaSDDV.Name = "ccbMaSDDV";
            this.ccbMaSDDV.Size = new System.Drawing.Size(160, 30);
            this.ccbMaSDDV.TabIndex = 4;
            this.ccbMaSDDV.SelectedIndexChanged += new System.EventHandler(this.ccbMaSDDV_SelectedIndexChanged);
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Location = new System.Drawing.Point(8, 259);
            this.dgvHoaDon.Margin = new System.Windows.Forms.Padding(4);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.Size = new System.Drawing.Size(1095, 212);
            this.dgvHoaDon.TabIndex = 3;
            this.dgvHoaDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellContentClick);
            // 
            // cboPTTT
            // 
            this.cboPTTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPTTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPTTT.FormattingEnabled = true;
            this.cboPTTT.Items.AddRange(new object[] {
            "Tín Dụng Ngân Hàng",
            "Tiền Mặt"});
            this.cboPTTT.Location = new System.Drawing.Point(215, 149);
            this.cboPTTT.Margin = new System.Windows.Forms.Padding(4);
            this.cboPTTT.Name = "cboPTTT";
            this.cboPTTT.Size = new System.Drawing.Size(160, 33);
            this.cboPTTT.TabIndex = 2;
            this.cboPTTT.SelectedIndexChanged += new System.EventHandler(this.cboPTTT_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(29, 153);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 25);
            this.label14.TabIndex = 0;
            this.label14.Text = "PTTT";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(408, 36);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(155, 25);
            this.label13.TabIndex = 0;
            this.label13.Text = "Số ngày đã thuê";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThanhTien.Location = new System.Drawing.Point(925, 145);
            this.txtThanhTien.Margin = new System.Windows.Forms.Padding(4);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(164, 30);
            this.txtThanhTien.TabIndex = 1;
            this.txtThanhTien.TextChanged += new System.EventHandler(this.txtThanhTien_TextChanged);
            // 
            // txtTienPhong
            // 
            this.txtTienPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienPhong.Location = new System.Drawing.Point(925, 86);
            this.txtTienPhong.Margin = new System.Windows.Forms.Padding(4);
            this.txtTienPhong.Name = "txtTienPhong";
            this.txtTienPhong.Size = new System.Drawing.Size(164, 30);
            this.txtTienPhong.TabIndex = 1;
            this.txtTienPhong.TextChanged += new System.EventHandler(this.txtTienPhong_TextChanged);
            // 
            // txtTienDichVu
            // 
            this.txtTienDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienDichVu.Location = new System.Drawing.Point(925, 32);
            this.txtTienDichVu.Margin = new System.Windows.Forms.Padding(4);
            this.txtTienDichVu.Name = "txtTienDichVu";
            this.txtTienDichVu.Size = new System.Drawing.Size(164, 30);
            this.txtTienDichVu.TabIndex = 1;
            this.txtTienDichVu.TextChanged += new System.EventHandler(this.txtTienDichVu_TextChanged);
            // 
            // txtPhuThu
            // 
            this.txtPhuThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhuThu.Location = new System.Drawing.Point(592, 145);
            this.txtPhuThu.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhuThu.Name = "txtPhuThu";
            this.txtPhuThu.Size = new System.Drawing.Size(164, 30);
            this.txtPhuThu.TabIndex = 1;
            this.txtPhuThu.TextChanged += new System.EventHandler(this.txtPhuThu_TextChanged);
            // 
            // txtSoNgayThue
            // 
            this.txtSoNgayThue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoNgayThue.Location = new System.Drawing.Point(592, 32);
            this.txtSoNgayThue.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoNgayThue.Name = "txtSoNgayThue";
            this.txtSoNgayThue.Size = new System.Drawing.Size(164, 30);
            this.txtSoNgayThue.TabIndex = 1;
            this.txtSoNgayThue.TextChanged += new System.EventHandler(this.txtSoNgayThue_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(781, 153);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 25);
            this.label12.TabIndex = 0;
            this.label12.Text = "Thành tiền";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(781, 94);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 25);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tiền Phòng";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(781, 36);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 25);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tiền dịch vụ";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 97);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Mã sử dụng DV";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(408, 94);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(154, 25);
            this.label11.TabIndex = 0;
            this.label11.Text = "Giảm giá KH(%)";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(408, 149);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "Phụ thu";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 39);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mã đặt phòng";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(99, 666);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(148, 48);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(392, 666);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(148, 48);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(660, 666);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(148, 48);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(905, 666);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(148, 48);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Blue;
            this.label15.Location = new System.Drawing.Point(504, 11);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(132, 32);
            this.label15.TabIndex = 14;
            this.label15.Text = "Hóa Đơn";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Location = new System.Drawing.Point(831, 66);
            this.btnTim.Margin = new System.Windows.Forms.Padding(4);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(148, 48);
            this.btnTim.TabIndex = 15;
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hóa đơn";
            this.label1.Click += new System.EventHandler(this.label2_Click);
            // 
            // ccbMaHD
            // 
            this.ccbMaHD.FormattingEnabled = true;
            this.ccbMaHD.Items.AddRange(new object[] {
            "HD01",
            "HD02",
            "HD03",
            "HD04",
            "HD05",
            "HD06",
            "HD07",
            "HD08",
            "HD09",
            "HD010"});
            this.ccbMaHD.Location = new System.Drawing.Point(231, 82);
            this.ccbMaHD.Name = "ccbMaHD";
            this.ccbMaHD.Size = new System.Drawing.Size(160, 24);
            this.ccbMaHD.TabIndex = 4;
            this.ccbMaHD.SelectedIndexChanged += new System.EventHandler(this.ccbMaSDDV_SelectedIndexChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ccbMaDP
            // 
            this.ccbMaDP.FormattingEnabled = true;
            this.ccbMaDP.Items.AddRange(new object[] {
            "PH01",
            "PH02",
            "PH03",
            "PH04",
            "PH05",
            "PH06",
            "PH07",
            "PH08",
            "PH09",
            "PH10"});
            this.ccbMaDP.Location = new System.Drawing.Point(215, 39);
            this.ccbMaDP.Name = "ccbMaDP";
            this.ccbMaDP.Size = new System.Drawing.Size(160, 30);
            this.ccbMaDP.TabIndex = 4;
            this.ccbMaDP.SelectedIndexChanged += new System.EventHandler(this.ccbMaSDDV_SelectedIndexChanged);
            // 
            // frmHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1143, 743);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.ccbMaHD);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHoaDon";
            this.Text = "frmHoaDon";
            this.Load += new System.EventHandler(this.frmHoaDon_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.ComboBox cboPTTT;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.TextBox txtTienPhong;
        private System.Windows.Forms.TextBox txtTienDichVu;
        private System.Windows.Forms.TextBox txtPhuThu;
        private System.Windows.Forms.TextBox txtSoNgayThue;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.ComboBox ccbMaSDDV;
        private System.Windows.Forms.ComboBox ccbGiamGia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ccbMaHD;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox ccbMaDP;
    }
}