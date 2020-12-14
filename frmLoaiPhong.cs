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
    public partial class frmLoaiPhong : Form
    {
        clsQLKS c = new clsQLKS();//KetnoiDL
        DataSet ds = new DataSet();
        int t = 0;
        public frmLoaiPhong()
        {
            InitializeComponent();
        }
        void ShowDanhSach(string sql, DataGridView d)
        {
            ds = c.DanhSach(sql);
            d.DataSource = ds.Tables[0];
        }
        void xuLiTextBox(Boolean t)
        {

            txtMaLoai.ReadOnly = t;
            txtTenLoai.ReadOnly = t;
        }
        void xuLiChucNang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;

            btnLuu.Enabled = !t;
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
            setButton(btnHinh, "upload.png");
        }
        private void frmDichVu_Load(object sender, EventArgs e)
        {
            xuLyButton();
            txtMaLoai.Enabled = false;
            xuLiTextBox(false);
            xuLiChucNang(true);
            ShowDanhSach("select * from loaiphg", dgvLoaiPHG);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLoaiPhong_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn có muốn đóng ứng dụng không?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.No == result)
                e.Cancel = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {

            txtMaLoai.Enabled = true;
            xuLiTextBox(false);
            xuLiChucNang(false);
            txtMaLoai.Focus();
            txtMaLoai.Text = PhatSinhMa(ds);
            t = 1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaLoai.Focus();
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

        private void btnLuu_Click(object sender, EventArgs e)
        {

            xuLiTextBox(true);
            xuLiChucNang(true);
            string sql = "";
            if (txtMaLoai.Text == "" || txtTenLoai.Text == "" || txtHinh.Text =="" || txtGiaTien.Text =="")
            {
                MessageBox.Show("Nhập thiếu dữ liệu!");
            }
            else
            {
                if (t != 0)
                {
                    if (t == 1)
                    {
                        sql = "insert into LoaiPHG(MaLoai,TenLoai,GiaTien,Hinh)values('" + txtMaLoai.Text + "',N'" + txtTenLoai.Text + "'," + int.Parse(txtGiaTien.Text) + ",N'" + txtHinh.Text + "');";
                    }
                    if (t == 2)
                    {

                        sql = "update LoaiPHG set TenLoai = N'" + txtTenLoai.Text + "', GiaTien = " + int.Parse(txtGiaTien.Text) + ",Hinh ='" + txtHinh.Text + "' where MaLoai = '" + txtMaLoai.Text + "'";
                    }
                    if (t == 3)
                    {
                        sql = "delete from LoaiPHG where MaLoai = '" + txtMaLoai.Text + "'";
                    }
                    if (c.CapNhat(sql) != 0)
                    {
                        MessageBox.Show("Thanh cong! ");
                    }
                    ShowDanhSach("select * from loaiphg", dgvLoaiPHG);
                    HienThi_TextBox(ds, 0);
                    t = 0;
                }
                else MessageBox.Show("Vui lòng chọn chức năng!!");
            }    
            
        }
        string ddanh = "ImagesQLKS\\Rooms\\";
        void HienThi_TextBox(DataSet ds, int vt)
        {
            try
            {
                txtMaLoai.Text = ds.Tables[0].Rows[vt]["MaLoai"].ToString();
                txtTenLoai.Text = ds.Tables[0].Rows[vt]["TenLoai"].ToString();
                txtGiaTien.Text = ds.Tables[0].Rows[vt]["GiaTien"].ToString();
                txtHinh.Text = ds.Tables[0].Rows[vt]["Hinh"].ToString();
                loadNhieuAnh(txtHinh.Text);
            }
            catch (Exception x)
            {
                MessageBox.Show("Load thất bại!");
            }
        }
        void hienThiDanhSachAnh(string ten)
        {
            PictureBox p = new PictureBox();
            Size s = new Size(145,100);
            p.Size = s;
            Bitmap a = new Bitmap(ten);
            p.Image = a;
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            flpHinh.Controls.Add(p);
        }
        void loadNhieuAnh(string tenhinh)
        {
            string[] tenhinhs = tenhinh.Split(';');
            flpHinh.Controls.Clear();
            if (tenhinhs.Length == 1)
            {
                hienThiDanhSachAnh(ddanh + txtHinh.Text);
            }
            for (int i = 0; i < tenhinhs.Length - 1; i++)
            {
                hienThiDanhSachAnh(ddanh + tenhinhs[i]);
            }
        }
        private void btnHinh_Click(object sender, EventArgs e)
        {
            txtHinh.Clear();
            OpenFileDialog o = new OpenFileDialog();

            o.Filter = "bitmap (*.jpg)|*.jpg|(*.jpeg)|8.jepg|(*.png)|*.png|All Files (*.*)|*.*";
            o.Multiselect = true;
            if (o.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("ban chon anh san pham");

                o.ShowDialog();
            }
            else
            {
                foreach (String ten in o.FileNames)
                {
                    string[] chuoi;
                    chuoi = ten.Split('\\');
                    txtHinh.Text += chuoi[chuoi.Length - 1] + ";";
                    hienThiDanhSachAnh(ten);

                }
            }
        }

        string PhatSinhMa(DataSet ds)
        {
            int countRows = ds.Tables[0].Rows.Count;
            string s1 = "";
            int s2 = 0;
            s1 = Convert.ToString(dgvLoaiPHG.Rows[countRows - 1].Cells[0].Value);
            s2 = Convert.ToInt32((s1.Remove(0, 1)));
            return "L" + (s2 + 1).ToString(); ;
        }
        void clear()
        {
            txtMaLoai.Clear();
            txtTenLoai.Clear();
            txtGiaTien.Clear();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuLiTextBox(true);
            xuLiChucNang(true);
            t = 0;
            clear();
        }

        private void dgvLoaiPHG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLoai.Enabled = false;
            int vt = dgvLoaiPHG.CurrentCell.RowIndex;
            HienThi_TextBox(ds, vt);
        }

        private void txtGiaTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
