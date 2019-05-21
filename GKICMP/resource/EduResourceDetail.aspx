<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EduResourceDetail.aspx.cs" Inherits="GKICMP.resource.EduResourceDetail" %>

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
    <style type="text/css">
        .auto-style1 {
            height: 49px;
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
                        <td >
                            <asp:Literal ID="ltl_ResourseName" runat="server"></asp:Literal>
                        </td>
                        <td align="right">所属年级：</td>
                        <td>
                             <asp:Literal ID="ltl_GID" runat="server"></asp:Literal> <asp:Literal ID="ltl_TID" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" >学科：
                        </td>
                        <td >
                             <asp:Literal ID="ltl_CID" runat="server"></asp:Literal>
                        </td>
                         <td align="right" >类别：</td>
                        <td>
                             <asp:Literal ID="ltl_EType" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" >下载次数：</td>
                        <td>
                             <asp:Literal ID="ltl_DownLoadNum" runat="server"></asp:Literal>
                        </td>
                        <td align="right">大小：</td>
                        <td>
                             <asp:Literal ID="ltl_RSize" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        
                        <td align="right" >格式：</td>
                        <td>
                             <asp:Literal ID="ltl_RFormat" runat="server"></asp:Literal>
                        </td>
                        <td align="right" >是否精品：</td>
                        <td>
                             <asp:Literal ID="ltl_IsExcellent" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        
                        <td align="right" width="100px">是否对外公开：</td>
                        <td>
                             <asp:Literal ID="ltl_IsOpen" runat="server"></asp:Literal>
                        </td>
                         <td align="right">审核状态：</td>
                        <td>
                             <asp:Literal ID="ltl_AuditState" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr runat="server" id="tr_null">
                       
                        <td align="right" >审核人：</td>
                        <td>
                             <asp:Literal ID="ltl_AuditUser" runat="server"></asp:Literal>
                        </td>
                        <td align="right" >审核时间：</td>
                        <td>
                             <asp:Literal ID="ltl_AuditDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <%--<tr>
                        <td align="right" >资源链接</td>
                        <td colspan="3">
                            <asp:LinkButton ID="lbtn_Sourse"  runat="server" OnClientClick="return DownLoad(this);"  OnClick="lbtn_Sourse_Click"><%=name%></asp:LinkButton>
                            <asp:HiddenField ID="hf_psw"  runat="server" />
                        </td>
                    </tr>--%>



                </tbody>

            </table>
           
        </div>

    </form>
</body>
</html>



