<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepairDetail.aspx.cs" Inherits="GKICMP.office.RepairDetail" %>

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
                        <th colspan="4" align="left">报修信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">报修人：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_RepairName" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">报修设备：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_RepairObj" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="100px">报修日期：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_ARDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">受理部门：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_DutyDep" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="100px">本校受理人：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_DutyUser" runat="server"></asp:Literal>
                        </td>
                    </tr>

                    
                    <tr>
                        <td align="right" width="100px">故障描述：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_RepairContent" runat="server"></asp:Literal>
                        </td>
                    </tr>

                     <tr>
                        <td align="right">附件：</td>
                        <td align="left" colspan="3">
                            <asp:Image ID="Image1" runat="server" Width="350px" Height="200px" Visible="false" />
                        </td>
                    </tr>



                 <tr>
                   <th colspan="4" align="left">维修部门</th>
                </tr>
                     <tr>
                        <td align="right" width="100px">维修单位：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_Sdid" runat="server"></asp:Literal>
                        </td>
                     </tr>
                    <tr>
                        <td align="right" width="100px">联系人：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_LinkUser" runat="server"></asp:Literal>
                        </td>
                         <td align="right" width="100px">联系方式：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_LinkNo" runat="server"></asp:Literal>
                        </td>
                    </tr>

                      <tr>
                        <td align="right" width="100px">移交人：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_TransferUser" runat="server"></asp:Literal>
                        </td>
                         <td align="right" width="100px">移交说明：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_TransferDesc" runat="server"></asp:Literal>
                        </td>
                    </tr>

                <tr>
                   <th colspan="4" align="left">维修结果</th>
                </tr>
                    <tr>
                        <td align="right" width="100px">状态：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_ARState" runat="server"></asp:Literal>
                        </td>
                        <td align="right" width="100px">完成日期：</td>
                        <td align="left">
                            <asp:Literal ID="ltl_CompDate" runat="server"></asp:Literal>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" width="100px">完成说明：</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_CompDesc" runat="server"></asp:Literal>
                        </td>
                    </tr>

                     <tr id="reject" runat="server">
                        <td align="right" width="100px">驳回意见</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="ltl_Reject" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    

                    

                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
