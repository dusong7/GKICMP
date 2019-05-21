<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AfficheEdit.aspx.cs" Inherits="GKICMP.oamanage.AfficheEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />
    
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/js.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>

    <script type="text/javascript">
        $(function () {
            jQuery("#form1").Validform();//验证控件
            $("select#ddl_AType").change(function () {
                var a = $(this).val();
                var url = "../ashx/UserList.ashx?method=GetGroupUser";
               
            });
        });
        function setValue() {
            //var val = $('#Series').combotree('getValues');             获取包含上级id的集合
            //document.getElementById("hf_TID").value = val;
            var U = new Array();                                                                                     //获取选中的不包含上级id的集合
            $($("#Series").combotree("tree").tree("getChecked")).each(function () {
                if (this.children == null && $("#Series").combotree("tree").tree("find", this.id) != null) {
                    U.push(this.id);
                    document.getElementById("hf_TID").value = $.unique(U);
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal ID="ltl_Content" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField ID="hf_TID" runat="server" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">通知公告</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">公告标题：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_AfficheTitle" runat="server" Width="70%" datatype="*" nullmsg="请填写公告标题" CssClass="searchbg" Style="resize: none" TextMode="MultiLine"
                                MaxLength="200"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>

                    </tr>
                    <tr>
                        <td align="right" width="120">公告类型：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_AType" runat="server" datatype="ddl" errormsg="请选择公告类型"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">是否公示：</td>
                        <td align="left" colspan="3">
                            <style>
                                .edilab label {
                                    float: none;
                                }

                                .edilab input {
                                    height: 13px;
                                }
                            </style>
                            <asp:RadioButtonList ID="rbl_IsDisplay" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="edilab">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr id="aa" runat="server">
                        <td align="right" width="120">接收人：</td>
                        <td align="left" colspan="3">
                            <%--<asp:TextBox ID="txt_Accept" runat="server" Width="70%" CssClass="searchbg" class="easyui-combotree"  Style="resize: none" TextMode="MultiLine" Columns="6" Height="100px"></asp:TextBox>--%>
                            <input id="Series" name="Series" style="width: 85%; height: 80px" class="easyui-combotree" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">公告内容：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_AContent" runat="server" datatype="*" nullmsg="请输入公告内容" Width="70%" CssClass="searchbg" Style="resize: none" TextMode="MultiLine" Columns="6" Height="100px"></asp:TextBox><span style="color: Red; float: none">*</span></td>

                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" OnClientClick='setValue()' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

