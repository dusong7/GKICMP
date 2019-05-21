<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRegAdd.aspx.cs" Inherits="GKICMP.freshmen.StudentRegAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
        function getfile() {
            var hfatta = $id("hf_UpFile");
            var careful = $id("more").getElementsByTagName("input");
            hfatta.value = careful.length;
        }
    </script>

    <style>
        .edilab label {
            float: none;
        }

        .edilab input {
            height: 13px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_UserSex" runat="server" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">基本信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">姓名：</td>
                        <td align="left">
                            <asp:Label ID="lbl_RealName" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="right" width="120">性别：</td>
                        <td align="left">
                            <asp:Label ID="lbl_UserSex" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">曾用名：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_UsedName" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="120">身份证号码：</td>
                        <td align="left">
                            <asp:Label ID="lbl_IDCard" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" width="120">出生日期：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BirthDay" runat="server" datatype="*" nullmsg="请选择出生日期" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">监护人：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_Guardian" runat="server" datatype="*" nullmsg="请填写监护人"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">民族：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_Nation" datatype="ddl" errormsg="请选择民族"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right" width="120">户口类型：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_RegistType" datatype="ddl" errormsg="请选择户口类型"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>

                    </tr>
                    <tr>
                        <td align="right" width="120">电子校牌：</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txt_CardNum"></asp:TextBox>

                        </td>
                        <td align="right" width="120">监护人身份证号码：</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txt_GuardNum" datatype="idcard" nullmsg="请填写监护人身份证号码"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="140">父母手机号码：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_CellPhone" runat="server" datatype="m" nullmsg="请填写父母手机号码"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right" width="120">籍贯：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_PlaceOrigion" runat="server" datatype="*" nullmsg="请填写籍贯"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right" width="120">是否留守儿童：</td>
                        <td align="left">
                            <asp:RadioButtonList ID="rbl_IsLeftBehind" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="edilab">
                            </asp:RadioButtonList>
                        </td>
                        <td align="right" width="120">是否外地学生：</td>
                        <td align="left">
                            <asp:RadioButtonList ID="rbl_IsField" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="edilab">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">是否独生子女：</td>
                        <td align="left">
                            <asp:RadioButtonList ID="rbl_IsOnly" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="edilab">
                            </asp:RadioButtonList>
                        </td>
                        <td align="right" width="120">流动人口：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_pid" runat="server" OnSelectedIndexChanged="ddl_pid_SelectedIndexChanged" AutoPostBack="true" datatype="ddl" errormsg="请选择流动人口"></asp:DropDownList>
                            <asp:DropDownList ID="ddl_IsFlow" runat="server" Visible="false"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right" width="120">户口所在地：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_RegisteredPlace" runat="server" Width="600"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="4" align="left">学籍信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">班级：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_DepID" runat="server" datatype="ddl" errormsg="请选择班级"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right" width="120">状态：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_Usuate" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">入团党日期：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_LoinDate" runat="server" onclick="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请填写入团党日期"></asp:TextBox>
                        </td>
                        <td align="right" width="120">入学日期：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_EntranceDate" runat="server" onclick="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请填写入学日期"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">省学籍号：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_PEnrollment" runat="server" Width="400px" datatype="*" nullmsg="请填写省学籍号"></asp:TextBox></td>
                        <td align="right" width="120">政治面貌：                    
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_Politics" datatype="ddl" errormsg="请选择政治面貌"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">全国学籍号：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_GEnrollment" runat="server" Width="400px" datatype="*" nullmsg="请填写全国学籍号"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th colspan="4" align="left">照片上传</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">照片：</td>
                        <td colspan="3">
                            <asp:Image ID="Image1" runat="server" Width="200px" Visible="false" />
                            <div id="more">
                                <asp:FileUpload ID="fl_UpFile" runat="server" onchange="if(this.value)judgepic(this.value,this);" />
                            </div>
                            <asp:HiddenField ID="hf_UpFile" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <asp:Button ID="btn_Back" runat="server" Text="返回" CssClass="editor" OnClick="btn_Back_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>


