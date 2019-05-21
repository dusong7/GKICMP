<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendRecordDetail.aspx.cs" Inherits="GKICMP.teachermanage.AttendRecordDetail" %>

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
                        <th colspan="4" align="left">考勤基本信息
                        </th>
                    </tr>
                     <tr>
                        <td align="right" >姓名</td>
                        <td align="left">
                            <asp:Literal ID="ltl_RealName" runat="server"></asp:Literal>
                        </td>
                      
                    </tr>

                    <tr>
                        <td align="right" >打卡时间</td>
                        <td align="left">
                            <asp:Literal ID="ltl_RecordDate" runat="server"></asp:Literal>
                        </td>
                       
                    </tr>
                    <tr>
                        <td align="right" >打卡类型</td>
                        <td align="left">
                            <asp:Literal ID="ltl_OutType" runat="server"></asp:Literal>
                        </td>
                       
                    </tr>
                    <tr>
                        <td align="right" >考勤图像</td>
                        <td align="left">
                          <div style="width:450px;height:400px;"> <asp:Image ID="img_AttImg" runat="server" Width="100%" Height="100%" /></div> 
                        </td>
                      
                    </tr>

                </tbody>
            </table>
        </div>
</body>
</html>

