using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AkashNProject
{
    public partial class Registration : System.Web.UI.Page
    {
       // SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindrepeater();
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FullName", txtfullname.Text);
                cmd.Parameters.AddWithValue("@MobileNo", txtmobileno.Text);
                cmd.Parameters.AddWithValue("@EmailId", txtemail.Text);
                cmd.Parameters.AddWithValue("@CompanyName", txtcomapny.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Bindrepeater();
            }
        }
        protected void Bindrepeater()
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("getdata", con);
                con.Open();
                Repeater1.DataSource = cmd.ExecuteReader();
                Repeater1.DataBind();

            }
        }

       
       
        protected void lknupdate_Click(object sender, EventArgs e)
        {
                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                int ID = int.Parse((item.FindControl("id") as Label).Text);
                string NAME = (item.FindControl("txtfullname") as TextBox).Text.Trim();
                string MOBILE = (item.FindControl("txtmobileno") as TextBox).Text.Trim();
                //int MOBILE = int.Parse((item.FindControl("txtmobileno") as TextBox).Text);
                string Email = (item.FindControl("txtemail") as TextBox).Text.Trim();
                string Company = (item.FindControl("txtcompany") as TextBox).Text.Trim();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[sp_update]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpID", ID);
                    cmd.Parameters.AddWithValue("@FullName", NAME);
                    cmd.Parameters.AddWithValue("@MobileNo", MOBILE);
                    cmd.Parameters.AddWithValue("@EmailId", Email);
                    cmd.Parameters.AddWithValue("@CompanyName", Company);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Bindrepeater();

                }
            }

        protected void linedit_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            this.ToggleElements(item, true);
            this.ToggleElements1(item, false);
        }

         private void ToggleElements(RepeaterItem item, bool isEdit)
            {
                
                item.FindControl("lknupdate").Visible = isEdit;
                item.FindControl("txtfullname").Visible = isEdit;
                item.FindControl("txtmobileno").Visible = isEdit;
                item.FindControl("txtemail").Visible = isEdit;
                item.FindControl("txtcompany").Visible = isEdit;
                

            }

            private void ToggleElements1(RepeaterItem item, bool isEdit)
            {
                item.FindControl("linedit").Visible = isEdit;
                item.FindControl("lblfullname").Visible = isEdit;
                item.FindControl("lblmobileno").Visible = isEdit;
                item.FindControl("txtemail").Visible = isEdit;
                item.FindControl("lblcompany").Visible = isEdit;

            }

        protected void lkndelete_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(((sender as LinkButton).NamingContainer.FindControl("id") as Label).Text);
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpID", ID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Bindrepeater();
            }
        }
    }
 }

