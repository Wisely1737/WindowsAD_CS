<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default_00.aspx.cs" Inherits="Default_00" %>

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
    
        <span class="auto-style1">當使用者要求此頁面時，要求會被重新導向到 Default_01_Logon.aspx頁面。</span>
        <br />
        <br />
        <strong><span class="auto-style1">
        驗證要求之後</span></strong><span class="auto-style1">，要求會被重新導向至 Default_00.aspx 頁面。</span><br />
        <br />
        <br />
        <br />
        <asp:Label ID="lblName" runat="server" />
        <br />
        <br />
        <asp:Label ID="lblAuthType" runat="server" />
    </div>
    </form>
</body>
</html>
