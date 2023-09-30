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
    public partial class Editcategory : System.Web.UI.Page
    {
        connectionCLAS obj = new connectionCLAS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grid_bind();
            }
            
        }
        public void grid_bind()
        {
            string s = "select * from tab_cat";
            DataSet ds = obj.fun_adapter(s);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int id = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string del = "delete from tab_cat where ca_id=" + id + "";
            int j = obj.fun_Nonquery(del);
            grid_bind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            grid_bind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            grid_bind();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int k = e.RowIndex;
            int id1 = Convert.ToInt32(GridView1.DataKeys[k].Value);
            TextBox txtcat = (TextBox)GridView1.Rows[k].Cells[3].Controls[0];

            TextBox txtdes = (TextBox)GridView1.Rows[k].Cells[5].Controls[0];
            string up = "update tab_cat set ca_name='" + txtcat.Text + "',ca_des='" + txtdes.Text + "' where ca_id=" + id1 + "";
            int j = obj.fun_Nonquery(up);
            GridView1.EditIndex = -1;
            grid_bind();
        }


        //protected void LinkButton1_Command(object sender, CommandEventArgs e)
        //{
        //    int id = Convert.ToInt32(e.CommandArgument);
        //    string del = "delete from tab_cat where ca_id=" + id + "";
        //    int i = obj.fun_Nonquery(del);
        //    grid_bind();
        //}

        //protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        //{
        //    GridViewRow rw=GridView1.Rows[e.NewSelectedIndex]
        //}
    }
}