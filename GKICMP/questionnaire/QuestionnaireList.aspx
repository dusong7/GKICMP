<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuestionnaireList.aspx.cs" Inherits="GKICMP.questionnaire.QuestionnaireList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>智慧校园学生管理平台</title>
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
                return openbox('A_id', 'QuestionnaireEdit.aspx', '', 1060, 450, -1);
            });
            $('#btn_Publish').click(function () {
                var ids = document.getElementById("hf_CheckIDS").value;
                if (checkselectones(ids) == false) {
                    alert("系统提示：请至少选择一条信息！");
                    return false;
                }
                else {
                    return true;
                }
            });
        })
        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'QuestionnaireEdit.aspx', 'id=' + id, 1060, 450, 0);
        }
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'QuestionResult.aspx', 'id=' + id, 1060, 450, 43);
        }
        function addinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'AddQuestion.aspx', 'id=' + id, 1060, 450, -1);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="问卷管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="70">问卷名称：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_QuestName" runat="server"></asp:TextBox>
                        </td>
                        <td width="70" align="right">创建日期：</td>
                        <td width="250">
                            <asp:TextBox ID="txt_Begin" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                        <asp:TextBox ID="txt_End" runat="server" Style="width: 85px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <%--<td width="70" align="right">是否发布：</td>
                        <td width="250">
                            <asp:DropDownList runat="server" ID="ddl_IsOrNot">
                                <asp:ListItem Value="-2">--请选择--</asp:ListItem>
                                <asp:ListItem Value="1">是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:DropDownList>
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
                            <asp:Button ID="btn_Publish" runat="server" Text="发布"  CssClass="listbtncss listadd" OnClick="btn_Publish_Click" />
                            <asp:Button ID="btn_CancelPublic" runat="server" Text="取消发布"  CssClass="listbtncss listadd" OnClick="btn_CancelPublic_Click" />
                            <%--<asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />--%>
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
                        <th align="center" width="300">问卷名称</th>
                        <th align="center">截至日期</th>
                        <th align="center">是否实名投票</th>
                        <th align="center">是否发布</th>
                        <th align="center">创建人</th>
                        <th align="center">创建日期</th>
                        <th width="160px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("QID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("QID") %>' id='ck_<%#Eval("QID") %>' /></label>
                                </td>
                                <td><%#Eval("QuestName")%></td>
                                <td><%#Eval("LastDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot>(Eval("IsRealName"))%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot>(Eval("IsPublish"))%></td>
                                <td><%#Eval("CreateName")%></td>
                                <td><%#Eval("CreateDate","{0:yyyy-MM-dd}")%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Subject" runat="server" Visible='<%#Boolean.Parse(getValue(Eval("CreateUser").ToString())) %>'  CssClass="listbtn btnsubcolor" ToolTip="增加题目" OnClientClick='return addinfo(this);'>题目</asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField1" Value='<%#Eval("QID") %>' runat="server" />
                                        <asp:LinkButton ID="lbtn_Results" runat="server" CssClass="listbtn btnresultcolor" CommandArgument='<%#Eval("QID") %>' ToolTip="查看结果" OnClick="lbtn_Result_Click">结果</asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField2" Value='<%#Eval("QID") %>' runat="server" />
                                        <asp:LinkButton ID="lbtn_Edit" runat="server" Visible='<%#Boolean.Parse(getValue(Eval("CreateUser"))) %>' CssClass="listbtn btneditcolor" ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton> 
                                        <asp:HiddenField ID="HiddenField3" Value='<%#Eval("QID") %>' runat="server" />
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" CommandArgument='<%#Eval("QID") %>'  ToolTip="详情" OnClick="lbtn_Detail_Click">详情</asp:LinkButton>                          
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("QID") %>' runat="server" />
                                        <asp:LinkButton ID="lbtn_Delete" runat="server" Visible='<%#Boolean.Parse(getValue(Eval("CreateUser"))) %>' CssClass="listbtn btndeletecolor" ToolTip="删除" CommandArgument='<%#Eval("QID") %>' OnClientClick="return confirm('确认删除选中的信息吗？');" OnClick="lbtn_Delete_Click">删除</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID1" Value='<%#Eval("QID") %>' runat="server" />
                                    </div>
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




