using System;

namespace QuanLyKhachSan
{
    partial class frmDichVu
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
            this.tbDichVu = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewDichVu = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbLoaiDichVu = new System.Windows.Forms.ComboBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTenDV = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaDV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLamMoiDV = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnXoaDV = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnThemDV = new System.Windows.Forms.Button();
            this.tbSĐichVu = new System.Windows.Forms.TabPage();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnLamMoiDSSDDV = new System.Windows.Forms.Button();
            this.btnCapNhap = new System.Windows.Forms.Button();
            this.btnHuyPhieu = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbMaDatPhong = new System.Windows.Forms.ComboBox();
            this.cbMaDichVu = new System.Windows.Forms.ComboBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMaSDDV = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvSuDungDichVu = new System.Windows.Forms.DataGridView();
            this.btnThoatt = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tbLoaiDichVu = new System.Windows.Forms.TabPage();
            this.btnLamMoiLDV = new System.Windows.Forms.Button();
            this.btnCapNhatLDV = new System.Windows.Forms.Button();
            this.btnXoaLDV = new System.Windows.Forms.Button();
            this.btnThoatLDV = new System.Windows.Forms.Button();
            this.btnThemLDV = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataGridViewLoaiDichVu = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cboMaLoaiPhong = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTenLDV = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMaLoaiDV = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.tbDichVu.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDichVu)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tbSĐichVu.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuDungDichVu)).BeginInit();
            this.tbLoaiDichVu.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoaiDichVu)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDichVu
            // 
            this.tbDichVu.Controls.Add(this.tabPage1);
            this.tbDichVu.Controls.Add(this.tbSĐichVu);
            this.tbDichVu.Controls.Add(this.tbLoaiDichVu);
            this.tbDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDichVu.Location = new System.Drawing.Point(0, 4);
            this.tbDichVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbDichVu.Name = "tbDichVu";
            this.tbDichVu.SelectedIndex = 0;
            this.tbDichVu.Size = new System.Drawing.Size(1376, 638);
            this.tbDichVu.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnLamMoiDV);
            this.tabPage1.Controls.Add(this.btnCapNhat);
            this.tabPage1.Controls.Add(this.btnXoaDV);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnThoat);
            this.tabPage1.Controls.Add(this.btnThemDV);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1368, 603);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dịch vụ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewDichVu);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(516, 75);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(731, 427);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Sách Dịch Vụ";
            // 
            // dataGridViewDichVu
            // 
            this.dataGridViewDichVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDichVu.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDichVu.Location = new System.Drawing.Point(5, 25);
            this.dataGridViewDichVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewDichVu.Name = "dataGridViewDichVu";
            this.dataGridViewDichVu.RowHeadersWidth = 51;
            this.dataGridViewDichVu.RowTemplate.Height = 24;
            this.dataGridViewDichVu.Size = new System.Drawing.Size(719, 398);
            this.dataGridViewDichVu.TabIndex = 0;
            this.dataGridViewDichVu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDichVu_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbLoaiDichVu);
            this.groupBox1.Controls.Add(this.txtGia);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTenDV);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMaDV);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(33, 75);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(475, 427);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phiếu Dịch Vụ";
            // 
            // cbLoaiDichVu
            // 
            this.cbLoaiDichVu.FormattingEnabled = true;
            this.cbLoaiDichVu.Location = new System.Drawing.Point(213, 134);
            this.cbLoaiDichVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbLoaiDichVu.Name = "cbLoaiDichVu";
            this.cbLoaiDichVu.Size = new System.Drawing.Size(215, 37);
            this.cbLoaiDichVu.TabIndex = 3;
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(213, 267);
            this.txtGia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(216, 34);
            this.txtGia.TabIndex = 2;
            this.txtGia.TextChanged += new System.EventHandler(this.txtGia_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(136, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 29);
            this.label5.TabIndex = 1;
            this.label5.Text = "Giá:";
            // 
            // txtTenDV
            // 
            this.txtTenDV.Location = new System.Drawing.Point(213, 197);
            this.txtTenDV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenDV.Name = "txtTenDV";
            this.txtTenDV.Size = new System.Drawing.Size(216, 34);
            this.txtTenDV.TabIndex = 2;
            this.txtTenDV.TextChanged += new System.EventHandler(this.txtTenDV_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 29);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tên dịch vụ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã loại dịch vụ:";
            // 
            // txtMaDV
            // 
            this.txtMaDV.Location = new System.Drawing.Point(213, 66);
            this.txtMaDV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaDV.Name = "txtMaDV";
            this.txtMaDV.Size = new System.Drawing.Size(216, 34);
            this.txtMaDV.TabIndex = 2;
            this.txtMaDV.TextChanged += new System.EventHandler(this.txtMaDV_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã dịch vụ:";
            // 
            // btnLamMoiDV
            // 
            this.btnLamMoiDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoiDV.Location = new System.Drawing.Point(1116, 537);
            this.btnLamMoiDV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLamMoiDV.Name = "btnLamMoiDV";
            this.btnLamMoiDV.Size = new System.Drawing.Size(148, 48);
            this.btnLamMoiDV.TabIndex = 25;
            this.btnLamMoiDV.Text = "Làm Mới";
            this.btnLamMoiDV.UseVisualStyleBackColor = true;
            this.btnLamMoiDV.Click += new System.EventHandler(this.btnLamMoiDV_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.Location = new System.Drawing.Point(861, 537);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(148, 48);
            this.btnCapNhat.TabIndex = 25;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnXoaDV
            // 
            this.btnXoaDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaDV.Location = new System.Drawing.Point(601, 537);
            this.btnXoaDV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoaDV.Name = "btnXoaDV";
            this.btnXoaDV.Size = new System.Drawing.Size(148, 48);
            this.btnXoaDV.TabIndex = 26;
            this.btnXoaDV.Text = "Xóa ";
            this.btnXoaDV.UseVisualStyleBackColor = true;
            this.btnXoaDV.Click += new System.EventHandler(this.btnXoaDV_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(544, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 42);
            this.label1.TabIndex = 22;
            this.label1.Text = "Dịch Vụ";
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(103, 537);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(148, 48);
            this.btnThoat.TabIndex = 27;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnThemDV
            // 
            this.btnThemDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemDV.Location = new System.Drawing.Point(347, 537);
            this.btnThemDV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemDV.Name = "btnThemDV";
            this.btnThemDV.Size = new System.Drawing.Size(148, 48);
            this.btnThemDV.TabIndex = 28;
            this.btnThemDV.Text = "Thêm Dịch Vụ";
            this.btnThemDV.UseVisualStyleBackColor = true;
            this.btnThemDV.Click += new System.EventHandler(this.btnThemDV_Click);
            // 
            // tbSĐichVu
            // 
            this.tbSĐichVu.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tbSĐichVu.Controls.Add(this.btnThem);
            this.tbSĐichVu.Controls.Add(this.btnLamMoiDSSDDV);
            this.tbSĐichVu.Controls.Add(this.btnCapNhap);
            this.tbSĐichVu.Controls.Add(this.btnHuyPhieu);
            this.tbSĐichVu.Controls.Add(this.groupBox3);
            this.tbSĐichVu.Controls.Add(this.groupBox4);
            this.tbSĐichVu.Controls.Add(this.btnThoatt);
            this.tbSĐichVu.Controls.Add(this.label10);
            this.tbSĐichVu.Location = new System.Drawing.Point(4, 31);
            this.tbSĐichVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSĐichVu.Name = "tbSĐichVu";
            this.tbSĐichVu.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSĐichVu.Size = new System.Drawing.Size(1368, 603);
            this.tbSĐichVu.TabIndex = 1;
            this.tbSĐichVu.Text = "Danh sách sử dụng dịch vụ";
            this.tbSĐichVu.Click += new System.EventHandler(this.tbSĐichVu_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(283, 550);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(148, 48);
            this.btnThem.TabIndex = 21;
            this.btnThem.Text = "Thêm Phiếu";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnLamMoiDSSDDV
            // 
            this.btnLamMoiDSSDDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoiDSSDDV.Location = new System.Drawing.Point(1124, 550);
            this.btnLamMoiDSSDDV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLamMoiDSSDDV.Name = "btnLamMoiDSSDDV";
            this.btnLamMoiDSSDDV.Size = new System.Drawing.Size(148, 48);
            this.btnLamMoiDSSDDV.TabIndex = 18;
            this.btnLamMoiDSSDDV.Text = "Làm Mới";
            this.btnLamMoiDSSDDV.UseVisualStyleBackColor = true;
            this.btnLamMoiDSSDDV.Click += new System.EventHandler(this.btnLamMoiDSSDDV_Click);
            // 
            // btnCapNhap
            // 
            this.btnCapNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhap.Location = new System.Drawing.Point(869, 550);
            this.btnCapNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCapNhap.Name = "btnCapNhap";
            this.btnCapNhap.Size = new System.Drawing.Size(148, 48);
            this.btnCapNhap.TabIndex = 18;
            this.btnCapNhap.Text = "Cập Nhật";
            this.btnCapNhap.UseVisualStyleBackColor = true;
            this.btnCapNhap.Click += new System.EventHandler(this.btnCapNhap_Click);
            // 
            // btnHuyPhieu
            // 
            this.btnHuyPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyPhieu.Location = new System.Drawing.Point(581, 550);
            this.btnHuyPhieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuyPhieu.Name = "btnHuyPhieu";
            this.btnHuyPhieu.Size = new System.Drawing.Size(148, 48);
            this.btnHuyPhieu.TabIndex = 19;
            this.btnHuyPhieu.Text = "Xóa Phiếu";
            this.btnHuyPhieu.UseVisualStyleBackColor = true;
            this.btnHuyPhieu.Click += new System.EventHandler(this.btnHuyPhieu_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbMaDatPhong);
            this.groupBox3.Controls.Add(this.cbMaDichVu);
            this.groupBox3.Controls.Add(this.txtSoLuong);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtMaSDDV);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(23, 53);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(437, 377);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Phiếu Sử dụng dịch vụ";
            // 
            // cbMaDatPhong
            // 
            this.cbMaDatPhong.FormattingEnabled = true;
            this.cbMaDatPhong.Location = new System.Drawing.Point(212, 183);
            this.cbMaDatPhong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbMaDatPhong.Name = "cbMaDatPhong";
            this.cbMaDatPhong.Size = new System.Drawing.Size(196, 30);
            this.cbMaDatPhong.TabIndex = 4;
            this.cbMaDatPhong.SelectedIndexChanged += new System.EventHandler(this.cbMaDatPhong_SelectedIndexChanged);
            // 
            // cbMaDichVu
            // 
            this.cbMaDichVu.FormattingEnabled = true;
            this.cbMaDichVu.Location = new System.Drawing.Point(212, 121);
            this.cbMaDichVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbMaDichVu.Name = "cbMaDichVu";
            this.cbMaDichVu.Size = new System.Drawing.Size(196, 30);
            this.cbMaDichVu.TabIndex = 3;
            this.cbMaDichVu.SelectedIndexChanged += new System.EventHandler(this.cbMaDichVu_SelectedIndexChanged);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(212, 249);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(196, 28);
            this.txtSoLuong.TabIndex = 2;
            this.txtSoLuong.TextChanged += new System.EventHandler(this.txtSoLuong_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 22);
            this.label6.TabIndex = 1;
            this.label6.Text = "Số lượng:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 22);
            this.label7.TabIndex = 1;
            this.label7.Text = "Mã đặt phòng:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 22);
            this.label8.TabIndex = 1;
            this.label8.Text = "Mã dịch vụ:";
            // 
            // txtMaSDDV
            // 
            this.txtMaSDDV.Location = new System.Drawing.Point(212, 57);
            this.txtMaSDDV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaSDDV.Name = "txtMaSDDV";
            this.txtMaSDDV.Size = new System.Drawing.Size(196, 28);
            this.txtMaSDDV.TabIndex = 2;
            this.txtMaSDDV.TextChanged += new System.EventHandler(this.txtMaSDDV_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 22);
            this.label9.TabIndex = 1;
            this.label9.Text = "Mã sử dụng dịch vụ:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvSuDungDichVu);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(461, 63);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(907, 478);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Danh Sách Phiếu Sử Dụng Dịch Vụ";
            // 
            // dgvSuDungDichVu
            // 
            this.dgvSuDungDichVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSuDungDichVu.BackgroundColor = System.Drawing.Color.White;
            this.dgvSuDungDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuDungDichVu.Location = new System.Drawing.Point(5, 26);
            this.dgvSuDungDichVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSuDungDichVu.Name = "dgvSuDungDichVu";
            this.dgvSuDungDichVu.RowHeadersWidth = 51;
            this.dgvSuDungDichVu.RowTemplate.Height = 24;
            this.dgvSuDungDichVu.Size = new System.Drawing.Size(899, 447);
            this.dgvSuDungDichVu.TabIndex = 0;
            this.dgvSuDungDichVu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSuDungDichVu_CellContentClick);
            // 
            // btnThoatt
            // 
            this.btnThoatt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoatt.Location = new System.Drawing.Point(23, 550);
            this.btnThoatt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThoatt.Name = "btnThoatt";
            this.btnThoatt.Size = new System.Drawing.Size(148, 48);
            this.btnThoatt.TabIndex = 20;
            this.btnThoatt.Text = "Thoát";
            this.btnThoatt.UseVisualStyleBackColor = true;
            this.btnThoatt.Click += new System.EventHandler(this.btnThoatt_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label10.Location = new System.Drawing.Point(444, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(320, 42);
            this.label10.TabIndex = 15;
            this.label10.Text = "Sử Dụng Dịch Vụ";
            // 
            // tbLoaiDichVu
            // 
            this.tbLoaiDichVu.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tbLoaiDichVu.Controls.Add(this.btnLamMoiLDV);
            this.tbLoaiDichVu.Controls.Add(this.btnCapNhatLDV);
            this.tbLoaiDichVu.Controls.Add(this.btnXoaLDV);
            this.tbLoaiDichVu.Controls.Add(this.btnThoatLDV);
            this.tbLoaiDichVu.Controls.Add(this.btnThemLDV);
            this.tbLoaiDichVu.Controls.Add(this.groupBox5);
            this.tbLoaiDichVu.Controls.Add(this.groupBox6);
            this.tbLoaiDichVu.Controls.Add(this.label14);
            this.tbLoaiDichVu.Location = new System.Drawing.Point(4, 31);
            this.tbLoaiDichVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbLoaiDichVu.Name = "tbLoaiDichVu";
            this.tbLoaiDichVu.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbLoaiDichVu.Size = new System.Drawing.Size(1368, 603);
            this.tbLoaiDichVu.TabIndex = 2;
            this.tbLoaiDichVu.Text = "Loại dịch vụ";
            // 
            // btnLamMoiLDV
            // 
            this.btnLamMoiLDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoiLDV.Location = new System.Drawing.Point(1172, 517);
            this.btnLamMoiLDV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLamMoiLDV.Name = "btnLamMoiLDV";
            this.btnLamMoiLDV.Size = new System.Drawing.Size(148, 48);
            this.btnLamMoiLDV.TabIndex = 30;
            this.btnLamMoiLDV.Text = "Làm Mới";
            this.btnLamMoiLDV.UseVisualStyleBackColor = true;
            this.btnLamMoiLDV.Click += new System.EventHandler(this.btnLamMoiLDV_Click);
            // 
            // btnCapNhatLDV
            // 
            this.btnCapNhatLDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhatLDV.Location = new System.Drawing.Point(901, 517);
            this.btnCapNhatLDV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCapNhatLDV.Name = "btnCapNhatLDV";
            this.btnCapNhatLDV.Size = new System.Drawing.Size(148, 48);
            this.btnCapNhatLDV.TabIndex = 30;
            this.btnCapNhatLDV.Text = "Cập Nhật";
            this.btnCapNhatLDV.UseVisualStyleBackColor = true;
            this.btnCapNhatLDV.Click += new System.EventHandler(this.btnCapNhatLDV_Click);
            // 
            // btnXoaLDV
            // 
            this.btnXoaLDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaLDV.Location = new System.Drawing.Point(607, 517);
            this.btnXoaLDV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoaLDV.Name = "btnXoaLDV";
            this.btnXoaLDV.Size = new System.Drawing.Size(148, 48);
            this.btnXoaLDV.TabIndex = 31;
            this.btnXoaLDV.Text = "Xóa ";
            this.btnXoaLDV.UseVisualStyleBackColor = true;
            this.btnXoaLDV.Click += new System.EventHandler(this.btnXoaLDV_Click);
            // 
            // btnThoatLDV
            // 
            this.btnThoatLDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoatLDV.Location = new System.Drawing.Point(33, 517);
            this.btnThoatLDV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThoatLDV.Name = "btnThoatLDV";
            this.btnThoatLDV.Size = new System.Drawing.Size(148, 48);
            this.btnThoatLDV.TabIndex = 32;
            this.btnThoatLDV.Text = "Thoát";
            this.btnThoatLDV.UseVisualStyleBackColor = true;
            this.btnThoatLDV.Click += new System.EventHandler(this.btnThoatLDV_Click);
            // 
            // btnThemLDV
            // 
            this.btnThemLDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemLDV.Location = new System.Drawing.Point(323, 517);
            this.btnThemLDV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemLDV.Name = "btnThemLDV";
            this.btnThemLDV.Size = new System.Drawing.Size(148, 48);
            this.btnThemLDV.TabIndex = 33;
            this.btnThemLDV.Text = "Thêm ";
            this.btnThemLDV.UseVisualStyleBackColor = true;
            this.btnThemLDV.Click += new System.EventHandler(this.btnThemLDV_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataGridViewLoaiDichVu);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(507, 47);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(835, 430);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Danh Sách Dịch Vụ";
            // 
            // dataGridViewLoaiDichVu
            // 
            this.dataGridViewLoaiDichVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLoaiDichVu.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLoaiDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLoaiDichVu.Location = new System.Drawing.Point(5, 27);
            this.dataGridViewLoaiDichVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewLoaiDichVu.Name = "dataGridViewLoaiDichVu";
            this.dataGridViewLoaiDichVu.RowHeadersWidth = 51;
            this.dataGridViewLoaiDichVu.RowTemplate.Height = 24;
            this.dataGridViewLoaiDichVu.Size = new System.Drawing.Size(823, 402);
            this.dataGridViewLoaiDichVu.TabIndex = 0;
            this.dataGridViewLoaiDichVu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLoaiDichVu_CellContentClick);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cboMaLoaiPhong);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.txtTenLDV);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.txtMaLoaiDV);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(57, 69);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(413, 347);
            this.groupBox6.TabIndex = 28;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Phiếu Loại Dịch Vụ";
            // 
            // cboMaLoaiPhong
            // 
            this.cboMaLoaiPhong.FormattingEnabled = true;
            this.cboMaLoaiPhong.Location = new System.Drawing.Point(188, 247);
            this.cboMaLoaiPhong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboMaLoaiPhong.Name = "cboMaLoaiPhong";
            this.cboMaLoaiPhong.Size = new System.Drawing.Size(172, 30);
            this.cboMaLoaiPhong.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(29, 251);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(127, 22);
            this.label13.TabIndex = 3;
            this.label13.Text = "Mã loại phòng:";
            // 
            // txtTenLDV
            // 
            this.txtTenLDV.Location = new System.Drawing.Point(188, 167);
            this.txtTenLDV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenLDV.Name = "txtTenLDV";
            this.txtTenLDV.Size = new System.Drawing.Size(172, 28);
            this.txtTenLDV.TabIndex = 2;
            this.txtTenLDV.TextChanged += new System.EventHandler(this.txtTenLDV_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 171);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 22);
            this.label11.TabIndex = 1;
            this.label11.Text = "Tên loại dịch vụ:";
            // 
            // txtMaLoaiDV
            // 
            this.txtMaLoaiDV.Location = new System.Drawing.Point(188, 78);
            this.txtMaLoaiDV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaLoaiDV.Name = "txtMaLoaiDV";
            this.txtMaLoaiDV.Size = new System.Drawing.Size(172, 28);
            this.txtMaLoaiDV.TabIndex = 2;
            this.txtMaLoaiDV.TextChanged += new System.EventHandler(this.txtMaLoaiDV_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 22);
            this.label12.TabIndex = 1;
            this.label12.Text = "Mã loại dịch vụ:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label14.Location = new System.Drawing.Point(491, 2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(242, 42);
            this.label14.TabIndex = 27;
            this.label14.Text = "Loại Dịch Vụ";
            // 
            // frmDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1388, 654);
            this.Controls.Add(this.tbDichVu);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmDichVu";
            this.Text = "frmDichVu";
            this.Load += new System.EventHandler(this.frmDichVu_Load_1);
            this.tbDichVu.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDichVu)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tbSĐichVu.ResumeLayout(false);
            this.tbSĐichVu.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuDungDichVu)).EndInit();
            this.tbLoaiDichVu.ResumeLayout(false);
            this.tbLoaiDichVu.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoaiDichVu)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.TabControl tbDichVu;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewDichVu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbLoaiDichVu;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTenDV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaDV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnXoaDV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnThemDV;
        private System.Windows.Forms.TabPage tbSĐichVu;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnCapNhap;
        private System.Windows.Forms.Button btnHuyPhieu;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbMaDatPhong;
        private System.Windows.Forms.ComboBox cbMaDichVu;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaSDDV;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvSuDungDichVu;
        private System.Windows.Forms.Button btnThoatt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tbLoaiDichVu;
        private System.Windows.Forms.Button btnCapNhatLDV;
        private System.Windows.Forms.Button btnXoaLDV;
        private System.Windows.Forms.Button btnThoatLDV;
        private System.Windows.Forms.Button btnThemLDV;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dataGridViewLoaiDichVu;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTenLDV;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMaLoaiDV;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button btnLamMoiDV;
        private System.Windows.Forms.Button btnLamMoiLDV;
        private System.Windows.Forms.Button btnLamMoiDSSDDV;
        private System.Windows.Forms.ComboBox cboMaLoaiPhong;
    }
}