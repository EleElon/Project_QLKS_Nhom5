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
            this.hienThiThongKeKhachHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyKhachSanDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyKhachSanDataSet = new QuanLyKhachSan.QuanLyKhachSanDataSet();
            this.rptKhachHang = new Microsoft.Reporting.WinForms.ReportViewer();
            this.hienThiThongKeKhachHangTableAdapter = new QuanLyKhachSan.QuanLyKhachSanDataSetTableAdapters.HienThiThongKeKhachHangTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.hienThiThongKeKhachHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyKhachSanDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyKhachSanDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // hienThiThongKeKhachHangBindingSource
            // 
            this.hienThiThongKeKhachHangBindingSource.DataMember = "HienThiThongKeKhachHang";
            this.hienThiThongKeKhachHangBindingSource.DataSource = this.quanLyKhachSanDataSetBindingSource;
            // 
            // quanLyKhachSanDataSetBindingSource
            // 
            this.quanLyKhachSanDataSetBindingSource.DataSource = this.quanLyKhachSanDataSet;
            this.quanLyKhachSanDataSetBindingSource.Position = 0;
            // 
            // quanLyKhachSanDataSet
            // 
            this.quanLyKhachSanDataSet.DataSetName = "QuanLyKhachSanDataSet";
            this.quanLyKhachSanDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rptKhachHang
            // 
            this.rptKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.hienThiThongKeKhachHangBindingSource;
            this.rptKhachHang.LocalReport.DataSources.Add(reportDataSource1);
            this.rptKhachHang.LocalReport.ReportEmbeddedResource = "QuanLyKhachSan.InThongKeKhachHang.rdlc";
            this.rptKhachHang.Location = new System.Drawing.Point(3, 3);
            this.rptKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rptKhachHang.Name = "rptKhachHang";
            this.rptKhachHang.ServerReport.BearerToken = null;
            this.rptKhachHang.Size = new System.Drawing.Size(1463, 652);
            this.rptKhachHang.TabIndex = 0;
            // 
            // hienThiThongKeKhachHangTableAdapter
            // 
            this.hienThiThongKeKhachHangTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReportKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 660);
            this.Controls.Add(this.rptKhachHang);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmReportKhachHang";
            this.Text = "FrmReportKhachHang";
            this.Load += new System.EventHandler(this.FrmReportKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hienThiThongKeKhachHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyKhachSanDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyKhachSanDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptKhachHang;
        private System.Windows.Forms.BindingSource hienThiThongKeKhachHangBindingSource;
        private System.Windows.Forms.BindingSource quanLyKhachSanDataSetBindingSource;
        private QuanLyKhachSanDataSet quanLyKhachSanDataSet;
        private QuanLyKhachSanDataSetTableAdapters.HienThiThongKeKhachHangTableAdapter hienThiThongKeKhachHangTableAdapter;
    }
}