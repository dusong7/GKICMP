<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoiceEdit.aspx.cs" Inherits="GKICMP.invoice.InvoiceEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../EasyUI/jquery.easyui.min.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });

        function getfile() {
            var hfface = $id("hf_UpFile");
            var divone = $id("more").getElementsByTagName("input");
            hfface.value = divone.length;
        }

        function showbox() {
            var iid = document.getElementById("hf_IID").value;
            var accountunit = document.getElementById("txt_AccountUnit").value;
            var createdate = document.getElementById("txt_CreateDate").value;
            var invmodel = document.getElementById("ddl_InvModel").value;
            var desc = document.getElementById("txt_AduitUser").value;
            if (accountunit == "" || createdate == "" || invmodel == "" || desc == "") {
                alert("录入信息之前，请先录入带*的必填项。");
                return;
            }
            else {
                return parent.openbox('Add_id', 'InvoiceInfoEdit.aspx', 'iid=' + iid, 860, 400, -1);
            }
        }
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
        <asp:ImageButton ID="btnsear" runat="server" OnClick="imgbtn_inquiry_Click" Style="display: none" />
        <asp:HiddenField runat="server" ID="hf_IID" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">报销信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100">报销单位：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_AccountUnit" runat="server" datatype="*1-200" nullmsg="请填写报销单位" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="100">报销日期：</td>
                        <td>
                            <asp:TextBox runat="server" ID="txt_CreateDate" onclick="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请填写报销日期"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <%--<td align="right" width="100">报销类别：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_InvType" datatype="ddl" errormsg="请选择报销类别"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>--%>
                        <td align="right" width="100">报销方式：</td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_InvModel" datatype="ddl" errormsg="请选择报销方式"></asp:DropDownList>
                            <span style="color: red;">*</span>
                        </td>
                        <%--<td align="right">合计金额：</td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_CID" datatype="ddl" errormsg="请选择校区"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>--%>
                        <td align="right">是否签字：</td>
                        <td colspan="3">
                            <asp:RadioButtonList runat="server" ID="rdo_IsSign" CssClass="edilab" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1" Selected>是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">审批人：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox runat="server" ID="txt_AduitUser" TextMode="MultiLine" Width="70%" Height="50px" datatype="*" nullmsg="请填写审批人"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_InvoiceDesc" runat="server" TextMode="MultiLine" Height="50px" Width="70%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">报销项目：
                        </td>
                        <td colspan="3">
                            <table width="99%" class="border-r">
                                <tr>
                                    <td colspan="5">
                                        <img src="../images/addfile.gif" id="btn_add1" onclick="showbox()" />
                                        &nbsp;&nbsp; <span style="color: Red">注：录入信息之前，请先录入带*的必填项。</span></td>
                                </tr>
                                <tr style="text-align: center; color: #2b8e48; font-weight: bold;">
                                    <td style="width: 20%">序号</td>
                                    <td style="width: 20%">摘要
                                    </td>
                                    <td style="width: 20%">张数
                                    </td>
                                    <td style="width: 20%">金额
                                    </td>
                                    <td style="width: 5%">操作</td>
                                </tr>
                                <asp:Repeater runat="server" ID="rp_List1">
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center"><%#Eval("INum") %></td>
                                            <td align="center"><%#Eval("InvDesc").ToString().Length>20?Eval("InvDesc").ToString().Substring(0,20)+"...":Eval("InvDesc") %></td>
                                            <td align="center"><%#Eval("InvoiceCount") %></td>
                                            <td align="center"><%#Eval("InvoiceCash") %>
                                                <asp:HiddenField runat="server" ID="hf_Cash" Value='<%#Eval("InvoiceCash") %>' />
                                            </td>
                                            <td align="center">
                                                <asp:ImageButton ID="imbtn_Delete" ImageUrl="../images/d13.png" runat="server" Width="16px" Height="16px"
                                                    OnClick="imbtn_Delete_Click" CommandArgument='<%#Eval("InfoID")%>' OnClientClick="return confirm('您确认删除报销项目吗？');" />
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
                        <td align="right">附件：</td>
                        <td colspan="3">
                            <table>
                                <asp:Repeater ID="rp_File" runat="server" OnItemCommand="rpaccess_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="lbtn_load" CommandArgument='<%#Eval("AccessID") %>' CommandName="load"
                                                    runat="server"><%# Eval("AccessName")%></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ibtn_del" runat="server" ImageUrl="~/images/sq.png" CommandArgument='<%#Eval("AccessID") %>'
                                                    CommandName="del" OnClientClick='<%#"return delmessage(\"【"+Eval("AccessName")+"】\")" %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                            <div id="more">
                                <asp:FileUpload ID="fl_UpFile" runat="server" onchange="if(this.value)judge(this.value,this);" />
                                <img src="../images/addfile.gif" alt="" style='cursor: pointer; margin-bottom: -3px'
                                    onclick="addfile('more')" />
                            </div>
                            <asp:HiddenField ID="hf_UpFile" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" OnClientClick="return getfile()" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

