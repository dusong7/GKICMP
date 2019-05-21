<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassPhotos.aspx.cs" Inherits="GKICMP.spacemanage.ClassPhotos" %>

<!DOCTYPE html>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>智慧校园管理平台</title>
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
                return openbox('A_id', 'ClassPhotoUpload.aspx', 'claid=' + claid + '&flag=1', 1040, 480, 49);
            });
        });

        function commentinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'MessageEdit.aspx', 'id=' + id + '&flag=2', 940, 320, 59)
        }

        function viewinfo(id) {
            return openbox('A_id', 'PhotoDetail.aspx', 'id=' + id, 940, 560, 59)
        }
    </script>
</head>
<body>
    <form runat="server" id="form1">
        <asp:HiddenField runat="server" ID="hf_ClaID" />
        <asp:HiddenField runat="server" ID="hf_UserType" />
        <asp:HiddenField runat="server" ID="hf_DepID" />
        <div class="menucs">
            <ul>
                <li>
                    <asp:LinkButton runat="server" ID="lbtn_ClassHome" Text="班级主页" OnClick="lbtn_ClassHome_Click"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton runat="server" ID="lbtn_ClassCul" Text="文化墙" OnClick="lbtn_ClassCul_Click"></asp:LinkButton></li>
                <li class="selected">
                    <asp:LinkButton runat="server" ID="lbtn_Photo" Text="相册"></asp:LinkButton></li>
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
            <asp:Button runat="server" ID="btn_Upload" Text="上传图片" CssClass="listupload" />
        </div>
        <div class="whlist">
            <ul>
                <asp:Repeater runat="server" ID="rp_List">
                    <ItemTemplate>
                        <li><a href="#" onclick="return viewinfo('<%#Eval("TID") %>')">
                            <img src='<%#Eval("PhotoUrl") %>'>
                            <span><%#Eval("PhotoName") %></span>
                            <span><%#Eval("CreateUserName") %>【<%#Eval("CreateDate","{0:yyyy-MM-dd}") %>】</span></a>
                            <asp:LinkButton runat="server" ID="lbtn_Comment" Style="color: #25b782;" OnClientClick="return commentinfo(this);">评论</asp:LinkButton>
                            <asp:HiddenField ID="HiddenField1" Value='<%#Eval("TID") %>' runat="server" />
                            <asp:LinkButton runat="server" ID="lbtn_Delete" Style="color: #25b782;" Visible='<%#IsVisible(Eval("CreateUser")) %>' OnClick="lbtn_Delete_Click" OnClientClick="return confirm('确定删除照片吗？');" CommandArgument='<%#Eval("TID") %>' CommandName='<%#Eval("PhotoName") %>'>删除</asp:LinkButton>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
                <div style="clear: both"></div>
            </ul>
        </div>
        <div runat="server" id="tr_null" style="text-align: center" class="whlist">
            暂无记录                        
        </div>
        <div class="listmre" style="border: none; text-align: right">
            <div class="titname" style="font-size: 14PX;">
                <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
            </div>
        </div>
    </form>
</body>
</html>
