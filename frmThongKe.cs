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
    public partial class frmThongKe : Form
    {
        clsQLKS c = new clsQLKS();
        DataSet dsHD = new DataSet();
        DataSet dsNV = new DataSet();
        public void showDoanhThu(int thang, int nam)
        {
            if (xuLyHoaDon(thang,nam) != "")
            {
                dsHD = c.DanhSach(xuLyHoaDon(thang, nam));
                dgvHD.DataSource = dsHD.Tables[0];
                lblTongDT.Text = tongDT(dsHD).ToString();
                lblTongDT.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0 VND}", int.Parse(lblTongDT.Text));
            }
        }
        public void showNV(int thang,int nam)
        {
            string sql = "select nv.manv,nv.HoTen, COUNT(mahd) as tonghd, SUM(tongtien) as tongDoanhThu ";
            sql += "from nhanvien nv, hoadonTT tt ";
            sql += "where nv.manv = tt.manv and MONTH(tt.ngaythanhtoan) = "+thang+" and YEAR(tt.ngaythanhtoan) = "+nam+"";
            sql += "group by nv.MaNV, nv.HoTen";
            dsNV = c.DanhSach(sql);
            dgvNV.DataSource = dsNV.Tables[0];
        }
        public int tongDT(DataSet ds)
        {
            int tong = 0;
            for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                tong += int.Parse(ds.Tables[0].Rows[i]["tongtien"].ToString());
            }
            return tong;
        }
        public string xuLyHoaDon(int thang,int nam)
        {
            string sqlResult = "";
            if(thang == 0 || nam == 0)
            {
                MessageBox.Show("Thiếu dữ liệu !");
                sqlResult = "";
            }
            else
            {
                sqlResult = "select nv.hoten, hd.mahd, hd.ngaythanhtoan,hd.tongtien from HoaDonTT hd,nhanvien nv where hd.manv = nv.manv and MONTH(ngaythanhtoan) = " + thang + " and YEAR(ngaythanhtoan) = " + nam;
                
            }
            return sqlResult;
        }
        public frmThongKe()
        {
            InitializeComponent();
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            int thang = 0, nam=0;
            if (cboThang.SelectedIndex != -1)
                thang = cboThang.SelectedIndex + 1;
            if (txtNam.Text != "")
                nam = int.Parse(txtNam.Text);
            lblThang.Text = thang.ToString();
            showDoanhThu(thang, nam);
            showNV(thang,nam);
        }
        private void frmThongKe_Load(object sender, EventArgs e)
        {
            cboThang.SelectedIndex = -1;
        }
    }
}
