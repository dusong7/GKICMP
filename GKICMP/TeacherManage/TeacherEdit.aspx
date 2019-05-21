<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherEdit.aspx.cs" Inherits="GKICMP.teachermanage.TeacherEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />

    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>

    <style>
        .edilab label {
            float: none;
        }

        .edilab input {
            height: 13px;
        }

        .auto-style1 {
            height: 40px;
        }
        .auto-style2 {
            width: 170px;
        }
        .auto-style3 {
            height: 40px;
            width: 170px;
        }
        body{
            padding: 0px 20px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_TID" runat="server" Value="" />
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_PostRole" runat="server" />
        <asp:HiddenField ID="hf_PostRoleName" runat="server" />
        <asp:HiddenField ID="hf_SelectedValue" runat="server" />
        <asp:Literal ID="ltl_ggjb" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_PostRole" runat="server"></asp:Literal>
        <div class="positionc" id="div_top" runat="server" visible="false">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text="教师档案"></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="我的档案"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo1">
            <tbody>
                <tr>
                    <th colspan="7" align="left" style="padding-left: 15px">
                        <div class="xxsm">
                            <ul>
                                <%--<li class="selected"><a href="TeacherEdit.aspx?TID=<%=TID %>">基本信息</a></li>--%>
                                <li class="selected"><a href="TeacherEdit.aspx?id=<%=TID%>&flag=<%=Flag%>">基本信息</a></li>
                                <li><a href="TeacherEducationEdit.aspx?tid=<%=TID%>&flag=<%=Flag%>">学习经历</a></li>
                                <li><a href="TeacherWorkExperienceEditManage.aspx?tid=<%=TID%>&flag=<%=Flag%>">工作经历</a></li>
                            </ul>
                        </div>
                    </th>
                </tr>
              </tbody>
            </table>

          <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo1">
                <tbody>
                <tr>
                    <td align="right" class="auto-style2">姓名：</td>
                    <td align="left">
                        <asp:Literal runat="server" ID="ltl_RealName"></asp:Literal></td>
                    <td align="right" width="170px">曾用名：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_OldName" runat="server"></asp:TextBox>
                    </td>
                    <td align="right" width="170px">职务角色：</td>
                    <td align="ledt" colspan="3">
                        <input id="PostRole" name="PostRole" style="width: 90%; height: 40px" class="easyui-combotree" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style2">教职工号：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_TeacherCode" runat="server" datatype="*" nullmsg="请填写教职工号"></asp:TextBox>
                        <span style="color: Red; float: none">*</span>
                    </td>
                    <td align="right">性别：</td>
                    <td align="left">
                        <asp:DropDownList runat="server" ID="ddl_TSex" datatype="ddl" errormsg="请选择性别"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>
                    </td>

                     <td align="right" class="auto-style2">民族：</td>
                    <td align="left">
                        <asp:DropDownList ID="ddl_TNation" runat="server" datatype="ddl" errormsg="请选择民族"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>
                    </td>


                   
                </tr>
                <tr>
                    <td align="right" class="auto-style3">国籍/地区：</td>
                    <td align="left" class="auto-style1">
                        <asp:TextBox ID="txt_Nationality" runat="server" datatype="*" nullmsg="请填写国籍/地区"></asp:TextBox>
                        <span style="color: Red; float: none">*</span>
                    </td>

                     <td align="right">籍贯：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_PlaceOrigin" runat="server"></asp:TextBox>
                       <%-- <span style="color: Red; float: none">*</span>--%>
                    </td>
                    <td align="right">出生地：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_OneNative" runat="server" ></asp:TextBox>
                        <%--<span style="color: Red; float: none">*</span>--%>
                    </td>

                    
                </tr>
                <tr>
                    <td align="right" class="auto-style1">身份证件类型：</td>
                    <td align="left" class="auto-style1">
                        <asp:DropDownList runat="server" ID="ddl_CardType" datatype="ddl" errormsg="请选择身份证件类型"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>
                    </td>
                    <td align="right" class="auto-style1">身份证件号：</td>
                    <td align="left" class="auto-style1">
                        <asp:TextBox ID="txt_IDCardNum" runat="server" datatype="*" nullmsg="请填写身份证件号"></asp:TextBox>
                        <span style="color: Red; float: none">*</span>
                    </td>
                    <td align="right" class="auto-style2">出生日期：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_Birthday" runat="server" datatype="*" nullmsg="请选择出生日期" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        <span style="color: Red; float: none">*</span>
                    </td>
                   
                </tr>
                <tr>
                   <td align="right">婚姻状态：</td>
                    <td align="left">
                        <asp:DropDownList ID="ddl_MaritalStatus" runat="server" datatype="ddl" errormsg="请选择婚姻状态"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>
                    </td>
                    <td align="right">政治面貌：</td>
                    <td align="left">
                        <asp:DropDownList ID="ddl_Politics" runat="server" datatype="ddl" errormsg="请选择政治面貌"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>
                    </td>
                     <td align="right">入党时间</td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txt_PartyTme" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                    </td>
                </tr>

                

                <tr>
                    <td align="right" class="auto-style2">健康状况：</td>
                    <td align="left">
                        <asp:DropDownList ID="ddl_HealthStatus" runat="server" datatype="ddl" errormsg="请选择健康状况"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>
                    </td>
                    <td align="right">教职工来源：</td>
                    <td align="left">
                        <asp:DropDownList ID="ddl_TeaSource" runat="server" datatype="ddl" errormsg="请选择教职工来源"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>
                    </td>
                    <td align="right">教职工类别：</td>
                    <td>
                        <asp:DropDownList ID="ddl_TeaType" runat="server" datatype="ddl" errormsg="请选择教职工类别"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>
                    </td>
                </tr>

                <tr>
                    <td align="right" class="auto-style2">参加工作年月：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_JodDate" runat="server" datatype="*" nullmsg="请选择参加工作年月" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        <span style="color: Red; float: none">*</span>
                    </td>
                    <td align="right">进本校年月：</td>
                    <td>
                        <asp:TextBox ID="txt_JoinSchool" runat="server" datatype="*" nullmsg="请选择进本校年月" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        <span style="color: Red; float: none">*</span>
                    </td>
                     <td align="right">聘用时间：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_GradeDate" runat="server" onfocus="WdatePicker({skin:'whyGreen'})" ></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td align="right" class="auto-style2">是否在编：</td>
                    <td align="left" >
                        <%-- <asp:DropDownList ID="ddl_IsSeries" runat="server" datatype="ddl" errormsg="请选择是否在编"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>--%>
                        <asp:RadioButtonList runat="server" ID="ddl_IsSeries1" RepeatDirection="Horizontal" CssClass="edilab"
                            RepeatLayout="Flow">
                        </asp:RadioButtonList>
                    </td>

                    <td align="right">任课学段：</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddl_Section" datatype="ddl" errormsg="请选择任课学段">
                            <asp:ListItem Value="-2">--请选择--</asp:ListItem>
                            <asp:ListItem Value="1">学前教育</asp:ListItem>
                            <asp:ListItem Value="2">小学</asp:ListItem>
                            <asp:ListItem Value="3">普通初中</asp:ListItem>
                            <asp:ListItem Value="4">普通高中</asp:ListItem>
                        </asp:DropDownList> <span style="color: Red; float: none">*</span>
                      <%--  <asp:RadioButtonList runat="server" ID="rdo_Section" RepeatDirection="Horizontal" CssClass="edilab" RepeatLayout="Flow">
                            <asp:ListItem Value="1">小学</asp:ListItem>
                            <asp:ListItem Value="2">中学</asp:ListItem>
                        </asp:RadioButtonList>--%>
                    </td>

                    <td align="right">教授科目：</td>
                    <td align="left">
                        <asp:DropDownList ID="ddl_TCourse" runat="server" datatype="ddl" errormsg="请选择教授科目"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>
                    </td>
                </tr>

                <tr>
                    <td align="right" class="auto-style2">用人形式：</td>
                    <td align="left">
                        <asp:DropDownList ID="ddl_EmploymentType" runat="server" datatype="ddl" errormsg="请选择用人形式"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>
                    </td>
                    <td align="right">签订合同情况：</td>
                    <td align="left">
                        <asp:DropDownList ID="ddl_ContractState" runat="server" datatype="ddl" errormsg="请选择签订合同情况"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>
                    </td>
                    <td align="right">人员状态：</td>
                    <td align="left">
                        <asp:DropDownList ID="ddl_TeaState" runat="server" datatype="ddl" errormsg="请选择人员状态"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>
                    </td>
                </tr>
                

                <tr>
                    <td align="right">专业技术职称：</td>
                    <td align="left">
                        <asp:DropDownList runat="server" ID="ddl_CurrentProfessional"></asp:DropDownList>
                    </td>
                   <td align="right" class="auto-style2">专业技术岗位等级：</td>
                    <td align="left" colspan="3">
                        <asp:DropDownList runat="server" ID="ddl_GradeType"  OnSelectedIndexChanged="ddl_GradeType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        <asp:DropDownList runat="server" ID="ddl_ProfessGrade"></asp:DropDownList>
                        <%--<span style="color: red;">*</span>--%>
                    </td>


                </tr>


                <tr>
                    <td align="right">薪级：</td>
                    <td align="left">
                        <asp:DropDownList runat="server" ID="ddl_SalaryGrade"></asp:DropDownList>
                    </td>
                    <td align="right" class="auto-style2">是否专任教：</td>
                    <td>
                        <asp:RadioButtonList runat="server" ID="rdo_IsFull" RepeatDirection="Horizontal" CssClass="edilab"
                            RepeatLayout="Flow"></asp:RadioButtonList>
                    </td>
                    <td align="right">是否教学岗：</td>
                    <td>
                        <asp:RadioButtonList runat="server" ID="rdo_IsTea" RepeatDirection="Horizontal" CssClass="edilab"
                            RepeatLayout="Flow"></asp:RadioButtonList>
                    </td>
                  
                </tr>

                <tr>
                    
                     <td align="right" class="auto-style3">普通话水平：</td>
                    <td align="left" class="auto-style1">
                        <%-- <asp:DropDownList ID="ddl_IsSeries" runat="server" datatype="ddl" errormsg="请选择是否在编"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>--%>
                        <asp:DropDownList runat="server" ID="ddl_Mandarin"></asp:DropDownList>
                    </td>
                    <td align="right" class="auto-style1">是否受过特教专业培训：</td>
                    <td align="left" class="auto-style1">
                        <%--<asp:DropDownList ID="ddl_IsSpecialTrain" runat="server" datatype="ddl" errormsg="请选择是否受过特教专业培训"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>--%>
                        <asp:RadioButtonList runat="server" ID="ddl_IsSpecialTrain1" RepeatDirection="Horizontal" CssClass="edilab"
                            RepeatLayout="Flow">
                        </asp:RadioButtonList>
                    </td>
                    <td align="right" class="auto-style1">是否有特殊教育从业证书：</td>
                    <td align="left" class="auto-style1">
                        <%--  <asp:DropDownList ID="ddl_IsSpecialEdu" runat="server" datatype="ddl" errormsg="请选择是否有特殊教育从业证书"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>--%>
                        <asp:RadioButtonList runat="server" ID="ddl_IsSpecialEdu1" RepeatDirection="Horizontal" CssClass="edilab"
                            RepeatLayout="Flow">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style2">是否是特级教师：</td>
                    <td align="left">
                        <%--  <asp:DropDownList ID="ddl_IsSpecialTea" runat="server" datatype="ddl" errormsg="请选择是否是特级教师"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>--%>
                        <asp:RadioButtonList runat="server" ID="ddl_IsSpecialTea1" RepeatDirection="Horizontal" CssClass="edilab"
                            RepeatLayout="Flow">
                        </asp:RadioButtonList>
                    </td>
                    <td align="right">是否属于免费(公费)师范生：</td>
                    <td align="left">
                        <%--<asp:DropDownList ID="ddl_IsTeaStu" runat="server" datatype="ddl" errormsg="请选择是否属于免费(公费)师范生"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>--%>
                        <asp:RadioButtonList runat="server" ID="ddl_IsTeaStu1" RepeatDirection="Horizontal" CssClass="edilab"
                            RepeatLayout="Flow">
                        </asp:RadioButtonList>
                    </td>
                    <td align="right">是否参加基层服务项目：</td>
                    <td align="left">
                        <%--  <asp:DropDownList ID="ddl_IsGrassService" runat="server" datatype="ddl" errormsg="请选择是否参加基层服务项目"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>--%>
                        <asp:RadioButtonList runat="server" ID="ddl_IsGrassService1" RepeatDirection="Horizontal" CssClass="edilab"
                            RepeatLayout="Flow">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style2">信息技术应用能力：</td>
                    <td align="left" >
                        <asp:DropDownList ID="ddl_InformationLevel" runat="server" datatype="ddl" errormsg="请选择信息技术应用能力"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>
                    </td>
                     <td align="right">参加基层服务项目起始年月：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_GrassStartDate" runat="server" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                    </td>

                    <td align="right">参加基层服务项目结束年月：</td>
                    <td align="left">
                        <asp:TextBox ID="txt_GrassEndDate" runat="server" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td align="right" class="auto-style2">是否县级及以上骨干教师：</td>
                    <td align="left">
                        <%-- <asp:DropDownList ID="ddl_IsCountyLevel" runat="server" datatype="ddl" errormsg="请选择是否县级及以上骨干教师"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>--%>
                        <asp:RadioButtonList runat="server" ID="ddl_IsCountyLevel1" RepeatDirection="Horizontal" CssClass="edilab"
                            RepeatLayout="Flow">
                        </asp:RadioButtonList>
                    </td>
                    <td align="right">是否心理健康教育教师：</td>
                    <td align="left">
                        <%-- <asp:DropDownList ID="ddl_IsHealthTeahcer" runat="server" datatype="ddl" errormsg="请选择是否心理健康教育教师"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>--%>
                        <asp:RadioButtonList runat="server" ID="ddl_IsHealthTeahcer1" RepeatDirection="Horizontal" CssClass="edilab"
                            RepeatLayout="Flow">
                        </asp:RadioButtonList>
                    </td>
                    <td align="right">是否全日制师范类专业毕业：</td>
                    <td align="left">
                        <%-- <asp:DropDownList ID="ddl_IsFulltime" runat="server" datatype="ddl" errormsg="请选择是否全日制师范类专业毕业"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>--%>
                        <asp:RadioButtonList runat="server" ID="ddl_IsFulltime1" RepeatDirection="Horizontal" CssClass="edilab"
                            RepeatLayout="Flow">
                        </asp:RadioButtonList>
                    </td>
                </tr>

                 <tr>
                    <th  colspan="6" align="left">
                       教师资格证信息
                    </th>
                </tr>

                 <tr>
                    <td align="right" class="auto-style2">教师资格种类：</td> 
                     <td > <asp:DropDownList runat="server" ID="ddl_TeaQualiType" datatype="ddl" errormsg="请选择教师资格种类"></asp:DropDownList> <span style="color: Red; float: none">*</span>
                     </td>
                    <td align="right">资格证编号：</td> 
                     <td >
                         <asp:TextBox ID="txt_TeaQualCode" runat="server" datatype="*" nullmsg="请选择资格证编号"></asp:TextBox>
                        <span style="color: Red; float: none">*</span>
                     </td> <td align="right">任教学科：</td> 
                     <td >
                         <asp:DropDownList runat="server" ID="ddl_TeaQualCourse" datatype="ddl" errormsg="请选择学科"></asp:DropDownList>
                        <span style="color: Red; float: none">*</span>
                     </td>
                </tr>
                 <tr>
                    <td align="right" class="auto-style2">证书颁发日期：</td> 
                     <td > 
                         <asp:TextBox ID="txt_TeaQualDate" runat="server" datatype="*" nullmsg="请选择证书颁发日期" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                         <span style="color: Red; float: none">*</span>
                     </td>
                    <td align="right">首次注册日期：</td> 
                     <td colspan="3" >
                         <asp:TextBox ID="txt_TeaQualRegDate" runat="server" datatype="*" nullmsg="请选择首次注册日期"  onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        <span style="color: Red; float: none">*</span>
                   </td>
                </tr>
                <tr>
                    <td colspan="6" align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="return setValue()" OnClick="btn_Sumbit_Click" />
                        <%--<input type="button" name="button" id="cancell" value="返回" class="editor" onclick='javascript: window.history.back(-1);' />--%>
                        <input type="button" name="button" id="cancell" value="返回" class="editor" onclick='javascript: window.location.href = "TeacherManage.aspx";' />
                        <%-- <asp:Button ID="btn_return" runat="server" Text="返回" class="editor" OnClick="btn_return_Click" />--%>
                        <%--  <input type="button" name="button" id="cancell" value="返回" class="editor" onclick=' $.close("A_id");' />--%>
                    </td>
                </tr>
            </tbody>
        </table>
    </form>

    <script>
        $(function () {
            var a='<%=Flag%>';
            if (a == '1')
            {
                $("#cancell").hide();
            }
            $('#PostRole').combotree('setValues', [<%=Role%>]);
        });
        function setValue() {
            var role = $('#PostRole').combotree('getValues');
            if (role == "")
            { alert("请选择职务"); return false; }
            var rolename = $('#PostRole').combotree('getText');
            document.getElementById("hf_PostRole").value = role;
            document.getElementById("hf_PostRoleName").value = rolename;
            document.getElementById("hf_SelectedValue").value = val;
            // alert(rolename);
        }
    </script>
</body>
</html>
