<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherPaperDetail.aspx.cs" Inherits="GKICMP.teachermanage.TeacherPaperDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <script src="../js/jquery-3.1.1.min.js"></script>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
   
        
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">论文信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">姓名：</td>
                        <td align="left" colspan="3">
                             <asp:Literal ID="ltl_TeacherName" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">论文名称：</td>
                        <td colspan="3">
                             <asp:Literal ID="ltl_PaperName" runat="server"></asp:Literal>
                    </tr>
                    <tr>
                        <td align="right" width="120">发表刊物名称：</td>
                        <td align="left" colspan="3">
                             <asp:Literal ID="ltl_Publication" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">发表年月：</td>
                        <td align="left" >
                             <asp:Literal ID="ltl_PubDate" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="120">卷号：</td>
                        <td align="left">
                             <asp:Literal ID="ltl_Volume" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">期号：</td>
                        <td align="left" >
                             <asp:Literal ID="ltl_TermNum" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="120">起始页码：</td>
                        <td align="left">
                             <asp:Literal ID="ltl_BeginPage" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">结束页码：</td>
                        <td align="left" >
                             <asp:Literal ID="ltl_EndPage" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="120">本人角色：</td>
                        <td align="left">
                             <asp:Literal ID="ltl_URoles" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">学科领域：</td>
                        <td align="left" >
                             <asp:Literal ID="ltl_SubjectArea" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="120">论文收录情况：</td>
                        <td align="left">
                             <asp:Literal ID="ltl_Included" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>



