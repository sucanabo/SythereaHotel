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
    public partial class frmTruyVanHD : Form
    {
        clsQLKS c = new clsQLKS();
        DataSet dsTTKH = new DataSet();
        void TTKH(string sql)
        {
            dsTTKH = c.DanhSach(sql);
            dgvChiTiet.DataSource = dsTTKH.Tables[0];
            HienThi_ThongTinKH();
        }
        void HienThi_ThongTinKH()
        {
           
                lblTenKH.Text = dsTTKH.Tables[0].Rows[0]["HoTen"].ToString();
                txtCMND.Text = dsTTKH.Tables[0].Rows[0]["CMND"].ToString();
                txtSDT.Text = dsTTKH.Tables[0].Rows[0]["SDT"].ToString();
                txtSDT.ReadOnly = true;
                txtCMND.ReadOnly = true;
            
            
        }
        public frmTruyVanHD()
        {
            InitializeComponent();
        }

        private void frmTruyVanHD_Load(object sender, EventArgs e)
        {
            try
            {
                lblMaHD.Text = frmQuanLiHD.MaHD;
                string sql = "select phg.MaPHG,lp.TenLoai,lp.GiaTien,kh.HoTen,kh.CMND,kh.SDT";
                sql += " from HoaDonDP hddp, HDPHG hdp,PHG phg, LoaiPHG lp ,ChiTietDP ctp, KhachHang kh";
                sql += " where kh.CMND = ctp.MaKH and ctp.MaHDDP = hddp.MaHD and hddp.MaHD = hdp.MaHD and hdp.MaPHG = phg.MaPHG and phg.MaLoai = lp.MaLoai and hddp.MaHD = '" + lblMaHD.Text + "'";
                TTKH(sql);
            }
            catch(Exception x)
            {
                MessageBox.Show("Lỗi!");
                this.Close();
            }
        }
    }
}
