using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace bloodnonor
{
    public partial class DETAILS : System.Web.UI.Page
    {
        void getdata()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            String q = "details";
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "donors");
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                getdata();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CmdEdit")
            {
                //FInd Button Index Number
                int index = Convert.ToInt32(e.CommandArgument);
                //Find Row Index Number
                GridViewRow row = GridView1.Rows[index];
                //Assign names to columns
                Label l1 = (Label)row.FindControl("Label1");
                Label l2 = (Label)row.FindControl("Label2");
                Label l3 = (Label)row.FindControl("Label3");
                Label l4 = (Label)row.FindControl("Label4");
                Label l5 = (Label)row.FindControl("Label5");
                Label l6 = (Label)row.FindControl("Label6");
                Label l7 = (Label)row.FindControl("Label7");
                Label l8 = (Label)row.FindControl("Label8");

                //Create Sessions
                /*Session["t2"] = l2.Text;
                Session["t3"] = l3.Text;
                Session["t4"] = l4.Text;
                Session["t5"] = l5.Text;
                Session["t6"] = l6.Text;
                Session["t7"] = l7.Text;
                Session["t8"] = l8.Text;
                Session["t9"] = l9.Text;
                Response.Redirect("DETAILS.aspx");*/
            }
            else if (e.CommandName == "CmdDelete")
            {
                //Find Button Index Number
                int index = Convert.ToInt32(e.CommandArgument);
                //Find Row Index Number
                GridViewRow row = GridView1.Rows[index];
                //Assign Names
                Label l1 = (Label)row.FindControl("Label2");
                //Create connection by using SqlConnection Class
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
                //Open Connetion
                con.Open();
                //Pass query
                string q = "deletes";
                SqlCommand cmd = new SqlCommand(q, con);
                //Inform that we are using stoed Procedure
                cmd.CommandType = CommandType.StoredProcedure;
                //Pass Values
                cmd.Parameters.AddWithValue("@a", l1.Text);
                //Execute Query
                cmd.ExecuteNonQuery();
                //Close Connection
                con.Close();
                getdata();


            }
        }
    }

}