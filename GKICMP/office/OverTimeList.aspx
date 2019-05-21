<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OverTimeList.aspx.cs" Inherits="GKICMP.office.OverTimeList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>智慧校园行政办公平台</title>
     <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <style>       
         .listcent {
                     min-width:100px     
                   }
    </style>

    
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th align="center">姓名</th>
                       <%-- <th align="center">打卡机号码</th>--%>
                        <th align="center">加班日期</th>
                        <th align="center">加班时长</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("UserName")%></td>
                                <td><%#Eval("BeginDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("overdays")%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="4">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

