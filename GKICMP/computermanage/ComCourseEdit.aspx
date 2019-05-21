<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComCourseEdit.aspx.cs" Inherits="GKICMP.computermanage.ComCourseEdit" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>

    <%--<script src="../js/editinfor.js"></script>--%>
    <script src="../js/editinfor.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_CssFlag" runat="server" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">机房登记信息</th>
                    </tr>
                    <tr>
                        <td align="right">班级：</td>
                        <td align="left">
                            <div class="sel" style="float: left">
                                <asp:DropDownList ID="ddl_CID" runat="server" datatype="ddl" errormsg="请选择班级" OnSelectedIndexChanged="ddl_CID_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                <span style="color: Red">*</span>
                            </div>
                        </td>
                        <td align="right" width="150">学科：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_CourseID" runat="server" datatype="ddl" errormsg="请选择学科" OnSelectedIndexChanged="ddl_CourseID_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                            <span style="color: Red">*</span>
                            <%--<asp:DropDownList ID="ddl_Type" runat="server" Width="120px" datatype="ddl" errormsg="请选择数据类型"></asp:DropDownList>
                            <span style="color: Red">*</span>--%>
                           
                        </td>


                    </tr>
                    <tr>
                        <td align="right">章节：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_ChapterName" runat="server" datatype="*1-100" nullmsg="请填写章节"></asp:TextBox>
                            <span style="color: Red">*</span>
                        </td>
                        <td align="right">教师：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_Teach" runat="server" datatype="ddl" errormsg="请选择教师"></asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>


                    </tr>

                    <tr>
                        <td align="right">节次：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_Num" runat="server" datatype="ddl" errormsg="请选择节次"></asp:DropDownList><span style="color: Red">*</span>
                        </td>
                        <td align="right">登记时间：</td>
                        <td align="left">
                            <div class="sel" style="float: left">
                                <asp:TextBox ID="txt_RegDate" runat="server" datatype="*1-100" nullmsg="请填写登记时间" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox><span style="color: Red">*</span>
                            </div>
                        </td>


                    </tr>
                    <tr>
                        <td align="right">教室：</td>
                        <td align="left" colspan="3">
                            <div class="sel" style="float: left">
                                <asp:DropDownList ID="ddl_CRID" runat="server" datatype="ddl" errormsg="请选择教室"></asp:DropDownList>
                                <span style="color: Red">*</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' /></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>





