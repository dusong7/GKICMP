<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LessonEdit.aspx.cs" Inherits="GKICMP.lessonplan.LessonEdit" %>

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
    <script src="../utf8-net/ueditor.config.js"></script>
    <script src="../utf8-net/ueditor.all.js"></script>
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
        <asp:HiddenField runat="server" ID="hf_Teachers" />
        <asp:HiddenField runat="server" ID="hf_Type" />
        <asp:HiddenField runat="server" ID="hf_ClaID" />
        <asp:Literal runat="server" ID="ltl_Stu"></asp:Literal>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">备课信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100">活动时间：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_PDate" runat="server" datatype="*1-200" nullmsg="请填写名称" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="100">活动地点：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_ActivityAddress" runat="server" datatype="*1-200" nullmsg="请填写名称" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Literal runat="server" ID="ltl_Speaker"></asp:Literal>：</td>
                        <td align="left" colspan="3">
                            <asp:CheckBoxList runat="server" ID="chk_Speaker" CssClass="edilab" RepeatDirection="Horizontal" RepeatColumns="14" RepeatLayout="Flow"></asp:CheckBoxList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr id="trAssistant" runat="server">
                        <td align="right">助教：</td>
                        <td align="left" colspan="3">
                            <asp:CheckBoxList runat="server" ID="chk_Assistant" CssClass="edilab" RepeatDirection="Horizontal" RepeatColumns="14" RepeatLayout="Flow"></asp:CheckBoxList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr id="trClaIDs" runat="server">
                        <td align="right">班级：</td>
                        <td align="left" colspan="3">
                            <input id="ClaIDs" name="ClaIDs" style="width: 70%;" class="easyui-combotree" runat="server" />
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">活动内容：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox runat="server" ID="txt_AContent" TextMode="MultiLine" Width="70%" Height="50px" datatype="*" nullmsg="请填写活动内容"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">活动目标：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox runat="server" ID="txt_ActivityTarget" TextMode="MultiLine" Width="70%" Height="50px" datatype="*" nullmsg="请填写活动目标"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">活动准备：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox runat="server" ID="txt_ActivityPre" TextMode="MultiLine" Width="70%" Height="50px" datatype="*" nullmsg="请填写活动准备"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">活动安排：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_Content" runat="server" Height="300px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <script type="text/javascript">
            //实例化编辑器
            //建议使用工厂方法getEditor创建和引用编辑器实例，如果在某个闭包下引用该编辑器，直接调用UE.getEditor('editor')就能拿到相关的实例
            var ue = UE.getEditor('txt_Content');
        </script>
    </form>
    <script>
        $(function () {
            //绑定班级
            $.ajax({
                url: "../ashx/GetBaseDate.ashx",
                cache: false, type: "GET",
                data: "method=GetGrade&data=xs",
                dataType: "json",
                async: false,
                success: function (d) {
                    $('#ClaIDs').combotree({ data: d.data, multiple: true, onlyLeafCheck: true, multiline: true, });
                },
                error: function () { alert("查询出错，请稍候再试"); }
            });
            //判断班级
            $('#ClaIDs').combotree({
                onSelect: function (node) {
                    var tree = $(this).tree;
                    //选中的节点是否为叶子节点,如果不是叶子节点,清除选中  
                    var isLeaf = tree('isLeaf', node.target);
                    if (!isLeaf) {
                        //清除选中  
                        $('#ClaIDs').combotree('clear');
                        alert("请选择班级");
                    }
                    else {
                        document.getElementById("hf_ClaID").value = node.id;
                    }
                }
            });


            jQuery("#form1").Validform();
        });
        $(function () {
            $('#ClaIDs').combotree('setValues', [$("#hf_ClaID").val()]);
        });
    </script>
</body>
</html>

