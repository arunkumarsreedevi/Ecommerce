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
    public partial class product_details : System.Web.UI.Page
    {
        connectionCLAS obj = new connectionCLAS();
        protected void Page_Load(object sender, EventArgs e)
        {
            string st = "select ca_id from tab_cat ";
            string s = "select * from ta_product where";
            DataSet ds = obj.fun_adapter(s);

            //string regid = obj.fun_scalar(str1);
            Session["ca_id"] = ds;

            DataList1.DataSource = ds;
            DataList1.DataBind();
        }
    }
}