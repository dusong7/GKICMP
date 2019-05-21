<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AfficheResearchManage.aspx.cs" Inherits="GKICMP.oamanage.AfficheResearchManage" %>

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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text="教研活动"></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="教研活动"></asp:Label>
                </tr>
            </table>
        </div>

            


        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">教研标题：</td>
                        <td width="160">
                            <asp:TextBox ID="txt_AfficheTitle" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">发送人：</td>
                        <td width="80">
                           <asp:TextBox ID="txt_SendUser" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="70">发送日期：</td>
                        <td width="210">
                            <asp:TextBox ID="txt_SDate" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                              <asp:TextBox ID="txt_EDate" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
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
                             <asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>

            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                       <%-- <th align="center">教研类型</th>--%>
                        <th align="center">教研标题</th>
                          <th align="center">发送人</th>
                        <th align="center">教研内容</th>
                      
                        <th align="center">发送日期</th>
                        <th align="center">参与人</th>
                        <th align="center">不参与人</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                               <%-- <td><%# Eval("ATypeName")%></td>--%>
 <td title='<%#Eval("AfficheTitle")%>'><%#Eval("AfficheTitle").ToString().Length>15?Eval("AfficheTitle").ToString().Substring(0,14)+"…":Eval("AfficheTitle").ToString()%></td>
 <td><%#Eval("SenduserName")%></td>
 <td title='<%#Eval("AContent")%>'><%#Eval("AContent").ToString().Length>20?Eval("AContent").ToString().Substring(0,19)+"…":Eval("AContent").ToString()%></td>
                               
                                <td><%#Eval("SendDate","{0:yyyy-MM-dd HH:mm}")%></td>
 <td title='<%#Eval("YD")%>'><%#Eval("YD").ToString().Length>15?Eval("YD").ToString().Substring(0,14)+"…":Eval("YD").ToString()%></td>
 <td title='<%#Eval("WD")%>'><%#Eval("WD").ToString().Length>15?Eval("WD").ToString().Substring(0,14)+"…":Eval("WD").ToString()%></td>
                                
                                <td>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass=" listbtn btndetialcolor" CommandArgument='<%#Eval("nid") %>' CommandName='<%#Eval("SenduserName") %>' ToolTip="详细" OnClick="lbtn_View_Click">详细</asp:LinkButton>
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
