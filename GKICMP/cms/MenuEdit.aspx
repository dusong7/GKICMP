<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuEdit.aspx.cs" Inherits="GKICMP.cms.MenuEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园门户管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <link href="../css/easyui.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../utf8-net/ueditor.config.js"></script>
    <script src="../utf8-net/ueditor.all.js"></script>
    <script type="text/javascript">
        $(function () {           
            jQuery("#form1").Validform();
            
        });
      
        function SetValue() {
            var U = new Array();
            $($("#Role").combotree("tree").tree("getChecked")).each(function () {
                if (this.children == null && $("#Role").combotree("tree").tree("find", this.id) != null) {
                    U.push(this.id);
                }
            });
            // alert(U);
            document.getElementById("hf_SelectedValue").value = U;
           
        }
      
        function succ() {
            var sid = document.getElementById("hf_SID").value;
            window.parent.location.href = "MenuManage.aspx?SID=" + sid;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_PID" runat="server" />
        <asp:HiddenField ID="hf_ID" runat="server" />
        <asp:HiddenField ID="hf_imageurl" runat="server" />
        <asp:HiddenField runat="server" ID="hf_SID" />
        <div class="listcent pad0">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <td align="right" width="100px">上级栏目：</td>
                        <td>
                            <asp:DropDownList ID="ddl_MID" runat="server" CssClass="searchbg" Width="148px"></asp:DropDownList>
                        </td>

                        <td align="right" width="70px">栏目名称：</td>
                        <td>
                            <asp:TextBox ID="txt_MName" CssClass="searchbg" runat="server" datatype="*1-50"
                                nullmsg="请填写栏目名称" MaxLength="50"></asp:TextBox>
                            <span style="color: Red">*</span>
                        </td>
                        <td align="right" width="90px">英文名称：</td>
                        <td>
                            <asp:TextBox ID="txt_EngName" CssClass="searchbg" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>

                        <td align="right">排序：</td>
                        <td>
                            <asp:TextBox ID="txt_MOrder" runat="server" datatype="zhengnum" CssClass="searchbg" Width="70px" Text="0"></asp:TextBox>
                        </td>
                        <td align="right">类别：</td>
                        <td>
                            <asp:DropDownList ID="ddl_rbol_MType" runat="server" datatype="ddl" errormsg="请选择类别"></asp:DropDownList>
                        </td>
                        <td align="right">是否显示：</td>
                        <td>
                            <style>
                                .edilab label {
                                    float: none;
                                }

                                .edilab input {
                                    height: 13px;
                                }
                            </style>
                            <asp:RadioButtonList ID="rbol_MState" runat="server" RepeatDirection="Horizontal" CssClass="edilab"
                                RepeatLayout="Flow">

                                <asp:ListItem Value="1" Selected>是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">描述： </td>
                        <td>
                            <asp:TextBox ID="txt_MDescription" runat="server" MaxLength="150"
                                CssClass="searchbg"></asp:TextBox>
                        </td>
                        <td align="right">标题：</td>
                        <td>
                            <asp:TextBox ID="txt_MenuTitle" CssClass="searchbg" runat="server"></asp:TextBox>
                        </td>
                        <td align="right">关键字：</td>
                        <td>
                            <asp:TextBox ID="txt_MKeyWords" CssClass="searchbg" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="70px">链接地址： </td>
                        <td>
                            <asp:TextBox ID="txt_LinkUrl" CssClass="searchbg" runat="server"></asp:TextBox>
                        </td>
                        <td align="right">栏目图标：</td>
                        <td>
                            <div id="more">
                                <asp:FileUpload ID="fl_UpFile" runat="server" onchange="if(this.value)judgepic(this.value,this);" />
                                <asp:Image ID="Image2" runat="server" Width="35px" Height="35px" overflow="hidden" />
                            </div>
                            <asp:HiddenField ID="hf_UpFile" runat="server" />
                        </td>
                        <td align="right" width="75px">栏目Banner：</td>
                        <td>
                            <div id="more">
                                <asp:FileUpload ID="fl_MNanner" runat="server" onchange="if(this.value)judgepic(this.value,this);" />
                                <asp:Image ID="Image1" runat="server" Width="35px" Height="35px" overflow="hidden" />
                            </div>
                            <asp:HiddenField ID="hf_MNanner" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="70px">栏目模板： </td>
                        <td>
                            <asp:DropDownList ID="ddl_MenuTemplate" runat="server"></asp:DropDownList>
                        </td>
                        <td align="right">内容模版：</td>
                        <td>
                            <asp:DropDownList ID="ddl_DetailTemplate" runat="server"></asp:DropDownList>
                        </td>
                        <td align="right">开放栏目：</td>
                        <td>

                            <asp:RadioButtonList ID="rbl_IsOpen" runat="server" RepeatDirection="Horizontal" CssClass="edilab"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="1" Selected>是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">是否允许评论： </td>
                        <td>
                            <asp:RadioButtonList ID="rbl_IsComment" runat="server" RepeatDirection="Horizontal" CssClass="edilab"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="1" Selected>是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td align="right">评论审核：</td>
                        <td>
                            <asp:RadioButtonList ID="rbl_IsCommentAudit" runat="server" RepeatDirection="Horizontal" CssClass="edilab"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="1" Selected>是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td align="right">发布是否审核：</td>
                        <td>
                            <asp:RadioButtonList ID="rbl_IsAudit" runat="server" RepeatDirection="Horizontal" CssClass="edilab"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="1" Selected>是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            审核人：
                        </td>
                        <td colspan="5">
                            <asp:TextBox ID="txt_TIDS" cascadeCheck="false" runat="server" name="Tearcher" onlyLeafCheck="true" url="../ashx/ClassRoomList.ashx?method=TList" CssClass="easyui-combotree"  Height="30px" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">发布角色： </td>
                        <td colspan="5">
                             <asp:TextBox ID="Role" runat="server" Width="100%" Height="40px" TextMode="MultiLine"></asp:TextBox>
                           <%-- <input id="Role" name="Role" style="width: 90%; height: 40px" class="easyui-combotree" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">内容：</td>
                        <td colspan="5">
                            <asp:TextBox ID="txt_Content" runat="server" Width="100%" Height="300px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0">
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="return check()" OnClick="btn_Sumbit_Click" />
                        &nbsp; &nbsp;&nbsp;&nbsp; 
                            <asp:Button ID="btn_Delete" runat="server" Text="删除" CssClass="deletebtn" OnClick="btn_Delete_Click" OnClientClick="return confirm('您确认删除这条数据！')" />
                        &nbsp; &nbsp;&nbsp;&nbsp; 
                            <asp:Button ID="btn_Add" runat="server" Text="添加子模块" CssClass="addbtn" OnClick="btn_Add_Click" />
                        &nbsp; &nbsp;&nbsp;&nbsp;           
                    </td>
                </tr>
            </table>
        </div>
        <asp:Literal ID="ltl_Role" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField ID="hf_SelectedValue" runat="server" />
    </form>
    <script type="text/javascript">
        //实例化编辑器
        //建议使用工厂方法getEditor创建和引用编辑器实例，如果在某个闭包下引用该编辑器，直接调用UE.getEditor('editor')就能拿到相关的实例
        var ue = UE.getEditor('txt_Content');
        function check()
        {
            var v = $("input[name='rbl_IsAudit']:checked").val();
            //var v = $("#rbl_IsAudit").find("[checked]").val()
            if (v == 1)
            {
                var au = $("#txt_TIDS").val();
                var pub = $("#Role").val();
                if (au == "") {
                    alert("请选择审核人");
                    $("#txt_TIDS").focus();
                    return false;
                }
                if (pub == "") {
                    alert("请选择发布角色");
                    $("#Role").focus();
                    return false;
                }
            }
        }
    </script>
</body>
</html>

