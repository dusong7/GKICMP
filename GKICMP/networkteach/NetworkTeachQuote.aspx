<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NetworkTeachQuote.aspx.cs" Inherits="GKICMP.networkteach.NetworkTeachQuote" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <%--<script src="../js/jquery.min.js"></script--%>
    <title>智慧校园行政办公平台</title>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />

    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
       
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">网络课程信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="80">课程名称</td>
                        <td align="left">
                            <asp:TextBox ID="txt_NTTName" runat="server" datatype="*1-50" nullmsg="请填写课程名称" CssClass="searchbg"
                                MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td> </tr>
                    <tr>
                        <td align="right" width="80">适合年级</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_EPID" runat="server" datatype="ddl" errormsg="请选择年级" Width="120px" AutoPostBack="true" OnSelectedIndexChanged="ddl_MeetingRoom_SelectedIndexChanged"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">所属课程</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_CID" runat="server" datatype="ddl" errormsg="请选择课程" Width="120px"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td> 
                    </tr>
                     <tr>
                        <td align="right">可见班级</td>
                        <td align="left">
                            <asp:CheckBoxList ID="cbl_Class" Class="edilab"  runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
                        </td> 
                    </tr>
                    <tr>
                        <td align="right">在线开始时间</td>
                        <td>
                            <asp:TextBox ID="txt_TeaBegin" runat="server" Width="120px" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})" datatype="*" nullmsg="请选择开始时间"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">在线结束时间</td>
                        <td >
                            <asp:TextBox runat="server" ID="txt_TeaEnd" Width="120px" datatype="*" nullmsg="请选择结束时间" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">是否允许交流</td>
                        <td >
                            <style>
                                .edilab label {
                                    float: none;
                                }

                                .edilab input {
                                    height: 13px;
                                }

                                .auto-style1 {
                                    height: 16px;
                                }
                            </style>
                            <asp:CheckBox ID="cb_IsOrNot" Class="edilab" runat="server" Text="是" RepeatDirection="Horizontal"
                                RepeatLayout="Flow" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="SetValue()" OnClick="btn_Sumbit_Click" />
                            &nbsp;</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <asp:HiddenField ID="hf_UpFile" runat="server" />
        <asp:HiddenField ID="hf_UpImg" runat="server" />
    </form>
    
    
</body>
</html>


