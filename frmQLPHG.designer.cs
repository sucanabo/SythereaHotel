namespace QuanLyKhachSan
{
    partial class frmQLPHG
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtNgayNhan = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayTra = new System.Windows.Forms.DateTimePicker();
            this.cboLoaiPHG = new System.Windows.Forms.ComboBox();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cboGiaPHG = new System.Windows.Forms.ComboBox();
            this.dgvAn = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flpPHG = new System.Windows.Forms.FlowLayoutPanel();
            this.cboTang = new System.Windows.Forms.ComboBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAn)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(376, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày Trả";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(41, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày Nhận";
            // 
            // dtNgayNhan
            // 
            this.dtNgayNhan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayNhan.Location = new System.Drawing.Point(159, 115);
            this.dtNgayNhan.Margin = new System.Windows.Forms.Padding(4);
            this.dtNgayNhan.Name = "dtNgayNhan";
            this.dtNgayNhan.Size = new System.Drawing.Size(137, 27);
            this.dtNgayNhan.TabIndex = 3;
            // 
            // dtpNgayTra
            // 
            this.dtpNgayTra.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.dtpNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayTra.Location = new System.Drawing.Point(486, 115);
            this.dtpNgayTra.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNgayTra.Name = "dtpNgayTra";
            this.dtpNgayTra.Size = new System.Drawing.Size(171, 27);
            this.dtpNgayTra.TabIndex = 3;
            // 
            // cboLoaiPHG
            // 
            this.cboLoaiPHG.FormattingEnabled = true;
            this.cboLoaiPHG.Location = new System.Drawing.Point(129, 27);
            this.cboLoaiPHG.Margin = new System.Windows.Forms.Padding(4);
            this.cboLoaiPHG.Name = "cboLoaiPHG";
            this.cboLoaiPHG.Size = new System.Drawing.Size(219, 28);
            this.cboLoaiPHG.TabIndex = 4;
            // 
            // btnDangKy
            // 
            this.btnDangKy.Location = new System.Drawing.Point(45, 197);
            this.btnDangKy.Margin = new System.Windows.Forms.Padding(4);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(612, 70);
            this.btnDangKy.TabIndex = 0;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 32);
            this.label5.TabIndex = 1;
            this.label5.Text = "Giá Phòng";
            // 
            // cboGiaPHG
            // 
            this.cboGiaPHG.FormattingEnabled = true;
            this.cboGiaPHG.Location = new System.Drawing.Point(129, 81);
            this.cboGiaPHG.Margin = new System.Windows.Forms.Padding(4);
            this.cboGiaPHG.Name = "cboGiaPHG";
            this.cboGiaPHG.Size = new System.Drawing.Size(219, 28);
            this.cboGiaPHG.TabIndex = 4;
            // 
            // dgvAn
            // 
            this.dgvAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAn.Location = new System.Drawing.Point(7, 407);
            this.dgvAn.Name = "dgvAn";
            this.dgvAn.RowHeadersWidth = 51;
            this.dgvAn.Size = new System.Drawing.Size(10, 24);
            this.dgvAn.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightYellow;
            this.groupBox1.Controls.Add(this.flpPHG);
            this.groupBox1.Controls.Add(this.dgvAn);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 309);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1237, 332);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn phòng";
            // 
            // flpPHG
            // 
            this.flpPHG.AutoScroll = true;
            this.flpPHG.BackColor = System.Drawing.Color.Ivory;
            this.flpPHG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPHG.Location = new System.Drawing.Point(4, 24);
            this.flpPHG.Margin = new System.Windows.Forms.Padding(4);
            this.flpPHG.Name = "flpPHG";
            this.flpPHG.Size = new System.Drawing.Size(1229, 304);
            this.flpPHG.TabIndex = 0;
            // 
            // cboTang
            // 
            this.cboTang.FormattingEnabled = true;
            this.cboTang.Items.AddRange(new object[] {
            "Tất cả"});
            this.cboTang.Location = new System.Drawing.Point(129, 137);
            this.cboTang.Margin = new System.Windows.Forms.Padding(4);
            this.cboTang.Name = "cboTang";
            this.cboTang.Size = new System.Drawing.Size(219, 28);
            this.cboTang.TabIndex = 4;
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.Turquoise;
            this.btnLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(395, 19);
            this.btnLoc.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(115, 69);
            this.btnLoc.TabIndex = 0;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 30);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 32);
            this.label4.TabIndex = 1;
            this.label4.Text = "Loại phòng";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(10, 140);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 32);
            this.label6.TabIndex = 1;
            this.label6.Text = "Tầng";
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.LightSalmon;
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(395, 107);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(115, 69);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Aquamarine;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Chocolate;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1237, 90);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ ĐẶT PHÒNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightYellow;
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnHuy);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnLoc);
            this.groupBox2.Controls.Add(this.cboLoaiPHG);
            this.groupBox2.Controls.Add(this.cboTang);
            this.groupBox2.Controls.Add(this.cboGiaPHG);
            this.groupBox2.Location = new System.Drawing.Point(680, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(535, 189);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bộ lọc";
            // 
            // frmQLPHG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1237, 641);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.dtpNgayTra);
            this.Controls.Add(this.dtNgayNhan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQLPHG";
            this.Text = "frmQLPHG";
            this.Load += new System.EventHandler(this.frmQLPHG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAn)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboLoaiPHG;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboGiaPHG;
        private System.Windows.Forms.DataGridView dgvAn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboTang;
        private System.Windows.Forms.FlowLayoutPanel flpPHG;
        private System.Windows.Forms.Button btnLoc;
        public System.Windows.Forms.DateTimePicker dtNgayNhan;
        public System.Windows.Forms.DateTimePicker dtpNgayTra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}