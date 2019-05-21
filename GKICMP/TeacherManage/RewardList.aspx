<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RewardList.aspx.cs" Inherits="GKICMP.teachermanage.RewardList" %>

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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="教师获奖统计表"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">

            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                  
                    <tr>
                        <td align="right" width="80">获奖年月：</td>
                        <td width="220">
                            <asp:TextBox ID="txt_SDate" runat="server" Style="width: 85px" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_EDate" runat="server" Style="width: 85px" onfocus="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                        </td>
                        <td style="text-align: right">
                            <asp:Button ID="btn_Search" runat="server" CssClass="btn" Text="查询"  OnClick="btn_Query_Click" />
                        </td>
                       
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0" id="excel" runat="server">
           <%-- <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt">
                <tbody>
                    <tr>
                        <td align="left"></td>
                        <td align="right" valign="middle">
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>--%>
            <table width="100%" border='0' cellspacing='0' cellpadding="0" class='listinfoc'>
                <tbody>
                    <tr>
                        <th style="text-align:center" >序号</th>
                        <th style="text-align:center" >特等</th>
                        <th style="text-align:center" >一等</th>
                        <th style="text-align:center" >二等</th>
                        <th style="text-align:center" >三等</th>
                        <th style="text-align:center" >四等</th>
                        <th style="text-align:center" >未平等级</th>
                        <th style="text-align:center" >其他</th>
                    </tr>
                  
                    <asp:Repeater ID="rp_List" runat="server">
                        <ItemTemplate>

                            <tr>
                                <td><%#Container.ItemIndex + 1%></td>
                                <td align="center"><%#Eval("TD") %></td>
                                <td align="center"><%#Eval("YD") %></td>
                                <td align="center"><%#Eval("ED") %></td>
                                <td align="center"><%#Eval("SD") %></td>
                                <td align="center"><%#Eval("SID") %></td>
                                <td align="center"><%#Eval("WP") %></td>
                                <td align="center"><%#Eval("QT") %></td>
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

