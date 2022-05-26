<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default_03_LDAP_AddUser.aspx.cs" Inherits="Default_03_LDAP_AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        資料來源 <a href="http://msdn.microsoft.com/zh-tw/library/ms180912(v=vs.90).aspx">http://msdn.microsoft.com/zh-tw/library/ms180912%28v=vs.90%29.aspx</a><br />
        <br />
        建立（新增）使用者<br />
        <br />
        下列程式碼範例示範如何在組織單元（OU）中建立使用者。<br />
        <span class="auto-style1"><strong>依照預設，此帳戶將停用</strong></span>。</div>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button_啟用帳號" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Button_停用（Disable）帳號" OnClick="Button2_Click" />
        <br />
        <br />
        <br />
        建立群組（Group）也很類似，請看 <a href="http://msdn.microsoft.com/zh-tw/library/ms180903(v=vs.90).aspx">http://msdn.microsoft.com/zh-tw/library/ms180903%28v=vs.90%29.aspx</a>
    </form>
</body>
</html>
