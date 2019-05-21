<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsAudit.aspx.cs" Inherits="GKICMP.cms.NewsAudit" %>

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
        <div class="listcent pad0">
            <table width="100%" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <td align="right" width="90px">审核结果：
                        </td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_AuditState" datatype="ddl" errormsg="请选择审核结果"></asp:DropDownList>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <%-- <tr>
                        <td align="right" width="90px">审核意见：  </td>
                        <td >
                            <asp:TextBox ID="txt_Desc" runat="server" TextMode="MultiLine"  Height="30px" Width="420px"></asp:TextBox>
                        </td>
                    </tr>--%>
                </tbody>

            </table>
            <table width="100%" border="0">
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                         <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                        <%--<asp:Button ID="bt_ok" runat="server" class="editor" Text="返回" OnClick="bt_ok_Click" />--%>
                    </td>
                </tr>
            </table>
        </div>
        <script type="text/javascript">

            //实例化编辑器
            //建议使用工厂方法getEditor创建和引用编辑器实例，如果在某个闭包下引用该编辑器，直接调用UE.getEditor('editor')就能拿到相关的实例
            var ue = UE.getEditor('txt_Content');

        </script>
    </form>
</body>
</html>


