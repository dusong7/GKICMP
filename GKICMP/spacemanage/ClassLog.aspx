<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassLog.aspx.cs" Inherits="GKICMP.spacemanage.ClassLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
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
                return openbox('A_id', 'LogEdit.aspx', 'claid=' + claid, 1240, 620, 56);
            });
        });

        function commentinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'MessageEdit.aspx', 'id=' + id + '&flag=1', 940, 320, 59)
        }

        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'LogDetail.aspx', 'id=' + id, 1000, 540, 1);
        }
    </script>
    <%--<style>
        body
        {
            background-color:white;
        }
    </style>--%>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_ClaID" />
        <div class="menucs">
            <ul>
                <li>
                    <asp:LinkButton runat="server" ID="lbtn_ClassHome" Text="班级主页" OnClick="lbtn_ClassHome_Click"></asp:LinkButton></li>
                <li class="selected">
                    <asp:LinkButton runat="server" ID="lbtn_ClassCul" Text="文化墙"></asp:LinkButton></li>
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
            <asp:Button runat="server" ID="btn_Upload" Text="写日志" CssClass="listupload" />
        </div>
        <div class="centcss">
            <asp:Repeater runat="server" ID="rp_List">
                <ItemTemplate>
                    <div class="listm">
                            <div class="listt"><span><%#Eval("LogTitle") %></span> </div>
                            <div class="listd"><span><%#Eval("SysUserName") %></span>&nbsp;<%#Eval("CreateDate","{0:yyyy-MM-dd HH:mm}") %></div>
                            <div class="listi">
                                <%#Eval("LogText").ToString().Length>300?Eval("LogText").ToString().Substring(0,300)+"...":Eval("LogText").ToString() %>
                            </div>
                            <div class="listb">
                                <span>
                                    <asp:LinkButton runat="server" ID="lbtn_ReadAll" OnClientClick='return viewinfo(this);'>阅读全文>></asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField1" Value='<%#Eval("EGID") %>' runat="server" />
                                </span>
                                <span>
                                     <asp:LinkButton runat="server" ID="lbtn_Comment" OnClientClick="return commentinfo(this);">评论</asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField2" Value='<%#Eval("EGID") %>' runat="server" />
                                    <asp:LinkButton runat="server" ID="lbtn_Praise" OnClick="lbtn_Praise_Click" CommandArgument='<%#Eval("EGID") %>'>
                                        <%#GetDZ(Eval("EGID"))%>（<%#Eval("PeoNum") %>）</asp:LinkButton></span>
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