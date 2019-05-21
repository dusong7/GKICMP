<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EgovernmentDetail.aspx.cs" Inherits="GKICMP.app.EgovernmentDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>政务详情</title>

    <link href="../appcss/mui.css" rel="stylesheet" />

    <link href="../appcss/demo.css" rel="stylesheet" />
    <link href="../appcss/easyui.css" rel="stylesheet" />
    <link href="../appcss/iconfont.css" rel="stylesheet" />

    <link href="../appcss/new_file.css" rel="stylesheet" />

    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <script src="../appjs/mui.min.js"></script>
    <script src="../js/mui.min.js"></script>
    <script src="../js/oa_iconfont.js"></script>


    <link href="../EasyUI/themes/icon.css" rel="stylesheet" />


    <style>
        body {
            margin: 0px;
            padding: 0px;
            padding-bottom: 100px;
        }

        .selectdiv {
            display: none;
            width: 100%;
            height: 100%;
            position: fixed;
            top: 0px;
            left: 0px;
            background: #fff;
            color: #494949;
            overflow-y: auto;
            z-index: 999;
        }

        .allselect {
            float: left;
            margin: 5px;
            margin-left: 10px;
        }

            .allselect span {
                float: left;
                display: inline-block;
                border: 1px solid #989898;
                width: 16px;
                height: 16px;
                margin-right: 5px;
            }

                .allselect span.selected {
                    background: url(../appimages/selectinfo.png) center center no-repeat #f5faff;
                }

        .selectclose {
            float: right;
            display: block;
            border: 1px solid #989898;
            border-radius: 2px;
            padding: 3px 10px;
            margin: 5px;
            font-size: 14px;
        }

        .selectdiv ul, .selectdiv li {
            margin: 0px;
            list-style: none;
            padding: 0px;
        }

        .selectdiv .parentli {
            border-bottom: 1px solid #DDDDDD;
            padding: 10px 10px;
        }

            .selectdiv .parentli.selected ul {
                display: block;
            }

            .selectdiv .parentli span.selected {
                background: url(../appimages/selectinfo.png) center center no-repeat #f5faff;
            }

            .selectdiv .parentli ul {
                display: none;
            }

            .selectdiv .parentli span {
                display: inline-block;
                border: 1px solid #989898;
                width: 16px;
                height: 16px;
                float: left;
                margin-right: 5px;
            }

            .selectdiv .parentli img {
                float: left;
                margin-right: 5px;
            }

            .selectdiv .parentli li {
                width: 70px;
                display: inline-block;
                border: 1px solid #dedede;
                margin-top: 10px;
                padding: 3px 5px;
                border-radius: 2px;
            }

                .selectdiv .parentli li.select {
                    background: url(../appimages/selectinfo.png) 50px center no-repeat #f5faff;
                    border-color: #1296db;
                    color: #1296db;
                }
    </style>

    <script>
        $(function () {
            $(".parentli li").each(function () {
                if ($(this).hasClass("select"))
                { }
                else { $(this).addClass("noselect") }
            });
            $("#dxseclet").click(function () {
                $("#dxc").css("display", "block");
            })

            $("#selectclose").click(function () {
                $("#dxc").css("display", "none");
            })

            $(".parentli img").click(function () {
                if ($(this).parent("li").hasClass("selected")) {
                    $(this).parent("li").removeClass("selected");
                    $(this).attr("src", "../appimages/allpic.png");
                } else {
                    $(this).parent("li").addClass("selected");
                    $(this).attr("src", "../appimages/allinpic.png");
                }
            })
            $("#allselect span").click(function () {
                if ($(this).hasClass("selected")) {
                    $(this).removeClass("selected");
                    $(".parentli span").removeClass("selected");
                    $(".parentli li").removeClass("select");
                    $(".parentli li").addClass("noselect");
                } else {
                    $(this).addClass("selected");
                    $(".parentli span").addClass("selected");
                    $(".parentli li").addClass("select");
                    $(".parentli li").removeClass("noselect");
                }
                selectoption();
            })

            $(".parentli li").click(function () {
                if ($(this).hasClass("select")) {
                    $(this).addClass("noselect");
                    $(this).removeClass("select");
                } else {
                    $(this).removeClass("noselect");
                    $(this).addClass("select");
                }

                if ($(this).parent().find("li").hasClass("noselect")) {
                    $(this).parent().siblings("span").removeClass("selected");
                } else {
                    $(this).parent().siblings("span").addClass("selected");
                }
                selectoption();
            })

            $(".parentli span").click(function () {
                if ($(this).hasClass("selected")) {
                    $(this).removeClass("selected");
                    $(this).parent().find("li").addClass("noselect");
                    $(this).parent().find("li").removeClass("select");
                } else {
                    $(this).addClass("selected");
                    $(this).parent().find("li").removeClass("noselect");
                    $(this).parent().find("li").addClass("select");
                }
                selectoption();
            })
            function selectoption() {
                $("#hf_UID").val('');
                $("#dxseclet").val('');
                $(".parentli li").each(function () {
                    if ($(this).hasClass("select")) {
                        $("#hf_UID").val($("#hf_UID").val() + this.id + ",");
                        $("#dxseclet").val($("#dxseclet").val() + this.title + ",");
                    }
                });
                if ($("#dxc .parentli").find("li").hasClass("noselect")) {
                    $("#allselect span").removeClass("selected");
                } else {
                    $("#allselect span").addClass("selected");
                }
            }

        })
    </script>



</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
        <asp:HiddenField ID="hf_SelectedValue" runat="server" />
        <asp:HiddenField ID="hf_SelectedText" runat="server" />
        <asp:HiddenField ID="hf_UID" runat="server" />
        <div class="mui-content bgcolor-white">

            <div class="mui-col-xs-11" style="margin: auto;">
                <h3 style="text-align: center; line-height: 1.5;">
                    <asp:Label ID="lbl_ETitle" runat="server" Text=""></asp:Label>
                </h3>
                <h4 style="text-align: center; line-height: 1; font-size: 10px; color: #929292;">发件人：
                    <asp:Label ID="lbl_AcceptUser" runat="server" Text=""></asp:Label>
                    时间：  
                    <asp:Literal runat="server" ID="lbl_SendDate"></asp:Literal>
                </h4>
                <div style="line-height: 1.5;" id="zxyl">
                    <asp:Label ID="lbl_EContent" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div id="oacontent" class="listname">
                <ul>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <li>
                                <span><%#Eval("SendUserName")%></span><span class="iconfont icon-jiantou"></span>
                                <span><%#Eval("AcceptUser") %></span>
                            </li>
                            <li>
                                <%#Eval("Comment")%>&nbsp <%#Eval("SendDate","{0:yyyy-MM-dd HH:mm}")%>
                               
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div style="clear: both"></div>
                </ul>
            </div>
            <div class="dmenu" id="subnav">
                <ul>
                    <li runat="server" id="btn_YY123">
                        <span class="iconfont icon-zhuanfa"></span>
                        <span>
                            <input type="button" value="返回" onclick="javascript: window.history.back(-1);" />
                        </span>
                    </li>
                    <li runat="server" id="btn_CY123">
                        <span class="iconfont icon-chuanyue"></span>
                        <span>
                            <asp:Button ID="btn_CY" runat="server" Text="批转 " OnClick="btn_CY_Click" />
                        </span>
                    </li>
                </ul>
            </div>

            <div id="pz" runat="server" class="listcent pad0">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                    <%--<tr>
                        <td align="center">收件人</td>
                        <td align="LEFT">
                            <input id="Series" name="Series" style="height: 40px" class="easyui-combotree" />
                        </td>
                    </tr>--%>

                    <tr>
                        <td align="center">收件人</td>
                        <td align="LEFT">
                            <input type="text" id="dxseclet" name="dxseclet" placeholder="点击此处选择收件人">
                            <div class="selectdiv" id="dxc">
                                <div style="height: 30px">
                                    <div class="allselect" id="allselect"><span></span>全选</div>
                                    <span class="selectclose" id="selectclose">确定</span>
                                </div>
                                <ul>
                                    <asp:Repeater ID="rpmodule" runat="server" OnItemDataBound="rpmodule_ItemDataBound">
                                        <ItemTemplate>
                                            <li class='<%#Container.ItemIndex==0?"parentli selected":"parentli" %>'>
                                                <img src='<%#Container.ItemIndex==0?"../appimages/allinpic.png":"../appimages/allpic.png"%>' /><span></span><%#Eval("DepName") %>
                                                <asp:HiddenField runat="server" ID="hf_DID" Value='<%#Eval("DID") %>' />
                                                <ul>
                                                    <asp:Repeater ID="rpnextModule" runat="server">
                                                        <ItemTemplate>
                                                            <li id='<%#Eval("UID") %>' title='<%#Eval("RealName") %>'><%#Eval("RealName") %></li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>

                        </td>
                    </tr>

                    <tr>
                        <td align="center">批注</td>
                        <td align="LEFT">
                            <script>
                                $(function () {
                                    $('#cc').combobox({
                                        data: [
                                        { "id": "请领导审阅", "text": "请领导审阅" },
                                        { "id": "请按文件精神及时阅办", "text": "请按文件精神及时阅办" },
                                        { "id": "请在本单位内部传阅!!", "text": "请在本单位内部传阅!!" },
                                        { "id": "请阅办!", "text": "请阅办!" },
                                        { "id": "请抓紧落实!", "text": "请抓紧落实!" },
                                        { "id": "请尽快上报!", "text": "请尽快上报!" },
                                        { "id": "请上会商议!", "text": "请上会商议!" },
                                        { "id": "请传达学习!", "text": "请传达学习!" },
                                        { "id": "请参考执行!", "text": "请参考执行!" },
                                        { "id": "请准时参会!", "text": "请准时参会!" },
                                        ],

                                        valueField: 'id',
                                        textField: 'text',
                                        editable: true
                                    });
                                });
                            </script>
                            <input id="cc" class="easyui-combobox" name="dept" style="height: 40px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: left">
                            <asp:Button ID="btn_Send" runat="server" Text="发送" OnClientClick="SetValue()" OnClick="btn_Send_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>


        <nav class="mui-bar mui-bar-tab">
           <a href="/phone" class="mui-tab-item ">
                <span class="mui-icon mui-icon-home"></span>
                <span class="mui-tab-label">网站</span>
            </a>
            <a class="mui-tab-item">
                <span class="mui-icon iconfont icon-wd"></span>
                <span class="mui-tab-label">我的</span>
            </a>
            <%--  <a class="mui-tab-item">
                <span class="mui-icon iconfont icon-bj"></span>
                <span class="mui-tab-label">班级</span>
            </a>--%>
            <a href="AppMain.aspx" class="mui-tab-item mui-active">
                <span class="mui-icon iconfont icon-zhxy"></span>
                <span class="mui-tab-label">智慧校园</span>
            </a>
        </nav>
        <script src="../js/mui.min.js"></script>
        <script type="text/javascript" charset="utf-8">
            mui.init({
                swipeBack: true //启用右滑关闭功能
            });
            var slider = mui("#slider");
            slider.slider({
                interval: 3000
            });
            mui('body').on('tap', 'a', function () { document.location.href = this.href; });
        </script>
        <script type='text/javascript'>
            var subnav = document.getElementById('subnav'),
				aLi = document.querySelectorAll('#subnav li'),
				w = subnav.offsetWidth / aLi.length; //通过容器的宽度除以li的个数来计算每个li的宽度
            for (var i = 0; i < aLi.length; i++) {
                aLi[i].style.width = w + 'px';
            }
        </script>
        <script>
            function SetValue() {
                var val = $('#cc').combobox('getText');//批注
                document.getElementById("hf_SelectedText").value = val;
                var U = new Array();
                $($("#Series").combotree("tree").tree("getChecked")).each(function () {
                    if (this.children == null && $("#Series").combotree("tree").tree("find", this.id) != null) {
                        U.push(this.id);
                    }
                });
                document.getElementById("hf_SelectedValue").value = U;

            };
        </script>

        <%--<script src="http://code.jquery.com/jquery-1.9.1.js"></script>--%>
        <script type="text/javascript">
            $("#zxyl a[href$='.doc'],#zxyl a[href$='.docx'],#zxyl a[href$='.pdf']").click(function (e) {
                e.preventDefault();//取消默认操作
                //$("#viewer").remove()
                //    $("<div style='width:98;' id='viewer' class='panel'>" +
                //        "<div class='panel-header'><div class='panel-title'>文档预览</div>" +
                //        "<div class='panel-tool'>" +
                //        "<a href='javascript:void(0);' onclick='$(\"#viewer\").remove();' id='closeviewer' style='color:#F00;'>χ</a></div>" +
                //        "</div><div class='panel-body'>" +
                //        "<iframe frameborder=0 style='width:99.9%;border:none;height:800px;' src='http://office.scaqjg.com/op/view.aspx?src=" + ($(this).attr("url").indexOf("://") > 0 ? $(this).attr("url") : ("http://" + document.domain + "/" + $(this).attr("url"))) + "'></iframe></div></div>").insertAfter($(this));
            });
            //$("#zxyl a[href$='.doc'],#zxyl a[href$='.docx'],#zxyl a[href$='.xls'],#zxyl a[href$='.xlsx'],#zxyl a[href$='.ppt'],#zxyl a[href$='.pptx']").each(function () {
            //    $("<a href='javascript:void(0);' url='" + $(this).attr("href") + "' class='view' >在线预览</a>").insertAfter($(this));
            //});
            //$(".view").linkbutton({ iconCls: "icon-ok", plain: "true" }).click(function () {
            //    $("#viewer").remove();
            //    $("<div style='width:98;' id='viewer' class='panel'>" +
            //        "<div class='panel-header'><div class='panel-title'>文档预览</div>" +
            //        "<div class='panel-tool'>" +
            //        "<a href='javascript:void(0);' onclick='$(\"#viewer\").remove();' id='closeviewer' style='color:#F00;'>χ</a></div>" +
            //        "</div><div class='panel-body'>" +
            //        "<iframe frameborder=0 style='width:99.9%;border:none;height:800px;' src='http://office.scaqjg.com/op/view.aspx?src=" + ($(this).attr("url").indexOf("://") > 0 ? $(this).attr("url") : ("http://" + document.domain + "/" + $(this).attr("url"))) + "'></iframe></div></div>").insertAfter($(this));
            //});

        </script>

    </form>
</body>
</html>
