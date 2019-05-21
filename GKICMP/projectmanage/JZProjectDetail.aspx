<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JZProjectDetail.aspx.cs" Inherits="GKICMP.projectmanage.JZProjectDetail" %>

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
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">教装项目采购申请详情</th>
                    </tr>
                    <tr>
                        <td align="right">项目名称</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_ProName" runat="server"></asp:Literal>
                        </td>
                        <%--<td align="right">申报单位</td>
                        <td align="left">
                             <div class="sel" style="float: left">
                                <asp:DropDownList ID="ltl_Depart" runat="server">
                                </asp:DropDownList>
                            </div>
                        </td>--%>
                    </tr>
                    <tr>
                        <td align="right">资金来源</td>
                        <td align="left">
                            <asp:Literal ID="ltl_Financed" runat="server"></asp:Literal>
                        </td>
                        <td align="right">项目概算</td>
                        <td align="left">
                            <asp:Literal ID="ltl_ProBudget" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">项目类型</td>
                        <td align="left">
                            <asp:Literal ID="ltl_ProType" runat="server"></asp:Literal>
                        </td>
                        <td align="right">项目内容</td>
                        <td align="left">
                            <asp:Literal ID="ltl_ProContent" runat="server"></asp:Literal>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" valign="top" class="note">建筑面积</td>
                        <td>
                            <asp:Literal ID="ltl_ProArea" runat="server"></asp:Literal>
                        </td>
                        <td align="right" valign="top" class="note">数量</td>
                        <td>
                            <asp:Literal ID="ltl_Amount" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="note">单位负责人</td>
                        <td>
                            <asp:Literal ID="ltl_DepPerson" runat="server"></asp:Literal>
                        </td>
                        <td align="right" valign="top" class="note">联系电话</td>
                        <td>
                            <asp:Literal ID="ltl_DepLinkno" runat="server"></asp:Literal>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" valign="top" class="note">审核状态</td>
                         <td colspan="3">
                            <asp:Literal ID="ltl_State" runat="server"></asp:Literal>
                        </td>
                        
                    </tr>

                    <tr>
                       <td align="right" valign="top" class="note">审核说明</td>
                        <td colspan="3">
                            <asp:Literal ID="ltl_StateDesc" runat="server"></asp:Literal>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" valign="top" class="note">备注</td>
                        <td colspan="3">
                            <asp:Literal ID="ltl_ProDesc" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    
                     <tr>
                        <td align="right">附件</td>
                        <td align="left" colspan="3">
                            <table>
                                <asp:Repeater ID="rp_File" runat="server" OnItemCommand="rpaccess_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="lbn_load" CommandArgument='<%#Eval("PCFile") %>' CommandName="load"
                                                    runat="server"><%#getFileName(Eval("PCFile").ToString())%></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>

                </tbody>
            </table>
        </div>
    </form>
</body>
</html>






