<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommentManage.aspx.cs" Inherits="GKICMP.cms.CommentManage" %>

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
        $(function () {
            //$('#btn_Add').click(function () {
            //    //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
            //    return openbox('A_id', 'CommentReply.aspx', '', 840, 350, -1);
            //});

            $('#btn_IsPublish').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                var ids = document.getElementById("hf_CheckIDS").value;
                var flag = document.getElementById("hf_CID").value;
                if (checkselectones(ids) == false) {
                    alert("系统提示：请至少选择一条信息！");
                    return false;
                }
                else {
                    return openbox('A_id', 'CommentPublish.aspx', '&ids=' + ids + '&flag=' + flag, 500, 300, 32);
                }
            });
        });
        function viewinfo(e) {
            var id = $(e).next().next().val();
            var flag = document.getElementById("hf_CID").value;//1：留言 2：评论
            return openbox('A_id', 'CommentReply.aspx', 'id=' + id + '&flag=' + flag, 700, 245, 40);
        }
        //function editinfo(e) {
        //    var id = $(e).next().next().val();
        //    var flag = document.getElementById("hf_CID").value;//1：留言 2：评论
        //    return openbox('A_id', 'CommentEdit.aspx', 'id=' + id + '&flag=' + flag, 840, 550, 0);
        //}
        function useinfo(e) {
            var id = $(e).next().val();
            var flag = document.getElementById("hf_CID").value;//1：留言 2：评论
            return openbox('A_id', 'CommentDetail.aspx', 'id=' + id + '&flag=' + flag, 880, 345, 1);
        }
    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_CID" runat="server" />
       <%-- <asp:HiddenField ID="hf_SID" runat="server" />--%>
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>

                    <%--<td class="positiona"><a>首页</a><span>>网站管理</span><span><asp:Label ID="lbl_PMen" runat="server"></asp:Label>></span><asp:Label ID="lbl_Menuname" runat="server" Text="管理"></asp:Label>--%>
                     <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="评论管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">
                            <asp:Literal ID="ltl_ComTitle" runat="server"></asp:Literal>标题：</td>
                        <td width="200">
                            <asp:TextBox ID="txt_ComTitle" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">
                            <asp:Literal ID="ltl_OutDate" runat="server"></asp:Literal>时间：</td>
                        <td width="280">
                            <asp:TextBox ID="txt_BeginDate" Width="75px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_EndDate" Width="75px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td align="right" width="100">是否公开：</td>
                        <td width="200">
                            <div class="sel" style="float: left">
                                <asp:DropDownList ID="ddl_IsPublish" runat="server"></asp:DropDownList>
                            </div>
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
                            <%--  <asp:Button ID="btn_Add" runat="server" Text="回复"  CssClass="listbtncss listadd" />--%>
                            <asp:Button ID="btn_IsPublish" runat="server" Text="是否公开" CssClass="listbtncss listoutput" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
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
                        <th align="center">
                            <asp:Literal ID="ltl_title" runat="server"></asp:Literal>标题</th>
                        <th align="center">
                            <asp:Literal ID="ltl_content" runat="server"></asp:Literal>内容</th>
                        <th align="center">是否公开</th>
                        <th align="center">审核人</th>
                        <th align="center">
                            <asp:Literal ID="ltl_date" runat="server"></asp:Literal>时间</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("CID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("CID") %>' id='ck_<%#Eval("CID") %>' /></label>
                                </td>
                                <td><%#Eval("ComTitle")%></td>
                                <td><%#Eval("ComContent")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot>(Eval("IsPublish"))%></td>
                                <td><%#Eval("AuditUserName")%></td>
                                <td><%#Convert.ToDateTime( Eval("ComDate")).ToString("yyyy-MM-dd HH:mm:ss")%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Answer" runat="server" CssClass="listbtn btneditcolor" ToolTip="回复" Style="margin-left: 10px;" OnClientClick='return viewinfo(this);'>回复</asp:LinkButton>
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细" OnClientClick='return useinfo(this);'>详细</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID1" Value='<%#Eval("CID") %>' runat="server" />
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="7">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager runat="server" ID="Pager" />
    </form>
</body>
</html>
