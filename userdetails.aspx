<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userdetails.aspx.cs" Inherits="bloodnonor.userdetails" %>

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
        <p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:BoundField DataField="uid" HeaderText="ID" />
                    <asp:BoundField DataField="username" HeaderText="NAME" />
                    <asp:BoundField DataField="pwd" HeaderText="PWD" />
                    <asp:BoundField DataField="gender" HeaderText="GENDER" />
                    <asp:BoundField DataField="language" HeaderText="LANGUAGES" />
                    <asp:BoundField DataField="state" HeaderText="STATE" />
                    <asp:BoundField DataField="city" HeaderText="CITY" />
                    <asp:BoundField DataField="bloodgroup" HeaderText="BLOODGROUP" />
                    <asp:BoundField DataField="phno" HeaderText="PHNO" />
                    <asp:BoundField DataField="email" HeaderText="EMAIL" />
                    <asp:ButtonField HeaderText="ACTION" Text="EDIT" />
                    <asp:ButtonField HeaderText="ACTION" Text="DELETE" />
                </Columns>
            </asp:GridView>
        </p>
        <div>
        </div>
    </form>
</body>
</html>
