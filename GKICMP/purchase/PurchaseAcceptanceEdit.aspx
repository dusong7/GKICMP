<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseAcceptanceEdit.aspx.cs" Inherits="GKICMP.purchase.PurchaseAcceptanceEdit" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <title>采购申请</title>
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
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">采购项目验收</th>
                    </tr>
                    <tr>
                        <td align="right">项目名称</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_ProName" datatype="ddl" nullmsg="请选择项目" runat="server"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">验收内容：</td>
                        <td align="left">
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
                        <td align="right">综合评价：</td>
                        <td align="left">
                            <%--<asp:TextBox ID="txt_Evaluate" runat="server"  datatype="*" nullmsg="请填写综合评价"></asp:TextBox>--%>
                            <asp:DropDownList ID="ddl_Evaluate" datatype="ddl" nullmsg="请选择综合评价" runat="server"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="note">验收意见</td>
                        <td>
                            <asp:TextBox runat="server" ID="txt_Opinion" datatype="*" nullmsg="请填写验收意见"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="note">验收时间</td>
                        <td>
                            <asp:TextBox runat="server" ID="txt_PCDate" onclick="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请选择验收时间"></asp:TextBox><span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr runat="server" id="tr_file">
                        <td align="right">验收附件 </td>
                        <td align="left">
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
                            <asp:FileUpload ID="fl_UpFile" runat="server" onchange="if(this.value)judge(this.value,this);" />
                            <asp:HiddenField runat="server" ID="hf_file" />
                            <asp:HiddenField runat="server" ID="hf_RFile" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' /></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
