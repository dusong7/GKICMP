<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ElectiverScoreImport.aspx.cs" Inherits="GKICMP.electiver.ElectiverScoreImport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../js/Validform_v5.3.2.js" type="text/javascript"></script>
    <script src="../js/editinfor.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            return jQuery("#form1").Validform();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_TermID" />
        <div class="listcent pad0">
            <div>
                <table width="100%" cellspacing="0" cellpadding="0" class="listinfo">
                    <tr>
                        <th colspan="4" align="left">成绩导入
                        </th>
                    </tr>
                    <tr>
                        <td width="100px" align="right">学年度/学期：</td>
                        <td>
                            <asp:Literal ID="ltl_EYear" runat="server"></asp:Literal>学年度<asp:Literal ID="ltl_TermID" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">课程：</td>
                        <td>
                            <%--<asp:DropDownList runat="server" ID="ddl_EleID" datatype="ddl" errormsg="请选择选课任务" OnSelectedIndexChanged="ddl_EleID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>--%>
                            <asp:DropDownList ID="ddl_CourseID" runat="server" datatype="ddl" errormsg="请选择课程"></asp:DropDownList>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">学生名单：</td>
                        <td>
                            <asp:LinkButton ID="LinkButton" Style="color: blue" runat="server"
                                OnClick="lbtn_example_Click">[学生名单下载]</asp:LinkButton></td>
                    </tr>
                    <tr>
                        <td align="right">成绩导入：</td>
                        <td>
                            <asp:FileUpload ID="fuimport" onchange="if(this.value)judgexls(this.value,this);"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">导入说明：</td>
                        <td>
                            <span style="color: red;">1.导入成绩时请下载学生名单；<br />
                                2.请勿修改所下载的学生名单内容，填入相应的科目分数即可；<br />
                            </span></td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" class="editor" id="return" value="返回" onclick='$.close("A_id");' />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
