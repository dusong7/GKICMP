<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherWorkExperienceDetail.aspx.cs" Inherits="GKICMP.teachermanage.TeacherWorkExperienceDetail" %>

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
                        <th colspan="4" align="left">工作信息
                        </th>
                    </tr>
                     <tr>
                        <td align="right" >教师</td>
                        <td align="left">
                            <asp:Literal ID="ltl_RealName" runat="server"></asp:Literal>
                        </td>
                        <td align="right" >身份证</td>
                        <td align="left">
                            <asp:Literal ID="ltl_IDCardNum" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" >性别</td>
                        <td align="left">
                            <asp:Literal ID="ltl_TSex" runat="server"></asp:Literal>
                        </td>
                        <td align="right" >单位性质类别</td>
                        <td align="left">
                            <asp:Literal ID="ltl_TType" runat="server"></asp:Literal>
                        </td>
                       
                    </tr>
                    <tr>
                        <td align="right" >任职单位名称</td>
                        <td align="left">
                            <asp:Literal ID="ltl_TrainAddress" runat="server"></asp:Literal>
                        </td>
                        <td align="right" >任职岗位</td>
                        <td align="left">
                            <asp:Literal ID="ltl_TrainContent" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" >任职开始年月</td>
                        <td align="left">
                            <asp:Literal ID="ltl_TStartDate" runat="server"></asp:Literal>
                        </td>
                        <td align="right">任职结束年月</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_TEndDate"></asp:Literal>
                        </td>
                    </tr>
                    
                   
                  

                </tbody>
            </table>
        </div>
</body>
</html>
