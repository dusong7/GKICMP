<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentActEdit.aspx.cs" Inherits="GKICMP.schoolwork.StudentActEdit" %>

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
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../utf8-net/ueditor.config.js"></script>
    <script src="../utf8-net/ueditor.all.js"></script>
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

        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">学生活动信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">活动名称：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_ActName" runat="server" MaxLength="100" datatype="*" nullmsg="请输入活动名称" Width="70%"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">活动类型：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_ActType" runat="server" datatype="ddl" errormsg="请选择活动类型"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right">活动日期：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_ABegin" runat="server" Width="75px" datatype="*" nullmsg="请选择活动开始日期" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_AEnd" runat="server" Width="75px" datatype="*" nullmsg="请选择活动结束日期" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">指导教师：</td>
                        <td align="left">
                            <%-- <input id="Counselor" name="Counselor" class="easyui-combotree" runat="server" />
                            <span style="color: Red; float: none">*</span>--%>
                            <asp:TextBox ID="Series" runat="server" name="Series" cascadeCheck="false" multiline="true" multiple="true" onlyLeafCheck="true" url="../ashx/Tea.ashx?method=TeaL" CssClass="easyui-combotree" Width="70%"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">活动地点：</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txt_ActAddress" datatype="*" nullmsg="请填写活动地点"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">是否可报名：
                        </td>
                        <td>
                            <asp:RadioButtonList runat="server" ID="rdo_IsSign" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="edilab">
                                <asp:ListItem Value="1" Selected>是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td align="right">报名截至日期：</td>
                        <td colspan="3">
                            <asp:TextBox runat="server" ID="txt_ClosingDate" datatype="*" nullmsg="请选择活动结束日期" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">参与人：</td>
                        <td align="left" colspan="3">
                            <input id="ActUsers" name="ActUsers" style="width: 75%;" class="easyui-combotree" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">活动LOGO：</td>
                        <td colspan="3">
                            <asp:Image runat="server" ID="img_LogoUrl" Width="100px" Visible="false" />
                            <asp:FileUpload ID="fl_UpFile" runat="server" onchange="if(this.value)judge(this.value,this);" />
                            <asp:HiddenField ID="hf_UpFile" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">活动内容：</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_ActContent" TextMode="MultiLine" runat="server" datatype="*" nullmsg="请填写活动内容" Width="70%" Height="100px" Style="resize: none;"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_ActDesc" TextMode="MultiLine" runat="server" MaxLength="100"
                                Rows="6" Width="70%" Height="100px" CssClass="MultiLinebg" Style="resize: none;"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">活动模板：</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_Content" runat="server" Height="300px" TextMode="MultiLine" Width="100%" datatype="*" nullmsg="请填写活动模板"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="SetValue()" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick='javascript: window.history.back(-1);' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <asp:HiddenField ID="hf_Counselor" runat="server" />
        <asp:HiddenField ID="hf_ActUsers" runat="server" />
        <script type="text/javascript">
            //实例化编辑器
            //建议使用工厂方法getEditor创建和引用编辑器实例，如果在某个闭包下引用该编辑器，直接调用UE.getEditor('editor')就能拿到相关的实例
            var ue = UE.getEditor('txt_Content');
        </script>
    </form>
    <script>
        $(function () {
            $.ajax({
                url: "../ashx/GetBaseDate.ashx",
                cache: false, type: "GET",
                data: "method=GetUser&data=js",
                dataType: "json",
                async: false,
                success: function (d) {
                    $('#Counselor').combotree({ data: d.data, multiple: false, onlyLeafCheck: true, /*multiline: true,*/ });
                },
                error: function () { alert("查询出错，请稍候再试"); }
            });

            $.ajax({
                url: "../ashx/GetBaseDate.ashx",
                cache: false, type: "GET",
                data: "method=GetUser&data=''",
                dataType: "json",
                async: false,
                success: function (d) {
                    $('#ActUsers').combotree({ data: d.data, multiple: true, /*onlyLeafCheck: true,*//*multiline: true,*/ });
                },
                error: function () { alert("查询出错，请稍候再试"); }
            });

            $('#Counselor').combotree({
                onSelect: function (node) {
                    var tree = $(this).tree;
                    //选中的节点是否为叶子节点,如果不是叶子节点,清除选中  
                    var isLeaf = tree('isLeaf', node.target);
                    if (!isLeaf) {
                        //清除选中  
                        $('#Counselor').combotree('clear');
                    }
                    else {
                        document.getElementById("hf_Counselor").value = node.id;
                    }
                }
            });
            jQuery("#form1").Validform();
        });

        $(function () {
            $('#ActUsers').combotree('setValues', $("#hf_ActUsers").val().split(','));
            $('#Counselor').combotree('setValues', [$("#hf_Counselor").val()]);
        });



    </script>
    <script>
        function SetValue() {
            var U = new Array();
            $($("#ActUsers").combotree("tree").tree("getChecked")).each(function () {
                if (this.children == null && $("#ActUsers").combotree("tree").tree("find", this.id) != null) {
                    U.push(this.id);
                };
            });
            document.getElementById("hf_ActUsers").value = U;
        };
    </script>

    <script>
        $(function () {
            $('#Series').combotree({
                onSelect: function (node) {
                    if (typeof (node.children) != "undefined") {
                        alert("不能选择部门");
                        document.getElementsById("Series").value = ""
                    }
                }
            });
            jQuery("#form1").Validform();
        });
    </script>

</body>
</html>








