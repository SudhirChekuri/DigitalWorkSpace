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
    public partial class AdminPaySlips : System.Web.UI.Page
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
                DisplayPayslips();
            }
        }
        public void DisplayPayslips()
        {
            SqlCommand cmd = new SqlCommand("select * from Tbl_Payslips", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvPaySlips.DataSource = ds;
            gvPaySlips.DataBind();
        }

        protected void gvPaySlips_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPaySlips.EditIndex = e.NewEditIndex;
            DisplayPayslips();
        }

        protected void gvPaySlips_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPaySlips.EditIndex = -1;
            DisplayPayslips();

        }

        protected void gvPaySlips_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string pid = ((TextBox)gvPaySlips.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
            string id = ((TextBox)gvPaySlips.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string mid = ((TextBox)gvPaySlips.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string year = ((TextBox)gvPaySlips.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            string month = ((TextBox)gvPaySlips.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
            string pdf = ((TextBox)gvPaySlips.Rows[e.RowIndex].Cells[5].Controls[0]).Text;

            sqlquery = "update  Tbl_Payslips set Id=" + id + ",MId=" + mid + ",Year='" + year + "',Month='"+month+"',Pdf='"+pdf+"' where PId=" + pid;
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd = new SqlCommand(sqlquery, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                Response.Write("PaySlips Detailes Updated Successfully");
                gvPaySlips.EditIndex = -1;
                DisplayPayslips();
            }
            else
            {
                Response.Write("PaySlips Detailes Updated failed");
            }
            con.Close();

        }

        protected void gvPaySlips_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string pid = gvPaySlips.Rows[e.RowIndex].Cells[0].Text;
            sqlquery = "delete from Tbl_Payslips where PId= " + pid;
            
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd = new SqlCommand(sqlquery, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                Response.Write("PaySlips Details deleted successfully");
                DisplayPayslips();
            }
            else
            {
                Response.Write("PaySlips Details deleted failed");
            }
            con.Close();
        }
    }
}
