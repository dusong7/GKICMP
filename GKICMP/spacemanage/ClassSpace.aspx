<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassSpace.aspx.cs" Inherits="GKICMP.spacemanage.ClassSpace" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>智慧校园管理平台</title>
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <link href="../css/zstyle.css" rel="stylesheet" type="text/css">
    <script type="text/javascript">
        $(function () {
            $('#btn_Upload').click(function () {
                var claid = document.getElementById("hf_ClaID").value;
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'MessageEdit.aspx', 'id=' + claid + '&flag=3', 940, 320, 59);
            });
        });

        function showbox(id) {
            return openbox('A_id', '../oamanage/AfficheDetail.aspx', 'id=' + id, 940, 360, 1)
        }
    </script>
</head>
<body>
    <form runat="server" id="form1">
        <asp:HiddenField runat="server" ID="hf_UserType" />
        <asp:HiddenField runat="server" ID="hf_DepID" />
        <asp:HiddenField runat="server" ID="hf_ClaID" />
        <div class="menucs">
            <ul>
                <%--<li class="selected"><a href="#">班级主页</a></li>
            <li><a href="#">文化墙</a></li>--%>
                <%--<li><a href="ClassPhotos.aspx?claid=<%=ClaID %>" target="main">相册</a></li>--%>
                <li class="selected">
                    <asp:LinkButton runat="server" ID="lbtn_ClassHome" Text="班级主页"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton runat="server" ID="lbtn_ClassCul" Text="文化墙" OnClick="lbtn_ClassCul_Click"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton runat="server" ID="lbtn_Photo" Text="相册" OnClick="lbtn_Photo_Click"></asp:LinkButton></li>
            </ul>
        </div>
        <div class="bancs">
            <div class="bancent">
                <div class="bantit">
                    <asp:Literal runat="server" ID="ltl_GradeName"></asp:Literal><asp:Literal runat="server" ID="ltl_ClassName"></asp:Literal>
                </div>
                <%--<div class="baninfo">
                    <asp:Literal runat="server" ID="ltl_Notes"></asp:Literal>
                </div>--%>
            </div>
        </div>
        <div class="whlist">
            <asp:Button runat="server" ID="btn_Upload" Text="我要留言" CssClass="listupload" />
        </div>
        <div class="classcs">
            <div class="classtopleft" style="height: 160px;">
                年级主任：<asp:Literal runat="server" ID="ltl_GradeUser"></asp:Literal><br>
                班主任：<asp:Literal runat="server" ID="ltl_DutyUser"></asp:Literal><br>
                班级人数：<span class="clocs"><asp:Literal runat="server" ID="ltl_ClassCount"></asp:Literal></span> 人<br>
            </div>
            <div class="classtopright" style="height: 200px;">
                <div class="righttit">最新公告</div>
                <ul>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <%--<div class="listt"><span><%#Eval("AfficheTitle") %></span> <span><%#Eval("SendUserName") %></span></div>
                            <li><a href="#"><span>发送日期为：<%#Eval("SendDate","{0:yyyy-MM-dd HH：mm}") %>的<%#Eval("classname") %>的标题为：<%#Eval("AfficheTitle") %></span></a></li>--%>
                            <div class="listm" style="padding: 6px 10px;">
                                <div class="listt">
                                    <a onclick='<%#"showbox(\""+Eval("AID")+"\")"%>' style="cursor: pointer;">
                                        <span style="color: #666666;">【<%#Eval("SendUserName") %>】</span><span style="font-weight: normal; color: #666666; font-size: 16px;"><%#Eval("AfficheTitle") %></span>
                                        <span style="color: #666666; float: right;"><%#Eval("SendDate","{0:yyyy-MM-dd HH:mm}") %></span>
                                    </a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <li runat="server" id="li1" style="text-align: center; line-height: 50px;">暂无公告</li>
                </ul>
            </div>
            <div style="clear: both"></div>
        </div>
        <div class="classinfo">
            <ul>
                <asp:Repeater runat="server" ID="rp_MassageList">
                    <ItemTemplate>
                        <li>
                            <div>
                                <img src='<%#GetPhoto(Eval("UserType"))%>'><span><%#Eval("SysUserName") %>&nbsp;<%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.UserType>(Eval("UserType")) %><br>
                                    <%#Eval("CreateDate","{0:yyyy-MM-dd HH:mm}") %></span><div style="clear: both"></div>
                            </div>
                            <div><%#Eval("MContent") %></div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
                <li runat="server" id="li2" style="text-align: center; line-height: 30px; height: 30px;">暂无留言</li>
            </ul>
        </div>
        <div class="pagcs">
            <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
        </div>
    </form>
</body>
</html>
