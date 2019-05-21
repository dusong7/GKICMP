<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EgovernmentDetail.aspx.cs" Inherits="GKICMP.oamanage.EgovernmentDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/js.js"></script>

    <style media="print" type="text/css">
        .noprint {
            visibility: hidden;
        }
    </style>
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
                                <asp:Label ID="lbl_ETitle" runat="server" Text=""></asp:Label></td>
                        </tr>

                        <tr>

                            <td align="left" colspan="6" style="text-align: center">发件人：
                            <asp:Label ID="lbl_CreateUserName" runat="server" Text="" Font-Bold="true"></asp:Label>
                                日期：<asp:Label ID="lbl_CreateDate" runat="server" Text="" Font-Bold="true"></asp:Label>
                            </td>

                        </tr>
                        <tr>
                            <td colspan="6">
                                <div id="oacontent">
                                    <asp:Label ID="lbl_Comment" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr class="noprint">
                            <td colspan="6">已读：<asp:Label ID="lbl_IsRead" runat="server" Text=""></asp:Label><br />
                                <span style="color: red">未读：<asp:Label ID="lbl_NotRead" runat="server" Text=""></asp:Label><br />
                                </span>
                            </td>

                        </tr>
                    </tbody>
                </table>
                <br />
                
            <div id="pagenone" style="page-break-after:always;"></div>
            <br />
                <div id="egovernment" runat="server">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                        <tbody>
                            <tr>
                                <td colspan="4" align="center" style="font-size: 30px; font-weight: bold;">公文处理标签</td>
                            </tr>
                            <tr>
                                <td style="font-weight: 800" width="100px">公文类型</td>
                                <td>
                                    <asp:Label ID="lbl_EType" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="font-weight: 800">归档编号</td>
                                <td>
                                    <asp:Label ID="lbl_Ecode" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: 800">来文单位</td>
                                <td colspan="3">
                                    <asp:Label ID="lbl_EDepartment" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: 800">收文时间</td>
                                <td>
                                    <asp:Label ID="lbl_CreateDate1" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="font-weight: 800">文号</td>
                                <td>
                                    <asp:Label ID="lbl_EtitleType" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: 800">文件标题</td>
                                <td colspan="3" style="text-align: center; font-weight: 800; font-size: 18px">
                                    <asp:Label ID="lbl_ETitleName" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: 800">批阅流程</td>
                                <td colspan="3">
                                    <asp:Repeater ID="rp_List" runat="server">
                                        <ItemTemplate>
                                            <ul>
                                                <li>
                                                    <span><%#Eval("SendUserName") %>→<%#Eval("AcceptUser").ToString().Trim(',') %></span>&nbsp<span><%#Eval("SendDate","{0:yyyy-MM-dd HH:mm:ss}") %></span><br />
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
                                    <asp:Label ID="lbl_EState" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            
            <div style="text-align: center" id="RBack" runat="server" class="noprint">
                <input type="button" id="Cancell1" class="editor" value="返回" onclick="javascript: window.history.back(-1);" />
                <input type="button" id="print" class="print" value="打印" onclick="javascript: window.print()" />
            </div>
            <br />
            <div id="egovernmentPZ" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                    <tbody>
                        <tr>
                            <td colspan="4" align="center" style="font-size: 30px; font-weight: bold;">批转公文：《<asp:Label ID="lbl_Etitle1" runat="server" Text=""></asp:Label>》</td>
                        </tr>
                        <tr>
                            <td style="font-weight: 800">收件人</td>
                            <td>
                                <%--<asp:HiddenField ID="hf_CID" runat="server" />--%>
                                <%-- <asp:TextBox ID="txt_Name" runat="server" Enabled="false" Height="50px" TextMode="MultiLine" Width="360px"></asp:TextBox>
                            <asp:ImageButton ID="ibtn_Add" runat="server" ImageUrl="~/images/selectbtn.png" OnClientClick="return addshow(''); " />--%>
                                <input id="Series" name="Series" style="width: 90%; height: 40px" class="easyui-combotree" />
                                <asp:CheckBox ID="cb_SendMessage" runat="server" Text="短信通知" ForeColor="Red" />
                            </td>
                        </tr>
                        <tr>
                            <td>批注</td>
                            <td align="left" colspan="5">
                                <asp:TextBox ID="txt_Comment" runat="server" TextMode="MultiLine" Height="105px" Width="54%"></asp:TextBox>
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
                            <td colspan="2">

                                <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="return SetValue()" OnClick="btn_Sumbit_Click" />
                                <input type="button" id="Cancell" class="editor" value="返回" onclick="javascript: window.history.back(-1);" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
              
            <%-- <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <asp:HiddenField ID="hf_File" runat="server" />
            <asp:HiddenField ID="hf_Name" runat="server" />--%>
            <div style="text-align: center" id="yy" runat="server">
                <asp:Button ID="btn_Read" runat="server" Text="已阅" CssClass="addbtn" OnClick="btn_Read_Click" />
            </div>

        </div>
    </form>


    <script type="text/javascript">
        $(function () {
            
            var divheight = $("#oacontent").height();
            if (divheight <300)
            {
               // alert(divheight);
                $("#pagenone").remove();
            }
            $.ajaxSettings.async = false;
            var url = "../ashx/GetBaseDate.ashx?method=GetGroupUser";
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
            if (U.length < 1)
            {
                alert("请选择收件人");
                return false;
            }
            document.getElementById("hf_SelectedValue").value = $.unique(U);
            return true;
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
        //$(function () {
        //    $('a').click(function () {
        //        //alert("111");
        //        var a = $(this).attr("href");
        //        var b = $(this).attr("title");
        //        document.getElementById("hf_File").value = a;
        //        document.getElementById("hf_Name").value = b;
        //        $(this).attr("href", "#");
        //        document.getElementById("Button1").click();
        //    });
        //})
        $("#oacontent a").each(function () {

            $(this).attr("download", $(this).attr("title"));
        });
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
                 
                //"<iframe frameborder=0 style='width:99.9%;border:none;height:800px;' src='https://view.officeapps.live.com/op/view.aspx?src=" + ($(this).attr("url").indexOf("://") > 0 ? $(this).attr("url") : ("http://" + document.domain + "/" + $(this).attr("url"))) + "'></iframe></div></div>").insertAfter($(this));
        });

    </script>
</body>
</html>


