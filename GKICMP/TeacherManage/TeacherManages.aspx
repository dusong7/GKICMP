<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherManages.aspx.cs" Inherits="GKICMP.teachermanage.TeacherManages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btn_Input').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'TeacherImport.aspx', '', 1160, 560, -1);
            });
        });
        function editinfo(e) {
            //var id = $(e).next().next().val();
            //var tid = $(e).next().next().next().val();
            var id = $(e).next().next().val();
            alert(id);
            return openbox('A_id', 'TeacherEdit.aspx', 'id=' + id, 1160, 610, 0);
        }
        function viewinfo(e) {
            //var id = $(e).next().val();
            var id = $(e).next().next().next().val();
            return openbox('A_id', 'TeacherDetail.aspx', 'id=' + id, 1060, 600, 4);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="教师信息管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">姓名：</td>
                        <td width="100">
                            <asp:TextBox ID="txt_RealName" runat="server"></asp:TextBox>
                        </td>
                        <td width="60" align="right">性别：</td>
                        <td width="50">
                            <asp:DropDownList runat="server" ID="ddl_TSex"></asp:DropDownList>
                        </td>
                        <td align="right" width="60">政治面貌：</td>
                        <td width="100">
                            <asp:DropDownList runat="server" ID="ddl_Politics" Width="100"></asp:DropDownList>
                        </td>
                        <td align="right" width="60">教授科目：</td>
                        <td width="70">
                            <asp:DropDownList runat="server" ID="ddl_TCourse"></asp:DropDownList>
                        </td>
                        <td align="right" width="60">是否在编：</td>
                        <td width="70">
                            <asp:DropDownList runat="server" ID="ddl_IsSeries"></asp:DropDownList>
                        </td>

                        <td rowspan="2">
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="60">人员状态：</td>
                        <td colspan="9">                           
                                <asp:TextBox ID="txt_TeaState" runat="server" multiline="true" multiple="true" name="ClassRoom" onlyLeafCheck="true" url="../ashx/data.ashx?flag=2" CssClass="easyui-combotree" Width="100%"></asp:TextBox>
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
                            <asp:Button ID="btn_Input" runat="server" Text="导入"   CssClass="listbtncss listinput" />
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
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
                        <th align="center">身份证号码</th>
                        <th align="center">教授科目</th>
                        <th align="center">是否在编</th>
                        <th align="center">参加工作年月</th>
                        <th align="center">政治面貌</th>
                        <th align="center">用人形式</th>
                        <th align="center">签订合同情况</th>
                        <th align="center">人员状态</th>
                        <th align="center">是否上报</th>
                        <th width="100px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("TID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("TID") %>' <%#GetState(Eval("IsReport")) %> id='ck_<%#Eval("TID") %>' /></label>
                                </td>


                                <td><%#Eval("RealName")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XB>(Eval("TSex"))%></td>
                                <td><%#Eval("IDCardNum").ToString()==""?"暂无身份证信息":Eval("IDCardNum").ToString().Length>14?Eval("IDCardNum").ToString().Substring(0,4)+"******"+Eval("IDCardNum").ToString().Substring(14):"身份证有误，请修改"%></td>
                                <td><%#Eval("CourseName") %></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot>(Eval("IsSeries"))%></td>
                                <%-- <td><%#Eval("IsSeries")%></td>--%>
                                <td><%#Eval("JodDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.ZZMM>(Eval("Politics"))%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.EmploymentForm>(Eval("EmploymentType"))%></td>
                                <%--<td><%#Eval("EmploymentType")%></td>--%>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.ContractState>(Eval("ContractState"))%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.TeaState>(Eval("TeaState"))%></td>
                                <td><%#Eval("IsReport").ToString()=="1"? "已上报":"<span style='color:red'>未上报</span>" %></td>

                                <td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" CommandArgument='<%#Eval("TID") %>' Visible='<%#Eval("IsReport").ToString()=="1" ? false:true %>' ToolTip="编辑" OnClick="lbtn_Edit_Click">编辑</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Info" runat="server" CssClass="listbtn btndetialcolor" CommandArgument='<%#Eval("TID") %>' ToolTip="详情" OnClick="lbtn_Info_Click">详情</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_Report" runat="server" CssClass="listbtn btnreportncolor" Visible='<%#Eval("IsReport").ToString()=="1" ? false:true %>' ToolTip="上报" CommandArgument='<%#Eval("TID") %>' OnClick="lbtn_SB_Click" OnClientClick="return  confirm('您确认要上报该信息吗？');">上报</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("TID") %>' runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="12">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>

