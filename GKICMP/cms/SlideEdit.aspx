<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SlideEdit.aspx.cs" Inherits="GKICMP.cms.SlideEdit" %>

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
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_Image" />
        <div class="listcent pad0">
            <table width="100%" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">
                            <asp:Literal runat="server" ID="ltl_SName"></asp:Literal>信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="80px">类别：</td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_SType" datatype="ddl" errormsg="请选择类别"></asp:DropDownList>
                            <span style="color: red;">*</span>
                        </td>
                        <td align="right" width="100px">
                            <asp:Literal runat="server" ID="ltl_Name"></asp:Literal>名称：
                        </td>
                        <td>
                            <asp:TextBox ID="txt_SlideName" datatype="*" nullmsg="请选择类别标识" runat="server">
                            </asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">链接：</td>
                        <td>
                            <asp:TextBox runat="server" ID="txt_SlideUrl" datatype="*" nullmsg="请填写链接"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                        <td align="right">失效日期：
                        </td>
                        <td>
                            <asp:TextBox ID="txt_InvalidDate" datatype="*" nullmsg="请填写失效日期" runat="server" onclick="WdatePicker({skin:'whyGreen' ,startDate:'%y-%M-%d %H:%m:&s',dateFmt:'yyyy-MM-dd HH:mm:ss'})">
                            </asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">图片：</td>
                        <td colspan="3">
                            <div id="divimg">
                                <asp:FileUpload ID="fl_SImage" runat="server" onchange="if(this.value)judgepic(this.value,this);" />
                                <span style="color:red "><asp:Literal runat="server" ID="ltl_Small"></asp:Literal></span>
                            </div>
                            <asp:HiddenField ID="hf_SImage" runat="server" />
                            <asp:Image ID="img_SImage" runat="server" Width="200px" Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
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

