namespace QuanLyKhachSan
{
    partial class frmThemDichVu
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
            this.gbDv = new System.Windows.Forms.GroupBox();
            this.dgrDichVu = new System.Windows.Forms.DataGridView();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.cboDichVu = new System.Windows.Forms.ComboBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMaPHG = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MaPHG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thanhtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbDv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDichVu)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDv
            // 
            this.gbDv.Controls.Add(this.dgrDichVu);
            this.gbDv.Controls.Add(this.btnThanhToan);
            this.gbDv.Controls.Add(this.btnThem);
            this.gbDv.Controls.Add(this.cboDichVu);
            this.gbDv.Controls.Add(this.txtSoLuong);
            this.gbDv.Controls.Add(this.label3);
            this.gbDv.Controls.Add(this.label2);
            this.gbDv.Controls.Add(this.lblMaPHG);
            this.gbDv.Controls.Add(this.label1);
            this.gbDv.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gbDv.Location = new System.Drawing.Point(12, 22);
            this.gbDv.Name = "gbDv";
            this.gbDv.Size = new System.Drawing.Size(625, 530);
            this.gbDv.TabIndex = 0;
            this.gbDv.TabStop = false;
            this.gbDv.Text = "Dịch Vụ";
            // 
            // dgrDichVu
            // 
            this.dgrDichVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrDichVu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPHG,
            this.MaDV,
            this.SoLuong,
            this.thanhtien});
            this.dgrDichVu.Location = new System.Drawing.Point(19, 193);
            this.dgrDichVu.Name = "dgrDichVu";
            this.dgrDichVu.RowTemplate.Height = 24;
            this.dgrDichVu.Size = new System.Drawing.Size(589, 317);
            this.dgrDichVu.TabIndex = 4;
            this.dgrDichVu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrDV_cellClick);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThanhToan.Location = new System.Drawing.Point(479, 124);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(129, 54);
            this.btnThanhToan.TabIndex = 3;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThem.Location = new System.Drawing.Point(359, 124);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(104, 54);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cboDichVu
            // 
            this.cboDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboDichVu.FormattingEnabled = true;
            this.cboDichVu.Location = new System.Drawing.Point(151, 72);
            this.cboDichVu.Name = "cboDichVu";
            this.cboDichVu.Size = new System.Drawing.Size(457, 28);
            this.cboDichVu.TabIndex = 2;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSoLuong.Location = new System.Drawing.Point(151, 124);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(140, 27);
            this.txtSoLuong.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(15, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số Lượng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(15, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Dịch Vụ";
            // 
            // lblMaPHG
            // 
            this.lblMaPHG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMaPHG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblMaPHG.Location = new System.Drawing.Point(151, 27);
            this.lblMaPHG.Name = "lblMaPHG";
            this.lblMaPHG.Size = new System.Drawing.Size(140, 30);
            this.lblMaPHG.TabIndex = 0;
            //this.lblMaPHG.Click += new System.EventHandler(this.lblMaHD_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã PHG";
            // 
            // MaPHG
            // 
            this.MaPHG.DataPropertyName = "MaPHG";
            this.MaPHG.HeaderText = "MaPHG";
            this.MaPHG.Name = "MaPHG";
            // 
            // MaDV
            // 
            this.MaDV.DataPropertyName = "MaDV";
            this.MaDV.HeaderText = "MaDV";
            this.MaDV.Name = "MaDV";
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "SoLuong";
            this.SoLuong.Name = "SoLuong";
            // 
            // thanhtien
            // 
            this.thanhtien.DataPropertyName = "thanhtien";
            this.thanhtien.HeaderText = "ThanhTien";
            this.thanhtien.Name = "thanhtien";
            // 
            // frmThemDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 578);
            this.Controls.Add(this.gbDv);
            this.Name = "frmThemDichVu";
            this.Text = "Thêm Dịch Vụ";
            this.Load += new System.EventHandler(this.ThemDVcs_Load);
            this.gbDv.ResumeLayout(false);
            this.gbDv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDichVu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDv;
        private System.Windows.Forms.ComboBox cboDichVu;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMaPHG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgrDichVu;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPHG;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn thanhtien;
    }
}