<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContractManage.aspx.cs" Inherits="GKICMP.teachermanage.ContractManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8">
    <title>教师合同管理</title>
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
                return openbox('A_id', 'ContractEdit.aspx', '', 1000, 450, -1);
            });

            $('#btn_Remove').click(function () {
                if (checkselectone("解除", "合同") == true) {
                    return openbox('A_id', 'TeacherRetire.aspx', '&tcid=' + document.getElementById("hf_CheckIDS").value + '&flag=2', 480, 220, 14);
                }
            });
        });
        function editinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'ContractEdit.aspx', 'id=' + id, 1000,450, 0);
        }
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'ContractDetail.aspx', 'id=' + id, 960, 450, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="合同管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">姓名：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_TeacherName" Text="" runat="server"></asp:TextBox>
                        </td>

                       <td width="80" align="right">合同类型：</td>
                        <td width="130">
                            <div class="sel" style="float: left">
                                <asp:DropDownList ID="ddl_CType" runat="server"></asp:DropDownList>
                            </div>
                        </td>
                       
                        <td width="80" align="right">到期日期：</td>
                        <td width="220">
                             <asp:TextBox ID="txt_BeginDate" runat="server" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>—
                             <asp:TextBox ID="txt_EndDate" runat="server" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
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
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" />
                           <%-- <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />--%>
                             <asp:Button ID="btn_Remove" runat="server"  CssClass="listbtncss listdel" Text="解除" />
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
                        <th align="center">姓名</th>
                        <th align="center">合同周期</th>
                        <th align="center">合同类型</th>
                        <th align="center">签订日期</th>
                        <th align="center">到期日期</th>
                        <th align="center">解除日期</th>
                        <th align="center">合同状态</th>
                        <th align="center">是否上报</th>
                        <th width="100px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("TCID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("TCID")%>' <%#GetState(Eval("IsReport")) %> id='ck_<%#Eval("TCID") %>' /></label>
                                </td>
                                 <td> <%#Eval("RealName") %></td>
                                <td><%#Eval("TCycle") %>年</td>
                                <td><%#Eval("CTypeName")%></td>
                                <td><%#Eval("TStartDate","{0:yyyy-MM-dd}") %></td>
                                <td><%#Eval("TEndDate","{0:yyyy-MM-dd}") %></td>
                                <td><%#Eval("OverDate","{0:yyyy-MM-dd}") %></td>
                                <td><%#GetState(Eval("TState"),Eval("TEndDate")) %></td>
                                <td><%#Eval("IsReport").ToString()=="0"? "<span style='color:red'>未上报</span>":"已上报" %></td>
                                <td>
                                        <asp:LinkButton ID="lbtn_Edit"  runat="server" CssClass="listbtn btneditcolor" Visible='<%#Eval("IsReport").ToString()=="1" ? false:true %>' ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor"  ToolTip="详细" CommandArgument='<%#Eval("TCID") %>' OnClick="lbtn_Info_Click">详细</asp:LinkButton>
                                         <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("TCID") %>' runat="server" />
                                        <asp:LinkButton ID="lbtn_Report"  runat="server" CssClass="listbtn btnreportncolor" Visible='<%#Eval("IsReport").ToString()=="1" ? false:true %>' ToolTip="上报" CommandArgument='<%#Eval("TCID") %>' OnClick="lbtn_SB_Click" OnClientClick="return  confirm('您确认要上报该信息吗？');">上报</asp:LinkButton>
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
