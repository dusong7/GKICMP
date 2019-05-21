<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScrapManage.aspx.cs" Inherits="ICMP.assetmanage.ScrapManage" %>

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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="资产报废管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">资产名称：</td>
                        <td width="200">
                            <asp:TextBox ID="txt_AssetName" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">报废人：</td>
                        <td width="200">
                            <asp:TextBox ID="txt_CreaterUser" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="100">报废时间：</td>
                        <td width="280">
                            <asp:TextBox ID="txt_BeginDate" Width="75px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_EndDate" Width="75px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
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
                            <%--<asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />--%>
                              <asp:Button ID="lbtn_Report" runat="server" Text="上报"   CssClass="listbtncss listreport" OnClick="lbtn_MoreSB_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)">
                            </label>
                        </th>
                        <th align="center">资产分类</th>
                        <th align="center">资产名称</th>
                        <th align="center">报废数量</th>
                        <th align="center">报废时间</th>
                        <th align="center">报废人</th>
                       <%--  <th align="center">报废说明</th>--%>
                        <th align="center">是否上报</th>
                        <th width="60px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                 <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("ASID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("ASID")%>' <%#GetState(Eval("IsReport")) %>  id='ck_<%#Eval("ASID") %>' />
                                    </label>
                                </td>
                                <td><%#Eval("TypeName")%></td>
                                <td><%#Eval("AssetName")%></td>
                                <td><%#Eval("ASNum")%></td>
                                
                                <td><%#Eval("ASDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("CreateUserName")%></td>
                               <%-- <td><%#Eval("ASMark")%></td>--%>
                                <td><%#Eval("IsReport").ToString()=="0"?"<span style='color:red'>未上报</span>":"已上报"%></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Delete" runat="server" CssClass="listbtn btndelcolor" OnClick="btn_Delete_Click" CommandArgument='<%#Eval("ASID")%>' OnClientClick="return  confirm('您确认删除选中的信息吗？');">删除</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID1" Value='<%#Eval("ASID") %>' runat="server" />
                                    <asp:LinkButton ID="lbtn_Report" runat="server" CssClass="listbtn btnreportncolor" ToolTip="" Visible='<%#Eval("IsReport").ToString()=="1"?false:true %>' CommandArgument='<%#Eval("ASID") %>' OnClick="lbtn_SB_Click" OnClientClick="return  confirm('您确认要上报该信息吗？');">上报</asp:LinkButton>
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
