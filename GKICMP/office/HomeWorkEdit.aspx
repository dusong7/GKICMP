<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeWorkEdit.aspx.cs" Inherits="GKICMP.office.HomeWorkEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
        //function showbox() {
        //    return parent.openbox('W_id', '../studentinfo/ClassSelectMore.aspx', '', 960, 585, 57);
        //}
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
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">作业详情</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">班级：</td>
                        <td >
                            <asp:CheckBoxList ID="chk_ClaID" runat="server" CssClass="edilab" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
                            <asp:HiddenField runat="server" ID="hf_ClaID" />
                            <asp:HiddenField runat="server" ID="hf_ClaidName" />
                        </td>
                   
                        <td align="right">课程：</td>
                        <td align="left" >
                            <asp:DropDownList ID="ddl_CID" runat="server" datatype="ddl" errormsg="请选择课程"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                       
                    </tr>
                    <tr>
                         <td align="right">是否发送：</td>
                        <td align="left">

                            <asp:RadioButtonList ID="rbl_IsorNo" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="edilab">
                            </asp:RadioButtonList>
                        </td>
                        <td align="right">完成时间(分钟)：</td>
                        <td>
                            <asp:TextBox ID="txt_CompleteTime" runat="server" datatype="zheng" nullmsg="请输入完成时间"  MaxLength="4" Width="70px"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>  </td>
                    </tr>
                    <tr>
                        <td align="right">作业内容：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_HomeWork" runat="server" CssClass="searchbg" Height="120px" Style="resize: none" Rows="6" TextMode="MultiLine" Width="80%"
                                datatype="*" nullmsg="请填写作业内容"></asp:TextBox>
                            <span style="color: Red; float: none">*</span> </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>



