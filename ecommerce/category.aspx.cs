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
    public partial class category : System.Web.UI.Page
    {
        connectionCLAS obj = new connectionCLAS();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/images" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            string str = "insert into tab_cat values('" + TextBox1.Text + "','" + p + "','" + TextBox2.Text + "','active')";
            int i = obj.fun_Nonquery(str);
            if (i != 0)
            {
                Label4.Visible = true;
                Label4.Text = "inserted";

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Editcategory.aspx");
        }
    }
}