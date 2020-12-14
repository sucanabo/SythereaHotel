using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class frmTimKiem : Form
    {
        clsQLKS c = new clsQLKS();//KetnoiDL
        DataSet ds = new DataSet();
        private string loai;

        //Hien thi du lieu
        void ShowDanhSach(string sql, DataGridView d)
        {
            ds = c.DanhSach(sql);
            d.DataSource = ds.Tables[0];
        }
        public frmTimKiem()
        {
            InitializeComponent();
        }
        public frmTimKiem(string loai)
        {
            this.loai = loai;
            InitializeComponent();
        }
        public void nhanData()
        {
            
            if (loai == "KH")
            {
                ShowDanhSach("select * from khachhang",dgvData);
                lblNhan.Text = "TRA CỨU KHÁCH HÀNG";
            }
            else if(loai == "NV")
            {
                ShowDanhSach("select * from nhanvien", dgvData);
                lblNhan.Text = "TRA CỨU NHÂN VIÊN";
            }
            else if (loai == "DV")
            {
                ShowDanhSach("select * from dichvu", dgvData);
                lblNhan.Text = "TRA CỨU DỊCH VỤ";
            }
            else if (loai == "PHG")
            {
                ShowDanhSach("select DISTINCT phg.maphg as N'Mã phòng',phg.maloai as N'Mã Loại',phg.trangthai as N'Trạng thái',loaiphg.tenloai as N'Loại',loaiphg.giatien as N'Giá tiền' from phg,loaiphg where phg.maloai = loaiphg.maloai", dgvData);
                lblNhan.Text = "TRA CỨU PHÒNG";
            }
        }
        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if(loai == "KH")
            {
                string sql = "select * from KhachHang where CMND like N'%" + txtValue.Text + "%' or Hoten like N'%" + txtValue.Text + "%' or SDT like N'%" + txtValue.Text + "%' or Email like N'%" + txtValue.Text + "%'";
                ShowDanhSach(sql, dgvData);
            }
            else if(loai == "NV")
            {
                string sql = "select * from NhanVien where MaNV like N'%" + txtValue.Text + "%' or HoTen like N'%" + txtValue.Text + "%' or ngsinh like N'%" + txtValue.Text + "%' or dchi like N'%" + txtValue.Text + "%' or sdt like N'%" + txtValue.Text + "%' or chucvu like N'%" + txtValue.Text + "%'";
                ShowDanhSach(sql, dgvData);
            }
            else if (loai == "DV")
            {
                string sql = "select * from dichvu where MaDV like N'%" + txtValue.Text + "%' or TenDV like N'%" + txtValue.Text + "%' or dongia like N'%" + txtValue.Text + "%' or loaidv like N'%" + txtValue.Text + "%' or trangthai like N'%" + txtValue.Text + "%'";
                ShowDanhSach(sql, dgvData);
            }
            else if (loai == "PHG")
            {
                string sql = "select * from phg where MaPHG like N'%" + txtValue.Text + "%' or MaLoai like N'%" + txtValue.Text + "%' or trangthai like N'%" + txtValue.Text + "%'";
                ShowDanhSach(sql, dgvData);
            }

        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (loai == "KH")
                {
                    string sql = "select * from KhachHang where CMND = N'" + txtValue.Text + "' or Hoten = N'" + txtValue.Text + "' or SDT = N'" + txtValue.Text + "' or Email = N'" + txtValue.Text + "'";
                    ShowDanhSach(sql, dgvData);
                }
                else if (loai == "NV")
                {
                    string sql = "select * from NhanVien where MaNV = N'" + txtValue.Text + "' or HoTen = N'" + txtValue.Text + "' or ngsinh = N'" + txtValue.Text + "' or dchi = N'" + txtValue.Text + "' or sdt = N'" + txtValue.Text + "' or chucvu = N'" + txtValue.Text + "'";
                    ShowDanhSach(sql, dgvData);
                }
                else if (loai == "DV")
                {
                    string sql = "select * from dichvu where MaDV = N'" + txtValue.Text + "' or TenDV = N'" + txtValue.Text + "' or dongia = N'" + txtValue.Text + "' or loaidv = N'" + txtValue.Text + "' or trangthai = N'" + txtValue.Text + "'";
                    ShowDanhSach(sql, dgvData);
                }
                else if (loai == "PHG")
                {
                    string sql = "select * from phg where MaPHG = N'" + txtValue.Text + "' or MaLoai = N'" + txtValue.Text + "' or trangthai  N'" + txtValue.Text + "'";
                    ShowDanhSach(sql, dgvData);
                }
            }
            catch(Exception x)
            {
                MessageBox.Show("Dữ liệu nhập sai !!", "Lỗi !!",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        void setButton(Button btn, String img)
        {
            Size size = new Size(40, 40);
            Bitmap path = new Bitmap("ImagesQLKS\\icon\\" + img);
            btn.Image = path;
            btn.Image = (Image)(new Bitmap(path, size));
            btn.ImageAlign = ContentAlignment.TopLeft;
            btn.TextAlign = ContentAlignment.BottomRight;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Microsoft Sans Serif", 15);
        }
        void xuLyButton()
        {
            setButton(btnTim, "search.png");
            setButton(btnRefresh, "refresh.png");
        }
        private void frmTimKiem_Load(object sender, EventArgs e)
        {
            xuLyButton();
            nhanData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            nhanData();
            txtValue.Clear();
        }
    }
}
