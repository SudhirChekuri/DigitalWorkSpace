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
    
    public partial class AdminUsers : System.Web.UI.Page
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
                ViewEmployees();
                NonApprovedEmployees();
            }
        }
        public void ViewEmployees()
        {
            SqlCommand cmd = new SqlCommand("select * from tbl_Register where Status='A'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvApprovedUsers.DataSource = ds;
            gvApprovedUsers.DataBind();
        }
        public void NonApprovedEmployees()
        {

            SqlCommand cmd = new SqlCommand("select * from tbl_Register where Status='I'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvNonApproveUsers.DataSource = ds;
            gvNonApproveUsers.DataBind();
        }
    }

}
    
