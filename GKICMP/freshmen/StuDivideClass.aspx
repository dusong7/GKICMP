<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuDivideClass.aspx.cs" Inherits="GKICMP.freshmen.StuDivideClass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>

    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
     <script src="../js/editinfor.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
   
    <script src="../js/common.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });

        function Check() {
            var a = document.getElementById("txt_Sex").value;
            var b = document.getElementById("txt_Education").value;
            var c = document.getElementById("txt_Ability").value;
            var d = document.getElementById("txt_Score").value;
            //alert(a);
            //alert("权重总和不能超过100%！");
           
        }

    </script>

    <style>
        .edilab label {float: none; }
        .edilab input { height: 13px;}
        .auto-style1 {height: 16px;}
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_FID" />
        <asp:HiddenField runat="server" ID="hf_UsersPwd"  />
        <asp:HiddenField runat="server" ID="hf_UState" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">分班信息</th>
                    </tr>
                     <tr runat="server" id="ddlcid" >
                        <td align="right" width="100px">所属校区</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_CID" runat="server" datatype="ddl" errormsg="请选择所属校区" AutoPostBack="True" OnSelectedIndexChanged="ddl_ProType_SelectedIndexChanged"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" >分班数目</td>
                        <td align="left">
                            <asp:TextBox ID="txt_ClassCount" runat="server"  MaxLength="50" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" >分班班级名称</td>
                        <td align="left">
                           <asp:Label ID="ltl_DepName" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" >学生总数</td>
                        <td align="left">
                           <asp:Label ID="ltl_Num" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td align="right">分班说明</td>
                        <td>
                            <span style="color: red;">
                                1.分班之前请设置好年级，班级以及班级所在的校区；<br />
                                2.分班之前请导入新生信息，支持分批导入；<br />
                                3.分班已默认各班性别大致均等；<br />
                                4.分班是随机分班，不按照列表中学生出现的顺序分班；<br />
                                4.分班完成后可在系统管理-用户管理-学生列表查看各个班级的学生信息；<br />
                            </span>
                        </td>
                    </tr>

                    <%--<tr> 
                        <td align="right" width="120">
                          平均年龄控制在多少岁以内？
                            <asp:CheckBox ID="cb_Age" CssClass="edilab" Text="是否平均年龄" runat="server" /> 
                        </td>
                        <td align="left">
                           
                            <asp:TextBox ID="txt_Age" runat="server" MaxLength="5"  datatype="zheng" nullmsg="请填写平均年龄权重" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">%</span>
                        </td>
                      </tr>--%>

                   <%--  <tr> 
                        <td align="right" width="120">
                             <asp:CheckBox ID="cb_Sex" CssClass="edilab"  Text="新生性别权重" runat="server" /> 
                         </td>
                        <td align="left">
                            <asp:TextBox ID="txt_Sex" runat="server"   datatype="zheng" nullmsg="请填写新生性别权重" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">%</span>
                        </td>
                    </tr>

                    <tr> 
                        <td align="right" width="120">
                             <asp:CheckBox ID="cb_Education" CssClass="edilab" Text="最高学历权重" runat="server" /> 
                         </td>
                        <td align="left">
                            <asp:TextBox ID="txt_Education" runat="server"   datatype="zheng" nullmsg="请填写最高学历权重" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">%</span>
                        </td>
                    </tr>

                    <tr> 
                        <td align="right" width="120">
                            <asp:CheckBox ID="cb_Ability" CssClass="edilab" Text="交流水平权重" runat="server" /> 
                         </td>
                        <td align="left">
                            <asp:TextBox ID="txt_Ability" runat="server"  datatype="zheng" nullmsg="请填写交流水平权重"   CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">%</span>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" width="120">
                            <asp:CheckBox ID="cb_Score" CssClass="edilab" Text="学生成绩权重" runat="server" /> 
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txt_Score" runat="server"  MaxLength="5" datatype="zheng" nullmsg="请填写学生成绩权重"  CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">%</span>
                        </td>
                      </tr>--%>


                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="return Check()"  OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="返回" class="editor" onclick='javascript: window.history.back(-1);' />
                        </td>
                    </tr>

                </tbody>
               
            </table>
        </div>
        <asp:HiddenField ID="hf_ID" runat="server" />
    </form>

     <script>
         //function Check() {
         //    //if ($("#cb_Age").is(':checked') && $("#cb_Score").is(':checked'))
         //    //{
         //    //    alert("两个条件只能选其一");
         //    //    return false;
         //    //}
         //}
     </script>

</body>
</html>
