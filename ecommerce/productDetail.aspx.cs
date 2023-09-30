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
    public partial class productDetail : System.Web.UI.Page
    {
        connectionCLAS obj = new connectionCLAS();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            string s = "select * from ta_product where ca_id ="+Session["c_id"]+"";
            DataSet ds = obj.fun_adapter(s);

            
            DataList1.DataSource = ds;
            DataList1.DataBind();

        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Write("cart button");
        }
    }
}