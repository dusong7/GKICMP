<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradeManage.aspx.cs" Inherits="GKICMP.sysmanage.GradeManage" %>

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
        $(function () {
            $('#btn_Add').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'GradeEdit.aspx', '', 800, 400, -1);
            });
        });
        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'GradeEdit.aspx', 'id=' + id, 800, 400, 0);
        }
        function gradution(e) {
            if (confirm("确认毕业当前的年级")) {
                var id = $(e).next().val();
                var GradeYear = $(e).next().next().val();
                var date = new Date;
                var year = date.getFullYear();
                if (year - GradeYear >= 3) {
                    return openbox('B_id', 'GradeGradution.aspx', 'id=' + id, 600, 350, 44);
                }
                else {
                    alert("毕业至少要满三年");
                    return false;
                }
            }
            else {
                return false;
            }
        }
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'GradeDetail.aspx', 'id=' + id, 960, 430, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="年级管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">年级名称：</td>
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
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出"    CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
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
                        <th align="center">年级名称</th>
                        <th align="center">年级简称</th>
                        <th align="center">入学年份</th>
                        <th align="center">年级负责人</th>
                        <th align="center">班级数</th>
                        <%-- <th align="center">创建日期</th>--%>
                        <th align="center">学生数</th>
                        <th align="center">是否毕业</th>
                        <th width="100px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("GID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("GID")%>' id='ck_<%#Eval("GID") %>' /></label>
                                </td>
                                <td><%#Eval("GradeName")%></td>
                                <td width="200px;"><span style="width: inherit; float: left; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="<%#Eval("ShortGName")%>"><%#Eval("ShortGName")%></span></td>
                                <td><%#Eval("GradeYear")%></td>

                                <td width="200px;"><span style="width: inherit; float: left; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="<%#Eval("AcceptUserName")%>"><%#Eval("AcceptUserName")%></span></td>
                                <td><%#Eval("ClassCount")%></td>
                                <%--  <td><%#Convert.ToDateTime( Eval("CreateDate")).ToString("yyyy-MM-dd")%></td>--%>
                                <td><%#Eval("StuCount")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot>(Eval("IsGraduate"))%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" OnClientClick='return editinfo(this);' Visible='<%#Eval("IsGraduate").ToString()=="1"?false:true %>'>编辑</asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField2" Value='<%#Eval("GID") %>' runat="server" />
                                        <asp:LinkButton ID="lbtn_Gradution" runat="server" CssClass="listbtn btngraduationcolor" OnClientClick='return gradution(this);' Visible='<%#Eval("IsGraduate").ToString()=="1"?false:true %>'>毕业</asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField1" Value='<%#Eval("GID") %>' runat="server" />
                                        <asp:HiddenField ID="HiddenField3" Value='<%#Eval("GradeYear") %>' runat="server" />
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("GID") %>' runat="server" />
                                    </div>
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


