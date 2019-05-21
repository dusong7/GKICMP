<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AbsentWorkStatisticsManage.aspx.cs" Inherits="GKICMP.educationals.AbsentWorkStatisticsManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        //function editinfo(e) {
        //    var id = $(e).next().next().val();
        //    return openbox('A_id', 'SubstituteEdit.aspx', 'id=' + id, 600, 650, 0);
        //}
        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'SubstituteDetail.aspx', 'id=' + id, 840, 500, 1);
        }
        function show(tid, acount, flag) {
            if (acount != 0) {
                return openbox('A_id', 'AbsentWorkStatisticsDetail.aspx', 'id=' + tid + '&flag=' + flag + '&begin=' + $("#hf_begin").val() + '&end=' + $("#hf_end").val(), 940, 550, 1);
            }
        }
    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_begin" runat="server" />
        <asp:HiddenField ID="hf_end" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="代课工作量统计"></asp:Label></td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="40">姓名：</td>
                        <td width="80">
                            <asp:TextBox ID="txt_SubUser" runat="server"></asp:TextBox>
                        </td>
                        <td width="70px" align="right">代课日期：</td>
                        <td width="350px">
                            <asp:TextBox ID="txt_Begin" runat="server" Style="width: 75px" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})"></asp:TextBox>--
                            <asp:TextBox ID="txt_End" runat="server" Style="width: 75px" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt" id="taboperation" runat="server">
                <tbody>
                    <tr>
                        <td align="right" valign="middle">
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th align="center">姓名</th>
                        <th align="center">代课-</th>
                        <th align="center">代课+</th>
                        <th align="center">核计</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("SubUserName")%></td>
                                <td><a href="#" onclick='<%#"show(\""+Eval("Name")+"\",\""+Eval("Allowance")+"\",1)"%>'><%#Eval("Allowance").ToString()=="0.00"?0:Eval("Allowance")%></a></td>
                                <td><a href="#" onclick='<%#"show(\""+Eval("Name")+"\",\""+Eval("Plus")+"\",2)"%>'><%#Eval("Plus").ToString()=="0.00"?0:Eval("Plus")%></a></td>
                                <td><%#Eval("ACount").ToString()=="0.00"?0:Eval("ACount")%></td>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="4">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>


