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
        clsQLKS c = new clsQLKS();//KetnoiDL
        DataSet ds = new DataSet();
        void ShowDanhSach(string sql, DataGridView d)
        {
            ds = c.DanhSach(sql);
            d.DataSource = ds.Tables[0];
        }
        public frmQuanLiHD()
        {
            InitializeComponent();
        }

        private void QuanLiHD_Load(object sender, EventArgs e)
        {
            ShowDanhSach("select * from HoaDonDP", dgrQuanLyHD);
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
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql ="";
               sql = "delete from HoaDonDP where MaHD = '" + txtTim.Text + "'";
               if (c.CapNhat(sql) != 0)
               {
                   MessageBox.Show("Thanh cong! ");
               }
               //ShowDanhSach("select * from HoaDonHD", dgrQuanLyHD);
                
        }

    }
}
