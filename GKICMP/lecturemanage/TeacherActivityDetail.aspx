<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherActivityDetail.aspx.cs" Inherits="GKICMP.lecturemanage.TeacherActivityDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../utf8-net/ueditor.config.js"></script>
    <script src="../utf8-net/ueditor.all.js"></script>
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

        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">教学活动信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">活动名称：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_ActName" runat="server" ></asp:Literal>
                        </td>
                        <td align="right">活动地点：</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_ActAddress"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">活动类型：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_ActType" runat="server" ></asp:Literal>
                        </td>
                        <td align="right">活动日期：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_ABegin" runat="server" ></asp:Literal>至
                            <asp:Literal ID="ltl_AEnd" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">参与教师：</td>
                        <td align="left" colspan="3">
                            <%-- <input id="Counselor" name="Counselor" class="easyui-combotree" runat="server" />
                            <span style="color: Red; float: none">*</span>--%>
                            <asp:Literal ID="Series" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">活动内容：</td>
                        <td colspan="3">
                            <asp:Literal ID="ltl_ActContent" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td colspan="3">
                            <asp:Literal ID="ltl_ActDesc" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <input type="button" name="button" id="cancell" value="返回" class="editor" onclick="$.close('A_id')" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
