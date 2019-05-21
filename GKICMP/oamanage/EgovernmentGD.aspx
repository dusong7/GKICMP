<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EgovernmentGD.aspx.cs" Inherits="GKICMP.oamanage.EgovernmentGD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/ImgPreview.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">
                            公文归档分类信息
                        </th>
                    </tr>
                    <tr>
                        <td align="right" width="120">
                            归档分类</td>
                        <td align="left">
                            <%--<asp:TextBox ID="txt_DataDesc" runat="server" datatype="*1-50" nullmsg="请填写资产编号" CssClass="searchbg"
                                MaxLength="50"></asp:TextBox>--%>
                            <asp:DropDownList runat="server" ID="ddl_Etype" datatype="ddl" errormsg="请选择分类">
                            </asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
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


