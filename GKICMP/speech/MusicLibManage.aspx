<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MusicLibManage.aspx.cs" Inherits="GKICMP.speech.MusicLibManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>学生评语管理</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">

        $(function () {
            $('#btn_Add').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'MusicLibEdit.aspx', '', 840, 260, -1);
            });
           
        });
        function MusicOnline(e) {
            var id = $(e).next().val();
            //return openbox('A_id', 'MusicLibEdit.aspx', 'id=' + id, 840, 260, 0);
             $("#prevmusic").remove();
             $("<div><audio autoplay='autoplay' id='prevmusic' controls='controls'><source src='" + id + "'/></audio></div>").insertAfter($(e).next().next());
             //$(e).append("<div><audio autoplay='autoplay' id='prevmusic' controls='controls'><source src='" + id + "'/></audio></div>");
        }
       
        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'MusicLibEdit.aspx', 'id=' + id, 840, 260, 0);
        }
    </script>
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="音乐库"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="50px">音乐名称：</td>
                        <td width="70px">
                            <asp:TextBox ID="txt_Name" runat="server" Width="100px"></asp:TextBox>
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
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)" /></label>
                        </th>
                        <th align="center">音乐名称</th>
                        <th align="center">大小</th>
                        <th align="center">上传人</th>
                        <th align="center">上传时间</th>
                        <th align="center" width="70px">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("MID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("MID") %>' id='ck_<%#Eval("MID") %>' /></label>
                                </td>
                                <td><%#Eval("Name")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CountSize(int.Parse(Eval("Size").ToString()))%></td>
                                <td><%#Eval("UserName")%></td>
                                <td><%#Eval("CreateDate","{0:yyyy-MM-dd HH:mm}")%></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_VideoPlay" runat="server" CssClass="listbtn btndelcolor" ToolTip="广播播放" CommandArgument='<%#Eval("Src") %>'  OnClick="lbtn_VideoPlay_Click">广播播放</asp:LinkButton>
                                    
                                    <a class="listbtn btngraduationcolor" title="本地试听" onclick="MusicOnline(this);" >本地试听 </a>
                                    <asp:HiddenField ID="HiddenField2" Value='<%#Eval("Src") %>' runat="server" />
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField1" Value='<%#Eval("MID") %>' runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="12" align="center">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>

