﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AfficheManage.aspx.cs" Inherits="GKICMP.oamanage.AfficheManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
     <script type="text/javascript">
        //$(function () {
        //    $('#btn_Add').click(function () {
        //        //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
        //        return openbox('A_id', 'AfficheEdit.aspx', '', 940, 450, -1);
        //    });

         //});
         function Check(e)
         {
             var r = confirm("确定撤销选中的公告信息吗");
             if (r == true)
             {
                 var date = new Date();
                 var date2 = $(e).next().val();
                 var a = date - new Date(date2);
                 if (a < 300000) { return true; }
                 else { alert("超过五分钟后不能撤销！"); return false; }
             }
             else { return false;}
         }
    </script>
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text="通知公告"></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="通知公告"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="dvTab">
            <ul class="menuall">
                <li class="tab activeTab"><a href="AfficheManage.aspx">已发通知公告</a></li>  
                <li class="tab "><a href="AfficheAcceptManage.aspx">已收通知公告</a></li>   
            </ul>
            <div class="dv"></div>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">公告标题：</td>
                        <td width="160">
                            <asp:TextBox ID="txt_AfficheTitle" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">公告类型：</td>
                        <td width="80">
                            <asp:DropDownList ID="ddl_AType" runat="server"></asp:DropDownList>
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
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" OnClick="btn_Add_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th align="center">公告类型</th>
                        <th align="center">公告标题</th>
                        <th align="center">发送日期</th>
                        <th align="center">接收对象</th>
                        <th align="center">是否公示</th>
                        <th align="center">是否已读</th>
                        <th width="130px" align="center">操作</th>

                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("AtypeName")%></td>
                                <td title='<%#Eval("AfficheTitle")%>'><%#GetCutStr( Eval("AfficheTitle"),20)%></td>
                                <td><%#Eval("SendDate","{0:yyyy-MM-dd HH:mm}")%></td>
                                <td><%#Eval("AcceptUserName")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot> (Eval("IsDisplay"))%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot> (Eval("IsRead"))%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Revoke" runat="server" CssClass=" listbtn btndelcolor" CommandArgument='<%#Eval("AID") %>' CommandName='<%#Eval("AcceptUser") %>' ToolTip="撤销" OnClick="lbtn_Delete_Click" OnClientClick='return Check(this)'>撤销</asp:LinkButton>
                                        <asp:HiddenField ID="hf_date" runat="server" Value='<%#Eval("SendDate")%>' />
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass=" listbtn btndetialcolor" CommandArgument='<%#Eval("AID") %>' CommandName='<%#Eval("AcceptUser") %>' ToolTip="详细" OnClick="lbtn_View_Click">详细</asp:LinkButton>
                                    </div>
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


