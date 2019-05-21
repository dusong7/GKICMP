<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoiceEdit.aspx.cs" Inherits="GKICMP.voice.VoiceEdit" %>

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
                        <th colspan="4" align="left">视频配置信息</th>
                    </tr>
                    
                    <tr>
                        <td align="right" width="120">设备名称</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txt_EquipName"  datatype="*1-50" nullmsg="请填写设备名称"  ></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                        <td align="right" width="120">IP地址</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txt_EquipIP"  datatype="*1-50" nullmsg="请填写IP地址"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" width="120">端口号：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_PotNum" runat="server" datatype="zhengnum" nullmsg="请填写端口号" ></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">设备端口：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_EquipPotNum" runat="server"  datatype="zhengnum" nullmsg="请填写设备端口"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        
                    </tr>
                  <tr>
                      <td align="right" width="120">用户名：</td>
                        <td>
                            <asp:TextBox ID="txt_UserName" runat="server" datatype="*1-50" nullmsg="请填写用户名" ></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">密码：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_UserPwd" runat="server" datatype="*1-50" nullmsg="请填写密码" ></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        
                    </tr>
                    
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

