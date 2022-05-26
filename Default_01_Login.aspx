<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default_01_Login.aspx.cs" Inherits="Default_01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            background-color: #FFCCFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        資料來源&nbsp; <a href="http://msdn.microsoft.com/zh-tw/library/ms180890.aspx">http://msdn.microsoft.com/zh-tw/library/ms180890.aspx</a>
        <br />
        <br />
        1. 請先「<strong>加入參考</strong>」-- System.Directory.Services.DLL檔<br />
        2. 新增一個<strong>類別檔</strong>，LdapAuthentication.cs或 .vb<br />
        3. 改寫<strong> Global.asax檔</strong>（全域應用程式類別）<br />
        4. 修改 Web.Config檔，尤其是&lt;forms&gt;、&lt;authentication&gt;、&lt;authorization&gt;。進行這些變更之後，只有已驗證的使用者可以存取應用程式，而未驗證的要求會被重新導向到 Default_01_Logon.aspx 頁面。<br />
        <br />
        <hr />
        <br />
        <asp:Label ID="Label1" runat="server">Domain:</asp:Label>
        <asp:TextBox ID="txtDomain" runat="server"></asp:TextBox>&nbsp;請輸入 domain，適用Win 2008 Server以後版本<br />
        <br />
        <asp:Label ID="Label2" runat="server">Username:</asp:Label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label3" runat="server">Password:</asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />

        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"></asp:Button><br />

        <asp:Label ID="errorLabel" runat="server" ForeColor="#ff3300"></asp:Label><br />
        <asp:CheckBox ID="chkPersist" runat="server" Text="Persist Cookie" />    
        <br />
        <br />
        <br />
        <br />
        <p class="auto-style1">
            從使用者收集資訊，並呼叫 LdapAuthentication類別上的方法。</p>
        <p class="auto-style1">
            當程式碼驗證使用者並取得群組清單之後，會建立 FormsAuthenticationTicket物件、加密票證、將加密的票證加入至 Cookie、將 Cookie 加入至 HttpResponse.Cookies[]集合，然後將要求重新導向至<strong>當初要求的 URL</strong>。</p>
        <p>
            <span class="auto-style1">Default_00.aspx頁面是當初要求的頁面。當使用者要求此頁面時，要求會被重新導向到 Default_01_Logon.aspx頁面。</span><strong><span class="auto-style1">驗證要求之後</span></strong><span class="auto-style1">，要求會被重新導向至 Default_00.aspx 頁面。</span></p>
    </div>
    </form>
</body>
</html>
