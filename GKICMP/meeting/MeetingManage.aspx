<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeetingManage.aspx.cs" Inherits="GKICMP.meeting.MeetingManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
            //$('#btn_Add').click(function () {
            //    //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
            //    return openbox('A_id', 'MeetingEdit.aspx', '', 1040, 670, -1);
            //});

            $('#lbtn_Audit').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                var id = document.getElementById("hf_CheckIDS").value;
                if (id == "") {
                    alert("系统提示：请至少选择一条记录");
                    return;
                }
                return openbox('A_id', 'MeetingAuditEdit.aspx', 'id=' + id, 540, 220, -1);
            });

            //$('#btn_Summary').click(function () {
            //    var id = document.getElementById("hf_CheckIDS").value;

            //    var ids = new Array();
            //    ids = id.split(',');

            //    if (id == "") {
            //        alert("系统提示：请选择一条信息!");
            //        return;
            //    }
            //    else if (ids.length > 2) {
            //        alert("系统提示：只可操作一条记录，请检查");
            //        return;
            //    }
            //    return openbox('A_id', 'MeetingSummary.aspx', '', 940, 410, 23);
            //});
        });
        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'MeetingEdit.aspx', 'id=' + id, 1040, 670, 0);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="会议管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">会议主题：</td>
                        <td width="200">
                            <asp:TextBox ID="txt_MTitle" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">会议室：</td>
                        <td width="200">
                            <asp:DropDownList ID="ddl_MeetingRoom" runat="server"></asp:DropDownList>
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
                            <%--<asp:Button ID="btn_Summary" runat="server" Text="会议纪要" CssClass="listsummary" />--%>
                            <asp:Button ID="lbtn_Audit" runat="server" Text="审核" CssClass="listsummary" />
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
                        <th align="center">会议主题</th>
                        <th align="center">会议室</th>
                        <th align="center">会议主持人</th>
                        <th align="center">会议时间</th>
                        <th align="center">录入人</th>
                        <th align="center">录入时间</th>
                        <th align="center">审核状态</th>
                        <th width="120px" align="center" runat="server" id="th1">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("MID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("MID") %>' id='ck_<%#Eval("MID") %>' /></label>
                                </td>
                                <td><%#Eval("MTitle")%></td>
                                <td><%#Eval("MRName")%></td>
                                <td><%#Eval("MeetingHostName")%></td>
                                <td><%#Eval("MBegin","{0:yyyy-MM-dd HH:mm}")%>至<%#Eval("MEnd","{0:yyyy-MM-dd HH:mm}") %></td>
                                <td><%#Eval("CreateUserName")%></td>
                                <td><%#Eval("CreateDate","{0:yyyy-MM-dd HH:mm}")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.PraState>(Eval("AuditState"))%></td>
                                <td runat="server" id="td1">
                                    <div>
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" OnClick="lbtn_Detail_Click" CommandArgument='<%#Eval("MID") %>'>详情</asp:LinkButton>
                                        <asp:LinkButton ID="lbtn_Edit" runat="server" Visible='<%#Eval("AuditState").ToString()=="0"?true:false %>' CssClass="listbtn btneditcolor" OnClick="lbtn_Edit_Click" CommandArgument='<%#Eval("MID") %>'>编辑</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID1" Value='<%#Eval("MID") %>' runat="server" />
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="9">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>
