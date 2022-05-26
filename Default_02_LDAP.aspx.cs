using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//****自己宣告(加入)*********************************
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices.AccountManagement;  //自己 [加入參考] 才行
//**************************************************

public partial class Default_02_LDAP : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        // DisplayCurrentUser==================================
        using (var user = UserPrincipal.Current)
        {
            Response.Write(String.Format("Context = Context Name: {0}, ***Container: {1}, ***Server: {2}, ***Context: {3}", user.Context.Name, user.Context.Container, user.Context.ConnectedServer, user.Context.ToString()));
            Response.Write("<br />Name--" + user.Name);
            Response.Write("<br />Description--" + user.Description);
            Response.Write("<br />DisplayName--" + user.DisplayName);
            Response.Write("<br />EmailAddress--" + user.EmailAddress);
            Response.Write("<br />EmployeeId--" + user.EmployeeId);
            Response.Write("<br />GivenName--" + user.GivenName);
            Response.Write("<br />HomeDirectory--" + user.HomeDirectory);
            Response.Write("<br />LastLogon--" + String.Format("{0:d}", user.LastLogon));
            Response.Write("<br />ScriptPath--" + user.ScriptPath);
            Response.Write("<br />Certificates--" + user.Certificates);
            Response.Write("<br />UserCannotChangePassword--" + user.UserCannotChangePassword);
            Response.Write("<br />DistinguishedName--" + user.DistinguishedName);
        }
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        // FindUsers==================================
        var context = new PrincipalContext(ContextType.Domain, "ABCXYZ");
        //最後一個字串 , 請輸入網域主機的名稱。也就是上面第一個按鈕 的user.Context.ConnectedServer裡面「第一個主機名稱」

        var userFilter = new UserPrincipal(context);
        userFilter.EmailAddress = "MIS2000Lab@123.com";
        userFilter.Enabled = true;

        using (var searcher = new PrincipalSearcher())
        {
            searcher.QueryFilter = userFilter;
            var searchResult = searcher.FindAll();
            foreach (var user in searchResult)
            {
                Response.Write(user.Name + "<hr />");
                Response.Write("<br />DisplayName--" + user.DisplayName);
                Response.Write("<br />SamAccountName--" + user.SamAccountName);
                Response.Write("<br />Guid--" + user.Guid);
            }
        }
    }



    protected void Button3_Click(object sender, EventArgs e)
    {
        // CreateUser==================================
        using (var context = new PrincipalContext(ContextType.Domain, "ABCXYZ"))
        //最後一個字串 , 請輸入網域主機的名稱。也就是上面第一個按鈕 的user.Context.ConnectedServer裡面「第一個主機名稱」

        using (var user = new UserPrincipal(context, "Tomcat 帳號", "P@$$w0rd 密碼", true))
        {
            user.GivenName = "Tomcat 帳號";
            user.EmailAddress = "TomCat@JerryMouse.com";

            user.Save();
        }
    }



    protected void Button4_Click(object sender, EventArgs e)
    {
        // ResetPassword==================================
        using (var context = new PrincipalContext(ContextType.Domain, "ABCXYZ"))
        //最後一個字串 , 請輸入網域主機的名稱。也就是上面第一個按鈕 的user.Context.ConnectedServer裡面「第一個主機名稱」

        using (var user = UserPrincipal.FindByIdentity(context, IdentityType.Name, "Tomcat 帳號"))
        {
            user.SetPassword("NewP@$$w0rd 新密碼");

            user.Save();
        }
    }
}