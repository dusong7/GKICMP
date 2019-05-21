<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendRecordImport.aspx.cs" Inherits="GKICMP.teachermanage.AttendRecordImport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
  <link href="../css/green_formcss.css" rel="stylesheet" />
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

        <div class="listcent pad0">
            <div>
                <table width="100%" cellspacing="0" cellpadding="0" class="listinfo1">
                    <tr>
                        <th colspan="4" align="left">考勤记录导入
                        </th>
                    </tr>
                    <tr>
                        <td align="right">记录信息：</td>
                        <td>
                            <asp:FileUpload ID="fuimport" onchange="if(this.value)judge(this.value,this);"
                                runat="server" />&nbsp;&nbsp;<asp:LinkButton ID="lbtn_example" Style="color: blue" runat="server"
                                    OnClick="lbtn_example_Click">[模板下载]</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td  align="right">
                            导入说明：</td>
                        <td>
                            <span style="color: red;">1.请先下载导入模板并严格按照导入模板录入数据进行导入；<br />
                            2.考勤时间不能为空； </span></td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>

