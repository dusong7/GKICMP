<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetAccountEdit.aspx.cs" Inherits="GKICMP.assetmanage.AssetAccountEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园学生管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <link href="../css/easyui.css" rel="stylesheet" />
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        $(function () {
            //$('#Series').combotree({
            //    onSelect: function (node) {
            //        var val = node.id;
            //        document.getElementById("hf_TID").value = val;
            //        document.getElementById("hf_TIDName").value = node.text;
            //        //alert(val);
            //    }
            //});

            jQuery("#form1").Validform();//验证控件
        });

        function showbox(aitype) {
            //var tid = document.getElementById("hf_TID").value;
            var accbegin = document.getElementById("txt_AccBegin").value;
            var accend = document.getElementById("txt_AccEnd").value;
            var accgroup = document.getElementById("txt_AccGroup").value;
            //if (tid.length <= 0 || accbegin == "" || accend == "" || accgroup == "") {
            if (accbegin == "" || accend == "" || accgroup == "") {
                alert("录入信息之前，请先录入带*的必填项。");
                return;
            }
            else {
                var aaid = document.getElementById("hf_AAID").value;
                return parent.openbox('Add_id', 'AssetAccountInfoEdit.aspx', 'aaid=' + aaid + '&aitype=' + aitype, 860, 400, -1);
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
        <asp:Literal ID="ltl_Content" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField runat="server" ID="hf_AAID" />
        <asp:HiddenField ID="hf_TID" runat="server" />
        <asp:HiddenField ID="hf_TIDName" runat="server" />
        <asp:ImageButton ID="btnsear" runat="server" OnClick="imgbtn_inquiry_Click" Style="display: none" />
        <div class="listcent pad0">

            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">资产盘点信息</th>
                    </tr>
                    <tr>
                        <td align="right">负责人：</td>
                        <td align="left">
                            <%--<input id="Series" name="Series" class="easyui-combotree" runat="server" />--%>
                            <asp:DropDownList ID="ddl_FZR" runat="server"></asp:DropDownList><span style="color: Red; float: none">*</span></td>
                        <td align="right">盘点日期：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_AccBegin" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请选择盘点开始日期"></asp:TextBox>--
                            <asp:TextBox ID="txt_AccEnd" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请选择盘点结束日期" ckdate="txt_AccBegin"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">主要成员：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_AccGroup" runat="server" Style="width: 85%;" datatype="*" nullmsg="请填写主要成员"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <%--<tr>
                        <td align="right">盘点类型：</td>
                        <td colspan="3">
                            <asp:RadioButtonList runat="server" ID="rdo_AAFlag" CssClass="edilab" RepeatLayout="Flow" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdo_AAFlag_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="1" Selected="True">全部盘点</asp:ListItem>
                                <asp:ListItem Value="2">部门盘点</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>--%>
                    <tr runat="server" id="tr_Dep" visible="false">
                        <td align="right">盘点部门：
                        </td>
                        <td colspan="3">
                            <asp:DropDownList runat="server" ID="ddl_DepID" datatype="ddl" errormsg="请选择盘点部门"></asp:DropDownList>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">有账无物：</td>
                        <td colspan="3">
                            <table width="99%" class="border-r">
                                <tr>
                                    <td colspan="5">
                                        <img src="../images/addfile.gif" id="btn_add1" onclick="showbox(1)" />
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
                                <asp:Repeater runat="server" ID="rp_List1">
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
                                <tr runat="server" id="tr_null1">
                                    <td colspan="5" style="text-align: center">暂无记录</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">有物无账：</td>
                        <td colspan="3">
                            <table width="99%" class="border-r">
                                <tr>
                                    <td colspan="5">
                                        <img src="../images/addfile.gif" id="btn_add2" onclick="showbox(2)" />
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
                                <asp:Repeater runat="server" ID="rp_List2">
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
                                <tr runat="server" id="tr_null2">
                                    <td colspan="5" style="text-align: center">暂无记录</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="140px">固定资产清查情况说明：</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_AccDesc" runat="server" TextMode="MultiLine" Rows="6" Style="width: 85%; height: 100px"></asp:TextBox>
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


