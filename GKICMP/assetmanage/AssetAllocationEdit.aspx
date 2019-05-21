<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetAllocationEdit.aspx.cs" Inherits="GKICMP.assetmanage.AssetAllocationEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园学生管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        $(function () {
            jQuery("#form1").Validform();//验证控件
        });

        function showbox() {
            var flag = $("#hf_Flag").val();

            if (flag == 1) {
                var OutUser = document.getElementById("txt_OutUser").value;
                var AcceptUser = document.getElementById("txt_AcceptUser").value;
                var OutDep = document.getElementById("txt_OutDep").value;
                var InDep = document.getElementById("txt_InDep").value;
                var AllocationDate = document.getElementById("txt_AllocationDate").value;
                if (OutUser == "" || AcceptUser == "" || OutDep == "" || InDep == "" || AllocationDate == "") {
                    alert("录入信息之前，请先录入带*的必填项。");
                    return;
                }
                else {
                    var aaid = document.getElementById("hf_AAID").value;
                    return parent.openbox('Add_id', 'AssetAccountInfoEdit.aspx', 'aaid=' + aaid + '&aitype=3', 860, 400, -1);
                }
            }
            else {
                var txt_AcceptDep = document.getElementById("txt_AcceptDep").value;
                var txt_data = document.getElementById("txt_data").value;
                if (txt_AcceptDep == "" || txt_data == "") {
                    alert("录入信息之前，请先录入带*的必填项。");
                    return;
                }
                else {
                    var aaid = document.getElementById("hf_AAID").value;
                    return parent.openbox('Add_id', 'AssetAccountInfoEdit.aspx', 'aaid=' + aaid + '&aitype=4', 860, 400, -1);
                }
            }

        }
    </script>
    <style>
        .border-r td:last-child {
            border-right: 1px solid #e4e4e4;
        }

        .listinfo tr:nth-child(2n+1) td {
            background: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_AAID" />
        <asp:HiddenField ID="hf_Flag" runat="server" />
        <asp:ImageButton ID="btnsear" runat="server" OnClick="btnsear_Click" Style="display: none" />
        <div class="listcent pad0">

            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">
                            <asp:Literal ID="ltl_bt" runat="server"></asp:Literal></th>
                    </tr>
                    <div id="div1" runat="server">
                        <tr>
                            <td align="right">移交人：</td>
                            <td align="left">
                                <asp:TextBox ID="txt_OutUser" runat="server" datatype="*" nullmsg="请输入移交人"></asp:TextBox>
                                <span style="color: Red; float: none">*</span></td>
                            <td align="right">接收人：</td>
                            <td align="left">
                                <asp:TextBox ID="txt_AcceptUser" runat="server" datatype="*" nullmsg="请输入接收人"></asp:TextBox>
                                <span style="color: Red; float: none">*</span></td>
                        </tr>
                        <tr>
                            <td align="right">调出单位：</td>
                            <td align="left">
                                <asp:TextBox ID="txt_OutDep" runat="server" datatype="*" nullmsg="请输入调出单位"></asp:TextBox>
                                <span style="color: Red; float: none">*</span></td>
                            <td align="right">调入单位：</td>
                            <td align="left">
                                <asp:TextBox ID="txt_InDep" runat="server" datatype="*" nullmsg="请输入调入单位"></asp:TextBox>
                                <span style="color: Red; float: none">*</span></td>
                        </tr>
                        <tr>
                            <td align="right">调拨日期：</td>
                            <td align="left" colspan="3">
                                <asp:TextBox ID="txt_AllocationDate" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请选择调拨日期"></asp:TextBox>
                                <span style="color: Red; float: none">*</span></td>
                        </tr>
                    </div>
                    <div id="div2" runat="server">
                        <tr id="tr_acceptdep">
                            <td align="right">接收部门：</td>
                            <td align="left">
                                <asp:TextBox ID="txt_AcceptDep" runat="server" datatype="*" nullmsg="请输入接收部门"></asp:TextBox>
                                <span style="color: Red; float: none">*</span></td>
                            <td align="right">退回日期：</td>
                            <td align="left" colspan="3">
                                <asp:TextBox ID="txt_data" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请选择退回日期"></asp:TextBox>
                                <span style="color: Red; float: none">*</span></td>
                        </tr>
                    </div>
                    <tr>
                        <td align="right">资产信息：</td>
                        <td colspan="3">
                            <table width="99%" class="border-r">
                                <tr>
                                    <td colspan="5">
                                        <img src="../images/addfile.gif" id="btn_add" onclick="showbox()" />
                                        &nbsp;&nbsp; <span style="color: Red">注：录入信息之前，请先录入带*的必填项。</span></td>
                                </tr>
                                <tr style="text-align: center; color: #2b8e48; font-weight: bold;">
                                    <td style="width: 20%">资产名称</td>
                                    <td style="width: 20%">数量
                                    </td>
                                    <td style="width: 20%">计量单位
                                    </td>
                                    <td style="width: 20%">评估净值(元)
                                    </td>
                                    <td style="width: 5%">操作</td>
                                </tr>
                                <asp:Repeater runat="server" ID="rp_List">
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center"><%#Eval("AccName") %></td>
                                            <td align="center"><%#Eval("AccNum") %></td>
                                            <td align="center"><%#Eval("AccUnitName") %></td>
                                            <td align="center"><%#Eval("AccountCash") %></td>
                                            <td align="center">
                                                <asp:ImageButton ID="imbtn_Delete" ImageUrl="../images/d13.png" runat="server" Width="16px" Height="16px"
                                                    OnClick="imbtn_Delete_Click" CommandArgument='<%#Eval("AAIID")%>' OnClientClick="return  confirm('您确认删除资产信息吗？');" />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr runat="server" id="tr_null">
                                    <td colspan="5" style="text-align: center">暂无记录</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="140px">说明：</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_AllDesc" runat="server" TextMode="MultiLine" Rows="6" Style="width: 99%; height: 100px; resize: none;"></asp:TextBox>
                        </td>
                    </tr>
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



