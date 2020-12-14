using System;
using System.Collections;
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
    public partial class frmDangKyPHG : Form
    {
        clsQLKS c = new clsQLKS();//KetnoiDL
        DataSet ds = new DataSet();
        ArrayList a = QuanLyKhachSan.frmQLPHG.listPHG;
        DataSet dsHDDP = new DataSet();
        DataTable dtHDDP = new DataTable();
        DataSet dsNV = new DataSet();
        void dsHD(String sql, ref DataTable dtHDDP)
        {
            dsHDDP = c.DanhSach(sql);

            dtHDDP = dsHDDP.Tables[0];
           
        }
    int t = 0;
        void ShowDanhSach(string sql, DataGridView d)
        {
            ds = c.DanhSach(sql);
            d.DataSource = ds.Tables[0];
        }
        public frmDangKyPHG()
        {
            InitializeComponent();
        }

        
        void HienThi_TextBox(DataSet ds, int vt)
        {
            txtCMND.Text = ds.Tables[0].Rows[vt]["CMND"].ToString();
            txtTenKH.Text = ds.Tables[0].Rows[vt]["HoTen"].ToString();
            txtSDT.Text = ds.Tables[0].Rows[vt]["SDT"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[vt]["Email"].ToString();
            string s = "";
            s = ds.Tables[0].Rows[vt]["Phai"].ToString();
            if (s == "Nam")
                cboPhai.SelectedIndex = 0;
            else if (s == "Nữ")
                cboPhai.SelectedIndex = 1;
            

        }
        private void dgrKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = dgvKH.CurrentCell.RowIndex;
            HienThi_TextBox(ds, vt);
        }
        void xuLiTextBox(Boolean t)
        {
            txtCMND.ReadOnly = t;
        }
        void xuLiChucNang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
        }
        string PhatSinhMa(DataTable ds)
        {
            int countRows = dtHDDP.Rows.Count;
            string s1 = "";
            int s2 = 0;
            if (countRows == 0)
                s1 = "HD000";
            else
                s1 = Convert.ToString(dtHDDP.Rows[countRows - 1][0]);
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
        void setButton(Button btn, String img)
        {
            Size size = new Size(40, 40);
            Bitmap filter = new Bitmap("ImagesQLKS\\icon\\" + img);
            btn.Image = filter;
            btn.Image = (Image)(new Bitmap(filter, size));
            btn.ImageAlign = ContentAlignment.TopLeft;
            btn.TextAlign = ContentAlignment.BottomRight;
        }
        void xuLyButton()
        {
            setButton(btnThem, "plus.png");
            setButton(btnXoa, "bin.png");
            setButton(btnSua, "pencil.png");
            setButton(btnLuu, "savereal.png");
            setButton(btnHuy, "cancel.png");
            setButton(btnThoat, "close.png");
            setButton(btnDangKy, "tick.png");
            setButton(btnTim, "search.png");
        }
        private void frmDangKyPHG_Load(object sender, EventArgs e)
        {
            xuLyButton();
            dsHD("select * from HoaDonDP", ref dtHDDP);
            ShowNhanVien("select * from nhanvien where chucvu = N'Thu Ngân' or chucvu = N'Quản lý'");
            lblMaHD.Text = PhatSinhMa(dtHDDP);
            dtpNgayNhan.Value = QuanLyKhachSan.frmQLPHG.NN;
            dtpNgayTra.Value = QuanLyKhachSan.frmQLPHG.ND;
            dtpNgayTra.Enabled = false;
            dtpNgayNhan.Enabled = false;
            ShowDanhSach("select * from KhachHang", dgvKH);
            lblDSPHG.Text = "";
            for(int i = 0; i < a.Count; i++)
            {
                if(i == a.Count-1)
                    lblDSPHG.Text += a[i];
                else
                lblDSPHG.Text += a[i] +", ";
            }
            lblDSPHG.Enabled = false;
            
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLiTextBox(false);
            xuLiChucNang(false);
            txtCMND.Focus();
            t = 1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtCMND.Enabled = true;
            xuLiTextBox(false);
            xuLiChucNang(false);
            txtCMND.Focus();
            t = 2;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtCMND.Enabled = true;
            xuLiTextBox(false);
            xuLiChucNang(false);
            txtCMND.Focus();
            t = 3;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuLiTextBox(true);
            xuLiChucNang(true);
            t = 0;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            xuLiTextBox(true);
            xuLiChucNang(true);
            //try
            //{
                string sql = "";
                if (t != 0)
                {   
                    if (txtCMND.Text == "" || txtTenKH.Text == "" || txtSDT.Text == "" || txtEmail.Text == "" || cboPhai.SelectedIndex == -1)
                    {
                        MessageBox.Show("Bạn nhập thiếu dữ liệu!");
                    }
                    else
                    {
                        if (t == 1)
                        {
                                sql = "insert into KhachHang values('" + txtCMND.Text + "', N'" + txtTenKH.Text + "', N'" + txtSDT.Text + "','" + txtEmail.Text + "', N'" + cboPhai.Text + "');"; 
                        }
                        if (t == 2)
                        {
                            sql = "delete from KhachHang where CMND = '" + txtCMND.Text + "'";
                        }
                        if (t == 3)
                        {
                            sql = "update KhachHang set Hoten ='"+txtTenKH.Text+"', SDT ='"+txtSDT.Text+"', email ='"+txtEmail.Text+"', Phai ='"+cboPhai.Text+"' where CMND ='"+txtCMND.Text+"'";
                        }
                        if (c.CapNhat(sql) != 0)
                        {
                            MessageBox.Show("Thanh cong!");
                        }
                        ShowDanhSach("select * from KhachHang", dgvKH);
                        HienThi_TextBox(ds, 0);
                        t = 0;
                    }           


                }
                    else MessageBox.Show("Vui lòng chọn chức năng!!");
                        t = 0;
            //}
            //catch(Exception x)
            //{
            //    MessageBox.Show("Thao tác lỗi!");
            //}
        }
        private void txtTT_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from KhachHang where CMND like N'%" + txtTT.Text + "%' or SDT like N'%"+txtTT.Text+"%'";
            sql += " or HoTen like N'%"+txtTT.Text+"%'";
            ShowDanhSach(sql, dgvKH);
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            string sql = "select * from KhachHang where CMND=N'" + txtTT.Text + "'";
            ShowDanhSach(sql, dgvKH);
        }
        void ShowNhanVien(string sql)
        {
            dsNV = c.DanhSach(sql);
            cboNhanVien.DataSource = dsNV.Tables[0];
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNV";
            cboNhanVien.SelectedIndex = -1;
        }
        int kt(string sdt, string cmnd)
        {
            int check = 0;
            if (sdt.Length < 10 || sdt.Length > 10)
                check = 1;
            if (cmnd.Length > 12 || cmnd.Length < 9)
                check = 2;
            return check;
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            int check = kt(txtSDT.Text, txtCMND.Text);
            if (check==0)
            {
                string sqlHDDP = "insert into hoadondp values ('" + lblMaHD.Text + "','" + cboNhanVien.SelectedValue + "','" + dtpNgayNhan.Value + "','" + dtpNgayTra.Value + "','0',GETDATE())";
                string sqlCTDP = "insert into chitietdp values('" + lblMaHD.Text + "','" + txtCMND.Text + "')";
                if (txtCMND.Text == "" || txtTenKH.Text == "" || txtSDT.Text == "" || txtEmail.Text == "" || cboPhai.SelectedIndex == -1 || cboNhanVien.SelectedIndex == -1)
                {
                    MessageBox.Show("Bạn nhập thiếu dự liệu!");
                }
                else
                {
                    if (c.CapNhat(sqlHDDP) == 1 && c.CapNhat(sqlCTDP) == 1)
                    {
                        for (int i = 0; i < a.Count; i++)
                        {

                            c.CapNhat("insert into hdphg values ('" + lblMaHD.Text + "','" + a[i] + "')");
                            c.CapNhat("update phg set trangthai = 1 where maphg = '" + a[i] + "'");

                        }
                        if (DialogResult.OK == (MessageBox.Show("Thanh Cong", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)))
                        {
                            this.Close();
                        }

                    }
                }
            }
            else if(check == 1)
            {
                MessageBox.Show("SĐT không hợp lệ!");
            }
            else
            {
                MessageBox.Show("Số CMND/Căn cước không hợp lệ!");
            }
            
                
                
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }
    }
}
