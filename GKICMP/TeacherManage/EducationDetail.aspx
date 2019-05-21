<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EducationDetail.aspx.cs" Inherits="GKICMP.teachermanage.EducationDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/ImgPreview.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
</head>
<body>
    <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">学历基本信息
                        </th>
                    </tr>
                     <tr>
                        <td align="right" >教师</td>
                        <td align="left">
                            <asp:Literal ID="ltl_RealName" runat="server"></asp:Literal>
                        </td>
                        <td align="right" >性别</td>
                        <td align="left">
                            <asp:Literal ID="ltl_TSex" runat="server"></asp:Literal>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" >获得学历</td>
                        <td align="left">
                            <asp:Literal ID="ltl_Education" runat="server"></asp:Literal>
                        </td>
                        <td align="right" >获得学历的国家(地区)</td>
                        <td align="left">
                            <asp:Literal ID="ltl_EduCountry" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" >获得学历的院校或机构</td>
                        <td align="left">
                            <asp:Literal ID="ltl_EduSchool" runat="server"></asp:Literal>
                        </td>
                        <td align="right">所学专业</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_EMajor"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" >入学年月</td>
                        <td align="left">
                            <asp:Literal ID="ltl_InDate" runat="server"></asp:Literal>
                        </td>
                        <td align="right">毕业年月</td>
                        <td align="left">
                            <asp:Literal ID="ltl_OutDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                         <td align="right" >学位层次</td>
                        <td align="left">
                            <asp:Literal ID="ltl_DegreeLevel" runat="server"></asp:Literal>
                        </td>
                        <td align="right">学位名称</td>
                        <td align="left">
                            <asp:Literal ID="ltl_DegreeName" runat="server"></asp:Literal>
                        </td>
                        
                    </tr>
                    <tr>
                        <td align="right" >获得学位的国家(地区)</td>
                        <td align="left">
                            <asp:Literal ID="ltl_GradeCountry" runat="server"></asp:Literal>
                        </td>
                        <td align="right">获得学位的院校或机构</td>
                        <td align="left">
                            <asp:Literal ID="ltl_GradeSchool" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" >学位授予年月</td>
                        <td align="left">
                            <asp:Literal ID="ltl_GrantDate" runat="server"></asp:Literal>
                        </td>
                        <td align="right">学习方式</td>
                        <td align="left">
                            <asp:Literal ID="ltl_StudyType" runat="server"></asp:Literal>
                        </td>
                    </tr>
                     
                     <tr>
                         <td align="right" >在学单位类别</td>
                        <td align="left">
                            <asp:Literal ID="ltl_CompanyType" runat="server"></asp:Literal>
                        </td>
                         <td align="right">是否师范类专业</td>
                        <td align="left">
                            <asp:Literal ID="ltl_IsTeach" runat="server"></asp:Literal>
                        </td>
                    </tr>

                </tbody>
            </table>
        </div>
</body>
</html>
