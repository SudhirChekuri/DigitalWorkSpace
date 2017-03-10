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
    
    public partial class AdminSignIn : System.Web.UI.Page
    {
        SqlConnection con = null;
        SqlDataAdapter da = null;
        SqlCommand cmd = null;
        DataSet ds = null;
        string sqlquery = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConDigitalWorkSpace"].ConnectionString);
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            if(ddlType.SelectedIndex==1)
            {
                if(txtUserName.Text=="Admin" && txtPwd.Text=="Admin")
                {
                    Response.Redirect("AdminHome.aspx");
                }
                else
                {
                    Response.Write("SignIn failed");
                }
            }
            else if(ddlType.SelectedIndex==2)
            {
               sqlquery = "select * from Tbl_Manager where UserName='" + txtUserName.Text + "' and Password='" + txtPwd.Text + "'";
                da = new SqlDataAdapter(sqlquery, con);
                ds = new DataSet();
                //da.Fill(ds, "manager");

                DataTable dt = new DataTable();

                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Session["UserName"] = txtUserName.Text;
                    Session["Pwd"] = txtPwd.Text;
                    Response.Redirect("~/Manager/ManagerHome.aspx");
                }
                else
                {
                    Response.Write("signin failed");
                }
                
            }
            else if (ddlType.SelectedIndex == 3)
            {
                sqlquery = "select * from Tbl_HR where UserName='" + txtUserName.Text + "' and Password='" + txtPwd.Text + "'";
                da = new SqlDataAdapter(sqlquery, con);
                ds = new DataSet();
                DataTable dt = new DataTable();

                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Session["UserName"] = txtUserName.Text;
                    Session["Pwd"] = txtPwd.Text;
                    Response.Redirect("~/HR/HRHome.aspx");
                }
               else
                {
                    Response.Write("SignIn failed");
                }
            }

        }
    }
}