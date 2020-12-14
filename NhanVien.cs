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
   
    public partial class frmNhanVien : Form
    {
        clsQLKS c = new clsQLKS();
        DataSet ds = new DataSet();
        public frmNhanVien()
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
            txtMaNV.ReadOnly = t;

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
            //setButton(btnHinh, "upload.png");
        }
        void xuLiChucNang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        int flag = 0;
        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLiTextBox(true);
            xuLiChucNang(false);
            txtTenNV.Focus();
            flag = 1;
            phatSinhMa();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLiTextBox(true);
            xuLiChucNang(false);
            txtTenNV.Focus();
            flag = 2;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            xuLiTextBox(true);
            xuLiChucNang(false);
            txtTenNV.Focus();
            flag = 3;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtDiaChi.Text == null || txtMaNV.Text == null || txtNgaySinh.Text == null || txtSDT.Text == null || txtTenNV.Text == null || cboLoaiNV.SelectedIndex == -1 || cboPhai.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn nhập thiếu dữ liệu!!", "Lưu ý !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                xuLiTextBox(true);
                xuLiChucNang(true);
                txtTenNV.Focus();
                string sql = "";
                if (flag == 1)
                {
                    sql = "insert into NhanVien(Manv,HoTen,NgSinh,DChi,Phai,SDT,ChucVu) values('" + txtMaNV.Text + "',N'" + txtTenNV.Text + "','" + txtNgaySinh.Text + "',N'" + txtDiaChi.Text + "',N'" + cboPhai.Text + "','" + txtSDT.Text + "',N'" + cboLoaiNV.Text + "')";

                }
                if (flag == 2)
                {
                    sql = "update NhanVien set HoTen = N'" + txtTenNV.Text + "',NgSinh='" + txtNgaySinh.Text + "',DChi=N'" + txtDiaChi.Text + "',Phai=N'" + cboPhai.Text + "',ChucVu=N'" + cboLoaiNV.Text + "',SDT='" + txtSDT.Text + "' where Manv='" + txtMaNV.Text + "'";

                }
                if (flag == 3)
                {
                    sql = "delete from NhanVien where manv ='" + txtMaNV.Text + "'";

                }
                if (c.CapNhat(sql) != 0)
                {
                    MessageBox.Show("Thanh cong! ");
                }
                ShowDanhSach("select * from nhanvien", dgvNV);
                HienThi_TextBox(ds, 0);

                flag = 0;
            }
        }
        void HienThi_TextBox(DataSet ds, int vt)
        {
            try
            {
                txtMaNV.Text = ds.Tables[0].Rows[vt]["MaNV"].ToString();
                txtTenNV.Text = ds.Tables[0].Rows[vt]["HoTen"].ToString();
                txtNgaySinh.Text = ds.Tables[0].Rows[vt]["NgSinh"].ToString();
                txtDiaChi.Text = ds.Tables[0].Rows[vt]["DChi"].ToString();
                txtSDT.Text = ds.Tables[0].Rows[vt]["SDT"].ToString();
                string sl = "";
                cboLoaiNV.Text = ds.Tables[0].Rows[vt]["ChucVu"].ToString();
                if (sl == "Phục Vụ")
                    cboLoaiNV.SelectedItem = 0;
                else if (sl == "Thu Ngân")
                    cboLoaiNV.SelectedItem = 1;
                else if (sl == "Giám đốc")
                    cboLoaiNV.SelectedItem = 2;
                else if (sl == "Bảo vệ")
                    cboLoaiNV.SelectedItem = 3;
                else if (sl == "Tiếp tân")
                    cboLoaiNV.SelectedItem = 4;
                else if (sl == "Bảo trì")
                    cboLoaiNV.SelectedItem = 5;
                string sp = "";
                cboPhai.Text = ds.Tables[0].Rows[vt]["Phai"].ToString();
                if (sp == "Nam")
                    cboLoaiNV.SelectedItem = 1;
                else if (sp == "Nữ")
                    cboLoaiNV.SelectedItem = 2;
            }
            catch (Exception x)
            {
                MessageBox.Show("Dữ liệu lỗi !!");
            }
            
        }
        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = dgvNV.CurrentCell.RowIndex;
            HienThi_TextBox(ds, vt);
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            xuLyButton();
            xuLiTextBox(true);
            xuLiChucNang(true);
            ShowDanhSach("select * from nhanvien", dgvNV);
        }
        void phatSinhMa()
        {
            int sl = ds.Tables[0].Rows.Count;
            txtMaNV.Text = "NV" + (sl+1).ToString();
        }
        string Phatsinh_ma(DataSet ds)  
        {
            int sodong = ds.Tables[0].Rows.Count;

            string macuoi = ds.Tables[0].Rows[sodong - 1]["ma loai"].ToString().Substring(1, 2);
      
            return (int.Parse(macuoi) + 1).ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuLiTextBox(true);
            xuLiChucNang(true);
            clear();
        }
        void clear()
        {
            txtMaNV.Clear();
            txtNgaySinh.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtTenNV.Clear();
            cboLoaiNV.SelectedIndex = -1;
            cboPhai.SelectedIndex = -1;
        }

        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn có muốn đóng ứng dụng không?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.No == result)
                e.Cancel = true;
        }
    } 
}
