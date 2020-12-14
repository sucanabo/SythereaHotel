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
using System.Collections;

namespace QuanLyKhachSan
{
    public partial class frmThemDichVu : Form
    {

        clsQLKS c = new clsQLKS();//KetnoiDL
        DataSet ds = new DataSet();
        DataSet dsDV = new DataSet();
        DataSet dsCTDV = new DataSet();
        DataSet dsdonGia = new DataSet();
        ArrayList a = frmQLPHG.listPHG;
        DataTable dtDV = new DataTable();
        void ShowCTDV(string sql)
        {
            cboDichVu.SelectedIndex = -1;
        }
        void ShowDV(string sql)
        {
            dsDV = c.DanhSach(sql);
            cboDichVu.DataSource = dsDV.Tables[0];
            cboDichVu.DisplayMember = "TenDV";
            cboDichVu.ValueMember = "MaDV";
            cboDichVu.SelectedIndex = -1;

        }
        void ShowDanhSach(string sql, DataGridView d)
        {
            ds = c.DanhSach(sql);
            d.DataSource = ds.Tables[0];
        }
        public frmThemDichVu()
        {
            InitializeComponent();
        }
        void HienThi_TextBox(DataSet ds, int vt)
        {
            lblMaPHG.Text = ds.Tables[0].Rows[vt]["MaPHG"].ToString();
            txtSoLuong.Text = ds.Tables[0].Rows[vt]["SoLuong"].ToString();
            string s = "";
            s = ds.Tables[0].Rows[vt]["MaDV"].ToString();
                if (s == "SV001")
                cboDichVu.SelectedIndex = 0;
                    else if (s == "SV002")
                        cboDichVu.SelectedIndex = 1;
                    else if (s == "SV003")
                        cboDichVu.SelectedIndex = 2;
                    else if (s == "SV004")
                        cboDichVu.SelectedIndex = 3;
                    else if (s == "SV005")
                        cboDichVu.SelectedIndex = 4;
                    else if (s == "SV006")
                        cboDichVu.SelectedIndex = 5;
                    else if (s == "SV007")
                        cboDichVu.SelectedIndex = 6;
                    else if (s == "SV008")
                        cboDichVu.SelectedIndex = 7;
                    else if (s == "SV009")
                        cboDichVu.SelectedIndex = 8;
        }
        private void dgrDV_cellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = dgrDichVu.CurrentCell.RowIndex;
            HienThi_TextBox(ds, vt);
        }
        private void ThemDVcs_Load(object sender, EventArgs e)
        {
            lblMaPHG.Text = frmQLPHG.MaPHG;
            string sql = " select * from ChiTietDV where MaPHG like '"+lblMaPHG.Text+"'";
            ShowDanhSach(sql, dgrDichVu);
            ShowDV("select * from Dichvu");
            ShowCTDV("select * from ChiTietDV");
        }
        void getDonGia(string maDV)
        {
            string sql = "";
            sql = "select dongia from dichvu where madv = '" + maDV + "'";
            dsdonGia = c.DanhSach(sql);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            getDonGia(cboDichVu.SelectedValue.ToString());
            int TT = int.Parse(dsdonGia.Tables[0].Rows[0]["dongia"].ToString()) * int.Parse(txtSoLuong.Text);
            string sql = "";
            sql = "insert into ChiTietDV(MaPHG,MaDV,SoLuong,thanhtien) values('"+lblMaPHG.Text+"','" + cboDichVu.SelectedValue + "','" + txtSoLuong.Text + "','" +TT.ToString() +"')";
            if (c.CapNhat(sql) != 0)
            {
                MessageBox.Show("Thanh cong! ");
            }
            ShowDanhSach(" select * from ChiTietDV where MaPHG like '" + lblMaPHG.Text + "'", dgrDichVu);
        }
    }
}
