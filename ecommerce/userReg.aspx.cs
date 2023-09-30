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
    public partial class userReg : System.Web.UI.Page
    {
        connectionCLAS obj = new connectionCLAS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Bind_ddlCountry();
                //Bind_ddlState();
                //Bind_ddlCity();

            }
        }

        public void Bind_ddlCountry()
        {
            string ins = "select County,CountryId from tblCountry";
            SqlDataReader n = obj.fun_reader(ins);
            drp_country.DataSource = n;

            drp_country.Items.Clear();
            //DropDownList1.Items.Insert(0, "--select--");
            //DropDownList1.Items.Clear();
            drp_country.Items.Add("--Please Select country--");
            drp_country.DataTextField = "County";
            drp_country.DataValueField = "CountryId";
            drp_country.DataBind();
        }
            public void Bind_ddlState()
        {
            

            string instate="select State,StateID from countryState where CountryId='" + drp_country.SelectedValue + "'";
            SqlDataReader n1 = obj.fun_reader(instate);
            //int n1 = obj.fun_Nonquery(instate);
            drp_state.DataSource = n1;
            drp_state.Items.Clear();
            drp_state.Items.Add("--Please Select state--");
            drp_state.DataTextField = "State";
            drp_state.DataValueField = "StateID";
            drp_state.DataBind();
            
        }
        public void Bind_ddlCity()
        {

            string insc = "select * from stateCity where StateId ='" + drp_state.SelectedValue + "'";
            SqlDataReader ci = obj.fun_reader(insc);
            //int ci = obj.fun_Nonquery(insc);
            drp_city.DataSource = ci;
            drp_city.Items.Clear();
            drp_city.Items.Add("--Please Select city--");
            drp_city.DataTextField = "City";
            drp_city.DataValueField = "CityID";
            drp_city.DataBind();
            
        }


        protected void user_reg_Click(object sender, EventArgs e)
        {
            string sel = "select max(u_id) from tab_login";
            string uid = obj.fun_scalar(sel);

            int user_id = 0;
            if (uid == "")
            {
                //Label13.Visible = true;
                //Label13.Text = "try another user name";
                user_id = 1;
                //Response.Redirect("userReg.aspx");

            }
            else
            {
                int newu_id = Convert.ToInt32(uid);
                user_id = newu_id + 1;

                //}
                string ra = RadioButtonList1.SelectedItem.Text;

                string dd = "";
                dd = drp_country.SelectedItem.Text;
                string dd1 = drp_state.SelectedItem.Text;
                string dd2 = drp_city.SelectedItem.Text;
                string ins = "insert into user_reg values(" + user_id + ",'" + txtfname.Text + "','" + txt_lname.Text + "','" + txtaddress.Text + "'," + txtage.Text + ",'" + ra + "','" + dd + "','" + dd1 + "','" + dd2 + "','" + txt_ph.Text + "','" + txt_mail.Text + "')";
                int i = obj.fun_Nonquery(ins);
                string inslog = "insert into tab_login values(" + user_id + ",'" + txt_uname.Text + "','" + txt_psw.Text + "','user','active')";
                int j = obj.fun_Nonquery(inslog);
                Response.Redirect("login.aspx");


            }
        }

        protected void drp_country_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_ddlState();
        }

        protected void drp_state_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_ddlCity();
        }
    }
}