using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ecommerce
{
    public class connectionCLAS
    {
        SqlConnection con;
        SqlCommand cmd;
        public connectionCLAS()
        {
            con = new SqlConnection(@"server=DESKTOP-MFIR2R5\SQLEXPRESS;database=pr_ecomm;Integrated security=true");
        }
        public int fun_Nonquery(string sql)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sql,con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }
        public string fun_scalar(string sql)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sql, con);
            con.Open();
            string s = cmd.ExecuteScalar().ToString();

            con.Close();
            return s;
        }
        public SqlDataReader fun_reader(string sql)

        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public DataSet fun_adapter(string sql)
        {
            if (con.State == ConnectionState.Open)
            {

                con.Close();
            }
           
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
           da.Fill(ds);
            return ds;
           
        }

    }

}