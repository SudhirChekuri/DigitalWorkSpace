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
    public partial class HRPaySlips : System.Web.UI.Page
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
                DisplayPayslips();

            }
        }
        public void Display()
        {
            cmd = new SqlCommand("select Mid,UserName from Tbl_Manager", con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GV1_Payslips.DataSource = dt;
            GV1_Payslips.DataBind();

        }

        protected void GV1_Payslips_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                txtMId.Text = GV1_Payslips.Rows[num].Cells[1].Text;
                SqlCommand cmd = new SqlCommand("Select Id,UserName From Tbl_Register Where MId='" + txtMId.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GV2_Payslips.DataSource = dt;
                GV2_Payslips.DataBind();

            }


        }

        protected void GV2_Payslips_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Select")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                txtUId.Text = GV2_Payslips.Rows[num].Cells[1].Text;
            }

        }
        public void DisplayPayslips()
        {
            SqlCommand cmd = new SqlCommand("Select * From Tbl_Payslips", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GV3_Payslips.DataSource = dt;
            GV3_Payslips.DataBind();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileupload.HasFile)
            {
                string str = fileupload.FileName;
                fileupload.SaveAs(Server.MapPath("~/Upload/" + str));
                SqlCommand cmd = new SqlCommand("insert Tbl_Payslips(Id,MId,Year,Month,Pdf) Values('" + txtUId.Text + "','" + txtMId.Text + "','" + ddlYear.SelectedItem.Value + "','" + ddlMonth.SelectedItem.Value + "','" + str + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayPayslips();
            }
            else
            {
                Response.Write("file uploaded Failed");
            }

        }
    }
}