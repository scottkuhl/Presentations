<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginControl.aspx.cs" Inherits="admin_Pages_LoginControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Show User Name: <asp:CheckBox ID="ShowUserName" runat="server" />
        <asp:Button ID="Save" runat="server" Text="Save" onclick="Save_Click" />
    </form>
</body>
</html>
