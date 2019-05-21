<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EgovernmentTR.aspx.cs" Inherits="GKICMP.oamanage.EgovernmentTR" %>

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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="已收政务"></asp:Label>
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
                            <asp:TextBox ID="txt_Begin" runat="server" Width="85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_End" runat="server" Width="85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
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
                            <%--<asp:Button ID="Button1" runat="server" Text="提交"  CssClass="listbtncss listadd" />
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" />--%>
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)"></label></th>
                        <th align="center" width="60%">公文标题</th>
                        <th align="center">发件人</th>
                        <th align="center">发送日期</th>
                        <th align="center">是否已读</th>
                        <th align="center">政务状态</th>
                        <th align="center">处理状态</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("FID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("FID") %>' id='ck_<%#Eval("FID") %>' /></label>
                                </td>
                                <td><span title='<%#Eval("ETitle")%>'><%#Eval("ETitle").ToString().Length>40?Eval("ETitle").ToString().Substring(0,39)+"…":Eval("ETitle").ToString()%></span></td>
                                <td><%#Eval("CreateUserName")%></td>
                                <td><%#Eval("CreateDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("IsRead").ToString()=="0"?"<span style='color:red'>未读</span>":"已读"%></td>
                                <%--<td><%#getState(Eval("State"))%></td>--%>
                                <td><%#Eval("Completed").ToString()=="1"?"<span style='color:#FF83FA'>已归档</span>":GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.GWType>(Eval("Estate"))%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.GWType>(Eval("state"))%></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_yy" runat="server" CssClass="listbtn btnimportcolor" ToolTip="已阅"  CommandArgument='<%#Eval("FID") %>' CommandName="YY" Visible='<%#(Eval("state").ToString()=="5"||Eval("Completed").ToString()=="1")?false:true%>' OnClick="lbtn_Detail_Click">已阅</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Endorse" runat="server" CssClass="listbtn btnpzcolor" ToolTip="批转"  CommandArgument='<%#Eval("FID") %>' CommandName="PZ" Visible='<%#Eval("isapproved").ToString()=="1"?Eval("Completed").ToString()=="1"?false:true:false%>' OnClick="lbtn_Detail_Click">批转</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细" CommandArgument='<%#Eval("FID") %>' CommandName="XQ"  OnClick="lbtn_Detail_Click">详细</asp:LinkButton>
                                    
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








