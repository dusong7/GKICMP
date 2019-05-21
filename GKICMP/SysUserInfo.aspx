<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysUserInfo.aspx.cs" Inherits="GKICMP.sysmanage.SysUserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>芜湖智慧体测健康管理平台</title>

    <link href="css/green_formcss.css" rel="stylesheet" />
    <script src="js/jquery-1.8.2.min.js"></script>
    <script src="js/Validform_v5.3.2.js"></script>
    <script src="js/My97/WdatePicker.js"></script>
    <script src="js/editinfor.js"></script>
    <script src="js/common.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_FID" />
        <asp:HiddenField runat="server" ID="hf_UsersPwd" Value="" />
        <asp:HiddenField runat="server" ID="hf_UState" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">用户信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="150">用户名：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_UserName" runat="server" datatype="*1-50" nullmsg="请填写用户名" MaxLength="50" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td rowspan="4" colspan="2" align="center">
                            <asp:Image ID="Image1" runat="server" Width="200px" Height="200px" ImageUrl="/images/graduate_male.png" />
                            <div id="more">
                                <asp:FileUpload ID="fl_UpFile" runat="server" onchange="if(this.value)judgepic(this.value,this);" />
                            </div>
                            <asp:HiddenField ID="hf_UpFile" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">身份证号码：</td>
                        <td>
                            <asp:TextBox ID="txt_IDCard" runat="server" MaxLength="50" datatype="idcard" nullmsg="请填写身份证号码" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right" width="150">姓名：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_RealName" runat="server" datatype="*1-50" nullmsg="请填写姓名" MaxLength="50" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">性别：</td>
                        <td>
                            <div class="sel" style="float: left">
                                <asp:DropDownList runat="server" ID="ddl_UserSex" datatype="ddl" errormsg="请选择性别"></asp:DropDownList>
                                <span style="color: Red; float: none">*</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="150">手机号：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_CellPhone" runat="server" datatype="m" nullmsg="请填写手机号码" MaxLength="50" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right">公司座机：</td>
                        <td>
                            <asp:TextBox ID="txt_CompanyNum" runat="server" MaxLength="50" CssClass="searchbg"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="150">出生年月：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BirthDay" runat="server" datatype="*" nullmsg="请选择出生年月" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">家庭地址：</td>
                        <td>
                            <asp:TextBox ID="txt_Address" runat="server" datatype="*1-50" nullmsg="请填写家庭地址" MaxLength="50" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right" width="150">邮箱：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_MailNum" runat="server" MaxLength="50" CssClass="searchbg"></asp:TextBox>
                        </td>
                        <td align="right">QQ：</td>
                        <td>
                            <asp:TextBox ID="txt_QQNum" runat="server" MaxLength="15" CssClass="searchbg"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="150">微信号：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_WeiNum" runat="server" MaxLength="50" CssClass="searchbg"></asp:TextBox>
                        </td>
                        <td align="right">用户类别：</td>
                        <td>
                            <asp:DropDownList runat="server" datatype="ddl" errormsg="请选择类型" ID="ddl_UserType"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="150">民族：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" datatype="ddl" errormsg="请选择民族" ID="ddl_UserNation"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">一卡通：</td>
                        <td>
                            <asp:TextBox ID="txt_CardNum" runat="server" MaxLength="50" CssClass="searchbg"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td align="right">原密码：</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_OldPwd" runat="server" MaxLength="100" TextMode="Password"></asp:TextBox>
                    </tr>
                    <tr>
                        <td align="right">新密码：</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_SysPwd" runat="server" MaxLength="100" TextMode="Password"></asp:TextBox>
                    </tr>
                    <tr>
                        <td align="right">重复密码：</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_AgainPwd" runat="server" MaxLength="100" TextMode="Password"></asp:TextBox>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            &nbsp;</td>
                    </tr>

                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
