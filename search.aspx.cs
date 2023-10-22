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
    public partial class search : System.Web.UI.Page
    {

        void bloodgroup()
        {
            //create SqlConnection by using Sql Connection Class
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            //pass query to db by using SqldataAdapter
            String q = "proc_blood";
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            //create dataset
            DataSet ds = new DataSet();
            //fill data set
            da.Fill(ds, "bloodgroup");
            //provideLink b/w dropdownlist and dataset
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "group_name";
            DropDownList1.DataValueField = "group_id";
            //databind
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "---select---");

        }
        void getstates()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            String q = "proc_states";
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "ststes");
            DropDownList2.DataSource = ds;
            DropDownList2.DataTextField = "saname";
            DropDownList2.DataValueField = "sid";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "--Select--");
        }
        void Cities()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            String q = "proc_cities";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", DropDownList2.SelectedItem.Value);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "cities");
            DropDownList3.DataSource = ds;
            DropDownList3.DataTextField = "cname";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, "--Select--");

        }
        void data()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            String q = "searchdetailss";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@b", DropDownList3.SelectedItem.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "donors");
            GridView1.DataSource = ds;
            GridView1.DataBind();


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack==false)
            {
                bloodgroup();
                getstates();
                DropDownList1.Items.Insert(0, "---Select Blood---");
                DropDownList2.Items.Insert(0, "---Select State---");
                DropDownList3.Items.Insert(0, "---Select City---");
            }

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cities();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            data();
        }
    }
}