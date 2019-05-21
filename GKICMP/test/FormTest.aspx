<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormTest.aspx.cs" Inherits="GKICMP.test.FormTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="date" id="date" /> <input type="number" id="datetime" />
            <table>
                <tr>
                    <th>姓名</th>
                    <th>测试 </th>
                    <th>数学</th>
                </tr>
                <asp:Repeater ID="rpt_List" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("姓名")%><asp:HiddenField ID="hf_TID" Value='<%#Eval("id")%>' runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txt_CJ1" runat="server" Text='<%#Eval("语文")%>'></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_CJ2" runat="server" Text='<%#Eval("数学")%>'></asp:TextBox>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="btn_Add" runat="server" Text="提交" OnClick="btn_Add_Click" /></td>
                </tr>
            </table>
        </div>
        <div>
             <asp:TextBox ID="txt_StuName"  runat="server" name="txt_StuName"    url="../ashx/Stu.ashx?method=StuGrade" CssClass="easyui-combotree"    Width="90%"></asp:TextBox>
             <asp:TextBox ID="txt_StuName1"  runat="server" name="txt_StuName1"    url="../ashx/EUIDataList.ashx?method=GList&IsChild=true&IsRE=true&IsUser=true" CssClass="easyui-combotree"    Width="90%"></asp:TextBox>
             
        </div>
    </form>
</body>
</html>
