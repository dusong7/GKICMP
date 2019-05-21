<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherLearnManage.aspx.cs" Inherits="GKICMP.teachermanage.TeacherLearnManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
     <script src="../js/AsyncBox.v1.4.js"></script> 
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
     <script src="../js/My97/WdatePicker.js"></script>
   
    <script type="text/javascript">
        //$(function () {
        //    $('#btn_Add').click(function () {
        //        //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
        //        return openbox('A_id', 'TeacherLearnEdit.aspx', '', 1000, 450, -1);
        //    });
        //});
        //function editinfo(e) {
        //    var id = $(e).next().val();
        //    return openbox('A_id', 'TeacherLearnEdit.aspx', 'id=' + id, 1000, 450, 0);
        //}
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'TeacherLearnDetail.aspx', 'id=' + id, 960, 450, 4);
        }
    </script>
</head>
<body>
   <form id="form1" runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_CssFlag" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="学习培训管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td width="7%" align="right">培训年份</td>
                        <%--<td width="10%"> <asp:TextBox ID="txt_Year" runat="server" Style="width:100%" ></asp:TextBox></td>--%>
                        <td width="10%"> 
                            <asp:TextBox ID="txt_Year" runat="server" Style="width:100%" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy'})"></asp:TextBox>
                        </td>
                        <td width="7%"  align="right">姓名</td>
                        <td width="10%"><asp:TextBox ID="txt_TeacName" runat="server" Style="width: 100px" ></asp:TextBox></td>
                        <td align="right" width="90">开始日期：</td>
                        <td width="220">
                            <asp:TextBox ID="txt_SDate" runat="server" Style="width: 85px" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>—
                            <asp:TextBox ID="txt_EDate" runat="server" Style="width: 85px" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
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
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
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
                        <th align="center">性别</th>
                      <%--  <th align="center">身份证号码</th>--%>
                        <th align="center">培训年份</th>
                          <th align="center">课时</th>
                        <th align="center">学习或培训地点</th>
                        <th align="center">开始日期</th>
                        <th align="center">结束日期</th>
                        <th align="center">学习或培训内容</th>
                        <th align="center">是否上报</th>
                       <%-- <th align="center">备注</th>--%>
                        <th width="120px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("TTID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("TTID") %>' <%#GetState(Eval("IsReport")) %> id='ck_<%#Eval("TTID") %>' /></label>
                                </td>
                                <td><%#Eval("RealName")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XB>(Eval("TSex"))%></td>
                                <%--<td width="100px;"><span style="width: inherit; float: left; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="<%#Eval("IDCardNum")%>"><%#Eval("IDCardNum")%></span></td>--%>
                                <td><%#Eval("TYear")%></td>
                                <td><%# Eval("THours") %></td>
                                <td width="150px"><span style="width: inherit; float: left; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="<%#Eval("TrainAddress")%>"><%#Eval("TrainAddress")%></span></td>
                                <td><%#Eval("TStartDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("TEndDate","{0:yyyy-MM-dd}")%></td>
                                <td width="150px"><span style="width: inherit; float: left; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="<%#Eval("TrainContent")%>"><%#Eval("TrainContent")%></span></td>
                                 <td><%#Eval("IsReport").ToString()=="0"? "<span style='color:red'>未上报</span>":"已上报" %></td>
                               <%-- <td><%# Eval("TDesc") %></td>--%>
                                <td>
                                        <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" Visible='<%#Eval("IsReport").ToString()=="1" ? false:true %>' ToolTip="编辑" CommandName='<%#Eval("TTID") %>' OnClick="lbtn_Edit_Click" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                         <asp:HiddenField ID="HiddenField1" Value='<%#Eval("TTID")%>' runat="server" />
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细"  OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("TTID")%>' runat="server" />
                                         <asp:LinkButton ID="lbtn_Report"  runat="server" CssClass="listbtn btnreportncolor" Visible='<%#Eval("IsReport").ToString()=="1" ? false:true %>' ToolTip="上报" CommandArgument='<%#Eval("TTID") %>' OnClick="lbtn_SB_Click" OnClientClick="return  confirm('您确认要上报该信息吗？');">上报</asp:LinkButton>
                                        
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
