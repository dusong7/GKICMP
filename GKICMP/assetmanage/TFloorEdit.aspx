<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TFloorEdit.aspx.cs" Inherits="ICMP.assetmanage.TFloorEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
  <%-- <link href="../css/green_list.css" rel="stylesheet" />--%>
    <%-- <link href="../css/green_asyncbox.css" rel="stylesheet" />--%>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
        function succ() {
            window.parent.location.href = "TFloorManage.aspx";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_PID" runat="server" />
        <asp:HiddenField ID="hf_ID" runat="server" />
         <asp:HiddenField ID="hf_flag" runat="server" Value="2" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="2" align="left">楼层信息
                        </th>
                    </tr>
                    <tr>
                        <td align="right">楼层名称</td>
                        <td align="left">
                            <asp:TextBox ID="txt_FloorName" runat="server" datatype="*1-100"
                                nullmsg="请填写楼层名称" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">楼层代码 </td>
                        <td align="left">
                            <asp:TextBox ID="txt_FNumber" runat="server" datatype="*1-100"
                                nullmsg="请填写楼层代码 " Width="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">排序 </td>
                        <td align="left">
                            <asp:TextBox ID="txt_FOrder" runat="server" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0">
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        <asp:Button ID="btn_Deleted" runat="server" Text="删除" CssClass="deletebtn" OnClick="btn_Delete_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

