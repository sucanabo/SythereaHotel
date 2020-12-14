using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class frmQLHDDP : Form
    {
        clsQLKS c = new clsQLKS();
        DataSet ds = new DataSet();
        DataSet dsPHG = new DataSet();
        DataSet dsDV = new DataSet();
        DataSet dsKH = new DataSet();
        DataSet dsCTHDDP = new DataSet();
        DataSet dsHDDP = new DataSet();
        DataSet dsHDTT = new DataSet();
        private static string maphg;
        private int tongThanhTien = 0;
        public frmQLHDDP()
        {
            InitializeComponent();
        }
        public void showNGay()
        {
            DataSet ngay = new DataSet();
            ngay = c.DanhSach("select * from HoaDonDP where MaHD = '"+lblMaHDDP.Text+"'");
            lblNgayNhan.Text = ngay.Tables[0].Rows[0]["NgayDen"].ToString();
            lblNgayTra.Text = ngay.Tables[0].Rows[0]["NgayDi"].ToString();

        }
        void DanhSach_PHG(string s)
        {
            string t = "select hddp.MaHD, phg.MaPHG,lp.TenLoai,lp.GiaTien, DATEDIFF(DAY,NgayDen, NgayDi) as soNgay, DATEDIFF(DAY,NgayDen, NgayDi) * lp.GiaTien as ThanhTien";
            t += " from HDPHG hdp, HoaDonDP hddp, PHG phg, LoaiPHG lp";
            t += " where hddp.MaHD = hdp.MaHD and hdp.MaPHG = phg.MaPHG and phg.MaLoai = lp.MaLoai and hddp.MaHD = '" + lblMaHDDP.Text + "'";
            dsPHG = c.DanhSach(t);
            dgvPHG.DataSource = dsPHG.Tables[0];

        }
        void DanhSach_DV(string s)
        {
            string t = "select dhp.MaHD, phg.MaPHG, dv.TenDV,ctdv.SoLuong,dv.DVT,dv.DonGia,ctdv.thanhtien ";
            t += " from HDPHG dhp, PHG phg, ChiTietDV ctdv, DichVu dv";
            t += " where dhp.MaPHG = phg.MaPHG and phg.MaPHG = ctdv.MaPHG and ctdv.MaDV = dv.MaDV and MaHD = '" + lblMaHDDP.Text + "'";
            dsDV = c.DanhSach(t);
            dgvDV.DataSource = dsDV.Tables[0];
        }
        private void frmQLHDDP_Load(object sender, EventArgs e)
        {
            dsHDTT = c.DanhSach("select * from hoadontt order by mahd");
        }
        void clear()
        {
            this.Close();
            frmQLHDDP frm = new frmQLHDDP();
            frm.Show();
        }
        void HienThi_TT_KH(string tt,string temp)
        {
            string sql ="";
            if(temp == "SDT")
            {
                sql = "SDT";
            }
            else
            {
                sql = "CMND";
            }
            try
            {
                if (tt.Length >10 && sql == "SDT")
                {
                    MessageBox.Show("Số điện thoại quá dài!");
                    clear();
                }
                else if(tt.Length < 10 && sql == "SDT")
                {
                    MessageBox.Show("SĐT quá ngắn!!");
                    clear();
                }
                else if((tt.Length >12 &&  sql == "CMND") || (tt.Length<9 && sql == "CMND") )
                {
                    MessageBox.Show("CMND không hợp lệ!");
                    clear();
                }
                else
                {
                    dsKH = c.DanhSach("select * from khachhang where " + sql + " ='" + tt + "'");
                    if (dsKH.Tables[0].Rows.Count != 0)
                    {
                        txtSDT.Text = dsKH.Tables[0].Rows[0]["SDT"].ToString();
                        txtHoTen.Text = dsKH.Tables[0].Rows[0]["HoTen"].ToString();
                        txtCMND.Text = dsKH.Tables[0].Rows[0]["CMND"].ToString();
                        txtEmail.Text = dsKH.Tables[0].Rows[0]["Email"].ToString();
                        //lblHD
                        string cmnd = dsKH.Tables[0].Rows[0]["CMND"].ToString();
                        dsCTHDDP = c.DanhSach("select mahddp from chitietDP cthd,khachhang kh where kh.cmnd = cthd.makh and cthd.makh ='" + cmnd + "'");
                        lblMaHDDP.Text = dsCTHDDP.Tables[0].Rows[0]["mahddp"].ToString();
                        dsHDDP = c.DanhSach("select * from hoadondp where mahd = '" + lblMaHDDP.Text + "'");
                        showNGay();
                    }
                    else
                    {
                        MessageBox.Show("Khách hàng không tồn tại !!", "Lỗi !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        clear();
                    }
                }
            }
            catch(Exception x)
            {
                MessageBox.Show("Khách hàng này hiện không có hợp đồng !!!");
                clear();
            }
            
        }
        double tinhTong(DataSet dt,string t,string ma)
        {
            double tong = 0;
            for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
            {
                string chkMa = "";
                chkMa = "MaHD";
                if(dt.Tables[0].Rows[i][chkMa].ToString() == ma)
                {
                    tong += double.Parse(dt.Tables[0].Rows[i][t].ToString());
                }
               
            }
                return tong;
        }
        void HienThi_Dgv()
        {
            DanhSach_DV(lblMaHDDP.Text);
            DanhSach_PHG(lblMaHDDP.Text);
        }
        void Xuly_ThanhTien()
        { 
            //Tinh tong
            lblTTPHG.Text =  tinhTong(dsPHG,"ThanhTien",lblMaHDDP.Text).ToString();
            lblTTDV.Text= tinhTong(dsDV,"ThanhTien", lblMaHDDP.Text).ToString();
            lblTTT.Text = double.Parse(lblTTPHG.Text) + double.Parse(lblTTDV.Text) + "";
            tongThanhTien = int.Parse(lblTTT.Text); 
            //Dinh dang
            lblTTPHG.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0 VND}", int.Parse( lblTTPHG.Text));
            lblTTDV.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0 VND}", int.Parse(lblTTDV.Text));
            lblTTT.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0 VND}", int.Parse(lblTTT.Text));
        }
        private void txtSDT_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                HienThi_TT_KH(txtSDT.Text,"SDT");
                HienThi_Dgv();
                Xuly_ThanhTien();
            }    
        }

        private void txtCMND_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HienThi_TT_KH(txtCMND.Text,"CMND");
                HienThi_Dgv();
                Xuly_ThanhTien();
            }
        }
        string PhatSinhMa(DataSet ds)
        {
            int countRows = ds.Tables[0].Rows.Count;
            string s1 = "";
            int s2 = 0;
            if (countRows == 0)
                s1 = "HD000";
            else
                s1 = Convert.ToString(ds.Tables[0].Rows[countRows - 1][0]);
            s2 = Convert.ToInt32((s1.Remove(0, 3)));
            if (s2 + 1 < 10)
            {
                return "HD00" + (s2 + 1).ToString();
            }
            else if (s2 + 1 < 100)
            {
                return "HD0" + (s2 + 1).ToString();
            }
            else return "HD" + (s2 + 1).ToString(); ;
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlctdv = "";
                if (dsDV.Tables[0].Rows.Count != 0)
                {
                    sqlctdv = "delete ChitietDV from HDPHG hp, ChitietDv ct where hp.MaPHG = ct.MaPHG and hp.MaHD = '" + lblMaHDDP.Text + "'";
                    c.CapNhat(sqlctdv);
                }
                string NvienLap = dsHDDP.Tables[0].Rows[0]["MaNV"].ToString();
                string sqlhdtt = "insert into HoaDonTT values('" + PhatSinhMa(dsHDTT) + "', '" + lblMaHDDP.Text + "', '" + NvienLap + "', GETDATE(), '" + tongThanhTien + "')";
                string sqlphg = "delete HDPHG where MaHD = '" + lblMaHDDP.Text + "'";
                string sqlctdp = "delete chitietdp where MaHDDP = '" + lblMaHDDP.Text + "'";
                string sqlhddp = "update HoadonDP set trangthai = 1 where mahd = '" + lblMaHDDP.Text + "'";

                for (int i = 0; i < dsPHG.Tables[0].Rows.Count; i++)
                {
                    string sql = "update PHG set Trangthai = 0 where MaPHG = '" + dsPHG.Tables[0].Rows[i]["MaPHG"].ToString() + "'";
                    c.CapNhat(sql);
                }

                if (c.CapNhat(sqlphg) != 0 && c.CapNhat(sqlctdp) != 0 && c.CapNhat(sqlhddp) != 0 && c.CapNhat(sqlhdtt) != 0)
                {
                    MessageBox.Show("Thành Công");
                    this.Close();
                    frmQLHDDP frm = new frmQLHDDP();
                    frm.Show();
                }
                else
                    MessageBox.Show("Thất bại");
            }
            catch (Exception x)
            {
                MessageBox.Show("Thao thác lỗi !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void mnuHD_Click(object sender, EventArgs e)
        {
            frmQuanLiHD frm = new frmQuanLiHD();
            frm.Show();
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
