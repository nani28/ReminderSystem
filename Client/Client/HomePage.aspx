<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Client.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 200px;
        }
        .auto-style3 {
            width: 386px;
        }
        .auto-style4 {
            width: 187px;
        }
        .auto-style6 {
            width: 159px;
        }
        .auto-style7 {
            width: 142px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" Text="UserId :"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox1" runat="server" Width="222px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="GetAllReminders" Width="128px" />
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                        <br />
                        <br />
                        <table class="auto-style1">
                            <tr>
                                <td class="auto-style7">
                                    <asp:Button ID="Button2" runat="server" Text="Insert" OnClick="Button2_Click" />
                                </td>
                                <td class="auto-style6">
                                    <asp:Button ID="Button3" runat="server" Text="Update" OnClick="Button3_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="Button4" runat="server" Text="Delete" OnClick="Button4_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">
                                    &nbsp;</td>
                                <td class="auto-style6">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
