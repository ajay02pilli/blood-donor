<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userwelcome.aspx.cs" Inherits="bloodnonor.userwelcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <p>
        <br />
    </p>
    <form id="form1" runat="server">
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
            <Items>
                <asp:MenuItem NavigateUrl="~/HOME.aspx" Text="HOME" Value="HOME"></asp:MenuItem>
                <asp:MenuItem Text="DETAILS" Value="DETAILS"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/search.aspx" Text="SEARCH" Value="SEARCH"></asp:MenuItem>
            </Items>
        </asp:Menu>
        <p>
        </p>
        <div>
        </div>
    </form>
</body>
</html>
