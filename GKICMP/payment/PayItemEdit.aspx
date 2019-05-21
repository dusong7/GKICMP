<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayItemEdit.aspx.cs" Inherits="GKICMP.payment.PayItemEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/ImgPreview.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_face" runat="server" Value="" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">缴费项信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">缴费项名称</td>
                        <td align="left">
                            <asp:TextBox ID="txt_PayName" runat="server" CssClass="searchbg" datatype="*" nullmsg="请输入缴费项名称"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right" width="120">金额</td>
                        <td align="left">
                            <asp:TextBox ID="txt_PayCount" runat="server" CssClass="searchbg" datatype="sum" nullmsg="请输入正确的金额"
                                MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>

                    <tr>
                        <td align="right" width="120">启用日期</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_Begin" runat="server" Style="width: 85px" datattype="*" nullmsg="请选择启用日期" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <%--<td align="right" width="120">停用日期</td>
                        <td align="left">
                            <asp:TextBox ID="txt_End" runat="server" Style="width: 85px" datatype="*" nullmsg="请选择停用日期" ckdate="txt_Begin" errormsg="停用日期不能小于启用日期" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>--%>
                    </tr>

                    <%--<tr>
                        <td align="right" width="120">是否停用：</td>
                        <td align="left" colspan="3">
                            <style>
                                .edilab label {
                                    float: none;
                                }

                                .edilab input {
                                    height: 13px;
                                }
                            </style>
                            <asp:RadioButtonList ID="rbl_IsDisable" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="edilab"></asp:RadioButtonList>
                        </td>
                    </tr>--%>



                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                        </td>
                    </tr>

                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

