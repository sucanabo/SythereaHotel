using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyKhachSan
{
    public partial class frmPhg : Form
    {
        clsQLKS c = new clsQLKS();//KetnoiDL
        DataSet ds = new DataSet();
        DataSet dsLoaiphg = new DataSet();
        DataSet dsAnh = new DataSet();
        int t = 0;
  
        void ShowDanhSach(string sql, DataGridView d)
        {
            ds = c.DanhSach(sql);
            d.DataSource = ds.Tables[0];
        }
        void ShowLoaiphg(string sql)
        {
            dsLoaiphg = c.DanhSach(sql);
            cboLoaiPhg.DataSource = dsLoaiphg.Tables[0];
            cboLoaiPhg.DisplayMember = "TenLoai";
            cboLoaiPhg.ValueMember = "MaLoai";
            cboLoaiPhg.SelectedIndex = -1;
           

        }
        void showanh(string sql, DataSet ds, int vt)
        {
            dsAnh = c.DanhSach(sql);
            try
            {
                string Tenanh = dsAnh.Tables[0].Rows[vt]["Hinh"].ToString();
                loadNhieuAnh(Tenanh);
            }
            catch (Exception x)
            {
                MessageBox.Show("Load thất bại!");
            }
        }
 
        public frmPhg()
        {
            InitializeComponent();
            txtMaPhg.KeyPress += new KeyPressEventHandler(txtMaPhg_KeyPress);
        }
        void setButton(Button btn, String img)
        {
            Size size = new Size(40, 40);
            Bitmap filter = new Bitmap("ImagesQLKS\\icon\\" + img);
            btn.Image = filter;
            btn.Image = (Image)(new Bitmap(filter, size));
            btn.ImageAlign = ContentAlignment.TopLeft;
            btn.TextAlign = ContentAlignment.BottomRight;
            btn.ForeColor = Color.White;
        }
        void xuLyButton()
        {
            setButton(btnThem, "plus.png");
            setButton(btnXoa, "bin.png");
            setButton(btnSua, "pencil.png");
            setButton(btnLuu, "savereal.png");
            setButton(btnHuy, "cancel.png");
            setButton(btnThoat, "close.png");
        }
        private void frmPhg_Load(object sender, EventArgs e)
        {
            xuLyButton();
            ShowDanhSach("select * from PHG", dgrPhg);
            ShowLoaiphg("select * from LoaiPHG");
            showanh("select Hinh from LoaiPHG,PHG where LoaiPHG.MaLoai=PHG.MaLoai",ds,0);
            xuLiChucNang(true);

        }
        void xuLiTextBox(Boolean t)
        {
            txtMaPhg.ReadOnly = t;
        }
        void xuLiChucNang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
        }
        string ddanh = "ImagesQLKS\\Rooms\\";
        void HienThi_TextBox(DataSet ds, int vt)
        {
            try
            {
                txtMaPhg.Text = ds.Tables[0].Rows[vt]["MaPHG"].ToString();
                string s = "";
                s = ds.Tables[0].Rows[vt]["MaLoai"].ToString();
                if (s == "L1")
                    cboLoaiPhg.SelectedIndex = 0;
                else if (s == "L2")
                    cboLoaiPhg.SelectedIndex = 1;
                else if (s == "L3")
                    cboLoaiPhg.SelectedIndex = 2;
                else if (s == "L4")
                    cboLoaiPhg.SelectedIndex = 3;
                else
                    cboLoaiPhg.SelectedIndex = 4;

                string s2 = "";
                s2 = ds.Tables[0].Rows[vt]["TrangThai"].ToString();
                if (s2 == "0")
                {
                    cboTrangThai.SelectedIndex = 0;
                }

                else cboTrangThai.SelectedIndex = 1;
                
            }
            catch(Exception x)
            {
                MessageBox.Show("Load thất bại!");
            }
           
        }

        private void dgrPHG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = dgrPhg.CurrentCell.RowIndex;
            HienThi_TextBox(ds, vt);
            showanh("select Hinh from LoaiPHG,PHG where LoaiPHG.MaLoai=PHG.MaLoai", ds, vt);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {

            txtMaPhg.Enabled = true;
            xuLiTextBox(false);
            xuLiChucNang(false);
            t = 1;
            clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLiTextBox(false);
            xuLiChucNang(false);
            t = 2;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            xuLiTextBox(false);
            xuLiChucNang(false);
            t = 3;
        }
        void hienThiDanhSachAnh(string ten)
        {
            PictureBox p = new PictureBox();
            Size s = new Size(120,120);
            p.Size = s;
            Bitmap a = new Bitmap(ten);
            p.Image = a;
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            flpAnh.Controls.Add(p);
        }
        void loadNhieuAnh(string tenhinh)
        {
            string[] tenhinhs = tenhinh.Split(';');
            flpAnh.Controls.Clear();
            if (tenhinhs.Length == 1)
            {
                hienThiDanhSachAnh(ddanh );
            }
            for (int i = 0; i < tenhinhs.Length - 1; i++)
            {
                hienThiDanhSachAnh(ddanh + tenhinhs[i]);
            }
        }
        //private void btnHinh_Click(object sender, EventArgs e)
        //{
        //    //txtHinh.Clear();
        //    OpenFileDialog o = new OpenFileDialog();

        //    o.Filter = "bitmap (*.jpg)|*.jpg|(*.jpeg)|8.jepg|(*.png)|*.png|All Files (*.*)|*.*";
        //    o.Multiselect = true;
        //    if (o.ShowDialog() == DialogResult.Cancel)
        //    {
        //        MessageBox.Show("ban chon anh san pham");

        //        o.ShowDialog();
        //    }
        //    else
        //    {
        //        foreach (String ten in o.FileNames)
        //        {
        //            string[] chuoi;
        //            chuoi = ten.Split('\\');
        //            txtHinh.Text += chuoi[chuoi.Length - 1] + ";";
        //            hienThiDanhSachAnh(ten);

        //        }
        //    }
        //}

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaPhg.Text == null || cboLoaiPhg.SelectedIndex == -1 || cboTrangThai.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn nhập thiếu dữ liệu!!", "Lưu ý !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                xuLiTextBox(true);
                xuLiChucNang(true);
                string sql = "";
                int tt;
                if (cboTrangThai.Text == "Trống")
                {
                    tt = 0;
                }
                else tt = 1;

                if (t != 0)
                {
                    if (t == 1)
                    {
                        sql = "insert into PHG(MaPHG,MaLoai,TrangThai)values('" + txtMaPhg.Text + "', '" + cboLoaiPhg.SelectedValue + "', " + tt + ");";
                    }
                    if (t == 2)
                    {
                        sql = "update PHG set MaLoai = '" + cboLoaiPhg.SelectedValue + "',TrangThai = " + tt + " where MaPHG = '" + txtMaPhg.Text + "';";
                    }
                    if (t == 3)
                    {
                        sql = "delete from PHG where MaPHG = '" + txtMaPhg.Text + "'";
                    }
                    if (c.CapNhat(sql) != 0)
                    {
                        MessageBox.Show("Thanh cong! ");
                    }
                    ShowDanhSach("select * from PHG", dgrPhg);
                    t = 0;
                }
                else MessageBox.Show("Vui lòng chọn chức năng!!");

            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuLiTextBox(true);
            xuLiChucNang(true);
            t = 0;
            clear();
        }

        private void frmPHG_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn có muốn đóng ứng dụng không?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.No == result)
                e.Cancel = true;
        }
        void clear()
        {
            txtMaPhg.Clear();
            cboLoaiPhg.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
        }

        private void txtMaPhg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }   
    }
}
