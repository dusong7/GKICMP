<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportSet.aspx.cs" Inherits="GKICMP.studentmanage.ReportSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
     <script type="text/javascript">
         jQuery(document).ready(function () {
             jQuery("#form1").Validform();
         });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">报告单配置项</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">学年</td>
                        <td align="left">
                            <asp:TextBox ID="txt_EYear"  runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="100px">学期</td>
                        <td align="left">
                           <asp:DropDownList runat="server" ID="ddl_Term" Width="150"></asp:DropDownList>
                        </td>


                    </tr>
                    <tr>
                        <td align="right" width="100px">班级</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_Dep" runat="server" OnSelectedIndexChanged="ddl_Dep_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList><span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">平时等级</td>
                        <td align="left" >
                            <asp:DropDownList ID="ddl_ScoureByPS" runat="server" datatype="ddl" errormsg="请选择平时等级" ></asp:DropDownList><span style="color: Red; float: none">*</span>
                            </td>

                    </tr>
                    <tr>

                        <td align="right">期终等级</td>
                        <td align="left" >
                            <asp:DropDownList ID="ddl_ScoureByQZ" runat="server" datatype="ddl" errormsg="请选择期终等级" ></asp:DropDownList><span style="color: Red; float: none">*</span>
                        </td>
                         <td align="right">综合等级</td>
                        <td align="left" >
                           <asp:DropDownList ID="ddl_ScoureByZH" runat="server"  datatype="ddl" errormsg="请选择综合等级" ></asp:DropDownList><span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">放假时间</td>
                        <td align="left" colspan="3">
                            <asp:TextBox runat="server" ID="txt_BDate" onclick="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请选择变动日期"></asp:TextBox>-<asp:TextBox runat="server" ID="txt_EDate" onclick="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请选择变动日期"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                       

                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="导出Word" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

