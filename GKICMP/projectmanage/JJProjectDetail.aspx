<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JJProjectDetail.aspx.cs" Inherits="GKICMP.projectmanage.JJProjectDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>基建项目申报</title>
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
                    </tr>
                    <tr>
                        <td align="right">实施地点</td>
                        <td align="left">
                            <asp:Literal ID="ltl_BuildAddr" runat="server"></asp:Literal>
                        </td>
                        <td align="right">建设内容</td>
                        <td align="left">
                            <asp:Literal ID="ltl_BuildContent" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">建设性质</td>
                        <td align="left">
                            <asp:Literal ID="ltl_BuildNature" runat="server"></asp:Literal>
                        </td>
                        <td align="right">建筑面积</td>
                        <td align="left">
                            <asp:Literal ID="ltl_Acreage" runat="server"></asp:Literal>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" valign="top" class="note">层 数</td>
                        <td>
                            <asp:Literal ID="ltl_Layers" runat="server"></asp:Literal>
                        </td>
                        <td align="right" valign="top" class="note">结 构</td>
                        <td>
                            <asp:Literal ID="ltl_Structure" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="note">资金预算金额</td>
                        <td>
                            <asp:Literal ID="ltl_BudgetAmount" runat="server"></asp:Literal>
                        </td>
                        <td align="right" valign="top" class="note">资金来源</td>
                        <td>
                            <asp:Literal ID="ltl_BSources" runat="server"></asp:Literal>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" valign="top" class="note">项目责任人</td>
                        <td>
                            <asp:Literal ID="ltl_DutyUser" runat="server"></asp:Literal>
                        </td>
                        <td align="right" valign="top" class="note">项目责任人联系电话</td>
                        <td>
                            <asp:Literal ID="ltl_DutyNO" runat="server"></asp:Literal>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" valign="top" class="note">申请单位负责人</td>
                        <td>
                            <asp:Literal ID="ltl_Contractor" runat="server"></asp:Literal>
                        </td>
                        <td align="right" valign="top" class="note">单位负责人号码</td>
                        <td>
                            <asp:Literal ID="ltl_PhoneNumber" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="note">建设理由</td>
                        <td colspan="3">
                            <asp:Literal ID="ltl_BuildReason" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="right" valign="top" class="note">审核状态</td>
                         <td colspan="3">
                            <asp:Literal ID="ltl_AState" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                       <td align="right" valign="top" class="note">审核说明</td>
                        <td colspan="3">
                            <asp:Literal ID="ltl_AStateDesc" runat="server"></asp:Literal>
                        </td>
                    </tr>

                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
