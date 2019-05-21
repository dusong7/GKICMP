<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherRetire.aspx.cs" Inherits="GKICMP.teachermanage.TeacherRetire" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   <%--  <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />--%>
    <link href="../css/green_formcss.css" rel="stylesheet" />

    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
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
                        <th colspan="4" align="left"><asp:Literal runat="server" ID="ltl_Message"></asp:Literal></th>
                    </tr>
                    <tr>
                        <td align="right" width="110"><asp:Literal runat="server" ID="ltl_Message1"></asp:Literal>时间</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txt_OutDate" datatype="*" nullmsg="请选择日期" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox><span style="color: red; float: none; padding-left: 5px">*</span>
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
