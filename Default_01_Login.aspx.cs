using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//*** 自己宣告（加入）***********
using FormsAuth;      //自己寫的類別，NameSpace名稱。
using System.Web.Security;    // FormsAuthenticationTicket與 FormsAuthentication會用到這個命名空間。
//*** 自己宣告（加入）***********

public partial class Default_01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string adPath = "LDAP://" + txtDomain.Text;
        //Windows Server 2008（含）後續新版的AD才能用。

        LdapAuthentication adAuth = new LdapAuthentication(adPath);
        //自己寫的類別檔。

        try
        {
            if (true == adAuth.IsAuthenticated(txtDomain.Text, txtUsername.Text, txtPassword.Text))
            {    //自己寫的類別檔裡面的「方法」。
                string groups = adAuth.GetGroups();


                //Create the ticket, and add the groups.登入成功後，是否用Cookie記錄？
                bool isCookiePersistent = chkPersist.Checked;

            //資料來源：http://msdn.microsoft.com/zh-tw/library/System.Web.Security.FormsAuthenticationTicket(v=vs.110).aspx
            //輸入參數： 使用 Cookie 名稱、版本、目錄路徑、核發日期、到期日期、永續性和使用者定義的資料
            // 此 Cookie 路徑設定為在Web.Config組態檔中建立的預設值，也就是  path="/"。
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1,
                          txtUsername.Text, DateTime.Now, DateTime.Now.AddMinutes(60), isCookiePersistent, groups);

            //-- 每個參數的用意 ---------------------------------------------------------------------------------------------
            //--  version  類型：System.Int32  票證(ticket)的版本號碼。
            //--  name  類型：System.String  與票證相關的使用者名稱。
            //--  issueDate  類型：System.DateTime  核發此票證時的本機日期和時間。
            //--  expiration  類型：System.DateTime  票證到期的本機日期和時間。
            //--  isPersistent  類型：System.Boolean  如果票證將存放於持續性 Cookie 中 (跨瀏覽器工作階段儲存)，則為 true，否則為 false。 
            //                                                                   如果票證是存放於 URL 中，則忽略這個值。 
            //--  userData  類型：System.String  要與票證一起存放的使用者特定資料。

                //Encrypt the ticket.
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                //Create a cookie, and then add the encrypted ticket to the cookie as data.
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                if (true == isCookiePersistent)
                    authCookie.Expires = authTicket.Expiration;

                //Add the cookie to the outgoing cookies collection.
                Response.Cookies.Add(authCookie);

                //You can redirect now. 通過身份驗證的人，才能看見原本的網頁Default_00.aspx。
                //通過驗證後，自動回到（導向）原本想看的網頁。
                Response.Redirect(FormsAuthentication.GetRedirectUrl(txtUsername.Text, false));
            }
            else
            {
                errorLabel.Text = "Authentication did not succeed. （認證失敗）Check user name and password.";
            }
        }
        catch (Exception ex)   {
            errorLabel.Text = "Error authenticating.（例外狀況） " + ex.Message;
        }
    }
}