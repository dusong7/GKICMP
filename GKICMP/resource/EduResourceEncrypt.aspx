<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EduResourceEncrypt.aspx.cs" Inherits="GKICMP.resource.EduResourceEncrypt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>

    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <title>智慧校园门户管理平台</title>
    <script type="text/javascript">

        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });


        function getfile() {
            var hfatta = $id("hf_UpFile");
            var careful = $id("more").getElementsByTagName("input");
            hfatta.value = careful.length;
        }
    </script>
    <style>
        .pz .select_box {
            display: none;
        }

        .listinfo label {
            float: none;
        }
        .auto-style1 {
            height: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_imageurl" runat="server" />
        <asp:HiddenField ID="hf_DataType" runat="server" />
        <asp:HiddenField ID="hf_CID" runat="server" />
        <asp:HiddenField ID="hf_SID" runat="server" />
        <div class="listcent pad0">
            <table width="100%" cellspacing="0" cellpadding="0" class="listinfo">
                
                <tbody>
                    <tr>
                        <th colspan="2" align="left">资源加密</th>
                    </tr>
                    <tr>
                        <td align="right" width="90px">资源密码：
                        </td>
                        <td>
                            <asp:TextBox ID="txt_ERPwd"  CssClass="searchbg" datatype="*1-100" nullmsg="请填写资源密码" runat="server"></asp:TextBox>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                  
                </tbody>

            </table>
            <table width="100%" border="0">
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        <%--<asp:Button ID="bt_ok" runat="server" class="editor" Text="返回" OnClick="bt_ok_Click" />--%>
                        <input type="button" name="button" id="cancell" value="返回" class="editor" onclick=' $.close("A_id");' />
                    </td>
                </tr>
            </table>
        </div>

    </form>
</body>
</html>



