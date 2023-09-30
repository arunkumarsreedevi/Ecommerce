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
    public partial class addproduct : System.Web.UI.Page
    {
       connectionCLAS obj = new connectionCLAS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind_cat();
            }

         }
        public void bind_cat()
        {
            string ins = "select ca_id,ca_name from tab_cat";
            SqlDataReader n = obj.fun_reader(ins);
            DropDownList1.DataSource = n;

            DropDownList1.Items.Clear();
            //DropDownList1.Items.Insert(0, "--select--");
            //DropDownList1.Items.Clear();
            DropDownList1.Items.Add("--Please Select category--");
            DropDownList1.DataTextField = "ca_name";
            DropDownList1.DataValueField = "ca_id";
            DropDownList1.DataBind();
        }
      

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/product_image" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            string dd = "";
            dd = DropDownList1.SelectedItem.Text;
            string dd1 = DropDownList1.SelectedItem.Value;
            string ins = "insert into ta_product values(" + dd1 + ",'" + txt_pname.Text + "','" + p + "'," + txt_price.Text + ",'" + txt_descr.Text + "'," + txt_stock.Text + ",'active')";
            int i = obj.fun_Nonquery(ins);
            //string inslog = "insert into tab_login values(" + user_id + ",'" + txt_uname.Text + "','" + txt_psw.Text + "','user','active')";
            //int j = obj.fun_Nonquery(inslog);
            if (i != 0)
            {
                Label7.Visible = true;
                Label7.Text = "inserted";

            }
        }

        protected void Edit_Product_Click(object sender, EventArgs e)
        {
            Response.Redirect("Editproduct.aspx");
        }
    }
}