<%@ Application Language="C#" %>



<script runat="server">

    //*****自己新增的程式碼***********************(start)
    //此事件處理常式會從 Context.Request.Cookies集合擷取驗證 Cookie、解密該 Cookie，
    //然後擷取將儲存在 FormsAuthenticationTicket.UserData 屬性中的群組清單。
    //群組會以管道分隔清單格式出現在 Default_01_Login.aspx 頁面上。
    //程式碼會剖析字串陣列中的字串以建立 GenericPrincipal 物件。建立 GenericPrincipal 物件之後，
    //此物件會被放在 HttpContext.User 屬性中。
    void Application_AuthenticateRequest(object sender, EventArgs e)
    {
        string cookieName = FormsAuthentication.FormsCookieName;
        HttpCookie authCookie = Context.Request.Cookies[cookieName];

        if (null == authCookie)
        {   //There is no authentication cookie.
            return;
        }
        FormsAuthenticationTicket authTicket = null;
        try
        {
            authTicket = FormsAuthentication.Decrypt(authCookie.Value);
        }
        catch (Exception ex)
        {   //Write the exception to the Event Log.
            return;
        }
        if (null == authTicket)
        {   //Cookie failed to decrypt.
            return;
        }
        //When the ticket was created, the UserData property was assigned a
        //pipe-delimited string of group names.
        string[] groups = authTicket.UserData.Split(new char[] { '|' });
        //Create an Identity.搭配的命名空間：System.Security.Principal
        System.Security.Principal.GenericIdentity id = new System.Security.Principal.GenericIdentity(authTicket.Name, "LdapAuthentication");
        //This principal flows throughout the request.
        System.Security.Principal.GenericPrincipal principal = new System.Security.Principal.GenericPrincipal(id, groups);
        Context.User = principal;
    }
    //*****自己新增的程式碼***********************(end)

    void Application_Start(object sender, EventArgs e) 
    {
        // 在應用程式啟動時執行的程式碼

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  在應用程式關閉時執行的程式碼

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // 在發生未處理的錯誤時執行的程式碼

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // 在新的工作階段啟動時執行的程式碼

    }

    void Session_End(object sender, EventArgs e) 
    {
        // 在工作階段結束時執行的程式碼
        // 注意: 只有在  Web.config 檔案中將 sessionstate 模式設定為 InProc 時，
        // 才會引起 Session_End 事件。如果將 session 模式設定為 StateServer 
        // 或 SQLServer，則不會引起該事件。

    }
       
</script>
