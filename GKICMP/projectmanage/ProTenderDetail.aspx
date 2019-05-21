<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProTenderDetail.aspx.cs" Inherits="GKICMP.projectmanage.ProTenderDetail" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="utf-8">
    <title>教装项目采购申请</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">教装项目采购申请</th>
                    </tr>
                    <tr>

                        <td align="right">标书编号</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_BidNumber" runat="server"></asp:Literal>
                        </td>
                        <%--<td align="right">申报单位</td>
                        <td align="left">
                             <div class="sel" style="float: left">
                                <asp:DropDownList ID="ddl_Depart" runat="server">
                                </asp:DropDownList>
                            </div>
                        </td>--%>
                    </tr>
                    <tr>
                        <td align="right">项目名称</td>
                        <td align="left">
                            <asp:Literal ID="ltl_ProName" runat="server"></asp:Literal>
                        </td>
                        <td align="right">供应商</td>
                        <td align="left">
                            <asp:Literal ID="ltl_SName" runat="server"></asp:Literal>
                        </td>

                    </tr>
                    <tr>
                        <td align="right">中标日期</td>
                        <td align="left">
                            <asp:Literal ID="ltl_BDate" runat="server"></asp:Literal>
                        </td>
                        <td align="right">中标金额</td>
                        <td align="left">
                            <asp:Literal ID="ltl_BAmount" runat="server"></asp:Literal>
                        </td>

                    </tr>

                    <tr>
                        <td align="right">开始实施日期</td>
                        <td align="left">
                            <asp:Literal ID="ltl_BSDate" runat="server"></asp:Literal>
                        </td>
                        <td align="right" valign="top" class="note">结束日期</td> 
                        <td>
                            <asp:Literal ID="ltl_BEDate" runat="server"></asp:Literal>
                        </td>

                    </tr>
                    <tr>
                         <td align="right" valign="top" class="note">保证金</td>
                        <td>
                            <asp:Literal ID="ltl_Bond" runat="server"></asp:Literal>
                        </td>
                        <td align="right" valign="top" class="note">保证金日期</td>
                        <td>
                            <asp:Literal ID="ltl_BondDate" runat="server"></asp:Literal>
                        </td>
                       
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="note">保证金是否归还</td>
                        <td>
                            <asp:Literal ID="ltl_IsReturn" runat="server"></asp:Literal>
                        </td>
                        <td align="right" valign="top" class="note">归还日期</td>
                        <td>
                            <asp:Literal ID="ltl_IsReturnDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="note">备注</td>
                        <td colspan="3">
                            <asp:Literal ID="ltl_PTDesc" runat="server"></asp:Literal>
                        </td>
                    </tr>
                   
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>







