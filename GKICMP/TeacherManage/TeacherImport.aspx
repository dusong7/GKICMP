<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherImport.aspx.cs" Inherits="GKICMP.teachermanage.TeacherImport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>智慧校园基础管理平台</title>
    <%-- <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />--%>
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
                <table width="100%" cellspacing="0" cellpadding="0" class="listinfo">
                    <tr>
                        <th colspan="4" align="left">教师信息导入
                        </th>
                    </tr>
                    <tr>
                        <td align="right">教师信息：</td>
                        <td>
                            <asp:FileUpload ID="fuimport" onchange="if(this.value)judgexls(this.value,this);"
                                runat="server" />&nbsp;&nbsp;<asp:LinkButton ID="lbtn_example" Style="color: blue" runat="server"
                                    OnClick="lbtn_example_Click">[模板下载]</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">导入说明：</td>
                            
                        <td>
                            <span style="color: red;">
                            1.请先下载课时导入模板并按照模板录入数据,<br />
                            2.导入数据时，为避免出错，请先用格式刷格式化数据<br />
                            3.Excel中若有下拉框,请严格按照下拉框数据选取，切勿修改模版,<br />
                            4.如未导入成功，请根据提示修改,<br /> 
                            5.如有问题，请联系QQ:993473161
                            </span>
                        </td>
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

