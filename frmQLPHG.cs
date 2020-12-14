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
    public partial class frmQLPHG : Form
    {
        clsQLKS cls = new clsQLKS();
        DataSet ds = new DataSet();
        DataSet dsLoaiPHG = new DataSet();
        DataSet dsGiaPHG = new DataSet();
        DataSet dsPHG = new DataSet();
        DataSet dsTang = new DataSet();
        public static DateTime NN;
        public static DateTime ND;
        public static ArrayList listPHG = new ArrayList();
        public static string MaPHG;
        public frmQLPHG()
        {
            InitializeComponent();
        }
        void getDSTANG(string sql)
        {
            dsTang = cls.DanhSach(sql);
            int count = dsTang.Tables[0].Rows.Count;
            string last = dsTang.Tables[0].Rows[count - 1][0].ToString();
            int tangCuoi = int.Parse(last.Remove(1, 2));
            for (int i = 1; i <= tangCuoi; i++)
            {
                cboTang.Items.Add("Tầng " + i);
            }
            cboTang.SelectedIndex = -1;
        }
        void ShowLoaiPHG(string sql)
        {
            dsLoaiPHG = cls.DanhSach(sql);
            cboLoaiPHG.DataSource = dsLoaiPHG.Tables[0];
            cboLoaiPHG.DisplayMember = "TenLoai";
            cboLoaiPHG.ValueMember = "MaLoai";
            cboLoaiPHG.SelectedIndex = -1;

        }
        void ShowGiaPHG(string sql)
        {
            dsGiaPHG = cls.DanhSach(sql);
            cboGiaPHG.DataSource = dsGiaPHG.Tables[0];
            cboGiaPHG.DisplayMember = "GiaTien";
            cboGiaPHG.ValueMember = "GiaTien";
            cboGiaPHG.SelectedIndex = -1;

        }
        DataTable PHG = new DataTable();
        public int slPHG(String sql)
        {
            ds = cls.DanhSach(sql);
            PHG = ds.Tables[0];
            return PHG.Rows.Count;
        }
        void ButtonClick(object sender, EventArgs e)
        {
            listPHG.Clear();
            nButton btn = (nButton)sender;
            Color daThue = Color.Gray;
            Color phgTrong = Color.LightSeaGreen;
            Color dangChon = Color.CornflowerBlue;
            if(btn.Clicked == 0)
            {
                btn.BackColor = dangChon;
                btn.Clicked = 3;
            }
            else if(btn.Clicked == 3)
            {
                btn.BackColor = phgTrong;
                btn.Clicked = 0;
            }
            else
            {
                MaPHG = btn.Text;
                frmThemDichVu frm = new frmThemDichVu();
                frm.Show();
            }
            foreach (nButton nbtn in flpPHG.Controls)
            {
                if(nbtn.Clicked == 3 && nbtn.BackColor == dangChon)
                {
                    listPHG.Add(nbtn.Text);
                }    
           
            }
        }
        void setButton(Button btn,String img)
        {
            Size size = new Size(40, 40);
            Bitmap filter = new Bitmap("ImagesQLKS\\icon\\"+img);
            btn.Image = filter;
            btn.Image = (Image)(new Bitmap(filter, size));
            btn.ImageAlign = ContentAlignment.TopLeft;
            btn.TextAlign = ContentAlignment.BottomRight;
        }
        void xuLyButton()
        {
            setButton(btnLoc, "filter.png");
            setButton(btnHuy, "cancel.png");
        }
        private void frmQLPHG_Load(object sender, EventArgs e)
        {
            xuLyButton();
            ShowLoaiPHG("select * from LoaiPHG");
            ShowGiaPHG("select * from LoaiPHG");
            string sql = "select MaPHG from PHG";
            getDSTANG(sql);
            showData("select * from PHG");
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if(listPHG.Count != 0)
            {
                if(dtpNgayTra.Value > dtNgayNhan.Value)
                {
                    NN = dtNgayNhan.Value;
                    ND = dtpNgayTra.Value;
                    this.Close();
                    frmDangKyPHG frm = new frmDangKyPHG();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Ngày không hợp lệ !! ", "Lỗi !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn phòng !! ", "Lỗi !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        void showData(string sql)
        {
            flpPHG.Controls.Clear();
            for (int i = 0; i < slPHG(sql); i++)
            {

                nButton btn = new nButton();
                int a = int.Parse(ds.Tables[0].Rows[i]["TrangThai"].ToString());
                if(a == 1)
                {
                    btn.Clicked = 1;
                    btn.BackColor = Color.Gray;
                    
                }
                if(a == 0)
                {
                    btn.Clicked = 0;
                    btn.BackColor = Color.LightSeaGreen;
                }
                
                btn.AutoSize = false;
                Size z = new Size(300, 135);
                btn.Size = z;
                string v = ds.Tables[0].Rows[i]["MaPHG"].ToString();
                btn.Text = v;
                btn.BackgroundImage= Image.FromFile ("ImagesQLKS\\icon\\hotel-solid.png");
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                btn.ForeColor = Color.White;
                btn.TextAlign = ContentAlignment.TopCenter;
                btn.Click += new EventHandler(this.ButtonClick);
                flpPHG.Controls.Add(btn);
                
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            cboLoaiPHG.SelectedIndex = -1;
            cboTang.SelectedIndex = -1;
            cboGiaPHG.SelectedIndex = -1;
            showData("select * from phg");
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            int loai = cboLoaiPHG.SelectedIndex;
            int gia = cboGiaPHG.SelectedIndex;
            int tang = cboTang.SelectedIndex;
            string loaiphg = "";
            string giaphg = "";
            string tangphg = "";
            if (loai != -1)
                loaiphg = "and lp.maloai = '" + cboLoaiPHG.SelectedValue + "'";
            if (gia != -1)
                giaphg = "and lp.GiaTien = " + cboGiaPHG.SelectedValue;
            if (tang != -1)
            {
                if (tang == 0)
                {
                    tangphg = "";
                }
                else
                    tangphg = "and MaPHG like '" + (cboTang.SelectedIndex).ToString() + "%'";
            }
            showData("select * from PHG phg,loaiphg lp where lp.maloai = phg.maloai " + tangphg + giaphg + loaiphg);
        }
    }
    class nButton : Button
    {
        public int Clicked = 0;
        public nButton() { }
    }
}
