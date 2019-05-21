<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseAudit.aspx.cs" Inherits="GKICMP.purchase.PurchaseAudit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园教务管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
    <style>
        .listinfo td {
            line-height: 30px;
        }

        .listinfo tr:nth-child(2n+1) td {
            background: none;
        }

        table tr:last-child td {
            border-bottom: #e4e4e4 1px solid;
        }

        table tr td:last-child {
            border-right: #e4e4e4 1px solid;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_PID" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <td align="right">采购名称：</td>
                        <td>
                            <asp:Literal ID="ltl_PTitle" runat="server"></asp:Literal>
                        </td>
                        <td align="right">概算</td>
                        <td>
                            <asp:Literal ID="ltl_PEstimate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td colspan="3">
                            <asp:Literal ID="ltl_PDesc" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                           <th colspan="4" align="left" style="border-top: 1px solid #3fa96b;border-bottom: #e4e4e4 0px solid;">采购明细</th>
                    </tr>
                    <tr>
                        <td align="left" colspan="4">
                            <table width="99%" id="tb_Right" style="border: 1px">
                                <tr style="text-align: center">
                                    <td style="font-weight: bold;">名称</td>
                                    <td style="font-weight: bold;">规格型号</td>
                                    <td style="font-weight: bold;">单价</td>
                                    <td style="font-weight: bold;">数量</td>
                                    <td style="font-weight: bold;">原因</td>
                                </tr>
                                <asp:Repeater runat="server" ID="rp_BList">
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center"><%#Eval("BName") %></td>
                                            <td align="center"><%#Eval("BModel") %></td>
                                            <td align="center"><%#Eval("BPrice") %></td>
                                            <td align="center"><%#Eval("BCount") %></td>
                                            <td align="center" title='<%#Eval("BReason") %>' style="cursor: pointer"><%#Eval("BReason").ToString().Length>20?Eval("BReason").ToString().Substring(0,20)+"…":Eval("BReason").ToString() %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr runat="server" id="tr_null">
                                    <td colspan="5" align="center">暂无记录</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">审核结果：</td>
                        <td align="left" colspan="3">
                            <asp:DropDownList ID="ddl_AuditResult" runat="server">
                            </asp:DropDownList>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">审核意见：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_AuditMark" runat="server" CssClass="searchbg" Height="100px" Rows="6" Style="resize: none" TextMode="MultiLine" Width="90%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="5" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="return Check()" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="返回" class="editor" onclick=' $.close("A_id");' />
                            <%-- <asp:Button ID="btn_Cancel" runat="server" Text="返回" CssClass="editor" OnClick="btn_Cancel_Click" />--%>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
    <script>
        function Check() {
            var a = jQuery("#ddl_AuditResult").val();
            var b = document.getElementById("txt_AuditMark").value;
            if (b == "") {
                if (a != 2) {
                    alert("审核意见不能为空");
                    $("#txt_AuditMark").focus();
                    return false;
                }
            }
        }
    </script>
</body>
</html>



