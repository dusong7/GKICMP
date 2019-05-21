<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContractDetail.aspx.cs" Inherits="GKICMP.teachermanage.ContractDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/lrtk.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/lrscroll.js"></script>
    <script src="../js/input_custom.js"></script>
    <script src="../js/formcommon.js"></script>
    <script src="../js/jquery1.2.js"></script>
    <script src="../js/jquery.scripts.js"></script>
    <script src="../js/jquery.custom.js"></script>
     <style type="text/css">
        .auto-style1 {
            height: 17px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" height="99%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">最新合同</th>
                    </tr>
                    <tr>
                        <td align="right">姓名</td>
                        <td align="left" colspan="2">
                            <asp:Literal ID="ltl_TeacherName" runat="server"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td align="right">合同周期</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_TCycle"></asp:Literal></td>
                        <td align="right">签订日期</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_TStartDate"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">到期日期</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_TEndDate"></asp:Literal></td>
                        <td align="right">解除日期</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_OverDate"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td align="right">合同类型</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_CType"></asp:Literal></td>
                        <td align="right">状态</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_TState"></asp:Literal></td>
                    </tr>
                    <tr>
                        <th colspan="4" align="left" class="auto-style1">合同历史
                        </th>
                    </tr>
                    <tr>
                        <th align="center" colspan="2">签订日期</th>
                        <th align="center" colspan="2">到期日期</th>
                    </tr>
                    <asp:Repeater ID="rp_List" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td colspan="2" align="center"><%#Eval("TStartDate","{0:yyyy-MM-dd}")%></td>
                                <td colspan="2" align="center"><%#Eval("TEndDate","{0:yyyy-MM-dd}")%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr_null" runat="server">
                        <td colspan="4" align="center">暂无记录</td>
                    </tr>
                    <tr>
                        <th colspan="4" align="left">合同附件</th>
                    </tr>

                    <tr>
                        <td align="left" colspan="4">
                            <div id="featureContainer">
                                <div id="feature">
                                    <div id="block">
                                        <div id="botton-scroll">
                                            <ul class="featureUL">
                                                <asp:Repeater runat="server" ID="rp_File">
                                                    <ItemTemplate>
                                                        <li class="featureBox">
                                                            <a href='..<%#Eval("tcfile")%>' class="image-icon" rel="gallery[modal]" target="_blank">
                                                                <img alt="Paracletos" src='..<%#Eval("tcfile")%>'>
                                                            </a>
                                                            &nbsp;&nbsp;</li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                        </div>
                                    </div>
                                    <a class="prev" href="javascript:void();">Previous</a><a class="next" href="javascript:void();">Next</a>
                                </div>
                            </div>
                            <div id="wrap"><span id="load">LOADING...</span></div>

                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: center" colspan="7">
                             <input type="submit" name="button2" id="button2" value="返回" onclick='history.go(-1);' class="editor">
                           <%-- <input type="submit" name="button2" id="button2" value="返回" onclick=' $.close("A_id");' class="editor">--%>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
