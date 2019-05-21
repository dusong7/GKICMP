<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseDetail.aspx.cs" Inherits="GKICMP.purchase.PurchaseDetail" %>

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
        function check() {
            var a = document.getElementById("txt_PTitle").value;
            var b = document.getElementById("txt_PEstimate").value;
            var c = document.getElementById("txt_PDesc").value;
            if (a == "" || b == "" || c == "") {
                return 1;
            }
            else { return 0; }
        }

        function showbox() {
            var pid = document.getElementById("hf_PID").value;
            var a = check();
            if (a == 1) {
                alert("请将带'*'的填写完整后选择审核人");
                return false;
            }
            else {
                return parent.openbox('S_id', 'PurchaseAuditUser.aspx', '&pid=' + pid + '&flag=1', 540, 350, 50);
            }
        }
        function addbill() {
            var pid = document.getElementById("hf_PID").value;
            return openbox('S_id', 'PurchaseBillAdd.aspx?pid=' + pid, '', 800, 300, 64);
        }
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
        <asp:Button ID="btn_Search" runat="server" Text="Button"  OnClick="btn_Search_Click" Style="display: none"/>
        <%--<asp:ImageButton ID="btn_Search" runat="server" OnClick="imgbtn_inquiry_Click" Style="display: none" />--%>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <td align="right" width="100px">采购名称：</td>
                        <td>
                            <asp:Literal ID="ltl_PTitle" runat="server"></asp:Literal>
                        </td>
                         <td align="right">概算</td>
                        <td>
                            <asp:Literal ID="ltl_PEstimate" runat="server"></asp:Literal> 
                        </td>
                    </tr>
                    <tr>
                        <td align="right">采购方式：</td>
                        <td colspan="3">
                            <asp:Literal ID="ltl_PType" runat="server"></asp:Literal>
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
                                     <td style="font-weight: bold;">合计</td>
                                    <td style="font-weight: bold;">原因</td>
                                </tr>
                                <asp:Repeater runat="server" ID="rp_BList" >
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center"><%#Eval("BName") %></td>
                                            <td align="center"><%#Eval("BModel") %></td>
                                            <td align="center"><%#Eval("BPrice") %></td>
                                            <td align="center"><%#Eval("BCount") %></td>
                                              <td align="center"><%#GetPrice(Eval("BPrice"),Eval("BCount")) %></td>
                                            <td align="center" title='<%#Eval("BReason") %>' style="cursor:pointer"><%#Eval("BReason").ToString().Length>20?Eval("BReason").ToString().Substring(0,20)+"…":Eval("BReason").ToString() %></td>

                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                 <tr runat="server" id="tr_All">
                                    <td colspan="4"></td>
                                    <td align="center">总计：<asp:Literal runat="server" ID="ltl_AllPrice"></asp:Literal></td>
                                    <td></td>
                                </tr>
                                <tr runat="server" id="tr_null">
                                    <td colspan="5" align="center">暂无记录</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                   
                    
                     
                     <tr>
                        <th colspan="4" align="left">审核信息
                        </th>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <table width="100%" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="rp_AList" runat="server">
                                    <ItemTemplate>
                                        <%
                                            if (count > 1)
                                            {   %>
                                        <tr>
                                            <td colspan="4"><%# Container.ItemIndex.ToString()=="0"?"第一":Container.ItemIndex.ToString()=="1"?"第二":Container.ItemIndex.ToString()=="2"?"第三":Container.ItemIndex.ToString()=="3"?"第四":"第五" %>审核人</td>
                                        </tr>
                                        <%} %>
                                        <tr>
                                            <td width="100px" align="center">审核人
                                            </td>
                                            <td>
                                                <%#Eval("RealName")%>
                                            </td>
                                            <td width="100px" align="center">审核日期
                                            </td>
                                            <td>
                                                <%#Eval("AuditDate", "{0:yyyy-MM-dd HH:mm}")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">审核结果
                                            </td>
                                            <td>
                                                <%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.AduitState>(Eval("AuditResult"))%>
                                            </td>
                                            <td align="center">审核意见
                                            </td>
                                            <td>
                                                <%#Eval("AuditMark")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr id="trnull" runat="server">
                                    <td colspan="4" align="center">暂无记录</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" align="center">
                           <input type="button" name="button" id="cancell" value="返回" class="editor" onclick=' $.close("A_id");' />
                           <%-- <asp:Button ID="btn_Cancel" runat="server" Text="返回" CssClass="editor" OnClick="btn_Cancel_Click" />--%>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
    <%-- <script>
        function print()
        {
            
            //document.body.innerHTML = document.getElementById('print').innerHTML;
            WindowPrint.execwb(7, 1);
            //window.print();

            //alert("打印");
        }
    </script>--%>
</body>
</html>



