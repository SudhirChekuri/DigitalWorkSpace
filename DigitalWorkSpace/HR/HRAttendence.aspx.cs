using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DigitalWorkSpace.HR
{
    public partial class HRAttendence : System.Web.UI.Page
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
                Display();
                DisplayAttendence();
            }
        }
        public void Display()
        {
            cmd = new SqlCommand("select Mid,UserName from Tbl_Manager", con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GV1_Attendence.DataSource = dt;
            GV1_Attendence.DataBind();

        }
        public void DisplayAttendence()
        {
            SqlCommand cmd = new SqlCommand("Select * From Tbl_Attendance", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GV3_Attendence.DataSource = ds;
            GV3_Attendence.DataBind();
        }

        protected void GV1_Attendence_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Select")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                txtMId.Text = GV1_Attendence.Rows[num].Cells[1].Text;
                SqlCommand cmd = new SqlCommand("Select Id,UserName From Tbl_Register Where MId = '" + txtMId.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GV2_Attendence.DataSource = dt;
                GV2_Attendence.DataBind();
            }

        }

        protected void GV2_Attendence_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                txtUId.Text = GV2_Attendence.Rows[num].Cells[1].Text;


            }

        }
        protected void btnCreateLeaves_Click(object sender, EventArgs e)
        {
            sqlquery = "insert into Tbl_Attendance(Id,MId,SickLeaves,PrivilegeLeaves,FromDate,ToDate) values('" + txtUId.Text + "','" + txtMId.Text + "','" + txtSickLeaves.Text + "','" + txtPrivilizeleaves.Text + "','" + txtFromDate.Text + "','" + txtToDate.Text + "')";
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            DisplayAttendence();
        }

        protected void btnUpdateLeaves_Click(object sender, EventArgs e)
        {

            sqlquery= "update  Tbl_Attendance set SickLeaves='"+txtSickLeaves.Text+"',PrivilegeLeaves='"+txtPrivilizeleaves.Text+"',FromDate='"+txtFromDate.Text+"',ToDate='"+txtToDate.Text+"' where Id="+txtUId.Text+"";
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            //cmd.ExecuteNonQuery();
            DisplayAttendence();
        }
    }
}
    
