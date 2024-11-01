namespace QuanLyKhachSan
{
    partial class frmTimKiemNhanVien
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
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvTimKiemNV = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.panelFilterOptions = new System.Windows.Forms.Panel();
            this.chkLuongTangDan = new System.Windows.Forms.CheckBox();
            this.chkLuongGiamDan = new System.Windows.Forms.CheckBox();
            this.btnQuayLai = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemNV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelFilterOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Location = new System.Drawing.Point(527, 67);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(74, 39);
            this.btnLamMoi.TabIndex = 17;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // dgvTimKiemNV
            // 
            this.dgvTimKiemNV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTimKiemNV.BackgroundColor = System.Drawing.Color.White;
            this.dgvTimKiemNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimKiemNV.Location = new System.Drawing.Point(5, 18);
            this.dgvTimKiemNV.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTimKiemNV.Name = "dgvTimKiemNV";
            this.dgvTimKiemNV.RowHeadersWidth = 51;
            this.dgvTimKiemNV.RowTemplate.Height = 24;
            this.dgvTimKiemNV.Size = new System.Drawing.Size(620, 257);
            this.dgvTimKiemNV.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(299, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 29);
            this.label3.TabIndex = 15;
            this.label3.Text = "TÌM KIẾM NHÂN VIÊN";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNV.Location = new System.Drawing.Point(262, 103);
            this.txtTenNV.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(125, 24);
            this.txtTenNV.TabIndex = 14;
            this.txtTenNV.TextChanged += new System.EventHandler(this.txtTenNV_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(135, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tên nhân viên";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Location = new System.Drawing.Point(262, 64);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(125, 24);
            this.txtMaNV.TabIndex = 12;
            this.txtMaNV.TextChanged += new System.EventHandler(this.txtMaNV_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Mã nhân viên";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(421, 67);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(85, 39);
            this.btnTimKiem.TabIndex = 17;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTimKiemNV);
            this.groupBox1.Location = new System.Drawing.Point(111, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(628, 281);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Kết Quả";
            // 
            // btnFilter
            // 
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(623, 67);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(2);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(74, 39);
            this.btnFilter.TabIndex = 17;
            this.btnFilter.Text = "Lọc";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // panelFilterOptions
            // 
            this.panelFilterOptions.Controls.Add(this.chkLuongGiamDan);
            this.panelFilterOptions.Controls.Add(this.chkLuongTangDan);
            this.panelFilterOptions.Location = new System.Drawing.Point(12, 27);
            this.panelFilterOptions.Name = "panelFilterOptions";
            this.panelFilterOptions.Size = new System.Drawing.Size(200, 100);
            this.panelFilterOptions.TabIndex = 19;
            this.panelFilterOptions.Visible = false;
            // 
            // chkLuongTangDan
            // 
            this.chkLuongTangDan.AutoSize = true;
            this.chkLuongTangDan.Location = new System.Drawing.Point(3, 12);
            this.chkLuongTangDan.Name = "chkLuongTangDan";
            this.chkLuongTangDan.Size = new System.Drawing.Size(143, 17);
            this.chkLuongTangDan.TabIndex = 0;
            this.chkLuongTangDan.Text = "Xếp theo lương tăng dần";
            this.chkLuongTangDan.UseVisualStyleBackColor = true;
            this.chkLuongTangDan.CheckedChanged += new System.EventHandler(this.chkLuongTangDan_CheckedChanged);
            // 
            // chkLuongGiamDan
            // 
            this.chkLuongGiamDan.AutoSize = true;
            this.chkLuongGiamDan.Location = new System.Drawing.Point(3, 34);
            this.chkLuongGiamDan.Name = "chkLuongGiamDan";
            this.chkLuongGiamDan.Size = new System.Drawing.Size(142, 17);
            this.chkLuongGiamDan.TabIndex = 0;
            this.chkLuongGiamDan.Text = "xếp theo lương giảm dần";
            this.chkLuongGiamDan.UseVisualStyleBackColor = true;
            this.chkLuongGiamDan.CheckedChanged += new System.EventHandler(this.chkLuongGiamDan_CheckedChanged);
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayLai.Location = new System.Drawing.Point(719, 67);
            this.btnQuayLai.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(74, 39);
            this.btnQuayLai.TabIndex = 17;
            this.btnQuayLai.Text = "Quay Lại";
            this.btnQuayLai.UseVisualStyleBackColor = true;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // frmTimKiemNhanVien
            // 
            this.AcceptButton = this.btnTimKiem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 482);
            this.Controls.Add(this.panelFilterOptions);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnQuayLai);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.label2);
            this.Name = "frmTimKiemNhanVien";
            this.Text = "frmTimKiemNhanVien";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemNV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panelFilterOptions.ResumeLayout(false);
            this.panelFilterOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvTimKiemNV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Panel panelFilterOptions;
        private System.Windows.Forms.CheckBox chkLuongGiamDan;
        private System.Windows.Forms.CheckBox chkLuongTangDan;
        private System.Windows.Forms.Button btnQuayLai;
    }
}