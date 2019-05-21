<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EgovernmentGDDetail.aspx.cs" Inherits="GKICMP.oamanage.EgovernmentGDDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
   <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../EasyUI/themes/icon.css" rel="stylesheet" />
    <link href="../EasyUI/themes/default/easyui.css" rel="stylesheet" />
    
    <script src="../EasyUI/jquery.min.js"></script>
    <script src="../EasyUI/jquery.easyui.min.js"></script>
   
    
    <style>
        .listinfo label {
            float: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
            <asp:HiddenField ID="hf_SelectedValue" runat="server" Value="" />
            <asp:HiddenField ID="hf_face" runat="server" Value="" />
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <td colspan="6" align="center" style="font-size: 18px; font-weight: bold;">
                            <asp:Label ID="ltl_ETitle" runat="server" Text=""></asp:Label></td>
                    </tr>

                    <tr>

                        <td align="left" colspan="6" style="text-align: center">发件人：
                            <asp:Label ID="ltl_CreateUserName" runat="server" Text="" Font-Bold="true"></asp:Label>
                            日期：<asp:Label ID="ltl_CreateDate" runat="server" Text="" Font-Bold="true"></asp:Label>
                        </td>

                    </tr>
                    <tr>
                        
                        <td colspan="6"> 
                            <div id="oacontent">
                            <asp:Label ID="ltl_Comment" runat="server" Text=""></asp:Label>
                            </div>
                        </td>

                        
                    </tr>
                    <tr>
                        <td colspan="6">已读：<asp:Label ID="ltl_IsRead" runat="server" Text=""></asp:Label><br />
                            <span style="color: red">未读：<asp:Label ID="ltl_NotRead" runat="server" Text=""></asp:Label><br />
                            </span>
                        </td>

                    </tr>

                </tbody>
            </table>
            <br />
            
            <div id="egovernment" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                    <tbody>
                        <tr>
                            <td colspan="4" align="center" style="font-size: 30px; font-weight: bold;">公文处理标签</td>
                        </tr>
                        <tr>
                            <td style="font-weight: 800">公文类型</td>
                            <td>
                                <asp:Label ID="ltl_EType" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="font-weight: 800">归档编号</td>
                            <td>
                                <asp:Label ID="ltl_Ecode" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: 800">来文单位</td>
                            <td colspan="3">
                                <asp:Label ID="ltl_EDepartment" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: 800">收文时间</td>
                            <td>
                                <asp:Label ID="ltl_CreateDate1" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="font-weight: 800">文号</td>
                            <td>
                                <asp:Label ID="ltl_EtitleType" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: 800">文件标题</td>
                            <td colspan="3" style="text-align: center; font-weight: 800; font-size: 18px">
                                <asp:Label ID="ltl_ETitleName" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: 800">批阅流程</td>
                            <td colspan="3">
                                <asp:Repeater ID="rp_List" runat="server">
                                    <ItemTemplate>
                                        <ul>
                                            <li>
                                                <span><%#Eval("SendUserName") %>→<%#Eval("AcceptUser") %></span>&nbsp<span><%#Eval("SendDate","{0:yyyy-MM-dd HH:mm:ss}") %></span><br />
                                                <span style="font-weight: 800">&nbsp;&nbsp;<%#Eval("Comment")%></span><br />
                                            </li>
                                        </ul>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: 800">公文状态</td>
                            <td colspan="3">
                                <asp:Label ID="ltl_EState" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div style="text-align: center" id="RBack" runat="server">
                <input type="button" id="Cancell1" class="editor" value="返回" onclick="javascript: window.history.back(-1);" />
            </div>
            <br />
           
        </div>
    </form>
    
   
    <script type="text/javascript">
        $(function () {
            $.ajaxSettings.async = false;
            var url = "../ashx/GetBaseDate.ashx?method=GetUser&data=js";
            $.getJSON(url, function (data) {
                $('#Series').combotree({
                    data: data.data,
                    multiple: true,
                    multiline: true,
                });
                $('#Series').combotree("setValues", $("#hf_SelectedValue").val().split(','));
            });
        });
        function SetValue() {
            var U = new Array();
            $($("#Series").combotree("tree").tree("getChecked")).each(function () {
                if (this.children == null && $("#Series").combotree("tree").tree("find", this.id) != null) {
                    U.push(this.id);
                }
            });
            document.getElementById("hf_SelectedValue").value = U;
        };
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
        };
    </script>
    <%--<script src="http://code.jquery.com/jquery-1.9.1.js"></script>--%>
    <script type="text/javascript">
        $("#oacontent a[href$='.doc'],#oacontent a[href$='.docx'],#oacontent a[href$='.xls'],#oacontent a[href$='.xlsx'],#oacontent a[href$='.ppt'],#oacontent a[href$='.pptx']").each(function () {
            $("<a href='javascript:void(0);' url='" + $(this).attr("href") + "' class='view' >在线预览</a>").insertAfter($(this));
        });
        $(".view").linkbutton({ iconCls: "icon-ok", plain: "true" }).click(function () {
            $("#viewer").remove();
            $("<div style='width:98;' id='viewer' class='panel'>" +
                "<div class='panel-header'><div class='panel-title'>文档预览</div>" +
                "<div class='panel-tool'>" +
                "<a href='javascript:void(0);' onclick='$(\"#viewer\").remove();' id='closeviewer' style='color:#F00;'>χ</a></div>" +
                "</div><div class='panel-body'>" +
                "<iframe frameborder=0 style='width:99.9%;border:none;height:800px;' src='https://view.officeapps.live.com/op/view.aspx?src=" + ($(this).attr("url").indexOf("://") > 0 ? $(this).attr("url") : ("http://" + document.domain + "/" + $(this).attr("url"))) + "'></iframe></div></div>").insertAfter($(this));
        });

        </script>
</body>
</html>


