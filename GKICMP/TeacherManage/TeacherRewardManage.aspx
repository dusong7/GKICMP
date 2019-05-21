<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherRewardManage.aspx.cs" Inherits="GKICMP.teachermanage.TeacherRewardManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
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
                return openbox('A_id', 'TeacherRewardEdit.aspx', '', 900, 500, -1);
            });
        });
        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'TeacherRewardEdit.aspx', 'id=' + id, 900, 500, 0);
        }
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'TeacherRewardDetail.aspx', 'id=' + id, 860, 470, 4);
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 41px;
        }
    </style>
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="奖励管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>


<%--<div class="dvTab">
   <ul class="menuall">
        <li class="tab "><a href="TeacherPaperManage.aspx">论文</a></li>
        <li class="tab activeTab"><a href="TeacherRewardManage.aspx">奖励</a></li>
       <li class="tab "><a href="TeacherJournalManage.aspx">著作</a></li>
                  <li class="tab "><a href="TeacherGuidanceManage.aspx">指导学生获奖</a></li>
    </ul>
<div class="dv"></div>--%>
<%--</div>--%>
           <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td width="80" align="right">姓名：</td>
                        <td width="100">
                            <asp:TextBox ID="txt_RealName" runat="server" width="100"></asp:TextBox>
                        </td>
                        <td width="80" align="right">奖励名称：</td>
                        <td width="100">
                            <asp:TextBox ID="txt_RewardName" runat="server" width="100"></asp:TextBox>
                        </td>
                         <td width="80" align="right">奖励类别：</td>
                        <td width="160">
                            <asp:DropDownList ID="ddl_RewardType" runat="server"></asp:DropDownList>
                        </td>
                        <td width="80" align="right">奖励级别：</td>
                        <td width="160">
                            <asp:DropDownList ID="ddl_RGrade" runat="server"></asp:DropDownList>
                        </td>
                        <td align="right" width="80">获奖年月：</td>
                        <td width="220">
                            <asp:TextBox ID="txt_SDate" runat="server" Style="width: 85px" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_EDate" runat="server" Style="width: 85px" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" CssClass="btn" Text="查询" OnClick="btn_Query_Click" />
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
                             <asp:Button ID="lbtn_Report" runat="server" Text="上报"   CssClass="listbtncss listreport" OnClick="lbtn_MoreSB_Click" />
                             <asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
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
                        <th align="center">奖励名称</th>
                        <th align="center">奖励类别</th>
                        <th align="center">奖励级别</th>
                        <th align="center">获奖年月</th>
                        <th align="center">授奖单位</th>
                        <%--<th align="center">是否上报</th>--%>
                        <th align="center">缩略图</th>
                        <th width="80px" align="center">操作</th>
                    </tr>
                    <asp:Repeater ID="rp_List" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("TPID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("TPID") %>' id='ck_<%#Eval("TPID") %>' /></label>
                                </td>
                                <td align="center"><%#Eval("TeacherName")%></td>
                                <td title='<%#Eval("RewardName")%>'><%#Eval("RewardName").ToString().Length>20?Eval("RewardName").ToString().Substring(0,19)+"…":Eval("RewardName").ToString()%></td>
                                 <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.RewardType>(Eval("RewardType"))%></td>
                                 <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.RGrade>(Eval("RGrade"))%></td>
                                <td align="center"><%#Eval("PubDate","{0:yyyy-MM-dd}")%></td>
                                <td title='<%#Eval("Lunit")%>'><%#Eval("Lunit").ToString().Length>15?Eval("Lunit").ToString().Substring(0,14)+"…":Eval("Lunit").ToString()%></td>
                               <%-- <td><%#Eval("IsReport").ToString()=="0"? "<span style='color:red'>未上报</span>":"已上报" %></td>--%>
                                    <td><asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("RFile")%>' Width="30px" Height="20px" /></td>
                                <td >
                                        <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor"  ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("TPID") %>' runat="server" />
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor"  ToolTip="详细"  OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>
                                        <asp:HiddenField ID="hf_TPID" Value='<%#Eval("TPID") %>' runat="server" />
                                        <asp:LinkButton ID="lbtn_Report"  runat="server" CssClass="listbtn btnreportncolor" Visible='<%#Eval("IsReport").ToString()=="1" ? false:true %>' ToolTip="上报" CommandArgument='<%#Eval("TPID") %>' OnClick="lbtn_SB_Click" OnClientClick="return  confirm('您确认要上报该信息吗？');">上报</asp:LinkButton>
                                         <asp:HiddenField ID="hf_sTPID" Value='<%#Eval("TPID") %>' runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="9" align="center">暂无记录</td>
                    </tr>
                </tbody>
            </table>
                      </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>



