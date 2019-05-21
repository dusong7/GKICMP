<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExamEdit.aspx.cs" Inherits="GKICMP.educational.ExamEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <%--<link href="../css/demo.css" rel="stylesheet" />--%>
    <link href="../css/easyui.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../EasyUI/jquery.easyui.min.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
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
        <asp:HiddenField runat="server" ID="hf_EID" />
        <asp:Literal ID="ltl_Stu" runat="server"></asp:Literal>
        <div class="listcent">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo1">
                <tbody>
                    <tr>
                        <th align="left">
                            <div class="xxsm">
                                <ul>
                                    <li class="selected"><a href="ExamEdit.aspx?id=<%=EID%>">考试信息</a></li>
                                    <li><a href="ExamSubjectManage.aspx?id=<%=EID%>">考试设置</a></li>
                                    <li><a href="SeatingSequenceManage.aspx?id=<%=EID%>">考场座位表</a></li>
                                    <li><a href="InvigilatorManage.aspx?id=<%=EID %>">监考表</a></li>
                                </ul>
                            </div>
                        </th>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <td align="right" width="120">年级：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_GID" datatype="ddl" errormsg="请选择年级信息" AutoPostBack="True" OnSelectedIndexChanged="ddl_GID_SelectedIndexChanged"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">学年度：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_EYear" runat="server" datatype="*" nullmsg="请填写学年度"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">学期：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_Term" datatype="ddl" errormsg="请选择学期信息"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">考试名称：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_ExamName" runat="server" datatype="*" nullmsg="请填写考试名称" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">考试时间：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BeginDate" runat="server" datatype="*" Width="135px" nullmsg="请选择考试开始时间" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_EndDate" runat="server" datatype="*" Width="135px" nullmsg="请选择考试结束时间" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">考场最多人数：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_PeoNum" runat="server" datatype="zhengnum" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">座位排序方式</td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddl_SeatModel" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">考场</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_ClassRoom" cascadeCheck="false" runat="server" multiline="true" multiple="true" name="ClassRoom" onlyLeafCheck="true" url="../ashx/ClassRoomList.ashx?method=CRList" CssClass="easyui-combotree" TextMode="MultiLine" Rows="3" Height="50px" Width="90%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">考生</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_Student" runat="server" multiline="true" multiple="true" name="ClassRoom" onlyLeafCheck="True" CssClass="easyui-combotree" TextMode="MultiLine" Rows="3" Height="50px" Width="90%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>


