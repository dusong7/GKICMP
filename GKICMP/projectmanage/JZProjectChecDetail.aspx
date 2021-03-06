﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JZProjectChecDetail.aspx.cs" Inherits="GKICMP.projectmanage.JZProjectChecDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link href="../css/green_formcss.css" rel="stylesheet" />

    <script src="../js/jquery.min.js"></script>
    <script src="../js/input_custom.js"></script>
    <script src="../js/formcommon.js"></script>
    <script src="../js/jquery1.2.js"></script>
    <script src="../js/lrscroll.js"></script>
    <script src="../js/jquery.scripts.js"></script>
    <script src="../js/jquery.custom.js"></script>
    <style>
        .selecttd {
            float: left !important;
            position: relative;
        }

            .selecttd input {
                position: absolute;
                left: 0px;
                top: 14px;
            }

            .selecttd label {
                margin-left: 20px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" height="99%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">项目验收详情</th>
                    </tr>
                    <tr>
                        <td align="right">项目名称</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_PName" runat="server"></asp:Literal></td>
                    </tr>
                   
                    <tr>
                        <td align="right">验收内容</td>
                        <td align="left" colspan="3">
                            <span class="selecttd">
                                <asp:CheckBox ID="cb_BrandChecked" runat="server" Text="品牌场地是否正确" />
                            </span>
                            <span class="selecttd">
                                <asp:CheckBox ID="cb_SpecificationChecked" runat="server" Text="规格型号是否正确" /></span>
                            <span class="selecttd">
                                <asp:CheckBox ID="cb_ConfigChecked" runat="server" Text="配置是否正确" />
                            </span>
                            <span class="selecttd">
                                <asp:CheckBox ID="cb_CountChecked" runat="server" Text="数量是否正确" />
                            </span>
                            <span class="selecttd">
                                <asp:CheckBox ID="cb_DebuggingChecked" runat="server" Text="安装调试是否正常" /></span>
                            <span class="selecttd">
                                <asp:CheckBox ID="cb_GuaranteeChecked" runat="server" Text="是否有保修卡" /></span>
                            <span class="selecttd">
                                <asp:CheckBox ID="cb_PackingChecked" runat="server" Text="是否包装完好" />
                            </span>
                            <span class="selecttd">
                                <asp:CheckBox ID="cb_ContractChecked" runat="server" Text="是否签订合同" /></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">综合评价</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_Evaluate"></asp:Literal></td>
                       <%-- <td align="right">验收意见</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_Opinion"></asp:Literal>
                        </td>--%>
                    </tr>

                    <tr>
                         <td align="right">验收意见</td>
                        <td align="left" colspan="3">
                            <asp:Literal runat="server" ID="ltl_Opinion"></asp:Literal>
                        </td>
                    </tr>

                    <tr>
                        <td align="right">验收时间</td>
                        <td align="left" colspan="3">
                            <asp:Literal runat="server" ID="ltl_PCDate"></asp:Literal></td>
                       <%-- <td align="right">品牌产地是否正确</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_BrandChecked"></asp:Literal></td>--%>
                    </tr>
                   <%-- <tr>
                        <td align="right">规格型号是否正确</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_SpecificationChecked"></asp:Literal></td>
                        <td align="right">安装调试是否正常</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_DebuggingChecked"></asp:Literal></td>
                    </tr>

                    <tr>
                        <td align="right">数量是否正确</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_CountChecked"></asp:Literal></td>
                        <td align="right">配置是否正确</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_ConfigChecked"></asp:Literal></td>
                    </tr>

                    <tr>
                        <td align="right">是否有保修卡</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_GuaranteeChecked"></asp:Literal></td>
                        <td align="right">是否包装完好</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_PackingChecked"></asp:Literal></td>
                    </tr>

                    <tr>
                        <td align="right">是否签订合同</td>
                        <td align="left" colspan="3">
                            <asp:Literal runat="server" ID="ltl_ContractChecked"></asp:Literal></td>
                    </tr>--%>
                    <tr>
                        <td align="right">验收附件</td>
                        <td align="left" colspan="3">
                            <%-- <a href='<%=234 %>'><asp:Literal runat="server" ID="ltl_PCFile"></asp:Literal></a>--%>
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

                    <tr>
                        <td style="text-align: center" colspan="4">
                            <input type="submit" name="button2" id="button2" value="返回" onclick=' $.close("A_id");' class="editor">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
