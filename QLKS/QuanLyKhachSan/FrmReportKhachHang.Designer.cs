namespace QuanLyKhachSan
{
    partial class FrmReportKhachHang
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rptKhachHang = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.quanLyKhachSanDataSet = new QuanLyKhachSan.QuanLyKhachSanDataSet();
            this.quanLyKhachSanDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hienThiThongKeKhachHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hienThiThongKeKhachHangTableAdapter = new QuanLyKhachSan.QuanLyKhachSanDataSetTableAdapters.HienThiThongKeKhachHangTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyKhachSanDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyKhachSanDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hienThiThongKeKhachHangBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rptKhachHang
            // 
            this.rptKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.hienThiThongKeKhachHangBindingSource;
            this.rptKhachHang.LocalReport.DataSources.Add(reportDataSource1);
            this.rptKhachHang.LocalReport.ReportEmbeddedResource = "QuanLyKhachSan.InThongKeKhachHang.rdlc";
            this.rptKhachHang.Location = new System.Drawing.Point(12, 180);
            this.rptKhachHang.Name = "rptKhachHang";
            this.rptKhachHang.ServerReport.BearerToken = null;
            this.rptKhachHang.Size = new System.Drawing.Size(1439, 628);
            this.rptKhachHang.TabIndex = 0;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(289, 54);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(200, 30);
            this.dtpTuNgay.TabIndex = 1;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(783, 49);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(200, 30);
            this.dtpDenNgay.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(172, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Từ Ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(626, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Đến Ngày:";
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Location = new System.Drawing.Point(1075, 50);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 32);
            this.btnIn.TabIndex = 5;
            this.btnIn.Text = "IN";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // quanLyKhachSanDataSet
            // 
            this.quanLyKhachSanDataSet.DataSetName = "QuanLyKhachSanDataSet";
            this.quanLyKhachSanDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // quanLyKhachSanDataSetBindingSource
            // 
            this.quanLyKhachSanDataSetBindingSource.DataSource = this.quanLyKhachSanDataSet;
            this.quanLyKhachSanDataSetBindingSource.Position = 0;
            // 
            // hienThiThongKeKhachHangBindingSource
            // 
            this.hienThiThongKeKhachHangBindingSource.DataMember = "HienThiThongKeKhachHang";
            this.hienThiThongKeKhachHangBindingSource.DataSource = this.quanLyKhachSanDataSetBindingSource;
            // 
            // hienThiThongKeKhachHangTableAdapter
            // 
            this.hienThiThongKeKhachHangTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReportKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 820);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.rptKhachHang);
            this.Name = "FrmReportKhachHang";
            this.Text = "FrmReportKhachHang";
            this.Load += new System.EventHandler(this.FrmReportKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quanLyKhachSanDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyKhachSanDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hienThiThongKeKhachHangBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptKhachHang;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.BindingSource hienThiThongKeKhachHangBindingSource;
        private System.Windows.Forms.BindingSource quanLyKhachSanDataSetBindingSource;
        private QuanLyKhachSanDataSet quanLyKhachSanDataSet;
        private QuanLyKhachSanDataSetTableAdapters.HienThiThongKeKhachHangTableAdapter hienThiThongKeKhachHangTableAdapter;
    }
}