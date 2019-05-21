<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherDetail.aspx.cs" Inherits="GKICMP.teachermanage.TeacherDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">基本信息
                        </th>
                    </tr>
                    <tr>
                        <td align="right" width="150px">姓名</td>
                        <td align="left">
                            <asp:Literal ID="ltl_RealName" runat="server"></asp:Literal>
                        </td>
                        <td align="right">曾用名</td>
                        <td align="left">
                            <asp:Literal ID="ltl_OldName" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">性别</td>
                        <td align="left">
                            <asp:Literal ID="ltl_TSex" runat="server"></asp:Literal>
                        </td>
                        <td align="right">教职工号</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_TeacherCode"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">身份证件类型</td>
                        <td align="left">
                            <asp:Literal ID="ltl_CardType" runat="server"></asp:Literal>
                        </td>
                        <td align="right">身份证件号</td>
                        <td align="left">
                            <asp:Literal ID="ltl_IDCardNum" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">国籍/地区</td>
                        <td align="left">
                            <asp:Literal ID="ltl_Nationality" runat="server"></asp:Literal>
                        </td>
                        <td align="right">籍贯</td>
                        <td align="left">
                            <asp:Literal ID="ltl_PlaceOrigin" runat="server"></asp:Literal>
                        </td>

                    </tr>
                    <tr>
                        <td align="right">出生地</td>
                        <td align="left">
                            <asp:Literal ID="ltl_OneNative" runat="server"></asp:Literal>
                        </td>
                        <td align="right">出生日期</td>
                        <td align="left">
                            <asp:Literal ID="ltl_Birthday" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">民族</td>
                        <td align="left">
                            <asp:Literal ID="ltl_TNation" runat="server"></asp:Literal>
                        </td>
                        <td align="right">政治面貌</td>
                        <td align="left">
                            <asp:Literal ID="ltl_Politics" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">婚姻状态</td>
                        <td align="left">
                            <asp:Literal ID="ltl_MaritalStatus" runat="server"></asp:Literal>
                        </td>
                        <td align="right">健康状况</td>
                        <td align="left">
                            <asp:Literal ID="ltl_HealthStatus" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">入党时间</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_PartyTme" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="4" align="left">教师资格证信息
                        </th>
                    </tr>
                    <tr>
                        <td align="right">教师资格种类：</td>
                        <td colspan="3">
                            <asp:Literal runat="server" ID="ltl_TeaQualiType"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">资格证编号：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_TeaQualCode"></asp:Literal>
                        </td>
                        <td align="right">任教学科：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_TeaQualCourse"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style2">证书颁发日期：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_TeaQualDate"></asp:Literal>
                        </td>
                        <td align="right">首次注册日期：</td>
                        <td colspan="3">
                            <asp:Literal runat="server" ID="ltl_TeaQualRegDate"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="4" align="left">教师信息</th>
                    </tr>
                    <tr>
                        <td align="right">参加工作年月</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_JodDate"></asp:Literal>
                        </td>
                        <td align="right">进本校年月</td>
                        <td align="left">
                            <asp:Literal ID="ltl_JoinSchool" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">教职工来源</td>
                        <td align="left">
                            <asp:Literal ID="ltl_TeaSource" runat="server"></asp:Literal>
                        </td>
                        <td align="right">教职工类别</td>
                        <td align="left">
                            <asp:Literal ID="ltl_TeaType" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">签订合同情况</td>
                        <td align="left">
                            <asp:Literal ID="ltl_ContractState" runat="server"></asp:Literal>
                        </td>
                        <td align="right">用人形式</td>
                        <td align="left">
                            <asp:Literal ID="ltl_EmploymentType" runat="server"></asp:Literal>
                        </td>
                    </tr>
                     <tr>
                        <td align="right">人员状态</td>
                        <td align="left">
                            <asp:Literal ID="ltl_TeaState" runat="server"></asp:Literal>
                        </td>
                        <td align="right">职务角色</td>
                        <td align="left">
                            <asp:Literal ID="ltl_PostRoleName" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr><td align="right">是否在编</td>
                        <td align="left">
                            <asp:Literal ID="ltl_IsSeries" runat="server"></asp:Literal>
                        </td>
                          <td align="right">是否教学岗：</td>
                    <td>
                        <asp:Literal ID="ltl_IsTea" runat="server"></asp:Literal>
                    </td>
                    </tr>
                    <tr>
                        <td align="right">专业技术岗位等级分类</td>
                        <td align="left">
                            <asp:Literal ID="ltl_GradeType" runat="server"></asp:Literal>
                        </td>
                        <td align="right">专业技术岗位等级</td>
                        <td align="left">
                            <asp:Literal ID="ltl_ProfessGrade" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                       
                        <td align="right">专业技术职称</td>
                        <td align="left">
                            <asp:Literal ID="ltl_CurrentProfessional" runat="server"></asp:Literal>
                        </td>
                        <td align="right">职称聘用时间：</td>
                    <td align="left">
                        <asp:Literal ID="ltl_GradeDate" runat="server"></asp:Literal>
                    </td>
                    </tr>
                    
                    <tr>
                         <td align="right">薪级</td>
                        <td align="left">
                            <asp:Literal ID="ltl_SalaryGrade" runat="server"></asp:Literal>
                        </td>
                        <td align="right" class="auto-style3">普通话水平：</td>
                    <td align="left" class="auto-style1">
                        <asp:Literal ID="ltl_Mandarin" runat="server"></asp:Literal>
                    </td>
                    </tr>
                    <tr>
                        <td align="right">是否是特级教师</td>
                        <td align="left">
                            <asp:Literal ID="ltl_IsSpecialTea" runat="server"></asp:Literal>
                        </td>
                        <td align="right">是否县级及以上骨干教师</td>
                        <td align="left">
                            <asp:Literal ID="ltl_IsCountyLevel" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    
                    <tr> 
                         <td align="right">信息技术应用能力</td>
                        <td align="left">
                            <asp:Literal ID="ltl_InformationLevel" runat="server"></asp:Literal>
                        </td>
                        <td align="right">是否全日制师范类专业毕业</td>
                        <td align="left">
                            <asp:Literal ID="ltl_IsFulltime" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">是否受过特教专业培训</td>
                        <td align="left">
                            <asp:Literal ID="ltl_IsSpecialTrain" runat="server"></asp:Literal>
                        </td>
                        <td align="right">是否有特殊教育从业证书</td>
                        <td>
                            <asp:Literal ID="ltl_IsSpecialEdu" runat="server"></asp:Literal>
                        </td>
                    </tr>

                    <tr>
                        <td align="right">是否属于免费(公费)师范生</td>
                        <td align="left">
                            <asp:Literal ID="ltl_IsTeaStu" runat="server"></asp:Literal>
                        </td>

                        <td align="right">是否参加基层服务项目</td>
                        <td align="left">
                            <asp:Literal ID="ltl_IsGrassService" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">参加基层服务项目起始年月</td>
                        <td align="left">
                            <asp:Literal ID="ltl_GrassStartDate" runat="server"></asp:Literal>
                        </td>
                        <td align="right">参加基层服务项目结束年月</td>
                        <td align="left">
                            <asp:Literal ID="ltl_GrassEndDate" runat="server"></asp:Literal>
                        </td>
                    </tr>

                    <tr>
                        <td align="right">是否心理健康教育教师</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_IsHealthTeahcer" runat="server"></asp:Literal>
                        </td>
                       
                    </tr>
                   
                    <tr>
                        <td colspan="4" align="center">
                            <input type="button" name="button" id="cancell" value="返回" class="editor" onclick='javascript: window.location.href = "TeacherManage.aspx";' /></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
