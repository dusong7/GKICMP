<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRegDetail.aspx.cs" Inherits="GKICMP.freshmen.StudentRegDetail" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/ImgPreview.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_FID" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>

                    <tr>
                        <th colspan="4" align="left">用户信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="90">用户名：</td>
                        <td align="left">
                             <asp:Literal ID="ltl_UserName" runat="server"></asp:Literal>
                        </td>
                        <td align="right">身份证号码：</td>
                        <td>
                             <asp:Literal ID="ltl_IDCard" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="90">姓名：</td>
                        <td align="left">
                             <asp:Literal ID="ltl_RealName" runat="server"></asp:Literal>
                        </td>
                        <td align="right">性别：</td>
                        <td>

                            <div class="sel" style="float: left">
                                 <asp:Literal ID="ltl_UserSex" runat="server"></asp:Literal>
                            </div>
                        </td>
                    </tr>
                    <tr>
                         <td align="right" width="90">民族：</td>
                        <td align="left">
                             <asp:Literal ID="ltl_UserNation" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="90">手机号：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_CellPhone" runat="server"></asp:Literal>
                        </td>
                       
                    </tr>
                    <tr>
                        <td align="right" width="90">出生年月：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_BirthDay" runat="server"></asp:Literal>
                        </td>
                        <td align="right">家庭地址：</td>
                        <td>
                            <asp:Literal ID="ltl_Address" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">所属校区：</td>
                        <td align="left">
                            <asp:Label ID="ltl_CampusName" runat="server"></asp:Label>
                        </td>
                        <td align="right" width="90">邮箱：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_MailNum" runat="server"></asp:Literal>
                        </td>
                       
                         
                    </tr>
                    <tr>
                        <td align="right" width="90">微信号：</td>
                        <td align="left" >
                            <asp:Literal ID="ltl_WeiNum" runat="server"></asp:Literal>
                        </td>
                          <td align="right">QQ：</td>
                        <td>
                            <asp:Literal ID="ltl_QQNum" runat="server"></asp:Literal>
                        </td>
                      
                    </tr>

                    <tr>
                        <td align="right" >家长最高学历：</td>
                        <td>
                            <asp:Literal ID="ltl_HighEducation" runat="server"></asp:Literal>
                        </td>
                       <td align="right" width="90">交流水平：</td>
                        <td align="left" >
                            <asp:Literal ID="ltl_LevelCommunication" runat="server"></asp:Literal>
                        </td>
                    </tr>

                     <tr>
                      <td align="right" >分数：</td>
                        <td align="left"  colspan="3">
                            <asp:Literal ID="ltl_Mark" runat="server"></asp:Literal>
                        </td>
                    </tr>


                    <tr>
                        <td align="right">备注：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_UserDesc" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

