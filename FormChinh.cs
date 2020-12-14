using QuanLyKhachSan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class FormChinh : Form
    {
        private int childFormNumber = 0;

        public FormChinh()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        void setButton(Button btn, String img,Size s)
        {
            Size size = s;
            Bitmap filter = new Bitmap("ImagesQLKS\\icon\\" + img);
            btn.Image = filter;
            btn.Image = (Image)(new Bitmap(filter, size));
            btn.ImageAlign = ContentAlignment.TopCenter;
            btn.TextAlign = ContentAlignment.BottomCenter;
        }
        void xuLyButton()
        {
            Size tt = new Size(150,150);
            Size hd = new Size(50, 50);
            setButton(btnQLHD, "ui.png", hd);
            setButton(btnBooking, "Booking.png",tt);
            setButton(btnTT, "Tt.png",tt);
            setButton(btnTK, "graph.png", hd);

        }

        //private void hoaDonDPToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmHoaDonDP f = new frmHoaDonDP();
        //    f.Show();
        //}
        private void mnuQLDV_Click(object sender, EventArgs e)
        {
            frmDichVu dv = new frmDichVu();
            dv.Show();
        }

        private void mnuTTHD_Click(object sender, EventArgs e)
        {
            frmQLHDDP frm = new frmQLHDDP();
            frm.Show();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.Show();
        }

        private void mnuQLDP_Click(object sender, EventArgs e)
        {
            frmQLPHG f = new frmQLPHG();
            f.Show();
        }

        private void mnuQLPHG_Click(object sender, EventArgs e)
        {
            frmPhg f = new frmPhg();
            f.Show();
        }

        private void mnuThemDV_Click(object sender, EventArgs e)
        {
            frmThemDichVu f = new frmThemDichVu();
            f.Show();
        }
        private void mnuLoaiDV_Click(object sender, EventArgs e)
        {
            frmLoaiDV frm = new frmLoaiDV();
            frm.Show();
        }

        private void mnuLoaiPHG_Click(object sender, EventArgs e)
        {
            frmLoaiPhong frm = new frmLoaiPhong();
            frm.Show();
        }

        private void mnuQLHD_Click(object sender, EventArgs e)
        {
            frmQuanLiHD f = new frmQuanLiHD();
            f.Show();
        }

        private void FormChinh_Load(object sender, EventArgs e)
        {
            xuLyButton();
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int Year = DateTime.Now.Year;
            int hour = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            lbnNgay.Text = hour +":"+m+"     "+(day +"/"+ month +"/"+ Year);
        }

        private void chucNangToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.Show();
        }

        private void btnPHG_Click(object sender, EventArgs e)
        {
            frmPhg frm = new frmPhg();
            frm.Show();
        }

        private void btnLoaiPhg_Click(object sender, EventArgs e)
        {
            frmLoaiPhong frm = new frmLoaiPhong();
            frm.Show();
        }

        private void btnDV_Click(object sender, EventArgs e)
        {
            frmDichVu frm = new frmDichVu();
            frm.Show();
        }

        private void btnLoaiDV_Click(object sender, EventArgs e)
        {
            frmLoaiDV frm = new frmLoaiDV();
            frm.Show();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            frmQLPHG frm = new frmQLPHG();
            frm.Show();
        }

        private void btnTT_Click(object sender, EventArgs e)
        {
            frmQLHDDP frm = new frmQLHDDP();
            frm.Show();
        }

        private void btnQLHD_Click(object sender, EventArgs e)
        {
            frmQuanLiHD frm = new frmQuanLiHD();
            frm.Show();
        }

        private void mnuTKH_Click(object sender, EventArgs e)
        {
            frmTimKiem frm = new frmTimKiem("KH");
            frm.Show();
        }

        private void mnuTNV_Click(object sender, EventArgs e)
        {
            frmTimKiem frm = new frmTimKiem("NV");
            frm.Show();
        }

        private void mnuTDV_Click(object sender, EventArgs e)
        {
            frmTimKiem frm = new frmTimKiem("DV");
            frm.Show();
        }

        private void mnuTPHG_Click(object sender, EventArgs e)
        {
            frmTimKiem frm = new frmTimKiem("PHG");
            frm.Show();
        }

        private void mnuThongKe_Click(object sender, EventArgs e)
        {
            frmThongKe frm = new frmThongKe();
            frm.Show();
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            frmThongKe frm = new frmThongKe();
            frm.Show();
        }
    }
}
