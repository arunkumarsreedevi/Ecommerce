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
    public partial class Editproduct : System.Web.UI.Page
    {
        connectionCLAS obj = new connectionCLAS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind_gridproduct();
            }

        }
        public void bind_gridproduct()
        {
            string insp = "select * from ta_product";
            DataSet ds = obj.fun_adapter(insp);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow rw = GridView1.Rows[e.NewSelectedIndex];
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int id = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string del = "delete from ta_product where pr_id=" + id + "";
            int j = obj.fun_Nonquery(del);
            bind_gridproduct();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind_gridproduct();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int k = e.RowIndex;
            int id1 = Convert.ToInt32(GridView1.DataKeys[k].Value);
            TextBox txtname = (TextBox)GridView1.Rows[k].Cells[5].Controls[0];
            TextBox txtprice = (TextBox)GridView1.Rows[k].Cells[7].Controls[0];
            TextBox txtdesc = (TextBox)GridView1.Rows[k].Cells[8].Controls[0];
            TextBox txtstock = (TextBox)GridView1.Rows[k].Cells[9].Controls[0];
            string up = "update ta_product set pr_name='" + txtname.Text + "',pr_price=" + txtprice.Text + ",pr_des='" + txtdesc.Text + "',pr_stock="+txtstock.Text+" where ca_id=" + id1 + "";
            int j = obj.fun_Nonquery(up);
            GridView1.EditIndex = -1;
            bind_gridproduct();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind_gridproduct();
        }
    }
}