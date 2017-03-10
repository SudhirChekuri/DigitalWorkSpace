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
    public partial class CreateHR : System.Web.UI.Page
    {
        SqlConnection con = null;
        SqlDataAdapter da = null;
        SqlCommand cmd = null;
        DataSet ds = null;
        string sqlquery = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConDigitalWorkSpace"].ConnectionString);
            if(!IsPostBack)
            {
                DisplayHR();
            }
        }
        public void DisplayHR()
        {
            SqlCommand cmd = new SqlCommand("select * from Tbl_HR", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvHRDetails.DataSource = ds;
            gvHRDetails.DataBind();
        }


        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert Tbl_HR(UserName,Password,EmailId,CreatedTime) values('" + txtUserName.Text + "','" + txtPwd.Text + "','" + txtEmail.Text + "',getdate())", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            DisplayHR();
            txtUserName.Text = "";
            txtPwd.Text = "";
            txtEmail.Text = "";
            txtcpwd.Text = "";

        }

        protected void gvHRDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvHRDetails.EditIndex = e.NewEditIndex;
            DisplayHR();
        }

        protected void gvHRDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvHRDetails.EditIndex = -1;
            DisplayHR();
        }

        protected void gvHRDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string hid = gvHRDetails.Rows[e.RowIndex].Cells[0].Text;
            sqlquery = "delete from Tbl_HR where Id= " + hid + "";
            
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd = new SqlCommand(sqlquery, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                Response.Write("HR Details deleted successfully");
                DisplayHR();
            }
            else
            {
                Response.Write("HR Details deleted failed");
            }
            con.Close();
        }

        protected void gvHRDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string hid = ((TextBox)gvHRDetails.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
            // string mid = gvManagerDetails.Rows[e.RowIndex].Cells[0].Text;
            string username = ((TextBox)gvHRDetails.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string password = ((TextBox)gvHRDetails.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string email = ((TextBox)gvHRDetails.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            string createdtime = ((TextBox)gvHRDetails.Rows[e.RowIndex].Cells[4].Controls[0]).Text;

            sqlquery = "update  Tbl_HR set Username='" + username + "',Password='" + password + "',EmailId='" + email + "' where Id=" + hid;
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd = new SqlCommand(sqlquery, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                Response.Write("HR Detailes Updated Successfully");
                gvHRDetails.EditIndex = -1;
                DisplayHR();
            }
            else
            {
                Response.Write("HR Detailes Updated failed");
            }
            con.Close();
        }
    }
}