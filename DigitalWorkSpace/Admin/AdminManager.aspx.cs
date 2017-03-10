using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DigitalWorkSpace.Admin
{
    public partial class CreateManager : System.Web.UI.Page
    {
        SqlConnection con = null;
        SqlDataAdapter da = null;
        SqlCommand cmd = null;
        DataSet ds = null;
        string sqlquery = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConDigitalWorkSpace"].ConnectionString);
            if (!IsPostBack)
            {
                DisplayManagerDetails();
            }
        }
        public void DisplayManagerDetails()
        {
            SqlCommand cmd = new SqlCommand("select * from Tbl_Manager", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvManagerDetails.DataSource = ds;
            gvManagerDetails.DataBind();
        }



        protected void btnCreateManager_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert Tbl_Manager(UserName,Password,EmailId,CreatedTime) values('" + txtUserName.Text + "','" + txtPwd.Text + "','" + txtEmail.Text + "',getdate())", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            DisplayManagerDetails();
            txtUserName.Text = "";
            txtPwd.Text = "";
            txtEmail.Text = "";
            txtcpwd.Text = "";

        }

        protected void gvManagerDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvManagerDetails.EditIndex = e.NewEditIndex;
            DisplayManagerDetails();
        }

        protected void gvManagerDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            string mid = gvManagerDetails.Rows[e.RowIndex].Cells[0].Text;
            sqlquery = "delete from Tbl_Manager where Mid= "+mid+"";
            //da = new SqlDataAdapter(sqlquery, con);
            //ds = new DataSet();
            //da.Fill(ds,"Manager");
            //gvManagerDetails.DataSource = ds.Tables["Manager"];
            //gvManagerDetails.DataBind();
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd = new SqlCommand(sqlquery, con);
            if(cmd.ExecuteNonQuery()>0)
            {
                Response.Write("Manager Details deleted successfully");
                DisplayManagerDetails();
            }
            else
            {
                Response.Write("Manager Details deleted failed");
            }
            con.Close();
            
        }

        protected void gvManagerDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvManagerDetails.EditIndex = -1;
            DisplayManagerDetails();
        }

        protected void gvManagerDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string mid = ((TextBox)gvManagerDetails.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
            // string mid = gvManagerDetails.Rows[e.RowIndex].Cells[0].Text;
            string username = ((TextBox)gvManagerDetails.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string password = ((TextBox)gvManagerDetails.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string email = ((TextBox)gvManagerDetails.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            string createdtime = ((TextBox)gvManagerDetails.Rows[e.RowIndex].Cells[4].Controls[0]).Text;

            sqlquery = "update  Tbl_Manager set Username='" + username + "',Password='" + password + "',EmailId='" + email + "' where Mid="+ mid;
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd = new SqlCommand(sqlquery, con);
            if(cmd.ExecuteNonQuery()>0)
            {
                Response.Write("Manager Detailes Updated Successfully");
                gvManagerDetails.EditIndex = -1;
                DisplayManagerDetails();
            }
            else
            {
                Response.Write("Manager Detailes Updated failed");
            }
            con.Close();
        }
    }
}
