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
    public partial class frmDichVu : Form
    {
        clsQLKS c = new clsQLKS();//KetnoiDL
        DataSet ds = new DataSet();
        DataSet dsLoaiDV = new DataSet();
        //Hien thi du lieu
        int t = 0;
        void ShowDanhSach(string sql,DataGridView d)
        {
            ds = c.DanhSach(sql);
            d.DataSource = ds.Tables[0];
        }
        public frmDichVu()
        {
            InitializeComponent();
        }
        void ShowDV(String sql)
        {
            cboLoaiDV.SelectedIndex = -1;
        }
        void ShowLoaiDV(string sql)
        {
            dsLoaiDV = c.DanhSach(sql);
            cboLoaiDV.DataSource = dsLoaiDV.Tables[0];
            cboLoaiDV.DisplayMember = "TenLoai";
            cboLoaiDV.ValueMember = "MaLoai";
            cboLoaiDV.SelectedIndex = -1;

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
            txtMaDV.Enabled = false;
            ShowDV("select * from phg");
            ShowLoaiDV("select * from loaidv");
            xuLiTextBox(false);
            xuLiChucNang(true);
            ShowDanhSach("select * from dichvu", dgrDV);
           
            
        }
        void xuLiTextBox(Boolean t)
        {
            txtMaDV.ReadOnly = t;
            txtDVT.ReadOnly = t;
        }
        void xuLiChucNang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
        }
        //Mang tang tu don
        string PhatSinhMa(DataSet ds)
        {
            int countRows = ds.Tables[0].Rows.Count;
            string s1 = "";
            int s2 = 0;
            s1 = Convert.ToString(dgrDV.Rows[countRows - 1].Cells[0].Value);
            s2 = Convert.ToInt32((s1.Remove(0, 3)));
            if (s2 + 1 < 10)
            {
                return "SV00" + (s2 + 1).ToString();
            }
            else if (s2 + 1 < 100)
            {
                return "SV0" + (s2 + 1).ToString();
            }
            else return "SV" + (s2 + 1).ToString(); ;
        }
        //Button chuc nang
        private void btnThem_Click(object sender, EventArgs e)
        {
           
            txtMaDV.Enabled = true;
            xuLiTextBox(false);
            xuLiChucNang(false);
            txtMaDV.Focus();
            txtMaDV.Text = PhatSinhMa(ds);
            t = 1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaDV.Focus();
            xuLiTextBox(false);
            xuLiChucNang(false);
            t = 2;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            xuLiTextBox(false);
            xuLiChucNang(false);
            txtDVT.Focus();
            t = 3;
        }
        Boolean ThieuDuLieu()
        {
            if (txtDG.Text == null || txtDVT.Text == null || txtMaDV.Text == null || txtTenDV.Text == null || cboLoaiDV.SelectedIndex == -1 || cboTrangThai.SelectedIndex == -1)
            {
                return false;
            }
            return true;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ThieuDuLieu())
            {
                xuLiTextBox(true);
                xuLiChucNang(true);
                string sql = "";
                int tt;
                if (cboTrangThai.Text == "Hoạt động")
                    tt = 1;
                else tt = 0;
                string ldv = cboLoaiDV.Text;
                if (t != 0)
                {
                    if (t == 1)
                    {
                        sql = "insert into DichVu(MaDV, LoaiDV, TenDV, DonGia, DVT, Anh, TrangThai)values('" + txtMaDV.Text + "', '" + cboLoaiDV.SelectedValue + "', N'" + txtTenDV.Text + "'," + int.Parse(txtDG.Text) + ", N'" + txtDVT.Text + "', '" + txtHinh.Text + "', " + tt + ");";
                    }
                    if (t == 2)
                    {
                        if (txtHinh.Text == "")
                            txtHinh.Text = "null";
                        sql = "update DichVu set LoaiDV = '" + cboLoaiDV.SelectedValue + "',TenDV = N'" + txtTenDV.Text + "',DonGia = " + int.Parse(txtDG.Text) + ",DVT = N'" + txtDVT.Text + "',Anh ='" + txtHinh.Text + "',TrangThai = " + tt + " where MaDV = '" + txtMaDV.Text + "';";
                    }
                    if (t == 3)
                    {
                        sql = "delete from DichVu where MaDV = '" + txtMaDV.Text + "'";
                    }
                    if (c.CapNhat(sql) != 0)
                    {
                        MessageBox.Show("Thanh cong! ");
                    }
                    ShowDanhSach("select * from dichvu", dgrDV);
                    HienThi_TextBox(ds, 0);
                    t = 0;
                }
                else MessageBox.Show("Vui lòng chọn chức năng!!");
            }
            else
            {
                MessageBox.Show("Bạn nhập thiếu dữ liệu!!", "Lưu ý !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnHuy_Click(this, null);
            }
            
                
            
        }
        //Hienthi
        string ddanh = "ImagesQLKS\\SERVICES\\";
        void HienThi_TextBox(DataSet ds, int vt)
        {
            txtMaDV.Text = ds.Tables[0].Rows[vt]["MaDV"].ToString();
            txtTenDV.Text = ds.Tables[0].Rows[vt]["TenDV"].ToString();
            txtDG.Text = ds.Tables[0].Rows[vt]["DonGia"].ToString();
            txtDVT.Text = ds.Tables[0].Rows[vt]["DVT"].ToString();
            //txtHinh.Text = "D:\\XT\\Ảnh\\";
            txtHinh.Text = ds.Tables[0].Rows[vt]["Anh"].ToString();
            
            //loadNhieuAnh(ds.Tables[0].Rows[vt]["Anh"].ToString());
            hienThiDanhSachAnh(ddanh + txtHinh.Text);


            string s = "";
            s = ds.Tables[0].Rows[vt]["LoaiDV"].ToString();
            if (s == "L001")
                cboLoaiDV.SelectedIndex = 0;
            else if (s == "L002")
                cboLoaiDV.SelectedIndex = 1;
            else if (s == "L003")
                cboLoaiDV.SelectedIndex = 2;
            string s2 = "";
            s2 = ds.Tables[0].Rows[vt]["TrangThai"].ToString();
            if (s2 == "1")
            {
                cboTrangThai.SelectedIndex = 0;
            }
                
            else cboTrangThai.SelectedIndex = 1;

        }
        private void dgrDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
                txtMaDV.Enabled = false;
                int vt = dgrDV.CurrentCell.RowIndex;
                HienThi_TextBox(ds, vt);
            
            
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDichVu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn có muốn đóng ứng dụng không?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.No == result)
                e.Cancel=true;
        }
        void hienThiDanhSachAnh(string ten)
        {
            //PictureBox p = new PictureBox();
            //Size s = new Size(220, 225);
            //p.Size = s;
            //flowLayoutPanel1.Controls.Add(p);
            Bitmap a = new Bitmap(ten);
            picDV.Image = a;
            picDV.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            txtHinh.Clear();
            o.Filter = "bitmap (*.jpg)|*.jpg|(*.jpeg)|8.jepg|(*.png)|*.png|All Files (*.*)|*.*" ;
            //o.Multiselect = true;
            if (o.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("ban chon anh san pham");
                
                o.ShowDialog();
            }
            else
            {
                string[] chuoi;
                chuoi = o.FileName.Split('\\');
                for(int i =0; i < chuoi.Length -1;i++)
                {
                   
                    txtHinh.Text = chuoi[chuoi.Length - 1];
                    hienThiDanhSachAnh(ddanh + txtHinh.Text);

                }
            }
        }

        private void cboLoaiDV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void clear()
        {
            txtDG.Clear();
            txtDVT.Clear();
            txtHinh.Clear();
            txtMaDV.Clear();
            txtTenDV.Clear();
            cboLoaiDV.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuLiTextBox(true);
            xuLiChucNang(true);
            picDV.Image = null;
            t = 0;
            clear();
        }

        private void txtDG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
