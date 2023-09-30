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
    public partial class Admin_Reg : System.Web.UI.Page
    {
        connectionCLAS obj = new connectionCLAS();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select max(u_id) from tab_login";
            string uid = obj.fun_scalar(sel);

            int user_id = 0;
            if (uid == "")
            {
                user_id = 1;

            }
            else
            {
                int newu_id = Convert.ToInt32(uid);
                user_id = newu_id + 1;

            }
            string ins = "insert into admin_reg values(" + user_id + ",'" + txtadmin.Text + "','" + ad_email.Text + "','" + txtnum.Text + "')";

            int i = obj.fun_Nonquery(ins);
            string inslog = "insert into tab_login values(" + user_id + ",'" + admin_uname.Text + "','" + admin_psw.Text + "','admin','active')";
            int j = obj.fun_Nonquery(inslog);
            Response.Redirect("login.aspx");
        }
    }
}