<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkPlanDetail.aspx.cs" Inherits="GKICMP.office.WorkPlanDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">

        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">工作计划信息</th>
                    </tr>
                    <tr>
                        <td align="right">学年度/学期：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_Weeks" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">内容：</td>
                        <td colspan="3">
                              <asp:Literal ID="ltl_ExamName" runat="server"></asp:Literal>
                    </tr>
                    <tr>
                        <td align="right" width="15%">开始时间：</td>
                        <td align="left">
                              <asp:Literal ID="ltl_BeginDate" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="10%">结束时间：</td>
                        <td align="left">
                              <asp:Literal ID="ltl_EndDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">参与人：</td>
                        <td align="left" colspan="3">
                              <asp:Literal ID="ltl_AllUsers" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">部门：</td>
                        <td align="left">
                              <asp:Literal ID="ltl_DepID" runat="server"></asp:Literal>
                        </td>
                        <td align="right">责任人：</td>
                        <td align="left">
                              <asp:Literal ID="ltl_DutyUser" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">发起人：</td>
                        <td align="left" >
                              <asp:Literal ID="ltl_CreateUser" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="10%">发起时间：</td>
                        <td align="left">
                              <asp:Literal ID="ltl_CreateDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
  

</body>
</html>








