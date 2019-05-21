<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EduResourseEdit.aspx.cs" Inherits="GKICMP.resource.EduResourseEdit" %>

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
                        <td align="right" width="90px">资源名称：
                        </td>
                        <td>
                            <asp:TextBox ID="txt_ResourseName" Width="80%" CssClass="searchbg" datatype="*1-100" nullmsg="请填写资源名称" runat="server"></asp:TextBox>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">所属年级：</td>
                        <td>
                            <asp:DropDownList ID="ddl_GID" CssClass="searchbg" datatype="ddl" errormsg="请选择年级" runat="server"></asp:DropDownList>
                            <asp:DropDownList ID="ddl_TID" CssClass="searchbg" datatype="ddl" errormsg="请选择学期" runat="server"></asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="60px">学科：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_CID" CssClass="searchbg" datatype="ddl" errormsg="请选择学科" runat="server"></asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="60px">类别：</td>
                        <td>
                            <asp:DropDownList ID="ddl_EType" CssClass="searchbg" runat="server">
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="70px" class="auto-style1">下载次数：</td>
                        <td class="auto-style1">
                            <asp:TextBox ID="txt_DownLoadNum" runat="server"  Width="130px" CssClass="searchbg" datatype="zhengnum"  Enabled="false" ></asp:TextBox>
                        </td>

                    </tr>

                    <tr>
                        <td align="right" width="50px">附件：</td>
                        <td>
                            <div id="more">
                                <a href='<%=Url %>'><%=Name %> </a><br />
                                <asp:FileUpload ID="fl_UpFile" runat="server"  />
                                
                            </div>
                            <asp:HiddenField ID="hf_UpFile" runat="server" />
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


