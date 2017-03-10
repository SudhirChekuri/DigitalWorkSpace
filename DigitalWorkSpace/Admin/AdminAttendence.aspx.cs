using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


namespace DigitalWorkSpace.Admin
{
    public partial class AdminAttendence : System.Web.UI.Page
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
                DisplayAttendence();
            }
        }
            
        public void DisplayAttendence()
        {
            SqlCommand cmd = new SqlCommand("select * from Tbl_Attendance", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            gvAttendence.DataSource = ds;
            gvAttendence.DataBind();
        }
        protected void gvAttendence_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAttendence.EditIndex = e.NewEditIndex;
            DisplayAttendence();
        }

        protected void gvAttendence_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAttendence.EditIndex = -1;
            DisplayAttendence();

        }

        protected void gvAttendence_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string aid = ((TextBox)gvAttendence.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
            string id = ((TextBox)gvAttendence.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string mid = ((TextBox)gvAttendence.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string sickleaves = ((TextBox)gvAttendence.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            string privilegeleaves = ((TextBox)gvAttendence.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
            string fromdate = ((TextBox)gvAttendence.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
            string todate = ((TextBox)gvAttendence.Rows[e.RowIndex].Cells[6].Controls[0]).Text;

            sqlquery = "update  Tbl_Attendance set Id=" + id + ",MId=" + mid + ",SickLeaves='" + sickleaves + "',PrivilegeLeaves='" + privilegeleaves + "',FromDate='" + fromdate + "',ToDate='"+todate+"' where AId=" + aid;
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd = new SqlCommand(sqlquery, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                Response.Write("Attendance Detailes Updated Successfully");
                gvAttendence.EditIndex = -1;
                DisplayAttendence();
            }
            else
            {
                Response.Write("Attendance Detailes Updated failed");
            }
            con.Close();

        }

        protected void gvAttendence_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string aid = gvAttendence.Rows[e.RowIndex].Cells[0].Text;
            sqlquery = "delete from Tbl_Attendance where AId= " + aid;

            if (con.State != ConnectionState.Open)
                con.Open();
            cmd = new SqlCommand(sqlquery, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                Response.Write("Attendance Details deleted successfully");
                DisplayAttendence();
            }
            else
            {
                Response.Write("Attendance Details deleted failed");
            }
            con.Close();
        }

    }
}
