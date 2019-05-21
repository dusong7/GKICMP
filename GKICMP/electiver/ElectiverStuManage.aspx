<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ElectiverStuManage.aspx.cs" Inherits="GKICMP.electiver.ElectiverStuManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>智慧校园基础管理平台</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_DID" runat="server" />

        <asp:HiddenField ID="hf_AvoidSubmit" runat="server" />
        <h1>
            &nbsp;
            <asp:Label ID="lbl_claid" runat="server"></asp:Label></h1>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">选课任务：</td>
                        <td width="180">
                            <asp:DropDownList ID="ddl_EleID" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th align="center">学生姓名</th>
                        <th align="center">课程</th>
                        <th align="center">选课时间</th>
                        <th align="center">学生姓名</th>
                        <th align="center">课程</th>
                        <th align="center">选课时间</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <%     v = v + 1;
                                   if (v % 2 == 1)
                                   {%>
                            <tr>
                                <%
                                   }  
                                %>
                                <td><%#Eval("StuIDName")%></td>
                                <td><%#Eval("CorseIDName")%></td>
                                <td><%#Eval("EleDate","{0:yyyy-MM-dd HH:mm:ss}")%></td>
                                <%if (v % 2 == 0)
                                  {%>
                            </tr>
                            <%}%>
                            <%if (v == x && v % 2 == 1)
                              {%>
                            <td></td>
                            <td></td>
                            <td></td>
                            <%}%>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="7">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>



