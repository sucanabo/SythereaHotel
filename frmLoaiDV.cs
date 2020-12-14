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
    public partial class frmLoaiDV : Form
    {
        clsQLKS c = new clsQLKS();//KetnoiDL
        DataSet ds = new DataSet();
        int t = 0;
        //Hien thi du lieu
        void ShowDanhSach(string sql, DataGridView d)
        {
            ds = c.DanhSach(sql);
            d.DataSource = ds.Tables[0];
        }
        public frmLoaiDV()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLoaiDV_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn có muốn đóng ứng dụng không?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.No == result)
                e.Cancel = true;
        }
        void xuLiTextBox(Boolean t)
        {
            txtMaLoai.ReadOnly = t;
            txtTenLoaiDV.ReadOnly = t;
        }
        void xuLiChucNang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {

            txtMaLoai.Enabled = true;
            xuLiTextBox(false);
            xuLiChucNang(false);
            txtMaLoai.Focus();
            txtMaLoai.Text = PhatSinhMa(ds);
            t = 1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaLoai.Focus();
            xuLiTextBox(false);
            xuLiChucNang(false);
            t = 2;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            xuLiTextBox(false);
            xuLiChucNang(false);
            t = 3;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            xuLiTextBox(true);
            xuLiChucNang(true);
            string sql = "";
            int tt;
            if (cboTinhTrang.Text == "Hoạt động")
                tt = 1;
            else tt = 0;
            if (t != 0)
            {
                if (t == 1)
                {
                    sql = "insert into LoaiDV(MaLoai,TenLoai,TinhTrang)values('" + txtMaLoai.Text+ "',N'"+txtTenLoaiDV.Text+"',"+ tt +");";
                }
                if (t == 2)
                {

                    sql = "update LoaiDV set TenLoai = N'" + txtTenLoaiDV.Text +"', TinhTrang = "+ tt +" where MaLoai = '" +txtMaLoai.Text+"'";
                }
                if (t == 3)
                {
                    sql = "delete from LoaiDV where MaLoai = '" + txtMaLoai.Text + "'";
                }
                if (c.CapNhat(sql) != 0)
                {
                    MessageBox.Show("Thanh cong! ");
                }
                ShowDanhSach("select * from loaidv", dgvLoaiDV);
                HienThi_TextBox(ds, 0);
                t = 0;
            }
            else MessageBox.Show("Vui lòng chọn chức năng!!");


        }
        void HienThi_TextBox(DataSet ds, int vt)
        {
            txtMaLoai.Text = ds.Tables[0].Rows[vt]["MaLoai"].ToString();
            txtTenLoaiDV.Text = ds.Tables[0].Rows[vt]["TenLoai"].ToString();
            string s = "";
            cboTinhTrang.Text = ds.Tables[0].Rows[vt]["TinhTrang"].ToString();
            if (s == "Hoạt động")
                cboTinhTrang.SelectedIndex = 0;
            else
                cboTinhTrang.SelectedIndex = 1;
        }
        string PhatSinhMa(DataSet ds)
        {
            int countRows = ds.Tables[0].Rows.Count;
            string s1 = "";
            int s2 = 0;
            s1 = Convert.ToString(dgvLoaiDV.Rows[countRows - 1].Cells[0].Value);
            s2 = Convert.ToInt32((s1.Remove(0, 3)));
            if (s2 + 1 < 10)
            {
                return "L00" + (s2 + 1).ToString();
            }
            else if (s2 + 1 < 100)
            {
                return "L0" + (s2 + 1).ToString();
            }
            else return "L" + (s2 + 1).ToString(); ;
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
        }
        private void frmLoaiDV_Load(object sender, EventArgs e)
        {
            xuLyButton();
            txtMaLoai.Enabled = false;
            xuLiTextBox(false);
            xuLiChucNang(true);
            ShowDanhSach("select * from loaidv", dgvLoaiDV);
        }

        private void dgvLoaiDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLoai.Enabled = false;
            int vt = dgvLoaiDV.CurrentCell.RowIndex;
            HienThi_TextBox(ds, vt);
        }
        void clear()
        {
            txtMaLoai.Clear();
            txtTenLoaiDV.Clear();
            cboTinhTrang.SelectedIndex = -1;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuLiTextBox(true);
            xuLiChucNang(true);
            t = 0;
            clear();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
