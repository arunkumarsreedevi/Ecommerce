using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ecommerce
{
    public partial class login : System.Web.UI.Page
    {
        connectionCLAS obj = new connectionCLAS();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count(u_id) from tab_login where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
            string cid = obj.fun_scalar(str);
            int cid1 = Convert.ToInt32(cid);
            if(cid1==1)
            {
                string str1 = "select u_id from tab_login where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
                string regid = obj.fun_scalar(str1);
                Session["userid"] = regid;
                string str2 = "select logtype from tab_login where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
                string log_type = obj.fun_scalar(str2);
                if(log_type=="admin")
                {
                    Response.Redirect("adminHome.aspx");

                }
                else if(log_type=="user")
                {
                    Response.Redirect("user_home.aspx");
                }
                else
                {
                    Label3.Visible = true;
                    Label3.Text = "invalid username or password";
                }
            }
        }
    }
}