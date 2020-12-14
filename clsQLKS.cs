using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace QuanLyKhachSan
{

    class clsQLKS
    {
        SqlConnection con = new SqlConnection();
        void KetNoi()
        {
            con.ConnectionString = @"data source =DESKTOP-RNKCRFS\SUCANABO;initial catalog = QuanLyKhachSan;integrated security = true";
            if (con.State == ConnectionState.Closed)
                con.Open();
        }
        void DongKetNoi()
        {
            con.Close();
        }
        //load du lieu
        public clsQLKS()
        {
            KetNoi();
        }
        public DataSet DanhSach(String sql)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql,con);
            da.Fill(ds);
            return ds;
            
        }
        //cap nhat du lieu
        public int CapNhat(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            return cmd.ExecuteNonQuery();
            
        
        }
    }
}
