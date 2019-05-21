<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeachMateriaImport.aspx.cs" Inherits="GKICMP.educational.TeachMateriaImport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../js/Validform_v5.3.2.js" type="text/javascript"></script>
    <script src="../js/editinfor.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            return jQuery("#form1").Validform();
        });
        function succ() {
            var id = document.getElementById("hf_CID").value;
            window.parent.location.href = "TeachMaterialList.aspx?id=" + id;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="listcent pad0">
            <div>
                <table width="100%" cellspacing="0" cellpadding="0" class="listinfo">
                    <tr>
                        <th colspan="4" align="left">章节导入
                        </th>
                    </tr>
                    <tr>
                        <td>模版下载</td>
                        <td><asp:LinkButton ID="LinkButton" Style="color: blue" runat="server"
                                    OnClick="lbtn_example_Click">[章节模版下载]</asp:LinkButton></td>
                    </tr>
                    <tr>
                        <td>章节导入</td>
                        <td>
                            <asp:FileUpload ID="fuimport" onchange="if(this.value)judgeExcel(this.value,this);"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            导入说明：</td>
                        <td>
                            <span style="color: red;">1.导入时年级请填写数字；<br />
                            2.请勿修改所下载的模版，填入相应内容即可；<br />
                            </span></td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" class="editor" id="return" value="返回" onclick='$.close("A_id");' />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>



