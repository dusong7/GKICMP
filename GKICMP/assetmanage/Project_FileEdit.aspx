<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Project_FileEdit.aspx.cs" Inherits="GKICMP.assetmanage.Project_FileEdit" %>

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
        jQuery(document).ready(function ()
        {
            jQuery("#form1").Validform();
        });
        function getfile() {
            var hfface = $id("hf_UpFile");
            var divone = $id("more").getElementsByTagName("input");
            hfface.value = divone.length;
        }
 </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_CssFlag" runat="server" />
        <asp:HiddenField ID="hf_IDCard" runat="server" />
        <asp:HiddenField ID="hf_Images" runat="server" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo1">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">项目文件信息</th>
                    </tr>
                    <tr>
                        <td align="right">项目名称</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_ProName" datatype="ddl" errormsg="请选择项目名称"></asp:DropDownList>
                            <span style="color: red;">*</span>
                        </td>
                        <td align="right">文件类型</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_ProStage" datatype="ddl" errormsg="请选择文件类型"></asp:DropDownList>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">附件：   </td>
                        <td colspan="3">
                            <table>
                                    <asp:Repeater ID="rp_File" runat="server" OnItemCommand="rpaccess_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <%--<img width="40" height="40" src='<%#Eval("tcfile") %>' />--%>
                                                     <asp:ImageButton ID="ibtn_del" runat="server" ImageUrl="~/images/sq.png" CommandArgument='<%#Eval("tcfile") %>'
                                                        CommandName="del" OnClientClick='<%#"return delmessage(\"【"+Eval("tcfile")+"】\")" %>' />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                           
                            <div id="more">
                                <asp:FileUpload ID="fl_UpFile" runat="server" onchange="if(this.value)judge(this.value,this);" />
                               <%-- <img src="../images/addfile.gif" alt="" style='cursor: pointer; margin-bottom: -3px'
                                    onclick="addfile('more')" />--%>
                            </div>
                            <asp:HiddenField ID="hf_UpFile" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="4">
                           <asp:Button ID="btn_Sumbit" runat="server" Text="提交"  CssClass="submit" OnClick="btn_Sumbit_Click" OnClientClick="getfile()" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
