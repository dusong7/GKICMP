<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseEdit.aspx.cs" Inherits="GKICMP.purchase.PurchaseEdit" %>

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
            //var c = document.getElementById("txt_PDesc").value;
            //if (a == "" || b == "" || c == "")
            if (a == "" || b == "") {
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
            var pesti = document.getElementById("txt_PEstimate").value;
            return openbox('S_id', 'PurchaseBillAdd.aspx?pid=' + pid + '&pestimate=' + pesti, '', 800, 300, 64);
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
        .auto-style1 {
            height: 31px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_PID" />
        <asp:Button ID="btn_Search" runat="server" Text="Button" OnClick="btn_Search_Click" Style="display: none" />
        <asp:HiddenField runat="server" ID="hf_Audit" Value="false" />
        <asp:HiddenField runat="server" ID="hf_Bill" Value="false" />
        <%--<asp:ImageButton ID="btn_Search" runat="server" OnClick="imgbtn_inquiry_Click" Style="display: none" />--%>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <td align="right">采购名称：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_PTitle" runat="server" datatype="*" nullmsg="请填写采购名称"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                         <td align="right">概算</td>
                        <td align="left">
                            <asp:TextBox ID="txt_PEstimate" runat="server" datatype="money" errormsg="请填写概算"></asp:TextBox>(单位:元) 
                            <span style="color: Red; float: none">*</span> 
                        </td>
                    </tr>

                     <tr>
                        <td align="right">备注：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_PDesc" runat="server" CssClass="searchbg" Height="70px" Style="resize: none" Rows="6" TextMode="MultiLine" Width="90%"></asp:TextBox>
                            <%--<span style="color: Red; float: none">*</span> --%>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="4" align="left" style="border-top: 1px solid #3fa96b;border-bottom: #e4e4e4 0px solid;">采购明细</th>
                    </tr>
                    <tr>
                        <td align="left" colspan="4">
                            <img src="../images/addfile1.gif" onclick="addbill()" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4">
                            <table width="99%" id="tb_Right" style="border: 1px">
                                <tr style="text-align: center">
                                    <td style="font-weight: bold;">名称
                                    </td>
                                    <td style="font-weight: bold;">规格型号
                                    </td>
                                    <td style="font-weight: bold;">单价
                                    </td>
                                    <td style="font-weight: bold;">数量
                                    </td>
                                    <td style="font-weight: bold;">合计
                                    </td>
                                    <td style="font-weight: bold; width: 5%">操作
                                    </td>
                                </tr>
                                <asp:Repeater runat="server" ID="rp_BList">
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center"><%#Eval("BName") %></td>
                                       <%--     <asp:HiddenField ID="hf_BID" runat="server" Value='<%#Eval("BID") %>' />--%>
                                            <td align="center"><%#Eval("BModel") %></td>
                                            <td align="center"><%#Eval("BPrice") %></td>
                                            <td align="center"><%#Eval("BCount") %></td>
                                            <td align="center"><%#GetPrice(Eval("BPrice"),Eval("BCount")) %></td>
                                            <td align="center">
                                                <asp:LinkButton ID="lbtn_BDelete" runat="server" ToolTip="删除" CommandArgument='<%#Eval("BID") %>' OnClientClick="return confirm('确认删除选中信息');" OnClick="lbtn_BDelete_Click">
                                                    <img src="../images/d13.png" />
                                                </asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr runat="server" id="tr_All">
                                    <td colspan="4"></td>
                                    <td align="center">总计：<asp:Literal runat="server" ID="ltl_AllPrice"></asp:Literal></td>
                                    <td></td>
                                </tr>
                                <tr runat="server" id="tr_null">
                                    <td colspan="6" align="center">暂无记录</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                   
                   
                     <tr runat="server" id="traudit">
                        <td align="right" class="auto-style1">采购审核人：</td>
                        <td align="left" colspan="3" class="auto-style1">
                            <asp:Repeater ID="rp_List" runat="server">
                                <ItemTemplate>
                                    <span><%#Eval("RealName") %>
                                        <asp:LinkButton ID="lbtn_Delete" OnClientClick="return  confirm('您确认删除选中的信息吗？');" CommandArgument='<%#Eval("PAID")%>' runat="server" OnClick="lbtn_Delete_Click"><img src="../images/del.png" /></asp:LinkButton>
                                    </span>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Literal runat="server" ID="ltl_Name" Text="暂无人员"></asp:Literal>
                            <img src="../images/selectbtn.png" onclick="return showbox();" />
                            <span style="color: Red; float: none">*</span> 
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" align="center">
                            <asp:Button ID="btn_Submit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Submit_Click" />
                            <input type="button" name="button" id="cancell" value="返回" class="editor" onclick=' $.close("A_id");' />
                            <%-- <input type="button" class="submit" value="打印" onclick="print()" />--%>
                            <%--<asp:Button ID="btn_OutPut" runat="server" Text="打印" CssClass="submit" OnClick="btn_OutPut_Click" />--%>
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


