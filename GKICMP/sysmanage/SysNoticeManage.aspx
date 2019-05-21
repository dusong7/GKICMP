<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysNoticeManage.aspx.cs" Inherits="GKICMP.sysmanage.SysNoticeManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>智慧校园基础管理平台</title>
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
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="系统日志"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>

                    <tr>
                        <td align="right" width="80" >通知人：</td>
                        <td width="100" >
                            <asp:TextBox ID="txt_CreateUser" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">通知内容：</td>
                        <td width="160px">
                            <asp:TextBox ID="txt_NContent" runat="server"></asp:TextBox>
                        </td>
                        <td width="30" align="right">通知时间：</td>
                        <td width="230px">
                            <asp:TextBox ID="txt_Begin" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_End" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>

                        <td>
                            <asp:Button ID="btn_Search" runat="server" CssClass="btn" Text="查询" OnClick="btn_Query_Click" />
                        </td>
                    </tr>

                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
          
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                       
                        <th align="center" width="10%">通知人</th>
                        <th align="center" width="10%">通知标题</th>
                        <th align="center" width="60%">通知内容</th>
                         <th align="center" width="10%">接收人</th>
                        <th align="center" width="10%">通知时间</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#(Eval("SendUserName"))%></td>
                                <td><%#Eval("MsgTitle")%></td>
                                <td ><span title="<%#Eval("NContent")%>"><%#Eval("NContent").ToString().Length>70?Eval("NContent").ToString().Substring(0,69)+"…":Eval("NContent").ToString()%></span></td>
                                 <td><%#Eval("AcceptUserName")%></td>
                                <td><%#Convert.ToDateTime( Eval("SendDate")).ToString("yyyy-MM-dd HH:mm")%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="4">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
       
    </form>
</body>
</html>
