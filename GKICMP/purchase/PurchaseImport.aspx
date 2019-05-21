<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseImport.aspx.cs" Inherits="GKICMP.purchase.PurchaseImport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">

        function importview(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'PurchaseImportDetail.aspx', 'id=' + id, 960, 630, 4);
        }
        function importa(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'PurchaseImportEdit.aspx', 'id=' + id, 960, 630, 3);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="供货清单管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">采购名称：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_GName" Text="" runat="server"></asp:TextBox>
                        </td>
                        <%--<td width="70" align="right">教学楼类型：</td>
                        <td width="250">
                            <asp:DropDownList runat="server" ID="ddl_BType"></asp:DropDownList>
                        </td>--%>
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
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)"></label></th>
                         <th align="center">采购名称</th>
                        <th align="center">概算</th>
                        <th align="center">申报人</th>
                        <th align="center">申报时间</th>
                         <th align="center">上级审核</th>
                        <th align="center">采购类型</th>
                        <th align="center">清单</th>
                        <%--<th align="center">审核时间</th>--%>
                        <th align="center">上报状态</th>
                        
                        <th width="100px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("PID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("PID")%>'  <%#GetState(Eval("PType")) %> id='ck_<%#Eval("PID") %>' /></label>
                                </td>
                                 <td width="200px;"><span style="width: inherit; float: left; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="<%#Eval("PTitle")%>"><%#Eval("PTitle")%></span></td>
                                <td><%#Eval("PEstimate")%></td>
                                <td><%#Eval("CreateUserName")%></td>
                                <td><%#Eval("CreateDate","{0:yyyy-MM-dd HH:mm}")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.AduitState>(Eval("PLState"))%></td>
                                <td><%#Eval("TypeName")%></td>
                                <td><%#Eval("Import").ToString()=="1"?"已导入":"<span style='color:red'>未导入</span>"%></td>
                                <td><%#Eval("Report").ToString()=="1"?"已上报":"<span style='color:red'>未上报</span>"%></td>
                                <td>
                                    <asp:LinkButton ID="btn_Input" runat="server" CssClass="listbtn btnimportcolor" ToolTip="供货清单导入" OnClientClick='return importa(this);'>导入</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细" OnClientClick='return importview(this);'>详细</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("PID") %>' runat="server" />
                                    <%--<asp:LinkButton ID="lbtn_Report" runat="server" CssClass="listbtn btnreportncolor" ToolTip="上报" Visible='<%#Eval("PType").ToString()=="1"?false:true%>' CommandArgument='<%#Eval("PID") %>' OnClick="lbtn_SB_Click">上报</asp:LinkButton>--%>
                                    <asp:LinkButton ID="lbtn_Report" runat="server" CssClass="listbtn btnreportncolor" ToolTip="上报" Visible='<%#Eval("Import").ToString()=="1"?Eval("Report").ToString()=="1"?false:true:true%>'   CommandArgument='<%#Eval("PID") %>' OnClick="lbtn_SB_Click" OnClientClick="return  confirm('您确认要上报该信息吗？');">上报</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="10">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>






