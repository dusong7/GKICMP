<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScrapEdit.aspx.cs" Inherits="ICMP.assetmanage.ScrapEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/ImgPreview.js"></script>
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
        <asp:HiddenField ID="hf_face" runat="server" Value="" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left"><asp:Label ID="lbl_PMen" runat="server"></asp:Label></th>
                    </tr>
                    <tr>
                        <td align="right" width="120">资产名称</td>
                        <td align="left">
                            <asp:TextBox ID="txt_Name" runat="server"  CssClass="searchbg" Enabled="false"
                                MaxLength="50"></asp:TextBox>
                        </td>
                       <td align="right" width="120">资产数量</td>
                        <td align="left">
                            <asp:TextBox ID="txt_Num" runat="server"  CssClass="searchbg" Enabled="false"
                                MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" width="120">报废数量</td>
                        <td align="left">
                            <asp:TextBox ID="txt_ASNum" runat="server" datatype="zheng" nullmsg="请填写数量" CssClass="searchbg"
                                MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">报废时间</td>
                        <td align="left">
                            <asp:TextBox ID="txt_ASDate" runat="server" Style="width: 85px" datatype="*" nullmsg="请选择时间" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>

                     <tr>
                        <td align="right" valign="top" class="note">报废说明</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_ASMark" TextMode="MultiLine" runat="server" MaxLength="100"
                                Rows="6" Width="70%" Height="100px" CssClass="MultiLinebg"></asp:TextBox></td>
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
