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
    public partial class ManagerUsers : System.Web.UI.Page
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
                // DisplayManager();
                 ManagerDetails();
                DisplayManager1();
               
            }
        }
       public void DisplayManager1()
        {
            SqlCommand cmd = new SqlCommand("Select Id,UserName,EmailId,Status from Tbl_Register Where Status='I'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GV1_Manager.DataSource = ds;
            GV1_Manager.DataBind();
        }

        public void ManagerDetails()
        {
            SqlCommand cmd = new SqlCommand("Select Id,UserName,EmailId,Status from Tbl_Register Where Status='A'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvApproves.DataSource = ds;
            gvApproves.DataBind();
        }
        protected void GV1_Manager_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int Id = Convert.ToInt32(GV1_Manager.DataKeys[e.NewEditIndex].Value);
            SqlCommand cmd = new SqlCommand("Update Tbl_Register Set Status='A' Where Id='" + Id + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            //DisplayManager();
             ManagerDetails();
            DisplayManager1();
           
        }
    }
}
