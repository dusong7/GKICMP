<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendSetEdit.aspx.cs" Inherits="GKICMP.rlsb.AttendSetEdit" %>

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
        $(function () {
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
    </style>
</head>
<body>
     <form id="form1" runat="server">
        <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField runat="server" ID="hf_SelectedValue" />
        <asp:HiddenField runat="server" ID="hf_UsersPwd" Value="" />
        <asp:HiddenField runat="server" ID="hf_UState" />

        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">考勤节点信息</th>
                    </tr>
                     <tr>
                        <td align="right" width="90px">节点名称：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_AName" runat="server" datatype="*" nullmsg="请填写名称" ></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                         </tr>
                    
                    <tr>
                        <td align="right" width="90px">开始时间：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_MBegin" runat="server" datatype="*" nullmsg="请选择开始时间" onfocus="WdatePicker({ dateFmt: 'HH:mm:ss' })"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">结束时间：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_MEnd" runat="server" datatype="*" ckdate="txt_MBegin" nullmsg="请选择结束时间" onfocus="WdatePicker({ dateFmt: 'HH:mm:ss' })" ></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                   
                   <tr>
                       <td align="right">是否启用：</td>
                        <td align="left" >
                           <asp:RadioButtonList runat="server" ID="rdo_IsUse" RepeatDirection="Horizontal" CssClass="edilab" RepeatLayout="Flow">
                               <asp:ListItem Value="1" Selected="True">是</asp:ListItem><asp:ListItem Value="0">否</asp:ListItem>
                           </asp:RadioButtonList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                       <td align="right">打卡方式：</td>
                        <td align="left" >
                           <asp:RadioButtonList runat="server" ID="rbo_Type" RepeatDirection="Horizontal" CssClass="edilab" RepeatLayout="Flow">
                               <asp:ListItem Value="1" Selected="True">进</asp:ListItem><asp:ListItem Value="2">出</asp:ListItem>
                           </asp:RadioButtonList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                   </tr>
                    <tr>
                        <td align="right" class="auto-style1">适用角色：</td>
                        <td align="left" colspan="3" class="auto-style1">
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
                            <asp:CheckBoxList ID="cbl_Role" Class="edilab" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                            </asp:CheckBoxList>
                        </td>
                    </tr>

                    <%-- <tr>
                        <td align="right">是否启用</td>
                        <td colspan="3">
                            <asp:RadioButtonList runat="server" ID="ddl_IsUse" RepeatDirection="Horizontal" CssClass="edilab"
                            RepeatLayout="Flow">
                        </asp:RadioButtonList>
                        </td>
                    </tr>--%>
                  
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit"  OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick='$.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

