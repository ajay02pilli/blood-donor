<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="awelcome.aspx.cs" Inherits="bloodnonor.awelcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
    <form id="form1" runat="server">
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
            <Items>
                <asp:MenuItem NavigateUrl="~/HOME.aspx" Text="HOME" Value="HOME"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/DETAILS.aspx" Text="DETAILS" Value="DETAILS"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/search.aspx" Text="SEARCH" Value="SEARCH"></asp:MenuItem>
            </Items>
            <StaticMenuStyle HorizontalPadding="200px" VerticalPadding="50px" />
        </asp:Menu>
        <div>
        </div>
    </form>
</body>
</html>
