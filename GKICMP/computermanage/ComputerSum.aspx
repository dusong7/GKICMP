<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComputerSum.aspx.cs" Inherits="GKICMP.computermanage.ComputerSum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
        <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/highcharts.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
        
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField ID="hf_SelectedValue" runat="server" />
        <asp:HiddenField ID="hf_Age" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text="班班通管理"></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="班班通统计"></asp:Label>
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
                                <li><a href="ComputerDep.aspx">按设备统计</a></li>
                                <li><a href="ComputerSubject.aspx">按学科统计</a></li>
                                <li><a href="ComputerTeacher.aspx">按教师统计</a></li>
                                <li><a href="ComputerDepartment.aspx">按部门统计</a></li>
                                <li class="selected"><a href="ComputerSum.aspx">按月份统计</a></li>
                            </ul>
                        </div>
                    </th>
                </tr>
              </tbody>
            </table>

        <div class="listcent searclass">

            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                  
                    <tr>
                        <td align="right" width="80">登记时间：</td>
                        <td width="300">
                            <asp:TextBox ID="txt_SDate" runat="server" Style="width: 85px" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox> --
                            <asp:TextBox ID="txt_EDate" runat="server" Style="width: 85px" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td >
                            <asp:Button ID="btn_Search" runat="server" CssClass="btn" Text="查询"  OnClick="btn_Query_Click" />
                        </td>
                       
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0" id="excel" runat="server">
           
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt">
                <tbody>
                    <tr>
                        <td align="right" valign="middle">
                            <span style="color: red; float: left; margin-left: 20px; font-size: 14px; font-weight: bold">
                               <asp:Literal ID="ltl_Sum" runat="server" ></asp:Literal>
                            </span>
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>

            <table width="100%" border='0' cellspacing='0' cellpadding="0" class='listinfoc'>
                <tbody>
                    <tr>
                       <%-- <th style="text-align:center" >序号</th>--%>
                        <th style="text-align:center" >月份</th>
                        <th style="text-align:center" >次数</th>
                    </tr>
                  
                    <asp:Repeater ID="rp_List" runat="server">
                        <ItemTemplate>

                            <tr>
                               <%-- <td><%#Container.ItemIndex + 1%></td>--%>
                                <td align="center"><%#Eval("ym") %></td>
                                <td align="center"><%#Eval("counts") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr_null" runat="server">
                        <td colspan="26" align="center">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
         <div id="container" style="min-width:400px;height:400px;margin:auto;width:98%;margin-top:15px">
             <asp:Literal ID="ltl_RewardList" runat="server"></asp:Literal>
         </div>
   
    </form>
</body>
</html>
