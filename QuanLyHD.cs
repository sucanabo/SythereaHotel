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
    public partial class frmQuanLiHD : Form
    {
        public static string MaHD;
        clsQLKS c = new clsQLKS();//KetnoiDL
        DataSet ds = new DataSet();
        void showCTDP(string sql ,int vt)
        {
            ds = c.DanhSach(sql);
            string b = ds.Tables[0].Rows[vt]["MaHD"].ToString();

        }
        void ShowDanhSach(string sql, DataGridView d)
        {
            try
            {
                ds = c.DanhSach(sql);
                d.DataSource = ds.Tables[0];
            }
            catch(Exception x)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ !!", "Lỗi !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public frmQuanLiHD()
        {
            InitializeComponent();
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
            btn.Font = new Font("Microsoft Sans Serif",16);
        }
        void xuLyButton()
        {
            setButton(btnTim, "search.png");
            setButton(btnXem, "eye.png");
        }
        private void QuanLiHD_Load(object sender, EventArgs e)
        {
            xuLyButton();
            ShowDanhSach("select * from HoaDonDP where trangthai = 0", dgrQuanLyHD);
        }
        private void txtTT_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from HoaDonDP where  MaHD like N'%" + txtTim.Text + "%'";
            sql += " or MaNV like N'%" + txtTim.Text + "%'";
            ShowDanhSach(sql, dgrQuanLyHD);
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            string sql = "select * from HoaDonDP where MaHD=N'" + txtTim.Text + "'";
            ShowDanhSach(sql, dgrQuanLyHD);
        }

        private void btnTim_Click_1(object sender, EventArgs e)
        {
            string sql ="select * from hoadondp where ngaylaphd  between '"+dtpNgayDau.Value+"' and '"+dtpNgayCuoi.Value+"'";
            ShowDanhSach(sql, dgrQuanLyHD);
        }

        private void dgrQuanLyHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int vt = dgrQuanLyHD.CurrentCell.RowIndex;
                MaHD = ds.Tables[0].Rows[vt]["MaHD"].ToString();
            }
            catch(Exception x)
            {
                MessageBox.Show("Lỗi");
            }
            
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            frmTruyVanHD frm = new frmTruyVanHD();
            frm.Show();
        }

    }
}
