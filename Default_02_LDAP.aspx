<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default_02_LDAP.aspx.cs" Inherits="Default_02_LDAP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Windows AD -- LADP</title>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            Windows AD （LDAP）裡面新增帳號、修改密碼<br />
            <br />
            請先<b> [加入參考]<br />
                System.DirectoryServices.DLL<br />
                System.DirectoryServices.AccountManagementDLL</b><br />
            <br />            

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button1_DisplayCurrentUser" />
            <br />
            <br />

            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button2_FindUsers" />
            <br />
            <br />

            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button3_CreateUser" />
            <br />
            <br />

            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Button4_ResetPassword" />
        </div>
    </form>
</body>
</html>
