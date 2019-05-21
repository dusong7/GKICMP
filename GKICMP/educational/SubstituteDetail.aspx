<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubstituteDetail.aspx.cs" Inherits="GKICMP.educational.SubstituteDetail" %>

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
                        <th colspan="4" align="left">调课信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">调课人：</td>
                        <td align="left" width="400px;">
                            <asp:Literal ID="ltl_ApplyUserName" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="120">被调课人：</td>
                        <td align="left" width="400px;">
                             <asp:Literal ID="ltl_SubUserName" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">调课时间：</td>
                        <td align="left">
                             <asp:Literal ID="ltl_SubBegin" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="120">被调课时间：</td>
                        <td align="left">
                             <asp:Literal ID="ltl_SubBegin1" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">调课课程：</td>
                        <td align="left">
                             <asp:Literal ID="ltl_SubCoruseName" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="120">被调课课程：</td>
                        <td align="left">
                             <asp:Literal ID="ltl_SubCoruseName1" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">调课节次：</td>
                        <td align="left">
                             <asp:Literal ID="ltl_SubName" runat="server"></asp:Literal>
                        </td>
                         <td align="right" width="120">被调课节次：</td>
                        <td align="left">
                             <asp:Literal ID="ltl_SubName1" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120" >调课原因：</td>
                        <td align="left" colspan="3">
                             <asp:Literal ID="ltl_ApplyReason" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">调课状态：</td>
                        <td align="left">
                             <asp:Literal ID="ltl_SubState" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="120">申请时间：</td>
                        <td align="left">
                             <asp:Literal ID="ltl_ApplyDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                     <tr id="audit" runat="server">
                        <td align="right" width="120">审核人：</td>
                        <td align="left">
                             <asp:Literal ID="ltl_AuditUserName" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="120">审核时间：</td>
                        <td align="left">
                             <asp:Literal ID="ltl_AuditDate" runat="server"></asp:Literal>
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



