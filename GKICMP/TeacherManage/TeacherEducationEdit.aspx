<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherEducationEdit.aspx.cs" Inherits="GKICMP.teachermanage.TeacherEducationEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btn_Add').click(function () {
                return openbox('A_id', 'EducationEdit.aspx', 'flag=' +<%=Flag%> +'&tid=' + document.getElementById("hf_TID").value, 1160, 560, -1);
            });
        });

        function editinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'EducationEdit.aspx', 'flag=' +<%=Flag%> +'&id=' + id + '&tid=' + document.getElementById("hf_TID").value, 1100, 470, 0);
        }
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'EducationDetail.aspx', 'id=' + id, 860, 470, 4);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_face" runat="server" Value="" />
        <asp:HiddenField ID="hf_TID" runat="server" />
        <div class="positionc" id="div_top" runat="server" visible="false">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="我的档案"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo1">
            <tbody>
                <tr>
                    <th align="left">
                        <div class="xxsm" style="padding-left: 15px">
                            <ul>
                                <li><a href="TeacherEdit.aspx?id=<%=TID%>&flag=<%=Flag%>">基本信息</a></li>
                                <li class="selected"><a href="TeacherEducationEdit.aspx?tid=<%=TID%>&flag=<%=Flag%>">学习经历</a></li>
                                <li><a href="TeacherWorkExperienceEditManage.aspx?tid=<%=TID%>&flag=<%=Flag%>">工作经历</a></li>
                            </ul>
                        </div>
                    </th>
                </tr>
            </tbody>
        </table>

        <div class="listcent pad0" style="margin-top: 1px;">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt">
                <tbody>
                    <tr>
                        <td align="left"></td>
                        <td align="right" valign="middle">
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfoc">
                <tbody>
                    <tr>
                        <th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)"></label></th>
                        <th align="center">获取学历</th>

                        <th align="center">获得学历的国家（地区）</th>
                        <th align="center">获得学历的院校或机构</th>
                        <th align="center">所学专业</th>
                        <th align="center">是否师范类专业</th>
                        <th align="center">入学年月</th>
                        <th align="center">毕业年月</th>
                        <th align="center">学位层次</th>
                        <th align="center">学位名称</th>
                        <th align="center">学习方式</th>
                        <th width="100px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("TEID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("TEID") %>' id='ck_<%#Eval("TEID") %>' /></label>
                                    <%--<input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("TEID") %>' id='ck_<%#Eval("TEID") %>' <%#GetState(Eval("UserType")) %> /></label>--%>
                                </td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XL>(Eval("Education"))%></td>
                                <td><%#Eval("EduCountryName")%></td>
                                <td><%#Eval("EduSchool")%></td>
                                <td><%#Eval("EMajor")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot>(Eval("IsTeach"))%></td>
                              <td><%#Convert.ToDateTime( Eval("InDate")).ToString("yyyy-MM")=="1900-01"?"":Convert.ToDateTime( Eval("InDate")).ToString("yyyy-MM") %></td>
                                <td><%#Convert.ToDateTime( Eval("OutDate")).ToString("yyyy-MM")=="1900-01"?"":Convert.ToDateTime( Eval("OutDate")).ToString("yyyy-MM") %></td>
                               <td><%#Eval("DegreeLevel").ToString()=="-2"?"": GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XWCC>(Eval("DegreeLevel"))%></td>
                         <td><%#Eval("DegreeName").ToString()=="-2"?"": GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XWLB>(Eval("DegreeName"))%></td>
                       <td><%#Eval("StudyType").ToString()=="-2"?"": GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XXFS>(Eval("StudyType"))%></td>

                                <%--<td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.MZ>(Eval("Nation"))%></td>
                                <td><%#Eval("IDCard").ToString().Substring(0,4)+"******"+Eval("IDCard").ToString().Substring(14)%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.UserType>(Eval("UserType"))%></td>
                                <td><%#Eval("LastDate").ToString()==""?"":Eval("LastDate","{0:yyyy-MM-dd HH:mm:ss}")%></td>--%>

                                <td>
                                    <%--<div class="operationd">--%>
                                    <%-- <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="editora" Style="margin-left: 10px;" ToolTip="编辑" OnClientClick='return editinfo(this);'></asp:LinkButton>
                                         <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="viewa"  ToolTip="详细" OnClientClick='return viewinfo(this);'></asp:LinkButton>--%>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细" OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("TEID") %>' runat="server" />
                                    <%--</div>--%>
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





    </form>
</body>
</html>
