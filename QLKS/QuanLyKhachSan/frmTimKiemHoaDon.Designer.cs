namespace QuanLyKhachSan
{
    partial class frmTimKiemHoaDon
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvTimKiemHoaDon = new System.Windows.Forms.DataGridView();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.ccbMaHD = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hóa đơn";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(429, 54);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(113, 38);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvTimKiemHoaDon
            // 
            this.dgvTimKiemHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvTimKiemHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimKiemHoaDon.Location = new System.Drawing.Point(2, 120);
            this.dgvTimKiemHoaDon.Name = "dgvTimKiemHoaDon";
            this.dgvTimKiemHoaDon.RowHeadersWidth = 51;
            this.dgvTimKiemHoaDon.RowTemplate.Height = 24;
            this.dgvTimKiemHoaDon.Size = new System.Drawing.Size(937, 306);
            this.dgvTimKiemHoaDon.TabIndex = 3;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Location = new System.Drawing.Point(634, 54);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(113, 38);
            this.btnLamMoi.TabIndex = 4;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // ccbMaHD
            // 
            this.ccbMaHD.FormattingEnabled = true;
            this.ccbMaHD.Location = new System.Drawing.Point(198, 54);
            this.ccbMaHD.Name = "ccbMaHD";
            this.ccbMaHD.Size = new System.Drawing.Size(131, 24);
            this.ccbMaHD.TabIndex = 5;
            // 
            // frmTimKiemHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(951, 439);
            this.Controls.Add(this.ccbMaHD);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.dgvTimKiemHoaDon);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.label1);
            this.Name = "frmTimKiemHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTimKiemHoaDon";
            this.Load += new System.EventHandler(this.frmTimKiemHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvTimKiemHoaDon;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.ComboBox ccbMaHD;
    }
}