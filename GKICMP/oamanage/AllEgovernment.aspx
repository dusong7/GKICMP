<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllEgovernment.aspx.cs" Inherits="GKICMP.oamanage.AllEgovernment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="已发政务"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">公文标题：</td>
                        <td width="200">
                            <asp:TextBox ID="txt_ETitle" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">发送日期：</td>
                        <td width="400">
                            <asp:TextBox ID="txt_Begin" Width="75px" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>--<asp:TextBox ID="txt_End" Width="75px" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt">
                <tbody>
                    <tr>
                        <td align="right" valign="middle">
                             <asp:Button runat="server" ID="btn_AllOut" Text="导出" CssClass="listbtncss listoutput" OnClick="btn_AllOut_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        
                        <th align="center" width="60%">公文标题</th>
                        <th align="center">发件人</th>
                        <th align="center">收件人</th>
                        <th align="center">发送日期</th>
                        <th align="center">是否已读</th>
                        <th align="center">状态</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><span title='<%#Eval("ETitle")%>'><%#Eval("ETitle").ToString().Length>40?Eval("ETitle").ToString().Substring(0,39)+"…":Eval("ETitle").ToString()%></span></td>
                                 <td><%#Eval("CreateUserName")%></td>
                               <%-- <td><%#Eval("CreateUserName")%></td>--%>
                                <td><span title="<%#Eval("AcceptUserList") %>"><%#GetAcceptName(Eval("Counta"),Eval("AcceptUserList"))%></span></td>
                                <td><%#Eval("CreateDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("ReadOrNot").ToString()=="0"?"<span style='color:red'>有人未读</span>":"全部已读"%></td>
                                <td><%#Eval("Completed").ToString()=="1"?"<span style='color:#FF83FA'>已归档</span>":getState(Eval("state"))%></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细" CommandArgument='<%#Eval("FID") %>' CommandName="XQ" OnClick="lbtn_Detail_Click">详细</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID3" Value='<%#Eval("FID") %>' runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="8">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>
