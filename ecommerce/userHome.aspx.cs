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
    public partial class userHome : System.Web.UI.Page
    {
        connectionCLAS obj = new connectionCLAS();
        protected void Page_Load(object sender, EventArgs e)
            {
            string s = "select * from tab_cat";
            DataSet ds = obj.fun_adapter(s);
            DataList1.DataSource = ds;  
            DataList1.DataBind();


        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("product_details.aspx");
        }
    }
}