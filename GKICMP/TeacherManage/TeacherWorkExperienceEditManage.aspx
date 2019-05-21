<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherWorkExperienceEditManage.aspx.cs" Inherits="GKICMP.teachermanage.TeacherWorkExperienceEditManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btn_Add').click(function () {
                return openbox('A_id', 'TeacherWorkExperienceEdit.aspx', 'flag='+<%=Flag%>+'&tid=' + document.getElementById("hf_TID").value, 860, 460, -1);
            });
        });

        function editinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'TeacherWorkExperienceEdit.aspx', 'flag='+<%=Flag%>+'&id=' + id + '&tid=' + document.getElementById("hf_TID").value, 860, 460, 0);
        }
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'TeacherWorkExperienceDetail.aspx', 'id=' + id, 860, 470, 4);
        }

    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_CID" runat="server" />
        <asp:HiddenField ID="hf_TID" runat="server" />
        <div class="positionc" id="div_top" runat="server" visible="false">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span>日常办公<span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="我的档案"></asp:Label>
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
                                <li><a href="TeacherEducationEdit.aspx?tid=<%=TID%>&flag=<%=Flag%>">学习经历</a></li>
                                <li class="selected"><a href="TeacherWorkExperienceEditManage.aspx?tid=<%=TID%>&flag=<%=Flag%>">工作经历</a></li>
                            </ul>
                        </div>
                    </th>
                </tr>
            </tbody>
        </table>


        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt">
                <tbody>
                    <tr>
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
                        <%-- <th align="center">教师</th>
                        <th align="center">身份证</th>
                        <th align="center">性别</th>--%>
                        <th align="center">任职单位名称</th>
                        <th align="center">任职岗位</th>
                        <th align="center">单位性质类别</th>
                        <th align="center">任职开始年月</th>
                        <th align="center">任职结束年月</th>
                        <th align="center">是否上报</th>
                        <th width="100px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("TWEID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("TWEID") %>' id='ck_<%#Eval("TWEID") %>' /></label>
                                </td>
                                <%-- <td><%#Eval("TName")%></td>
                                <td><%#Eval("IDCardNum")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XB>(Eval("TSex"))%></td>--%>
                                <td><%#Eval("TrainAddress")%></td>
                                <td><%#Eval("TrainContent")%></td>
                                <td><%#Eval("TTypeName")%></td>
                                         <td><%#Convert.ToDateTime( Eval("TStartDate")).ToString("yyyy-MM")=="1900-01"?"":Convert.ToDateTime( Eval("TStartDate")).ToString("yyyy-MM") %></td>
                                                   <td><%#Convert.ToDateTime( Eval("TEndDate")).ToString("yyyy-MM")=="1900-01"?"":Convert.ToDateTime( Eval("TEndDate")).ToString("yyyy-MM") %></td>
                         
                                <td><%#Eval("IsReport").ToString()=="0"? "<span style='color:red'>未上报</span>":"已上报" %></td>
                                <td>
                                    <%--<div class="operationd">--%>

                                    <%--<asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="editora" Style="margin-left: 10px;" ToolTip="编辑" OnClientClick='return editinfo(this);'></asp:LinkButton>
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="viewa" ToolTip="详细" OnClientClick='return viewinfo(this);'></asp:LinkButton>--%>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细" OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("TWEID") %>' runat="server" />
                                    <%--</div>--%>
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

    </form>
</body>
</html>
