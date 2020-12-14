using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data;
namespace QuanLyKhachSan
{
    public partial class frmHDBH : Form
    {
        clsQLKS c = new clsQLKS();
        DataSet ds = new DataSet();

        public frmHDBH()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        void showTextBox(String sql, TextBox txt)
        {
            ds = c.DanhSach(sql);
            //txt.Text = ds[0].Text;
        }
        private void btnTimKH_Click(object sender, EventArgs e)
        {
            String sdt = txtSDT.Text;
            string sql = "select TenKH from KhachHang where SDT like '%" + sdt + "%'";

        }
       public void showList(String sql, DataGridView d)
        {
            ds = c.DanhSach(sql);
            d.DataSource = ds.Tables[0];
        }    
        private void frmHDBH_Load(object sender, EventArgs e)
        {
            showList("select * from khachhang", dgv1);
        }
    }
}
