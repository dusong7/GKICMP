<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherClassHourImport.aspx.cs" Inherits="GKICMP.teachermanage.TeacherClassHourImport" %>

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
                        <th colspan="4" align="left">教师课时导入
                        </th>
                    </tr>
                    <tr>
                        <td align="right">课时信息：</td>
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
                            1.请先下载课时导入模板并按照模板录入数据<br />
                            2.纯课时数请填写正整数,避免导入失败,<br />
                            3.所授年级,主教学科,兼教学科在下拉框选择数据 
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
