<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LEDIssueManage.aspx.cs" Inherits="GKICMP.led.LEDIssueManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btn_Add').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'LEDPublish.aspx', '', 940, 550, -1);
            });
        });
        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'LEDPublish.aspx', 'id=' + id, 940, 550, 0);
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="教学活动"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
       
    
            <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="70">显示屏名称：</td>
                        <td width="160">
                            <asp:TextBox ID="txt_LName" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="70">播放日期：</td>
                        <td width="220">
                            <asp:TextBox ID="txt_Begin" runat="server" Style="width: 85px" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                              <asp:TextBox ID="txt_End" runat="server" Style="width: 85px" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
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
                            <asp:Button ID="btn_Publish" runat="server" Text="发布"  CssClass="listbtncss listadd" OnClick="btn_Publish_Click" />
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
                        <th align="center">显示屏名称</th>
                        <th align="center">发布内容</th>
                        <th align="center">发布类型</th>
                        <th align="center">开始日期</th>
                        <th align="center">结束日期</th>
                        <th align="center">开始时间</th>
                        <th align="center">结束时间</th>
                        <th align="center" width="70px">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("LIID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("LIID") %>' id='ck_<%#Eval("LIID") %>' /></label>
                                </td>
                                <td><%#Eval("LName")%></td>
                                <td><%#Eval("IFlag").ToString()=="1"?Eval("IName")+"."+Eval("IContent").ToString().Split('.')[Eval("IContent").ToString().Split('.').Length-1]:Eval("IContent")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.LedAddType>(Eval("IFlag"))%></td>
                                <td><%#Eval("BeginDate","{0:yyyy-MM-dd}")=="1900-01-01"?Eval("CreateDate","{0:yyyy-MM-dd}"):Eval("BeginDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("EndTime","{0:yyyy-MM-dd}")=="1900-01-01"?Eval("CreateDate","{0:yyyy-MM-dd}"):Eval("EndTime","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("BeginTime","{0:HH:mm:ss}")=="00:00:00"?Eval("CreateDate","{0:HH:mm:ss}"):Eval("BeginTime","{0:HH:mm:ss}")%></td>
                                <td><%#Eval("EndTime","{0:HH:mm:ss}")=="00:00:00"?Eval("CreateDate","{0:HH:mm:ss}"):Eval("EndTime","{0:HH:mm:ss}")%></td>
                                <td>
                                    <div>
                                        <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" OnClientClick="return editinfo(this);">编辑</asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField1" Value='<%#Eval("LIID") %>' runat="server" />
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


