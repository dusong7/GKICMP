﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JZProjectCheckList.aspx.cs" Inherits="GKICMP.projectmanage.JZProjectCheckList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>智慧校园</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script> 
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btn_Add').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'JZProjectCheckEdit.aspx', '', 1000, 550, -1);
            });
        });
        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'JZProjectCheckEdit.aspx', 'id=' + id, 1000, 550, 0);
        }
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'JZProjectChecDetail.aspx', 'id=' + id, 960, 500, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="验收管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">项目名称：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_GName" Text="" runat="server"></asp:TextBox>
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
                        <th align="center">项目名称</th>
                        <th align="center">综合评价</th>
                        <th align="center">验收意见</th>
                        <th align="center">验收时间</th>
                        <th align="center">验收单附件</th><th align="center">是否上报</th>
                        <th width="90px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("PCID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("PCID")%>' <%#GetState(Eval("IsReport")) %> id='ck_<%#Eval("PCID") %>' /></label>
                                </td>
                                <td width="200px;"><span style="width: inherit; float: left; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="<%#Eval("PName")%>"><%#Eval("PName")%></span></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.ProjectCheck>( Eval("Evaluate"))%></td>
                               <%-- <td><%#Eval("Evaluate")%></td>--%>
                                <td width="200px;"><span style="width: inherit; float: left; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="<%#Eval("Opinion")%>"><%#Eval("Opinion")%></span></td>
                                <td><%#Eval("PCDate","{0:yyyy-MM-dd}")%></td>
                               <%-- <td><%#Eval("PCFile")%></td>--%>
                                 <td><%#getFileName(Eval("PCFile").ToString())%></td>
                                <td><%#Eval("IsReport").ToString()=="0"?"<span style='color:red'>未上报</span>":"已上报"%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Edit"  runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" Visible='<%#Eval("IsReport").ToString()=="0"?true:false%>' OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField1" Value='<%#Eval("PCID") %>' runat="server" /> 
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor"  ToolTip="详细" OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("PCID") %>' runat="server" />
                                         <asp:LinkButton ID="lbtn_Report"  runat="server" CssClass="listbtn btnreportncolor" ToolTip="上报" Visible='<%#Eval("IsReport").ToString()=="0"?true:false%>' CommandArgument='<%#Eval("PCID") %>' OnClick="lbtn_SB_Click" OnClientClick="return  confirm('您确认要上报该信息吗？');">上报</asp:LinkButton>
                                    </div>
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




