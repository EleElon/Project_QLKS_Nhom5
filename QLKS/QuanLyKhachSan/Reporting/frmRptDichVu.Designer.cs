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
            this.SuspendLayout();
            // 
            // rptViewDichVu
            // 
            this.rptViewDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewDichVu.Location = new System.Drawing.Point(0, 0);
            this.rptViewDichVu.Name = "rptViewDichVu";
            this.rptViewDichVu.ServerReport.BearerToken = null;
            this.rptViewDichVu.Size = new System.Drawing.Size(800, 450);
            this.rptViewDichVu.TabIndex = 0;
            // 
            // frmRptDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rptViewDichVu);
            this.Name = "frmRptDichVu";
            this.Text = "frmRptDichVu";
            this.Load += new System.EventHandler(this.frmRptDichVu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptViewDichVu;
    }
}