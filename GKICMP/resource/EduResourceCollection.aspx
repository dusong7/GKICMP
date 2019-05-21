<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EduResourceCollection.aspx.cs" Inherits="GKICMP.resource.EduResourceCollection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/filecss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script>
        $(function () {
            $('#btn_UpLoad').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'EduResourseEdit.aspx', '', 960, 460, -1);
            });
        });
        function audit(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'EduResourceAudit.aspx', 'id=' + id, 880, 345, 1);
        }
        function edit(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'EduResourseEdit.aspx', 'id=' + id, 960, 460, 1);
        }
        function detail(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'EduResourceDetail.aspx', 'id=' + id, 960, 360, 4);
        }
        function yl(e) {
            var id = $(e).next().val();
            var a = id.substring(id.lastIndexOf('.'))
            if (a == "") {
                alert("暂不支持在线预览");
                return false;
            }
            else {
                return openbox('A_id', 'ReadOnLine.html', 'id=' + id, 960, 860, 1);
            }
        }
        function DownLoad(e) {
            var erid = $(e).next().val();
            jQuery.post("../ashx/SetDownLoad.ashx?id=" + erid, function (data) { });
            return true;
        }
    </script>
 
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_Flag" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="我关注的资源"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="rightlistbox">
            <div class="rightlisttab">
                <table width="100%" border="1" cellspacing="0" cellpadding="0" class="list_tab">
                    <tr>
                        <th align="left" width="280px">&nbsp;&nbsp;    类别：<asp:DropDownList ID="ddl_EType" runat="server"></asp:DropDownList>
                            &nbsp;&nbsp;   &nbsp;&nbsp;   &nbsp;&nbsp;   &nbsp;&nbsp;   资源名称：                   
                            <asp:TextBox ID="txt_ResourseName" runat="server"></asp:TextBox>
                            &nbsp;&nbsp;   &nbsp;&nbsp;   &nbsp;&nbsp;   &nbsp;&nbsp;
                            <asp:Button ID="btn_Query" runat="server" CssClass="btn" Text="查 询" OnClick="btn_Search_Click" />
                        </th>
                    </tr>
                </table>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Repeater ID="rp_List" runat="server">
                                <HeaderTemplate>
                                    <table width="100%" border="1" class="tab_detail" cellpadding="0" cellspacing="0">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <% v = v + 1; %>
                                    <%
                                        if (v % 2 == 1)
                                        {%>
                                    <tr>
                                        <% } %>
                                        <td align="center">
                                            <img src='<%#GetPic(Eval("RFormat")) %>' />
                                        </td>
                                        <td>
                                            <span style="color: #0062c9; font-weight: bold">
                                                <asp:LinkButton ID="lbtn_download" Style="color: blue; text-decoration: none" CommandArgument='<%#Eval("ResourseUrl") %>' CommandName='<%#Eval("ResourseName") %>' runat="server"
                                                    OnClientClick="return DownLoad(this);" OnClick="lbtn_download_Click"> <%# Eval("ResourseName")%></asp:LinkButton>
                                                <asp:HiddenField ID="hf_erid" Value='<%#Eval("Erid") %>' runat="server" />
                                            </span>
                                            <br />
                                            <span style="color: Gray">详细分类:<%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.EType>(Eval("EType"))%>   资源学科:<%#Eval("CIDName")%>  资源版本:人教版
                                                <br />
                                                资源大小:<%#GK.GKICMP.Common.CommonFunction.CountSize(int.Parse(Eval("RSize").ToString()))%>   资源格式:<%#Eval("RFormat")%>&nbsp;下载次数:<%#Eval("DownLoadNum")%>
                                                <br />
                                                上 传 人:<%#Eval("CreateUserName")%>
                                              上传时间:<%#Eval("CreateDate","{0:yyyy-MM-dd}")%>
                                            </span>
                                            <br />
                                            <asp:LinkButton ID="lbtn_Unfollow" runat="server" CommandName='<%#Eval("ResourseName") %>' CommandArgument='<%#Eval("EUID") %>' OnClick="lbtn_Unfollow_Click"><span style="color :#0062c9">取消关注</span></asp:LinkButton>
                                            <asp:LinkButton ID="lbtn_Detail" runat="server" ToolTip="详细" CommandArgument='<%#Eval("Erid") %>' OnClientClick='return detail(this);'>详细</asp:LinkButton>
                                            <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("Erid") %>' runat="server" />
                                            <asp:LinkButton ID="lbtn_PreView" runat="server" CommandName="PreView" CommandArgument='<%#Eval("Erid") %>'
                                                OnClientClick='return yl(this);'><span style="color :#0062c9"> 预览</span></asp:LinkButton>
                                            <asp:HiddenField ID="HiddenField2" Value='<%#Eval("ResourseUrl") %>' runat="server" />
                                            <asp:HiddenField ID="HiddenField1" Value='<%#Eval("Erid") %>' runat="server" />
                                        </td>
                                        <%
                                            if (v % 2 != 1)
                                            {%>
                                    </tr>
                                    <%}%>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                    <tr runat="server" visible="false" id="tr_null">
                        <td align="center" colspan="4" id="tdnull" height="30px">
                            <div class="datanone">抱歉！没有找到符合条件的相关资源信息<br>您可以尝试更换搜索条件再试</div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>
