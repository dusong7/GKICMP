<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsEdit.aspx.cs" Inherits="GKICMP.cms.NewsEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../utf8-net/ueditor.config.js"></script>
    <script src="../utf8-net/ueditor.all.js"></script>
    <title>智慧校园门户管理平台</title>
    <script type="text/javascript">
        function succ() {
            var sid = document.getElementById("hf_SID").value;
            window.location.href = "NewsManage.aspx?SID=" + sid;
        }
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
        //<!--
        var ColorHex = new Array('00', '33', '66', '99', 'CC', 'FF')
        var SpColorHex = new Array('FF0000', '00FF00', '0000FF', 'FFFF00', '00FFFF', 'FF00FF')
        var current = null
        function initcolor(id) {
            var colorTable = ''
            for (i = 0; i < 2; i++) {
                for (j = 0; j < 6; j++) {
                    colorTable = colorTable + '<tr height=15>'
                    colorTable = colorTable + '<td width=15 style="background-color:#000000">'
                    if (i == 0) {
                        colorTable = colorTable + '<td width=15 style="cursor:pointer;background-color:#' + ColorHex[j] + ColorHex[j] + ColorHex[j] + '" onclick="doclick(this.style.backgroundColor,' + id + ')">'
                    }
                    else {
                        colorTable = colorTable + '<td width=15 style="cursor:pointer;background-color:#' + SpColorHex[j] + '" onclick="doclick(this.style.backgroundColor,' + id + ')">'
                    }
                    colorTable = colorTable + '<td width=15 style="background-color:#000000">'
                    for (k = 0; k < 3; k++) {
                        for (l = 0; l < 6; l++) {
                            colorTable = colorTable + '<td width=15 style="cursor:pointer;background-color:#' + ColorHex[k + i * 3] + ColorHex[l] + ColorHex[j] + '" onclick="doclick(this.style.backgroundColor,' + id + ')">'
                        }
                    }
                }
            }
            colorTable = '<table border="0" cellspacing="0" cellpadding="0" style="border:1px #000000 solid;border-bottom:none;border-collapse: collapse;width:337px;" bordercolor="000000">'
    + '<tr height=20><td colspan=21 bgcolor=#ffffff style="font:12px tahoma;padding-left:2px;">'
     + '<span style="float:right;padding-right:3px;cursor:pointer;" onclick="colorclose()">×关闭</span>'
    + '</td></table>'
    + '<table border="1" cellspacing="0" cellpadding="0" style="border-collapse: collapse" bordercolor="000000" style="cursor:pointer;">'
    + colorTable + '</table>';
            var tid = '';
            if (id == '1') {
                tid = "txtvalue";
            }
            else if (id == '2') {
                tid = "txt2";
            }
            document.getElementById("colorpane").innerHTML = colorTable;
            var current_x = document.getElementById(tid).offsetLeft + 2;
            var current_y = document.getElementById(tid).offsetTop + 20;
            document.getElementById("colorpane").style.left = current_x + "px";
            document.getElementById("colorpane").style.top = current_y + "px";
        }
        function doclick(obj, id) {
            if (id == '1') {
                document.getElementById("txtvalue").value = obj;
                document.getElementById("txtvalue").style.backgroundColor = obj;
            }
            else if (id == '2') {
                document.getElementById("txt2").value = obj;
                document.getElementById("txt2").style.backgroundColor = obj;
            }
        }
        function colorclose() {
            document.getElementById("colorpane").style.display = "none";
        }
        function coloropen(id) {
            initcolor(id);
            document.getElementById("colorpane").style.display = "";
        }

        function getfile() {
            var hfatta = $id("hf_UpFile");
            var careful = $id("more").getElementsByTagName("input");
            hfatta.value = careful.length;
        }
    </script>
    <style>
        .pz .select_box {
            display: none;
        }

        .listinfo label {
            float: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_imageurl" runat="server" />
        <asp:HiddenField ID="hf_DataType" runat="server" />
        <asp:HiddenField ID="hf_CID" runat="server" />
        <asp:HiddenField ID="hf_SID" runat="server" />
        <div class="listcent pad0">
            <table width="100%" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <td align="right" width="90px">新闻标题：
                        </td>
                        <td colspan="6">
                            <asp:TextBox ID="txt_NewsTitle" Width="90%" CssClass="searchbg" datatype="*1-100" nullmsg="请填写新闻标题名称" runat="server"></asp:TextBox>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">所属栏目：</td>
                        <td>
                            <asp:DropDownList ID="ddl_MID" CssClass="searchbg" datatype="ddl" errormsg="请选择所属栏目" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_MID_SelectedIndexChanged">
                            </asp:DropDownList>
                            <span style="color: red;">*</span>
                        </td>
                        <td align="right" width="80px">作者：
                        </td>
                        <td>
                            <asp:TextBox ID="txt_NAuthor" CssClass="searchbg" runat="server"></asp:TextBox>
                        </td>
                        <%-- <td align="right" width="60px">状态：</td>
                        <td>
                            <asp:DropDownList ID="ddl_NState" CssClass="searchbg" runat="server">
                                <asp:ListItem Selected="True" Value="0">未发布</asp:ListItem>
                                <asp:ListItem Value="1">发布</asp:ListItem>
                            </asp:DropDownList>
                        </td>--%>
                        <td align="right" width="70px">发布日期：</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_CreateDate" runat="server" onfocus="WdatePicker({skin:'whyGreen' ,startDate:'%y-%M-%d %H:%m:&s',dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                                Width="130px" CssClass="searchbg"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <%--<td align="right">新闻模版： </td>
                        <td>
                            <asp:DropDownList ID="ddl_TempName" runat="server" CssClass="searchbg"></asp:DropDownList></td>--%>
                        <td align="right">新闻所属部门：</td>
                        <td>
                            <asp:DropDownList ID="ddl_NDep" runat="server" datatype="ddl" errormsg="请选择新闻所属部门"></asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>

                        <td align="right">排序：
                        </td>
                        <td>
                            <asp:TextBox ID="txt_NOrder" CssClass="searchbg" datatype="n" nullmsg="请填写排序号"
                                runat="server" Width="80" Text="0"></asp:TextBox>
                            <span style="color: Red">*</span>
                        </td>
                        <td style="text-align: left" colspan="2">
                            <asp:CheckBox ID="cb_MKeyWords" runat="server" Text="置顶" ToolTip="是否置顶" />
                            <asp:CheckBox ID="cb_MDescription" runat="server" Text="推荐" ToolTip="是否推荐" />
                            <asp:CheckBox ID="cb_IsRecommend" runat="server" Text="特别推荐" ToolTip="是否特别推荐" />
                            <asp:CheckBox ID="cb_IsImgNews" runat="server" Text="图片新闻" ToolTip="是否图片新闻" />
                            <asp:CheckBox ID="cb_IsComment" runat="server" Text="评论" ToolTip="是否允许评论" />
                        </td>

                    </tr>
                    <tr>
                        <td align="right">内容：</td>
                        <td colspan="6">
                            <asp:TextBox ID="txt_Content" runat="server" Width="100%" Height="300px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>



                        <td align="right">标题颜色：</td>
                        <td>
                            <%--<input id="txtvalue" type="text" onclick="coloropen(1)"/>--%>
                            <asp:TextBox ID="txtvalue" CssClass="searchbg" runat="server" onclick="coloropen(1)"></asp:TextBox>
                            <div id="colorpane" style="position: absolute; z-index: 999; display: none;">
                            </div>
                        </td>
                        <td align="right">链接：</td>
                        <td>
                            <%-- <asp:CheckBox ID="ck_IsLink" runat="server" ToolTip="是否是外部链接" Text="链接" />--%>
                            <asp:TextBox ID="txt_LinkUrl" CssClass="searchbg" runat="server"></asp:TextBox>



                        </td>
                        <td align="right">主题：</td>
                        <td>
                            <asp:TextBox ID="txt_NTtitle" CssClass="searchbg"
                                runat="server"></asp:TextBox>
                        </td>
                        
                    </tr>

                    <tr>
                       <%-- <td align="right">是否审核：</td>
                        <td>
                            <style>
                                .edilab label {
                                    float: none;
                                }

                                .edilab input {
                                    height: 13px;
                                }
                            </style>
                            <asp:RadioButtonList ID="rbol_IsAudit" runat="server" RepeatDirection="Horizontal" CssClass="edilab"
                                RepeatLayout="Flow">

                                <asp:ListItem Value="1" Selected>是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>--%>
                        <td align="right">评论次数：</td>
                        <td>
                            <asp:TextBox ID="txt_CommentNumber" CssClass="searchbg" runat="server" Text="0"></asp:TextBox>
                        </td>
                         <td align="right" >浏览次数 ：</td>
                        <td>
                            <asp:TextBox ID="txt_ReadCount" CssClass="searchbg" runat="server" Text="0"></asp:TextBox></td>
                        <td align="right">关键字：</td>
                        <td colspan="2">
                            <asp:TextBox ID="txt_NKeyWords" CssClass="searchbg" runat="server" Width="300px"></asp:TextBox>
                        </td>
                       
                    </tr>
                    <tr>
                        <td align="right">描述：</td>
                        <td colspan="6">
                            <asp:TextBox ID="txt_NDescription" CssClass="searchbg" runat="server" Width="700px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="50px">缩略图：</td>
                        <td colspan="6">
                            <div id="more">
                                <asp:FileUpload ID="fl_UpFile" runat="server" onchange="if(this.value)judgepic(this.value,this);" />
                                <asp:Image ID="Image1" runat="server" Width="35px" Height="35px" overflow="hidden" />
                            </div>
                            <asp:HiddenField ID="hf_UpFile" runat="server" />
                        </td>
                         <%--<td align="right" ><asp:CheckBox ID="cb_True" runat="server"  Text="是否推送到微官网"/></td>--%>
                       
                    </tr>


                </tbody>

            </table>
            <table width="100%" border="0">
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        <%--<asp:Button ID="bt_ok" runat="server" class="editor" Text="返回" OnClick="bt_ok_Click" />--%>
                        <input type="button" class="editor" onclick="Javascript: window.history.go(-1);" value="返回上一页" />

                    </td>
                </tr>
            </table>
        </div>
        <script type="text/javascript">

            //实例化编辑器
            //建议使用工厂方法getEditor创建和引用编辑器实例，如果在某个闭包下引用该编辑器，直接调用UE.getEditor('editor')就能拿到相关的实例
            var ue = UE.getEditor('txt_Content');

        </script>
    </form>
</body>
</html>

