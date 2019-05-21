<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentActTheme.aspx.cs" Inherits="GKICMP.schoolwork.StudentActTheme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/actcss.css" rel="stylesheet" type="text/css" />
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
            return openbox('A_id', '../spacemanage/LogDetail.aspx', 'id=' + id, 1000, 540, 1);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="bancs">
            <div style="float: left">
                <%--<img src="../images/FHC_web_03.png">--%>
                <asp:Image runat="server" ID="img_LogoUrl" Width="76px" Height="76px" />
            </div>
            <div class="bancent">
                <div class="bantit">
                    <asp:Literal runat="server" ID="ltl_ActName"></asp:Literal>
                </div>
                <!--<div class="baninfo"></div>-->
            </div>
            <div style="clear: both"></div>
               <div  style="border:2px dashed #A8CE84; border-radius:5px; ">
            <div style="padding-left:10px;">
                <h3>活动时间：</h3>
                <asp:Literal runat="server" ID="ltl_ABegin"></asp:Literal>
                至<asp:Literal runat="server" ID="ltl_AEnd"></asp:Literal>
            </div>
                   <div style="padding-left:10px">
                <h3>报名学生：</h3>
                <asp:Literal runat="server" ID="ltl_ActUserName"></asp:Literal>
            </div>
               <div style="padding-left:10px;padding-bottom:10px">
                <h3>活动内容：</h3>
                <asp:Literal runat="server" ID="ltl_ActContent"></asp:Literal>
            </div>
                   </div>
        </div>

   
        <div class="centcss">
            <asp:Repeater runat="server" ID="rp_List">
                <ItemTemplate>
                    <div class="listm">
                        <a href="#">
                            <div class="listt"><span><%#Eval("LogTitle") %></span> <span><%#Eval("RealName") %></span></div>
                            <div class="listd"><%#Eval("CreateDate","{0:yyyy-MM-dd}") %></div>
                            <div class="listi">
                                <%#Eval("LogText").ToString().Length>300?Eval("LogText").ToString().Substring(0,300)+"...":Eval("LogText") %>
                            </div>
                            <div class="listb">
                                <span>
                                    <asp:LinkButton runat="server" ID="lbtn_ReadAll" OnClientClick='return viewinfo(this);' ForeColor="#17bd90">阅读全文>></asp:LinkButton>
                                    <asp:HiddenField ID="hf_EGID" Value='<%#Eval("EGID") %>' runat="server" />
                                </span>
                                <%--<span>评论/浏览（0/77）</span>--%>
                            </div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="pagemore"></div>
    </form>
</body>
</html>

