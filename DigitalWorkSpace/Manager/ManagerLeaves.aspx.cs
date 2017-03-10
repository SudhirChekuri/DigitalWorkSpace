using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DigitalWorkSpace.Manager
{
    public partial class ManagerLeaves : System.Web.UI.Page
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

               NonApproveLeaves();
            }
        }
        public void NonApproveLeaves()
        {
            SqlCommand cmd = new SqlCommand("Select * From Tbl_Leaves Where Status='I'", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvLeavesApprove.DataSource = ds;
            gvLeavesApprove.DataBind();
        }
      protected void gvLeavesApprove_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            string employeeId = gvLeavesApprove.Rows[index].Cells[0].Text;
            SqlCommand cmd = new SqlCommand("update tbl_leaves set status='A' where Id='"
            + employeeId + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            NonApproveLeaves();
        }
    }


}
