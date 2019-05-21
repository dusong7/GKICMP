<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailEdit.aspx.cs" Inherits="GKICMP.mailmanage.EmailEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../utf8-net/ueditor.config.js"></script>
    <script src="../utf8-net/ueditor.all.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_face" runat="server" Value="" />
        <asp:HiddenField ID="hf_EID" runat="server" Value="" />
        <asp:HiddenField ID="hf_AcceptUser" runat="server" Value="" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span>邮件管理<span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="写信"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="6" align="left">写信</th>
                    </tr>
                    <tr>
                        <td align="right" width="70px">消息标题：
                        </td>
                        <td>
                            <asp:TextBox ID="txt_EmailTitle" Width="600px" CssClass="searchbg" datatype="*1-100" nullmsg="请填写消息标题" runat="server"></asp:TextBox>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">类型：</td>
                        <td>
                            <style>
                                .edilab label {
                                    float: none;
                                }

                                .edilab input {
                                    height: 13px;
                                }
                            </style>
                            <asp:RadioButtonList ID="rbl_EType" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="edilab" OnSelectedIndexChanged="rbl_IsorNo_SelectedIndexChanged">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr id="aa" runat="server">
                        <td align="right">发送对象：</td>
                        <td>
                            <input id="AllUsersID" name="AllUsersID" style="width: 70%;" class="easyui-combotree" runat="server" />
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">邮件内容</td>
                        <td align="left" colspan="5" style="line-height: 20px;">
                            <%--<script id="editor" name="myContent" type="text/plain"  style="width: 100%; height: 300px;"></script>--%>
                            <asp:TextBox ID="txt_Content" runat="server" Width="100%" Height="300px" TextMode="MultiLine"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0">
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_Add" runat="server" Text="保存" CssClass="submit" OnClientClick="SetValue()" OnClick="btn_Add_Click" />
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="SetValue()" OnClick="btn_Sumbit_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <script type="text/javascript">
        //实例化编辑器
        //建议使用工厂方法getEditor创建和引用编辑器实例，如果在某个闭包下引用该编辑器，直接调用UE.getEditor('editor')就能拿到相关的实例
        var ue = UE.getEditor('txt_Content');
    </script>

    <script>
        $(function () {
            $.ajax({
                url: "../ashx/GetBaseDate.ashx",
                cache: false, type: "GET",
                data: "method=GetUser&data=js",
                dataType: "json",
                async: false,
                success: function (d) {
                    $('#AllUsersID').combotree({ data: d.data, multiple: true, /*onlyLeafCheck: true,*//*multiline: true,*/ });
                },
                error: function () { alert("查询出错，请稍候再试"); }
            });
            jQuery("#form1").Validform();
        });
        $(function () {
            $('#AllUsersID').combotree('setValues', $("#hf_AcceptUser").val().split(','));
        });
    </script>
    <script>
        function SetValue() {
            var U = new Array();
            var A = new Array();
            // var t = $("#AllUsersID").combotree("tree")
            $($("#AllUsersID").combotree("tree").tree("getChecked")).each(function () {
                if (this.children == null && $("#AllUsersID").combotree("tree").tree("find", this.id) != null) {
                    U.push(this.id); A.push(this.text);
                };
            });
            document.getElementById("hf_AcceptUser").value = U;
        };
    </script>
</body>
</html>

