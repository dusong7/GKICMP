<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentElderDetail.aspx.cs" Inherits="GKICMP.studentmanage.StudentElderDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="positionc" id="div_top" runat="server" visible="false">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="家庭信息"></asp:Label>
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
                                <li><a href="StudentDetail.aspx?id=<%=StuID %>">基本信息</a></li>
                                <li class="selected"><a href="StudentElderDetail.aspx?id=<%=StuID %>">家庭信息</a></li>
                            </ul>
                        </div>
                    </th>
                </tr>
            </tbody>
        </table>

        <div class="listcent pad0" style="margin-top: 1px;">
           
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfoc">
                <tbody>
                    <tr>
                        <th align="center">家长姓名</th>
                        <th align="center">手机号</th>
                        <th align="center">工作单位</th>
                        <th align="center">职务</th>
                        <th align="center">关系</th>
                       
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                              
                                <td><%#Eval("ElderName")%></td>
                                <td><%#Eval("CellPhone")%></td>
                                <td><%#Eval("PostDep")%></td>
                                <td><%#Eval("PostName")%></td>
                                <td><%#Eval("ShipName")%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="5">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>

    </form>
</body>
</html>

