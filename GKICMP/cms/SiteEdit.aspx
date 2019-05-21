<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteEdit.aspx.cs" Inherits="GKICMP.cms.SiteEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
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
        function getfile() {
            var hflogo = $id("hf_Logo");
            var careful = $id("divlogo").getElementsByTagName("input");
            hflogo.value = careful.length;

            var hficon = $id("hf_UpFile");
            var icons = $id("divicon").getElementsByTagName("input");
            hficon.value = icons.length;

            var isPhone = /^([0-9]{3,4}-)?[0-9]{7,8}$/;
            var value = document.getElementById("txt_TellPhone").value.trim();
            var cz = document.getElementById("txt_Fax").value.trim();
            if (isPhone.test(value)) {
                //if (isPhone.test(cz)) {
                //    return true;
                //}
                //else {
                //    alert("请输入正确的传真号");
                //    return false;
                //}
            }
            else {
                alert("请输入正确的联系电话");
                return false;
            }

        }
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 39px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_Flag" runat="server" />
        <div class="listcent pad0">
            <table width="100%" cellspacing="0" cellpadding="0" class="listinfo1">
                <tr>
                    <th colspan="4" align="left">站点信息 </th>
                </tr>
                <tr>
                    <td align="right" width="80px">单位名称：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txt_CompanyName" runat="server" datatype="*1-100"
                            nullmsg="请填写单位名称" CssClass="searchbg" Width="260"></asp:TextBox>
                        <span style="color: Red">*</span>
                    </td>
                    <td align="right" width="80px">网站标题：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_WebTtitle" runat="server" datatype="*1-100"
                            nullmsg="请填写网站标题" CssClass="searchbg" Width="260"></asp:TextBox>
                        <span style="color: Red">*</span></td>
                </tr>
                <tr>
                    <td align="right" class="auto-style1">附加标题：</td>
                    <td align="left" class="auto-style1">
                        <asp:TextBox ID="txt_AttachTtile" runat="server" CssClass="searchbg" Width="260"></asp:TextBox></td>
                    <td align="right" class="auto-style1">网址：</td>
                    <td align="left" class="auto-style1">
                        <asp:TextBox ID="txt_DWebsite" runat="server" CssClass="searchbg" Width="260"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">联系人：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_LinkUser" runat="server" CssClass="searchbg" Width="260"></asp:TextBox></td>
                    <td align="right">联系电话：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_TellPhone" runat="server" CssClass="searchbg" Width="260"></asp:TextBox>
                        <span style="color: Red">*</span></td>
                </tr>
                <tr>
                    <td align="right">手机号码：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_CellPhone" runat="server" CssClass="searchbg" Width="260" datatype="m"></asp:TextBox>
                        <span style="color: Red">*</span></td>
                    <td align="right">传真：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_Fax" runat="server" CssClass="searchbg" Width="260"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">邮箱：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_EmailCode" runat="server" CssClass="searchbg" Width="260" datatype="e"></asp:TextBox>
                        <span style="color: Red">*</span></td>
                    <td align="right">邮编：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_PostCode" runat="server" CssClass="searchbg" Width="260" datatype="p">
                        </asp:TextBox><span style="color: Red">*</span></td>
                </tr>
                <tr>
                    <td align="right">备案号：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_RecordCode" runat="server" CssClass="searchbg" Width="260"></asp:TextBox></td>
                    <td align="right">地址：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_Address" runat="server" CssClass="searchbg" Width="260"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">统计代码：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_TotelCode" runat="server" CssClass="searchbg" Width="260"></asp:TextBox></td>
                    <td align="right">版权信息：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_Copyright" runat="server" CssClass="searchbg" Width="260"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">站点关键字：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_SiteKey" runat="server" CssClass="searchbg" Width="260"></asp:TextBox></td>
                     <td align="right">站点路径：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_SitePath" runat="server" CssClass="searchbg" Width="260"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">站点描述</td>
                    <td colspan="3">
                        <asp:TextBox ID="txt_SiteDesc" runat="server" TextMode="MultiLine" Rows="6" Height="100px" Width="60%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">Logo：</td>
                    <td colspan="3">
                        <asp:Image ID="img_Logo" runat="server" Width="300px" ImageUrl="images/detail.png" />
                        <div id="divlogo">
                            <asp:FileUpload ID="fl_Logo" runat="server" onchange="if(this.value)judgepic(this.value,this);" />
                        </div>
                        <asp:HiddenField ID="hf_Logo" runat="server" />

                    </td>
                </tr>
                <tr>
                    <td align="right">ICON：</td>
                    <td colspan="3">
                        <asp:Image ID="img_Icon" runat="server" Width="300px" ImageUrl="images/detail.png" />
                        <div id="divicon">
                            <asp:FileUpload ID="fl_UpFile" runat="server" onchange="if(this.value)judgepic(this.value,this);" />
                        </div>
                        <asp:HiddenField ID="hf_UpFile" runat="server" />
                    </td>
                </tr>
            </table>
            <table width="100%" border="0">
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" OnClientClick="return getfile()" />
                        <%--<asp:Button runat="server" ID="btn_Cancel" Text="取消" class="editor" OnClick="btn_Cancel_Click" />--%>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
