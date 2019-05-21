<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherSpace.aspx.cs" Inherits="GKICMP.spacemanage.TeacherSpace" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="../css/zstyle.css" rel="stylesheet" type="text/css" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <link href="../css/iconfont.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'LogDetail.aspx', 'id=' + id, 1000, 540, 1);
        }
    </script>
    <style>
        .pagelist {
            text-align: center;
        }

            .pagelist a {
                display: inline-block;
                width: 30px;
                height: 30px;
                text-decoration: none;
                color: #323232;
            }

        .ban {
            opacity: .4;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_UserID" />
        <asp:HiddenField runat="server" ID="hf_Num" />
        <div class="menucs">
            <ul>
                <li class="selected">
                    <asp:LinkButton runat="server" ID="lbtn_ClassHome" Text="个人主页"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton runat="server" ID="lbtn_ClassCul" Text="我的日志" OnClick="lbtn_ClassCul_Click"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton runat="server" ID="lbtn_Studio" Text="教学工作室" OnClick="lbtn_Photo_Click"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton runat="server" ID="lbtn_Lesson" Text="协同备课" OnClick="lbtn_Lesson_Click"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton runat="server" ID="lbtn_ClassSpace" Text="班级空间" OnClick="lbtn_ClassSpace_Click"></asp:LinkButton></li>
            </ul>
        </div>
        <div class="bancs gr">
            <div class="bancent">
                <div class="bantit">
                    <asp:Literal runat="server" ID="ltl_RealName"></asp:Literal>的个人空间
                </div>
            </div>
        </div>
        <div class="classcs">
            <div class="classtopleft w190">
                <div class="userinfocss">
                    <asp:Image runat="server" ID="img_Photo" Width="100px" Height="100px" />
                    <div style="text-align: center;">
                        <asp:Literal runat="server" ID="ltl_Sex"></asp:Literal>
                        <asp:Literal runat="server" ID="ltl_Birthday"></asp:Literal><br />
                        <asp:Literal runat="server" ID="ltl_Address"></asp:Literal>
                    </div>
                </div>
                <div class="userheadlist">
                    <div><span>同事列表</span></div>
                    <ul id="ul1">
                    </ul>
                    <div class="pagelist">
                        <a href="#" id="prePage" class="icon iconfont icon-zuo"></a>
                        <a href="#" id="nextPage" class="icon iconfont icon-you"></a>
                    </div>
                </div>
            </div>
            <div class="classtopright w785">
                <div class="righttit">最新动态</div>
                <hr style="color: #e0e0e0" />
                <ul>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <div class="listm">
                                <div class="listt"><span><%#Eval("LogTitle") %></span> </div>
                                <div class="listd"><span><%#Eval("SysUserName") %></span><%#Eval("CreateDate","{0:yyyy-MM-dd}") %></div>
                                <div class="listb">
                                    <span>
                                        <asp:LinkButton runat="server" ID="lbtn_ReadAll" OnClientClick='return viewinfo(this);'>阅读全文>></asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField1" Value='<%#Eval("EGID") %>' runat="server" />
                                    </span>
                                    <span>
                                        <asp:LinkButton runat="server" ID="lbtn_Praise" OnClick="lbtn_Praise_Click" CommandArgument='<%#Eval("EGID") %>'>赞（<%#Eval("PeoNum") %>）</asp:LinkButton>
                                    </span>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div runat="server" id="tr_null" style="text-align: center">
                    暂无记录      
                </div>
                <div class="listmre" style="border: none; text-align: right">
                    <div class="titname" style="font-size: 14PX;">
                        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
                    </div>
                </div>
            </div>
            <div style="clear: both"></div>
        </div>
        <script type="text/javascript">
            /** 
             * 分页函数 * pno--页数 * psize--每页显示记录数 
             * 分页部分是从真实数据行开始，因而存在加减某个常数，以确定真正的记录数 
             * 纯js分页实质是数据行全部加载，通过是否显示属性完成分页功能 
            **/
            var pageSize = 12;//每页显示行数  
            var currentPage_ = 1;//当前页全局变量，用于跳转时判断是否在相同页，在就不跳，否则跳转。  
            var totalPage;//总页数
            var allnum;
            var html = "";
            $.ajax({
                url: "../ashx/UserList.ashx",
                cache: false,
                type: "get",
                async: false,
                data: "method=GetPartner",
                dataType: "json",
                success: function (data) {
                    allnum = data.length;
                    if (data != '') {
                        for (var i = 0; i < data.length; i++) {
                            html += "<li><a href='TeacherSpace.aspx?id=" +
                                data[i].UID +
                                "' title='" +
                                data[i].RealName +
                                "'>" +
                                "<img src='" +
                                (data[i].Photos == "" ? "../images/t_male.png" : data[i].Photos) +
                                "' />" +
                                data[i].RealName +
                                "</a></li>";
                        }
                        $("#ul1").html(html);

                        goPage(currentPage_, pageSize, allnum);
                    }
                }
            });

            function goPage(pno, psize, num) {
                var url1;
                pageSize = psize;//每页显示行数  
                //总共分几页   
                if (num / pageSize > parseInt(num / pageSize)) {
                    totalPage = parseInt(num / pageSize) + 1;
                } else {
                    totalPage = parseInt(num / pageSize);
                }
                var currentPage = pno;//当前页数  
                currentPage_ = currentPage;
                var startRow = (currentPage - 1) * pageSize + 1;
                var endRow = currentPage * pageSize;
                endRow = (endRow > num) ? num : endRow;
                //遍历显示数据实现分页  

                $("#ul1 li").hide();
                for (var i = startRow - 1; i < endRow; i++) {
                    $("#ul1 li").eq(i).show();
                }

                if (currentPage > 1) {
                    $("#prePage").on("click", function (e) {
                        e.preventDefault(); // 阻止链接跳转
                        url1 = this.href; // 保存点击的地址
                        $('#userheadlist').load(url1 + ' #ul1').fadeIn('slow');
                        goPage(currentPage - 1, psize, allnum);
                    }).removeClass("ban");
                } else {
                    $("#prePage").off("click").addClass("ban");
                }
                if (currentPage < totalPage) {
                    $("#nextPage").on("click", function (e) {
                        e.preventDefault(); // 阻止链接跳转
                        url1 = this.href; // 保存点击的地址
                        $('#userheadlist').load(url1 + ' #ul1').fadeIn('slow');
                        goPage(currentPage + 1, psize, allnum);
                    }).removeClass("ban");
                } else {
                    $("#nextPage").off("click").addClass("ban");
                }
            }



            //$(function () {
            //    $.getJSON("../ashx/UserList.ashx?method=GetPartner", function (data) {
            //        var html = "";
            //        totalPage = data.length;
            //        //allnum = data.length;
            //        //document.getElementById("hf_Num").value = data.length;
            //        for (var i = 0; i < data.length ; i++) {
            //            html += "<li><a href='TeacherSpace.aspx?id=" + data[i].UID + "' title='" + data[i].RealName + "'>"
            //                + "<img src='" + (data[i].Photos == "" ? "../images/t_male.png" : data[i].Photos) + "' />" + data[i].RealName + "</a></li>";
            //        }
            //        $("#ul1").html(html);
            //        goPage(currentPage_, pageSize, totalPage);
            //    })
            //})
        </script>
    </form>
</body>
</html>

