using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//*** 自己宣告（加入）***********
using System.Security.Principal;
//*** 自己宣告（加入）***********

public partial class Default_00 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblName.Text = "Hello <big>" + Context.User.Identity.Name + "</big>.<br />";
        lblAuthType.Text = "You were authenticated using <big>" + Context.User.Identity.AuthenticationType + "</big>.";
    }
}