namespace QuanLyKhachSan
{
    partial class frmTruyVanHD
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
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiPHg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaPHG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD,
            this.LoaiPHg,
            this.PHG,
            this.GiaPHG,
            this.HoTen,
            this.CMND,
            this.SDT});
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvChiTiet.Location = new System.Drawing.Point(0, 181);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.RowTemplate.Height = 24;
            this.dgvChiTiet.Size = new System.Drawing.Size(800, 305);
            this.dgvChiTiet.TabIndex = 0;
            // 
            // lblMaHD
            // 
            this.lblMaHD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMaHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHD.ForeColor = System.Drawing.Color.Red;
            this.lblMaHD.Location = new System.Drawing.Point(16, 69);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(127, 33);
            this.lblMaHD.TabIndex = 1;
            this.lblMaHD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã hợp đồng";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.YellowGreen;
            this.label1.Location = new System.Drawing.Point(384, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên khách hàng:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenKH
            // 
            this.lblTenKH.BackColor = System.Drawing.Color.Snow;
            this.lblTenKH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenKH.Location = new System.Drawing.Point(571, 22);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(204, 30);
            this.lblTenKH.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.YellowGreen;
            this.label4.Location = new System.Drawing.Point(384, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 40);
            this.label4.TabIndex = 2;
            this.label4.Text = "CMND:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.YellowGreen;
            this.label6.Location = new System.Drawing.Point(384, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 40);
            this.label6.TabIndex = 2;
            this.label6.Text = "SDT:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MaHD
            // 
            this.MaHD.DataPropertyName = "MaHD";
            this.MaHD.HeaderText = "MAHD";
            this.MaHD.MinimumWidth = 6;
            this.MaHD.Name = "MaHD";
            this.MaHD.Visible = false;
            // 
            // LoaiPHg
            // 
            this.LoaiPHg.DataPropertyName = "TenLoai";
            this.LoaiPHg.HeaderText = "Loại phòng";
            this.LoaiPHg.MinimumWidth = 6;
            this.LoaiPHg.Name = "LoaiPHg";
            // 
            // PHG
            // 
            this.PHG.DataPropertyName = "MaPHG";
            this.PHG.HeaderText = "Phòng";
            this.PHG.MinimumWidth = 6;
            this.PHG.Name = "PHG";
            // 
            // GiaPHG
            // 
            this.GiaPHG.DataPropertyName = "GiaTien";
            this.GiaPHG.HeaderText = "Giá phòng";
            this.GiaPHG.MinimumWidth = 6;
            this.GiaPHG.Name = "GiaPHG";
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "hoten";
            this.HoTen.HeaderText = "hoten";
            this.HoTen.MinimumWidth = 6;
            this.HoTen.Name = "HoTen";
            this.HoTen.Visible = false;
            // 
            // CMND
            // 
            this.CMND.DataPropertyName = "cmnd";
            this.CMND.HeaderText = "cmnd";
            this.CMND.MinimumWidth = 6;
            this.CMND.Name = "CMND";
            this.CMND.Visible = false;
            // 
            // SDT
            // 
            this.SDT.DataPropertyName = "sdt";
            this.SDT.HeaderText = "sdt";
            this.SDT.MinimumWidth = 6;
            this.SDT.Name = "SDT";
            this.SDT.Visible = false;
            // 
            // txtCMND
            // 
            this.txtCMND.BackColor = System.Drawing.Color.Snow;
            this.txtCMND.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCMND.Location = new System.Drawing.Point(571, 67);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(204, 28);
            this.txtCMND.TabIndex = 3;
            // 
            // txtSDT
            // 
            this.txtSDT.BackColor = System.Drawing.Color.Snow;
            this.txtSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(571, 121);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(204, 28);
            this.txtSDT.TabIndex = 3;
            // 
            // frmTruyVanHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(800, 486);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtCMND);
            this.Controls.Add(this.lblTenKH);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMaHD);
            this.Controls.Add(this.dgvChiTiet);
            this.Name = "frmTruyVanHD";
            this.Text = "Thông tin hóa đơn";
            this.Load += new System.EventHandler(this.frmTruyVanHD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTenKH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiPHg;
        private System.Windows.Forms.DataGridViewTextBoxColumn PHG;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaPHG;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMND;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDT;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.TextBox txtSDT;
    }
}