<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuPlacement.aspx.cs" Inherits="GKICMP.freshmen.StuPlacement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>

    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>

    

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
                        <th colspan="4" align="left">分班信息(请在分班之前创建好对应的班级数)</th>
                    </tr>
                    <tr>
                        <td align="right" >分班数目：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_ClassCount" runat="server"  MaxLength="50" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>

                    <tr> 
                        <td align="right" width="120">
                            <style>
                                .edilab label {
                                    float: none;
                                }
                                .edilab input {
                                    height: 13px;
                                }
                                .auto-style1 {
                                    height: 16px;
                                }
                            </style>
                            <asp:CheckBox ID="cb_Age" CssClass="edilab" Text="是否平均年龄" runat="server" /> 
                        </td>
                        <td align="left">
                            平均年龄控制在多少岁以内？
                            <asp:TextBox ID="txt_Age" runat="server" MaxLength="5"  CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" width="120">
                            <style>
                                .edilab label {
                                    float: none;
                                }
                                .edilab input {
                                    height: 13px;
                                }
                                .auto-style1 {
                                    height: 16px;
                                }
                            </style>
                            <asp:CheckBox ID="cb_Score" CssClass="edilab" Text="是否平均成绩" runat="server" /> 
                        </td>
                        <td align="left">
                            平均成绩控制在多少岁以内？
                            <asp:TextBox ID="txt_Score" runat="server"  MaxLength="5" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>


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
         function Check()
         {
             if ($("#cb_Age").is(':checked') && $("#cb_Score").is(':checked'))
             {
                 alert("两个条件只能选其一");
                 return false;
             }
         }
     </script>

</body>
</html>




