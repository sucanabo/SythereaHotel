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
        DataSet dsTTDV = new DataSet();
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
        void getTTDV(string sql)
        {
            dsTTDV = c.DanhSach(sql);
           // dtTTDV = dsTTDV.Tables[0];

        }
        void ShowDanhSach(string sql, DataGridView d)
        {
            ds = c.DanhSach(sql);
            d.DataSource = ds.Tables[0];
        }
        public frmThemDichVu()
        {
            InitializeComponent();
            txtSoLuong.KeyPress += new KeyPressEventHandler(txtSoLuong_KeyPress);
        }
        void HienThi_TextBox(DataSet ds, int vt)
        {
            try
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
                else if (s == "SV010")
                    cboDichVu.SelectedIndex = 9;
                else if (s == "SV011")
                    cboDichVu.SelectedIndex = 10;
            }
            catch (Exception x)
            {
                MessageBox.Show("Load thất bại!");
            }

        }
        private void dgrDV_cellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = dgrDichVu.CurrentCell.RowIndex;
            HienThi_TextBox(ds, vt);
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
           
        }
        private void ThemDVcs_Load(object sender, EventArgs e)
        {
            lblMaPHG.Text = frmQLPHG.MaPHG;
            string sql = " select * from ChiTietDV where MaPHG like '"+lblMaPHG.Text+"'";
            ShowDanhSach(sql, dgrDichVu);
            ShowDV("select * from Dichvu where trangthai = 1");
            ShowCTDV("select * from ChiTietDV");
            xuLyButton();
        }
        void getDonGia(string maDV)
        {
            string sql = "";
            sql = "select dongia from dichvu where madv = '" + maDV + "'";
            dsdonGia = c.DanhSach(sql);
        }
        bool kiemTraTrungDV(string dv)
        {
           for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["MaDV"].ToString() == dv)
                    return true;
                    
            }
            return false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
           
            string sqlTTDV = "select TrangThai from dichvu where madv ='" + cboDichVu.SelectedValue + "'";
            if (txtSoLuong.Text ==""|| cboDichVu.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn nhập thiếu dữ liệu!!", "Lưu ý !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else

            { 
                getTTDV(sqlTTDV);
                int TTDV = int.Parse(dsTTDV.Tables[0].Rows[0]["trangthai"].ToString());
                if (TTDV == 0)
                {
                    MessageBox.Show("Dịch vụ này ngừng hoạt động !!!");
                    clear();
                }
                else
                {                 
                   getDonGia(cboDichVu.SelectedValue.ToString());
                   int TT = int.Parse(dsdonGia.Tables[0].Rows[0]["dongia"].ToString()) * int.Parse(txtSoLuong.Text);
                    string sql = "";
                    if (kiemTraTrungDV(cboDichVu.SelectedValue.ToString()) == true)
                    {
                        sql = "update chitietdv set soluong = soluong +" +txtSoLuong.Text+" where madv = '"+cboDichVu.SelectedValue+"'";
                    }
                    else
                    {
                        sql = "insert into ChiTietDV(MaPHG,MaDV,SoLuong,thanhtien) values('" + lblMaPHG.Text + "','" + cboDichVu.SelectedValue + "','" + txtSoLuong.Text + "','" + TT.ToString() + "')";
                    }    
                    
                    if (c.CapNhat(sql) != 0)
                    {
                        MessageBox.Show("Thanh cong! ");
                    }
                    ShowDanhSach(" select * from ChiTietDV where MaPHG like '" + lblMaPHG.Text + "'", dgrDichVu);
                    clear();
                    
                }
             }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            frmQLHDDP frm = new frmQLHDDP();
            frm.Show();
            this.Close();
            
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "";
                sql = "delete from ChiTietDV where MaDV = '" + cboDichVu.SelectedValue + "'";
                if (c.CapNhat(sql) != 0)
                {
                    MessageBox.Show("Thanh cong! ");
                }
                ShowDanhSach(" select * from ChiTietDV where MaPHG like '" + lblMaPHG.Text + "'", dgrDichVu);
                clear();
            }
            catch (Exception x)
            {
                MessageBox.Show("Load thất bại!");
            }
        }
        void clear()
        {
            txtSoLuong.Clear();
            cboDichVu.SelectedIndex = -1;
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void gbDv_Enter(object sender, EventArgs e)
        {

        }

        private void dgrDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }   

        
    }
}
