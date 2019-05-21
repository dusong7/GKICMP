<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScoreAnalysis.aspx.cs" Inherits="GKICMP.educational.ScoreAnalysis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <style>
        .gd th {
            line-height: 26px;
        }
    </style>
    <script type="text/javascript">
        function allgrade(flag) {
            if (flag == 1) {
                document.getElementById("btn_AllGrade").click();
            }
            else {
                document.getElementById("btn_PartGrade").click();
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btn_AllGrade" runat="server" OnClick="btn_AllGrade_Click" Style="display: none;" />
        <asp:Button ID="btn_PartGrade" runat="server" OnClick="btn_PartGrade_Click" Style="display: none;" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <asp:Literal ID="ltl_th" runat="server"></asp:Literal>
                    </tr>
                    <asp:Literal ID="ltl_zh" runat="server"></asp:Literal>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <asp:Literal ID="ltl_fsd" runat="server"></asp:Literal>
                    </tr>
                    <tr style="text-align: center">
                        <asp:Literal ID="ltl_Header" runat="server"></asp:Literal>
                    </tr>
                    <asp:Literal ID="ltl_Rows" runat="server"></asp:Literal>
                </tbody>
            </table>

            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="10" align="left">全年级排名各班人数情况 
                        </th>
                    </tr>
                    <tr style="text-align: center">
                        <th align="center">班级</th>
                        <th align="center">1-10名</th>
                        <th align="center">11-20名</th>
                        <th align="center">21-30名</th>
                        <th align="center">31-50名</th>
                        <th align="center">51-100名</th>
                        <th align="center">101-200名</th>
                        <th align="center">201-300名</th>
                        <th align="center">>301名</th>
                        <th align="center">总人数</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%#Eval("BJName") %>
                                </td>
                                <td align="center">
                                    <%#Eval("S10") %>
                                </td>
                                <td align="center">
                                    <%#Eval("S20") %>
                                </td>
                                <td align="center">
                                    <%#Eval("S30") %>
                                </td>
                                <td align="center">
                                    <%#Eval("S50") %>
                                </td>
                                <td align="center">
                                    <%#Eval("S100") %>
                                </td>
                                <td align="center">
                                    <%#Eval("S200") %>
                                </td>
                                <td align="center">
                                    <%#Eval("S300") %>
                                </td>
                                <td align="center">
                                    <%#Eval("QT") %>
                                </td>
                                <td align="center">
                                    <%#Eval("ZRS") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td align="center" colspan="10">
                            <asp:Button runat="server" ID="lbtn_OutPut" OnClick="lbtn_OutPut_Click" Text="导出"  CssClass="submit"></asp:Button>
                            <asp:Button runat="server" ID="btn_AllOut" Text="全部导出" CssClass="addbtn" OnClick="btn_AllOut_Click" />
                            <input type="button" class="editor" id="return" value="返回" onclick='javascript: window.history.back(-1);' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

