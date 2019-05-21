<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentInfo.aspx.cs" Inherits="GKICMP.studentpage.StudentInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
   <link href="../css/green_formcss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
          <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text="我的档案"></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="我的档案"></asp:Label><span>></span>基本信息
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent pad0">
            <asp:HiddenField ID="hf_face" runat="server" Value="" />
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                    <th align="left" colspan="4">
                        <div class="xxsm" style="padding-left: 15px">
                            <ul>
                                <li class="selected"><a href="StudentInfo.aspx">基本信息</a></li>
                                <li ><a href="StudentElderList.aspx">家庭信息</a></li>
                            </ul>
                        </div>
                    </th>
                </tr>
                    <tr>
                        <th colspan="4" align="left" style="font-size: 18px; font-weight: bold;">基本信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">姓名：</td>
                        <td align="left">
                            <asp:Label ID="lbl_RealName" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="100px">性别：</td>
                        <td align="left">
                            <asp:Label ID="lbl_Sex" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">曾用名：</td>
                        <td align="left">
                            <asp:Label ID="lbl_UsedName" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">&nbsp;身份证号码：</td>
                        <td align="left">
                            <asp:Label ID="lbl_IDCard" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">出生日期：</td>
                        <td align="left">
                            <asp:Label ID="lbl_BirthDay" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">监护人：</td>
                        <td align="left">
                            <asp:Label ID="lbl_Guardian" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">名族：</td>
                        <td align="left">
                            <asp:Label ID="lbl_Nation" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">户口类型：</td>
                        <td align="left">
                            <asp:Label ID="lbl_RegistType" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">电子校牌：</td>
                        <td align="left">
                            <asp:Label ID="lbl_CardNum" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right" width="140px">监护人身份证号码：</td>
                        <td align="left">
                            <asp:Label ID="lbl_GuardNum" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">父母手机号码：</td>
                        <td align="left">
                            <asp:Label ID="lbl_Cellphone" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">籍贯：</td>
                        <td align="left">
                            <asp:Label ID="lbl_PlaceOrigion" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">是否留守儿童：</td>
                        <td align="left">
                            <asp:Label ID="lbl_IsLeftBehind" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">是否外地学生：</td>
                        <td align="left">
                            <asp:Label ID="lbl_IsField" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">是否独生子女：</td>
                        <td align="left">
                            <asp:Label ID="lbl_IsOnly" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">流动人口：</td>
                        <td align="left">
                            <asp:Label ID="lbl_IsFlow" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">户口所在地：</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_RegisteredPlace" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">照片</td>
                        <td align="left" colspan="3">
                            <asp:Image ID="img_Photo" runat="server" Width="200" Height="200" Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <th colspan="4" align="left" style="font-size: 18px; font-weight: bold;">学籍信息</th>
                    </tr>
                    <tr>
                       
                        <td align="right">班级：</td>
                        <td align="left" colspan="3">
                            <asp:Label ID="lbl_Claid" runat="server" Text=""></asp:Label>
                        </td>

                    </tr>
                    <tr>
                        <td align="right">入学日期：</td>
                        <td align="left">
                            <asp:Label ID="lbl_EntranceDate" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">学生状态：</td>
                        <td align="left">
                            <asp:Label ID="lbl_Ustate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">入团党日期：</td>
                        <td align="left">
                            <asp:Label ID="lbl_LoinDate" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">政治面貌：</td>
                        <td align="left">
                            <asp:Label ID="lbl_Politics" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">全国学籍号：</td>
                        <td align="left">
                            <asp:Label ID="lbl_GEnrollment" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">省学籍号：</td>
                        <td align="left">
                            <asp:Label ID="lbl_PEnrollment" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>

                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

