using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace bloodnonor
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //Create Connection by using SqlConnetion Class
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            //Close Connection
            con.Open();
            string q = "proc_usered";
            SqlCommand cmd = new SqlCommand(q, con);
            //Inform that we are using Stored Procdure
            cmd.CommandType = CommandType.StoredProcedure;
            //Pass Parameters
            cmd.Parameters.AddWithValue("@a", TextBox1.Text);
            cmd.Parameters.AddWithValue("@b", TextBox2.Text);
            //Execute query
            Object p = cmd.ExecuteScalar();
            if ((int)p == 1)
            {
                Response.Redirect("userwelcome.aspx");
            }
            else
            {
                Response.Write("Invalid Credentials");
            }
            //Close connection
            con.Close();
        }
    }
}