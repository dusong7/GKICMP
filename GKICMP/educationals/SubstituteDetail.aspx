<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubstituteDetail.aspx.cs" Inherits="GKICMP.educationals.SubstituteDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });

    </script>
    <style>
        .edilab label {
            float: none;
        }

        .edilab input {
            height: 13px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_face" runat="server" Value="" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">代课信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">代课人：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_SubUserName" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="120">代课日期：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_SubDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">代课课程：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_SubCoruse" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="120">节次：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_SubNum" runat="server"></asp:Literal>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" width="120">请假人：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_AbsentUser" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="120">节数：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_SubCount" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">代课班级别名：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_OtherName" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="120">课时系数：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_Hourse" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">创建人：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_CreateUserName" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="120">创建日期：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_CreateDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr id="audit" runat="server">
                        <td align="right" width="120">状态：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_SubState" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr id="Tr1" runat="server">
                        <td align="right" width="120">原因：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_Reason" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <%--<asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />--%>
                            <input type="button" name="button" id="cancell" value="返回" class="editor" onclick=' $.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
