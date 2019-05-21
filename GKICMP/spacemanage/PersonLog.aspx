<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonLog.aspx.cs" Inherits="GKICMP.spacemanage.PersonLog" %>


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
                var claid = document.getElementById("hf_ClaID").value;
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'LogEdit.aspx', 'claid=' + claid, 1240, 620, 56);
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
                <li class="selected">
                    <asp:LinkButton runat="server" ID="lbtn_ClassCul" Text="文化墙"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton runat="server" ID="lbtn_Photo" Text="相册" OnClick="lbtn_Photo_Click"></asp:LinkButton></li>
            </ul>
        </div>
        <div class="bancs gr">
            <div class="bancent">
                <div class="bantit">
                    <asp:Literal runat="server" ID="ltl_RealName"></asp:Literal>的文化墙
                </div>
                <%--<div class="baninfo1">
                    <asp:Literal runat="server" ID="ltl_GradeName"></asp:Literal><asp:Literal runat="server" ID="ltl_ClassName"></asp:Literal>
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
                        <div class="listd"><span><%#Eval("SysUserName") %></span><%#Eval("CreateDate","{0:yyyy-MM-dd}") %></div>
                        <%--<div class="listi">
                                <%#Eval("LogTitle").ToString().Length>300?Eval("LogTitle").ToString().Substring(0,300)+"...":Eval("LogTitle").ToString() %>
                            </div>--%>
                        <div class="listb">
                            <span>
                                <asp:LinkButton runat="server" ID="lbtn_ReadAll" OnClientClick='return viewinfo(this);'>阅读全文>></asp:LinkButton>
                                <asp:HiddenField ID="HiddenField1" Value='<%#Eval("EGID") %>' runat="server" />
                            </span>
                            <span>
                                <asp:LinkButton runat="server" ID="lbtn_Praise" OnClick="lbtn_Praise_Click" CommandArgument='<%#Eval("EGID") %>'>赞（<%#Eval("PeoNum") %>）</asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lbtn_Edit" Visible='<%#IsVisible(Eval("SysID")) %>' OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                <asp:HiddenField ID="HiddenField2" Value='<%#Eval("EGID") %>' runat="server" />
                                <asp:LinkButton runat="server" ID="lbtn_Detele" Visible='<%#IsVisible(Eval("SysID")) %>' OnClick="lbtn_Detele_Click" CommandArgument='<%#Eval("EGID") %>' OnClientClick="return confirm('确认删除选中的信息吗？');">删除</asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lbtn_PrivateLog" Visible='<%#IsVisible(Eval("SysID")) %>' CommandArgument='<%#Eval("EGID") %>' Text='<%#Eval("IsPublish").ToString()=="1"?"取消发布":"发布" %>' OnClick="lbtn_PrivateLog_Click"></asp:LinkButton></span>
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

