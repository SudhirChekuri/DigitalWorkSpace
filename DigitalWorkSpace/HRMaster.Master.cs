using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigitalWorkSpace
{
    public partial class HRMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            label1.Text = Session["UserName"].ToString();
        }

        protected void lbtnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AdminSignIn.aspx");
        }
    }
}