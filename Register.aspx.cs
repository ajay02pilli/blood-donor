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
    public partial class Register : System.Web.UI.Page
    {

        void states()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            string q = "proc_states";
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "states");
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "saname";
            DropDownList1.DataValueField = "sid";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "--select--");

        }
        void cities()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            String q = "proc_cities";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", DropDownList1.SelectedItem.Value);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "cities");
            DropDownList2.DataSource = ds;
            DropDownList2.DataTextField = "cname";
            DropDownList2.DataValueField = "cid";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "--select--");
        }
        void bloodgroup()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            String q = "proc_blood";
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "bloodgroup");
            DropDownList3.DataSource = ds;
            DropDownList3.DataTextField = "group_name";
            DropDownList3.DataValueField = "group_id";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, "--Select--");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack==false)
            {
                bloodgroup();
                states();
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cities();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //Create Connection by using SqlConnetion Class
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            //Close Connection
            con.Open();
            String q = "";
            if (Button1.Text == "Insert")
            {
                q = "proc_insert";
            }
            else
            {
                q = "proc_update";
            }

            SqlCommand cmd = new SqlCommand(q, con);
            //Inform that we are using Stored Procdure
            cmd.CommandType = CommandType.StoredProcedure;
            //Pass Parameters
            cmd.Parameters.AddWithValue("@a", TextBox1.Text);
            cmd.Parameters.AddWithValue("@b", TextBox2.Text);
            cmd.Parameters.AddWithValue("@c", TextBox3.Text);
            string gender = "";
            if (RadioButton1.Checked == true)
            {
                gender = RadioButton1.Text;
            }
            else
            {
                gender = RadioButton2.Text;
            }
            cmd.Parameters.AddWithValue("@d", gender);
            string languages = "";
            if (CheckBox1.Checked == true)
            {
                languages = CheckBox1.Text;
            }
            if (CheckBox2.Checked == true)
            {
                languages = languages + " " + CheckBox2.Text;
            }
            if (CheckBox3.Checked == true)
            {
                languages = languages + " " + CheckBox3.Text;
            }
            cmd.Parameters.AddWithValue("@e", languages);
            cmd.Parameters.AddWithValue("@f", DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@g", DropDownList2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@h", DropDownList3.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@i", TextBox4.Text);
            cmd.Parameters.AddWithValue("@j", TextBox5.Text);
            //Execute Query
            int i = cmd.ExecuteNonQuery();
            if (i == 1)
            {
                Response.Write("Record Inserted");
            }
            else
            {
                Response.Write("Record not Inserted");
            }

            //close connetion
            con.Close();
            Button1.Text = "Insert";
        }
    }
}