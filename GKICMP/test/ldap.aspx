<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ldap.aspx.cs" Inherits="GKICMP.test.ldap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Literal ID="Literal1" runat="server">名称</asp:Literal>
                </td>
                 <td>
                     <asp:TextBox ID="txt_DName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Literal ID="Literal2" runat="server">注释</asp:Literal>
                </td>
                 <td>
                     <asp:TextBox ID="txt_Desc" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Button ID="btn_Add" runat="server" Text="创建" OnClick="btn__Click" /></td>
                <td >
                    <asp:Button ID="btn_Delete" runat="server" Text="删除" OnClick="btn_Delete_Click" /><asp:Button ID="btn_DeleteU" runat="server" Text="删除用户" OnClick="btn_DeleteU_Click" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
