using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System.Windows.Forms;

namespace QL_BangKeo
{
    class Connect
    {
        public static SqlConnection cn = new SqlConnection();
        public static void Ketnoi()
        {
            try
            {
                if(cn.State!=ConnectionState.Open)
                {
                    cn.ConnectionString = @"Data Source=DESKTOP-9HH0UJ6;Initial Catalog=QL_BangKeo;Integrated Security=True";
                    cn.Open();
                    MessageBox.Show("Kết nối thành công");
                }
                else MessageBox.Show("Không thể kết nối với dữ liệu");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static void NgatKetnoi()
        {
            if(cn.State==ConnectionState.Open)
            {
                cn.Close();
                cn.Dispose();
                cn = null;
            }
        }
        public DataTable xemDL(String sql)
        {
            Ketnoi();
            SqlDataAdapter adap = new SqlDataAdapter(sql, cn);
            DataTable dt=new DataTable();
            adap.Fill(dt);
            return dt;
            NgatKetnoi();
        }
        public SqlCommand ThucThiDL(String sql)
        {
            Ketnoi();
            SqlCommand cm=new SqlCommand(sql,cn);
            cm.ExecuteNonQuery();
            return cm;
            NgatKetnoi();
        }
    }
}
