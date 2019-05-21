<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseContract.aspx.cs" Inherits="GKICMP.purchase.PurchaseContract" %>

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
     <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btn_Add').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'PurchaseContractEdit.aspx', '', 1000, 650, -1);
            });
        });
        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'PurchaseContractEdit.aspx', 'id=' + id, 1000, 650, 0);
        }
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'PurchaseContractDetail.aspx', 'id=' + id, 960, 540, 4);
        }
        function admininfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', '', 'id=' + id, 860, 450, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text="采购管理"></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="采购管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">合同名称：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_Name" Text="" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">合同编号：</td>
                        <td width="220">
                            <asp:TextBox ID="txt_BidNumber" Text="" runat="server"></asp:TextBox>
                        </td>
                       <td align="right" width="60">乙方：</td>
                        <td width="220">
                             <asp:TextBox ID="txt_PartyB" Text="" runat="server"></asp:TextBox>
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
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
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
                        <th align="center">合同编号</th>
                        <th align="center">合同名称</th>
                        <th align="center">项目名称</th>
                        <th align="center">乙方</th>
                        <th align="center">金额</th>
                         <th align="center">签订日期</th>
                         <th align="center">维保开始日期</th>
                        <th align="center">维保年限</th>
                        <%--<th align="center">审核时间</th>--%>
                        <th align="center">上报状态</th>
                        <th width="90px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("ID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("ID")%>'  <%#GetDisabled(Eval("IsReport")) %> id='ck_<%#Eval("ID") %>' /></label>
                                </td>
                               <td><%#Eval("BidNumber")%></td>
                                <td><%#Eval("Name")%></td>
                                <td width="200px;"><span style="width: inherit; float: left; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="<%#Eval("PTitle")%>"><%#Eval("PTitle")%></span></td>
                                <td><%#Eval("PartyBName")%></td>
                                    <td><%#Eval("Price")%></td>
                                  <td><%#Eval("SignDate","{0:yyyy-MM-dd HH:mm}")%></td>
                                <td><%#Eval("ServerDate","{0:yyyy-MM-dd HH:mm}")%></td>
                                <td><%#Eval("ServerYears")%></td>
                                <td><%#Eval("IsReport").ToString()=="1"?"已上报":"<span style='color:red'>未上报</span>"%></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" Visible='<%#Eval("IsReport").ToString()=="1"?false:true %>' ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField1" Value='<%#Eval("ID") %>' runat="server" />
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor"  ToolTip="详细" OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("ID") %>' runat="server" />                                                                  
                                     <asp:LinkButton ID="lbtn_Report" runat="server" CssClass="listbtn btnreportncolor" ToolTip="上报" Visible='<%#Eval("IsReport").ToString()=="1"?false:true %>' CommandArgument='<%#Eval("ID") %>' OnClick="lbtn_SB_Click" OnClientClick="return  confirm('您确认要上报该信息吗？');">上报</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="11">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>






