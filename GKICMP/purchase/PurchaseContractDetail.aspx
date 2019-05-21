<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseContractDetail.aspx.cs" Inherits="GKICMP.purchase.PurchaseContractDetail" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <title>教装项目采购申请</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/select.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left" class="auto-style1">合同信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">采购项目</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_PID" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">合同名称</td>
                        <td align="left" colspan="3">
                             <asp:Literal ID="ltl_Name" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">合同编号</td>
                        <td align="left" colspan="3" >
                             <asp:Literal ID="ltl_BidNumber" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">甲方</td>
                        <td align="left">
                             <asp:Literal ID="ltl_PartyA" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="120">乙方</td>
                        <td align="left">
                             <asp:Literal ID="ltl_PartyB" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="note">签订日期</td>
                        <td>
                             <asp:Literal ID="ltl_SignDate" runat="server"></asp:Literal>
                        </td>
                        <td align="right" valign="top" class="note">合同价格</td>
                        <td>
                             <asp:Literal ID="ltl_Price" runat="server"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="note">施工工期</td>
                        <td colspan="3">
                             <asp:Literal ID="ltl_StartTime" runat="server"></asp:Literal><span style="color: red">天</span>
                        </td>

                    </tr>
                     <tr>
                        <td align="right" valign="top" class="note">维保周期</td>
                        <td >
                             <asp:Literal ID="ltl_ServerYears" runat="server"></asp:Literal><span style="color: red">年</span>
                        </td>
                          <td align="right" valign="top" class="note">维保开始日期</td>
                        <td >
                             <asp:Literal ID="ltl_ServerDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="note">维保联系人</td>
                        <td >
                             <asp:Literal ID="ltl_ServerLinkUser" runat="server"></asp:Literal>
                        </td>
                          <td align="right" valign="top" class="note">维保联系方式</td>
                        <td >
                             <asp:Literal ID="ltl_ServerPhone" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                         <asp:Literal ID="Literal13" runat="server"></asp:Literal>
                        <td align="right" valign="top" class="note">备注</td>
                        <td colspan="3">
                             <asp:Literal ID="ltl_PCDesc" runat="server"></asp:Literal>
                        </td>
                    </tr>
                     <tr>
                        <td align="right">附件：</td>
                        <td colspan="3">
                            <table>
                                <asp:Repeater ID="rp_File" runat="server" OnItemCommand="rpaccess_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="lbtn_load" CommandArgument='<%#Eval("AccessID") %>' CommandName="load"
                                                    runat="server"><%# Eval("AccessName")%></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            
                            <input type="button" name="button" id="cancell" value="返回" class="editor" onclick=' $.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>









