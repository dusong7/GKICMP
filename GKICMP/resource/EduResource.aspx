<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EduResource.aspx.cs" Inherits="GKICMP.resource.EduResource" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  <title>智慧校园门户管理平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
   <script>
       $(function () {
           $('#btn_Add').click(function () {
               //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
               return openbox('A_id', 'EduResourseEdit.aspx', '', 960, 460, -1);
           });
       });
       function audit(e) {
           var id = $(e).next().val();
           return openbox('A_id', 'EduResourceAudit.aspx', 'id=' + id , 880, 345, 1);
       }
       function edit(e) {
           var id = $(e).next().next().val();
           return openbox('A_id', 'EduResourseEdit.aspx', 'id=' + id, 960, 460, 1);
       }
       function detail(e) {
           var id = $(e).next().val();
           return openbox('A_id', 'EduResourceDetail.aspx', 'id=' + id, 960, 360, 1);
       }
       function yl(e) {
           var id = $(e).next().val();
           var a = id.substring(id.lastIndexOf('.'))
           if (a == "") {
               alert("暂不支持在线预览");
               return false;
           }
           else {
               return openbox('A_id', 'ReadOnLine.html', 'id=' + id, 960, 860, 1);
           }
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="我的资源"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
         <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">资源名称：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_ResourseName" runat="server"></asp:TextBox>
                        </td>
                        <td width="70" align="right">所属年级：</td>
                        <td width="230">
                            <asp:DropDownList ID="ddl_MName" runat="server"></asp:DropDownList>
                        </td>
                          <td width="70" align="right">类别：</td>
                        <td width="350">
                            <asp:DropDownList ID="ddl_EType" runat="server"></asp:DropDownList>
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
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd"  />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
                            <asp:Button ID="btn_Release" runat="server"   CssClass="listbtncss btnoutexcel" Text="发布" OnClick="btn_Release_Click"  />
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
                        <th align="center">资源名称</th>
                        <th align="center">所属年级</th>
                        <th align="center">学期</th>
                        <th align="center">学科</th>
                        <th align="center">类别</th>
                        <th align="center">上传者</th>
                        <th align="center">上传日期</th>
                        <th align="center">下载次数</th>
                        <th align="center">是否精品</th>
                        <th align="center">是否公开</th>
                        <th align="center">审核状态</th>
                        <th width="100px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("Erid")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("Erid") %>' id='ck_<%#Eval("Erid") %>'  /></label>
                                </td>
                                <td><%#Eval("ResourseName")%></td>
                                <td><%#Eval("GIDName")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XQ>(Eval("TID"))%></td>
                                <td><%#Eval("CIDName")%></td>
                                 <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.EType>(Eval("EType"))%></td>
                                <td><%#Eval("CreateUserName")%></td>
                                <td><%#Eval("CreateDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("DownLoadNum")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot>(Eval("IsExcellent"))%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot>(Eval("IsOpen"))%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.NewsAuditState>(Eval("AuditState")).ToString() %></td>
                                <td>
                                        <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" ToolTip="编辑" CommandArgument='<%#Eval("Erid") %>' OnClientClick='return edit(this);'>编辑</asp:LinkButton>
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor"  ToolTip="详细" CommandArgument='<%#Eval("Erid") %>' OnClientClick='return detail(this);' >详细</asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("Erid") %>' runat="server" />
                                        <asp:LinkButton ID="lbtn_Audit" runat="server" CssClass="listbtn btnreportncolor"  ToolTip="审核" OnClientClick='return audit(this);' Visible='<%#getState(Eval("AuditState"))%> '>审核</asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField1" Value='<%#Eval("Erid") %>' runat="server" />
                                     <asp:LinkButton ID="LinkButton1" runat="server" CssClass="listbtn btnreportncolor"  ToolTip="预览" OnClientClick='return yl(this);' >预览</asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField2" Value='<%#Eval("ResourseUrl") %>' runat="server" />
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


