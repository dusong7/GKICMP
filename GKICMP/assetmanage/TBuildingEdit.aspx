<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TBuildingEdit.aspx.cs" Inherits="ICMP.assetmanage.TBuildingEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
        function getfile() {
            var hflogo = $id("hf_SImage");
            var careful = $id("divimg").getElementsByTagName("input");
            hflogo.value = careful.length;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">教学楼信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="90">教学楼名称：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BName" runat="server" datatype="*" nullmsg="请填写教学楼名称" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                        <td align="right" width="90">教学楼代码：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BNumber" runat="server" datatype="*" nullmsg="请填写教学楼代码" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">所属校区：</td>
                        <td align="left">
                            <%--<asp:DropDownList runat="server" ID="ddl_CID" datatype="ddl" errormsg="请选择所属校区"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>--%>
                            <asp:DropDownList runat="server" ID="ddl_CID" ></asp:DropDownList>
                            
                        </td>
         
                        <td align="right">教学楼状态：</td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddl_BState" datatype="ddl" errormsg="请选择教学楼状态"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">总建筑面积：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_AllBuilding" runat="server" CssClass="searchbg" datatype="bigzero" nullmsg="请填写总建筑面积"
                                MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">总使用面积：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_AllUseArea" runat="server" CssClass="searchbg" datatype="bigzero" nullmsg="请填写总使用面积"
                                MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>

                        <td align="right">楼层数：</td>
                        <td>
                            <asp:TextBox ID="txt_FloorNum" runat="server" datatype="zheng" nullmsg="请填写楼层数" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">排序：</td>
                        <td>
                            <asp:TextBox ID="txt_BOrder" runat="server" datatype="zheng" nullmsg="请填写排序" MaxLength="100" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">教学楼地址：</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_BAddress" runat="server" Width="300px" datatype="*" nullmsg="请填写教学楼地址" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">教学楼图片：</td>
                        <td colspan="3">
                            <asp:Image ID="img_SImage" runat="server" width="200px" Height="80px"/>
                            <div id="divimg">
                                <asp:FileUpload ID="fl_SImage" runat="server" onchange="if(this.value)judgepic(this.value,this);" />
                            </div>
                            <asp:HiddenField ID="hf_SImage" runat="server" />

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
