<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Res_Detail.aspx.cs" Inherits="GKICMP.resourcesite.Res_Detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园资源平台</title>
    <link rel="icon" href="../gzimages/yghd_favicon.ico" type="image/x-icon" />
    <link href="../css/rourcecss.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <style type="text/css">
        body {
            background: url(../images/zy_1.png) center top no-repeat;
        }
    </style>
    <script type="text/javascript">
        //$("#li1").attr("class", "selected");
        function changecss(id) {
            if (id == 1) {
                document.getElementById("li1").className = "selected";
                document.getElementById("li2").className = "";
                document.getElementById("li3").className = "";
                document.getElementById("li4").className = "";
                document.getElementById("li5").className = "";
                document.getElementById("li6").className = "";
                document.getElementById("li7").className = "";
            }
            else if (id == 2) {
                document.getElementById("li1").className = "";
                document.getElementById("li2").className = "selected";
                document.getElementById("li3").className = "";
                document.getElementById("li4").className = "";
                document.getElementById("li5").className = "";
                document.getElementById("li6").className = "";
                document.getElementById("li7").className = "";
            }
            else if (id == 3) {
                document.getElementById("li1").className = "";
                document.getElementById("li2").className = "";
                document.getElementById("li3").className = "selected";
                document.getElementById("li4").className = "";
                document.getElementById("li5").className = "";
                document.getElementById("li6").className = "";
                document.getElementById("li7").className = "";
            }
            else if (id == 4) {
                document.getElementById("li1").className = "";
                document.getElementById("li2").className = "";
                document.getElementById("li3").className = "";
                document.getElementById("li4").className = "selected";
                document.getElementById("li5").className = "";
                document.getElementById("li6").className = "";
                document.getElementById("li7").className = "";
            }
            else if (id == 5) {
                document.getElementById("li1").className = "";
                document.getElementById("li2").className = "";
                document.getElementById("li3").className = "";
                document.getElementById("li4").className = "";
                document.getElementById("li5").className = "selected";
                document.getElementById("li6").className = "";
                document.getElementById("li7").className = "";
            }
            else if (id == 6) {
                document.getElementById("li1").className = "";
                document.getElementById("li2").className = "";
                document.getElementById("li3").className = "";
                document.getElementById("li4").className = "";
                document.getElementById("li5").className = "";
                document.getElementById("li6").className = "selected";
                document.getElementById("li7").className = "";
            }
            else {
                document.getElementById("li1").className = "";
                document.getElementById("li2").className = "";
                document.getElementById("li3").className = "";
                document.getElementById("li4").className = "";
                document.getElementById("li5").className = "";
                document.getElementById("li6").className = "";
                document.getElementById("li7").className = "selected";
            }
           
        }
        function DownLoad(e) {
            $.ajaxSetup({
                async: false
            });
            var a = true;
            var erid = getUrlParam("id");
            var psw = $(e).next().val();
            if (psw == "1") {
                var name = prompt("请输入密码", "");
                if (name != "" && name != null) {
                    jQuery.post("../ashx/SetDownLoad.ashx?id=" + erid + "&psw=" + name, function (data) {
                        if (data.result == "success") {
                            a = true;
                        }
                        else {
                            alert("密码错误");
                            a = false;
                        }
                    }, "json");
                }
                else {
                    a = false;
                }

            }
            else {
                jQuery.post("../ashx/SetDownLoad.ashx?id=" + erid, function (data) { });
                a = true;
            }
            return a;
        }
        function getUrlParam(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
            var r = window.location.search.substr(1).match(reg);  //匹配目标参数
            if (r != null) return unescape(r[2]); return null; //返回参数值
        }
    </script>
</head>
<body>
    <form runat="server">
        <div class="headcss">
            <div class="headlogo">
                <img src="../images/zy_2.png">
            </div>
            <div class="headmenu">
                <ul>
                    <li>
                        <a href="Res_NewMain.aspx">首页</a>
                    </li>
                    <li id="li1">
                        <a href="Index.aspx" onclick="changecss(1)">全部</a>
                    </li>
                    <li id="li2">
                        <a href="Index.aspx?RType=1" onclick="changecss(2)">课件</a>
                    </li>
                    <li id="li3">
                        <a href="Index.aspx?RType=2" onclick="changecss(3)">教案</a>
                    </li>
                    <li id="li4">
                        <a href="Index.aspx?RType=3" onclick="changecss(4)">试卷</a>
                    </li>
                    <li id="li5">
                        <a href="Index.aspx?RType=4" onclick="changecss(5)">素材</a>
                    </li>
                    <li id="li6">
                        <a href="Index.aspx?RType=5" onclick="changecss(6)">微课程</a>
                    </li>
                    <li id="li7">
                        <a href="Index.aspx?RType=7" onclick="changecss(7)">其他</a>
                    </li>
                </ul>
            </div>
        </div>
        <div class="centcss">
            <div class="leftcss">
                <div class=" listcss">
                    <div class="titlecss">最新资源</div>
                    <asp:Repeater ID="rp_zxList" runat="server">
                        <ItemTemplate>
                            <ul>
                                <li><a title="<%#Eval("ResourseName") %>"><%#GetCutStr( Eval("ResourseName"),20) %></a></li>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div runat="server" id="tr_null1" style="text-align: center">
                        暂无记录
                    </div>
                </div>
                <div class="listcss">
                    <div class="titlecss">精品资源</div>
                    <asp:Repeater ID="rp_jpList" runat="server">
                        <ItemTemplate>
                            <ul>
                                <li><a title="<%#Eval("ResourseName") %>"><%#GetCutStr( Eval("ResourseName"),20) %></a></li>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div runat="server" id="tr_null2" style="text-align: center">
                        暂无记录
                    </div>
                </div>
            </div>
            <asp:Repeater ID="rp_List" runat="server">
                <ItemTemplate>
                    <div class="rightcss">
                        <div class="infocss">
                            <h3>
                                <img src='<%#GetPic(Eval("RFormat")) %>' class="zybs"><%#Eval("ResourseName") %></h3>
                            <div class="leftf">
                                <div>
                                    <ul>
                                        <li><span>上传人：<%#Eval ("CreateUserName") %></span><span>资源格式：<%#Eval("RFormat") %></span></li>
                                        <li><span>资源大小：<%#GetSize( Eval("RSize").ToString()) %></span><span>下载量：<%#Eval("DownLoadNum") %></span></li>
                                        <li><span>上传时间：<%#Eval("CreateDate","{0:yyyy-MM-dd HH:mm:ss}") %></span></li>
                                        <li><span>资源分类：<a><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.EType>(Eval("EType")) %></a></span><span>资源学科：<a><%# Eval("SubtypeName")%>资源</a></span></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="rightf">
                                <a >
                                    <asp:ImageButton ID="img_xz" runat="server" ImageUrl="../images/info_09.png" OnClientClick="return DownLoad(this);"  OnClick="img_xz_Click" />
                                   <%-- <asp:HiddenField ID="hf_erid" Value='<%#Eval("Erid") %>' runat="server" />--%>
                                  <asp:HiddenField ID="hf_psw"  runat="server" Value='<%#Eval("ERPwd").ToString()!=""?"1":"0" %>' />
                                </a>  
                                <a>
                                    <asp:ImageButton ID="img_sc" runat="server" ImageUrl="../images/info_091.png" OnClick="img_sc_Click" /></a>
                            </div>
                            <div style="clear: both"></div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
