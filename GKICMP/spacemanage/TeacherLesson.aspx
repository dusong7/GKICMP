<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherLesson.aspx.cs" Inherits="GKICMP.spacemanage.TeacherLesson" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="../css/zstyle.css" rel="stylesheet" type="text/css">
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btn_Upload').click(function () {
                //var claid = document.getElementById("hf_ClaID").value;
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'LogEdit.aspx', 'claid=-2', 1240, 620, 56);
            });
        });

        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'LogDetail.aspx', 'id=' + id, 1000, 540, 1);
        }

        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'LogEdit.aspx', 'id=' + id, 1000, 540, 0);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_ClaID" />
        <asp:HiddenField runat="server" ID="hf_UID" />
        <div class="menucs">
            <ul>
                <li>
                    <asp:LinkButton runat="server" ID="lbtn_ClassHome" Text="个人主页" OnClick="lbtn_ClassHome_Click"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton runat="server" ID="lbtn_ClassCul" Text="我的日志" OnClick="lbtn_ClassCul_Click"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton runat="server" ID="lbtn_Studio" Text="教学工作室" OnClick="lbtn_Photo_Click"></asp:LinkButton></li>
                <li class="selected">
                    <asp:LinkButton runat="server" ID="lbtn_Lesson" Text="协同备课"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton runat="server" ID="lbtn_ClassSpace" Text="班级空间" OnClick="lbtn_ClassSpace_Click"></asp:LinkButton></li>
            </ul>
        </div>
        <div class="bancs gr">
            <div class="bancent">
                <div class="bantit">
                    <asp:Literal runat="server" ID="ltl_RealName"></asp:Literal>的协同备课
                </div>
                <%--<div class="baninfo1">
                    <asp:Literal runat="server" ID="ltl_GradeName"></asp:Literal><asp:Literal runat="server" ID="ltl_ClassName"></asp:Literal>
                </div>--%>
            </div>
        </div>
        <%--<div class="whlist">
            <asp:Button runat="server" ID="btn_Upload" Text="写日志" CssClass="listupload" />
        </div>--%>
        <div class="centcss">
            <asp:Repeater runat="server" ID="rp_List">
                <ItemTemplate>
                    <div class="listm">
                        <div class="listt"><span>【<%#Eval("LName") %>第<%#Eval("WeekNum") %>周】</span></div>
                        <div class="listd">&nbsp;&nbsp;<span><%#Eval("LYear") %></span><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XQ>(Eval("TID")) %></div>
                        <div class="listi">
                            &nbsp;&nbsp;<%#Eval("AContent").ToString().Length>300?Eval("AContent").ToString().Substring(0,300)+"...":Eval("AContent").ToString() %>
                        </div>
                        <div class="listb">
                            <span>
                            </span>
                            <span>
                                <asp:LinkButton runat="server" ID="lbtn_Bill" Visible='<%#IsVisible() %>' CommandName='<%#Eval("IsPrePare") %>' CommandArgument='<%# string.Format("{0},{1},{2}",Eval("LDID") ,Eval("LID"), Eval("LType"))%>' OnClick="lbtn_Bill_Click">备课</asp:LinkButton>
                                <asp:HiddenField ID="HiddenField2" Value='<%#Eval("LDID") %>' runat="server" />
                            </span>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div runat="server" id="tr_null" style="text-align: center; height: 30px; line-height: 30px;">
                暂无记录                                              
            </div>
            <div class="listmre" style="border: none; text-align: right">
                <div class="titname" style="font-size: 14PX;">
                    <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
