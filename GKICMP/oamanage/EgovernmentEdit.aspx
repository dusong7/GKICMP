<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EgovernmentEdit.aspx.cs" Inherits="GKICMP.oamanage.EgovernmentEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/js.js"></script>
    <%--<script src="../js/jquery.easyui.min.js"></script>--%>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>

    <script src="../utf8-net/ueditor.config.js"></script>
    <script src="../utf8-net/ueditor.all.js"></script>
    <script type="text/javascript">
        $(function () {

            jQuery("#form1").Validform();
            //$('#Series').combotree({
            //    onSelect: function (node) {
            //        var val = node.id;
            //        document.getElementById("hf_SelectedValue").value = val;
            //        alert(val);
            //    }
            //});
            if ($("#ck_IsOrNot").is(":checked"))
            { document.getElementById("pz").style.display = "table-row"; }
            else {
                document.getElementById("pz").style.display = "none";
            };
            $("#ck_IsOrNot").change(function () {
                if ($(this).is(":checked"))
                { document.getElementById("pz").style.display = "table-row"; }
                else
                { document.getElementById("pz").style.display = "none"; }
            });


        });
        //function getValues() {
        //    var U = new Array();
        //    $($("#Series").combotree("tree").tree("getChecked")).each(function () {
        //        if (this.children == null && $("#Series").combotree("tree").tree("find", this.id) != null) {
        //            U.push(this.id);
        //        }
        //        document.getElementById("hf_SelectedValue").value = U;
        //    });
        //}
    </script>
    <script type="text/javascript">
      
        function setValue() {
            var U = new Array();
            $($("#Series").combotree("tree").tree("getChecked")).each(function () {
                if (this.children == null && $("#Series").combotree("tree").tree("find", this.id) != null) {
                    U.push(this.id);
                    document.getElementById("hf_SelectedValue").value = $.unique(U);
                    
                }
            });
            //alert(U);
        }
    </script>
    <script>
        function clickSelect() {
            var selid = document.getElementById("slwb");
            var str = "";
            var s = 0;
            if (selid == null || selid.lenght < 1) {
                return str;
            }
            var k = 0;
            for (var i = 0; i < selid.length; i++) {
                if (selid.options[i].selected) {
                    if (s == 0) {
                        k = i;

                        str = selid.options[i].value;
                    }
                    else {
                        str = str + "，" + selid.options[i].value;
                    }
                    s++;
                }
            } if (s > 0) {
                document.getElementById("txt_Comment").value = str;
            }
            else {
                document.getElementById("txt_Comment").value = "";
            }
        }
    </script>
    <style>
        /*.pz .select_box {
            display: none;
        }*/
        .listinfo label {
            float: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField ID="hf_SelectedValue" runat="server" Value="" />
        <asp:HiddenField ID="hf_face" runat="server" Value="" />
        <asp:HiddenField ID="hf_EID" runat="server" Value="" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="6" align="left">基本信息</th>
                    </tr>

                    <tr>
                        <td align="right" width="80px">政务标题</td>
                        <td align="left" colspan="5">

                            <asp:TextBox ID="txt_ETitle" runat="server" Width="80%" datatype="*" nullmsg="请填写政务标题"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                            <asp:CheckBox ID="ck_IsOrNot" runat="server" ForeColor="Red" Text="批转公文" />

                            <%--   <label class="wxz" id="checkall_2l" style="float:left">
                                <input type="checkbox" name="checkall" value="复选框" id="checkall_2" onclick="djxz(this.id)" /></label><span>批转公文</span>--%>
                        </td>
                    </tr>

                    <tr id="pz" runat="server">
                        <td align="right">政务编号</td>
                        <td align="left">
                            <asp:TextBox ID="txt_ECode" runat="server" datatype="*1-50" nullmsg="请填写政务编号"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td>来文单位</td>
                        <td>
                            <asp:TextBox ID="txt_Department" runat="server"></asp:TextBox></td>
                        <td>文号</td>
                        <td>
                            <asp:TextBox ID="txt_EtitleType" runat="server" datatype="*1-50" nullmsg="请填写文号"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">收件人</td>
                        <td align="left" colspan="5">
                            <span id="select"></span>
                            <%-- <asp:HiddenField ID="hf_CID" runat="server" />--%>
                          <%--  <asp:TextBox ID="txt_r" runat="server" style="width: 85%; height: 80px" ></asp:TextBox>--%>
                            <input id="Series" name="Series" style="width: 85%; height: 80px" class="easyui-combotree" />
                            <%--<asp:TextBox ID="txt_Name" runat="server" Enabled="false" Height="50px" TextMode="MultiLine" Width="360px" datatype="*"  nullmsg="请选择收件人"></asp:TextBox>--%>
                            <span style="color: Red; float: none">*</span><asp:CheckBox ID="cb_SendMessage" runat="server" Text="短信通知" ForeColor="Red" />
                            <%--<asp:ImageButton ID="ibtn_Add" runat="server" ImageUrl="~/images/addfile.gif" OnClientClick="return addshow(''); " />--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">正文</td>
                        <td align="left" colspan="5" style="line-height: 20px;">
                            <%--<script id="editor" name="myContent" type="text/plain"  style="width: 100%; height: 300px;"></script>--%>
                            <asp:TextBox ID="txt_Content" runat="server" Width="100%" Height="300px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">批注</td>
                        <td align="left" colspan="5">
                            <asp:TextBox ID="txt_Comment" runat="server" TextMode="MultiLine" Height="105px" Width="54%" datatype="*" nullmsg="请填写批注"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                            <div class="pz" style="float: left">
                                <select name="slwb" id="slwb" class="slwb" multiple="multiple" onclick="clickSelect()">
                                    <option value="请领导审阅">请领导审阅</option>
                                    <option value="已初审通过，请领导审阅!">已初审通过，请领导审阅!</option>
                                    <option value="行文有以下不妥，请修改后重新发送!">行文有以下不妥，请修改后重新发送!</option>
                                    <option value="请向相关人员传阅">请向相关人员传阅!</option>
                                    <option value="请阅办!">请阅办!</option>
                                    <option value="请抓紧落实!">请抓紧落实!</option>
                                    <option value="请尽快上报!">请尽快上报!</option>
                                    <option value="请上会商议!">请上会商议!</option>
                                    <option value="请传达学习!">请传达学习!</option>
                                    <option value="请参考执行!">请参考执行!</option>
                                    <option value="请准时参会!">请准时参会!</option>

                                </select>
                            </div>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="6" align="center">
                            <asp:Button ID="btn_Add" runat="server" Text="保存" CssClass="editor" OnClientClick="setValue()" OnClick="btn_Add_Click" />&nbsp
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="setValue()" OnClick="btn_Sumbit_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
    <script type="text/javascript">
        //实例化编辑器
        //建议使用工厂方法getEditor创建和引用编辑器实例，如果在某个闭包下引用该编辑器，直接调用UE.getEditor('editor')就能拿到相关的实例
        var ue = UE.getEditor('txt_Content');
        $(function () {
            $.ajaxSettings.async = false;
            var url = "../ashx/GetBaseDate.ashx?method=GetGroupUser";
            $.getJSON(url, function (data) {
                $('#Series').combotree({
                    data: data.data,
                    multiple: true,
                    multiline: true,
                    onCheck: function () {
                        var M = 0;
                        $($("#Series").combotree("tree").tree("getChecked")).each(function () {
                            if (this.children == null) {
                                M++;
                               
                            }
                        });
                        //$("#select").text("当前选中人数：" + M);
                    }
                    
                });
                $('#Series').combotree("setValues", $("#hf_SelectedValue").val().split(','));
            });
        });
    </script>

</body>
</html>




