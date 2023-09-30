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
    public partial class product : System.Web.UI.Page
    {
        connectionCLAS obj = new connectionCLAS();
        protected void Page_Load(object sender, EventArgs e)
        {
            string insp = "select * from ta_product";
            DataSet ds = obj.fun_adapter(insp);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}