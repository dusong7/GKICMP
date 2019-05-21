<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysSetConfig.aspx.cs" Inherits="GKICMP.filemanage.SysSetConfig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>

    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btn_Add').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'AssetBorrowEdit.aspx', '', 840, 560, -1);
            });
        });

        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'AssetBorrowEdit.aspx', 'id=' + id, 840, 560, 0);
        }

        function viewinfo(e) {
            var flag = document.getElementById("hf_Flag").value;
            var id = $(e).next().val();
            return openbox('A_id', 'AssetBorrowDetail.aspx', 'id=' + id + '&flag=' + flag, 900, 460, 4);
        }

    </script>
    <style>
        .edilab label {
            float: none;
        }

        .edilab input {
            height: 13px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField runat="server" ID="hf_Flag" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="水印设置"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="2" align="left">文件水印设置</th>
                    </tr>
                    <tr>
                        <td align="right" width="150">水印类型：</td>
                        <td align="left">
                            <asp:RadioButtonList ID="rbtn_WaterType" runat="server" RepeatDirection="Horizontal" CssClass="edilab" RepeatLayout="Flow" AutoPostBack="true" OnSelectedIndexChanged="rbtn_WaterType_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="1">文字</asp:ListItem>
                                <asp:ListItem Value="2">图片</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">内容：</td>
                        <td align="left">
                            <div id="txt" runat="server">
                                <asp:TextBox ID="txt_LanIP" runat="server" datatype="*1-100" nullmsg="请填写文字"></asp:TextBox>
                                <span style="color: Red">*</span>
                            </div>
                            <asp:Image ID="Image1" runat="server" Width="200px" Visible="false" />
                            <div id="more" runat="server">
                                <asp:FileUpload ID="fl_UpFile" runat="server" onchange="if(this.value)judgepic(this.value,this);" />
                                <span style="color: Red">*</span>
                            </div>
                            <asp:HiddenField ID="hf_UpFile" runat="server" />
                        </td>
                    </tr>


                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' /></td>
                    </tr>
                </tbody>
            </table>
        </div>

    </form>
</body>
</html>
