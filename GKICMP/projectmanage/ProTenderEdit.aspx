<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProTenderEdit.aspx.cs" Inherits="GKICMP.projectmanage.ProTenderEdit" %>

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
                        <th colspan="4" align="left">招标信息</th>
                    </tr>
                    <tr>

                        <td align="right">标书编号</td>
                        <td align="left" colspan="3">
                            <asp:TextBox runat="server" ID="txt_BidNumber" Width="70%" datatype="*" nullmsg="请填写编号"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
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
                            <%--<div class="sel" style="float: left">--%>
                                <asp:DropDownList ID="ddl_ProName" Width="70%" datatype="ddl" nullmsg="请选择项目" runat="server"></asp:DropDownList>
                                <span style="color: Red; float: none">*</span>
                            <%--</div>--%>
                        </td>
                        <td align="right">供应商</td>
                        <td align="left">
                            <%--<div class="sel" style="float: left">--%>
                                <asp:DropDownList ID="ddl_SName" Width="70%" runat="server" datatype="ddl" nullmsg="请选择供应商"></asp:DropDownList>
                                <span style="color: Red; float: none">*</span>
                            <%--</div>--%>
                        </td>

                    </tr>
                    <tr>
                        <td align="right">中标日期</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BDate" runat="server" onclick="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请选择中标日期"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">中标金额</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BAmount" runat="server" datatype="money" nullmsg="请填写中标金额"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>

                    </tr>

                    <tr>
                        <td align="right">开始实施日期</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BSDate" runat="server" onclick="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请选择开始日期"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" valign="top" class="note">结束日期</td>
                        <td>
                            <asp:TextBox runat="server" ID="txt_BEDate" onclick="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请选择结束日期"></asp:TextBox><span style="color: Red; float: none">*</span>
                        </td>

                    </tr>
                    <tr>
                        <td align="right" valign="top" class="note">保证金日期</td>
                        <td>
                            <asp:TextBox runat="server" ID="txt_BondDate" onclick="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请选择中标日期"></asp:TextBox><span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" valign="top" class="note">保证金</td>
                        <td>
                            <asp:TextBox runat="server" ID="txt_Bond" datatype="money" nullmsg="请填写保证金额"></asp:TextBox><span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="note">备注</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_PTDesc" TextMode="MultiLine" Rows="6" runat="server" Width="90%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' /></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>






