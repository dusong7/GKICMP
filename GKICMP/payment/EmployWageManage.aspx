<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployWageManage.aspx.cs" Inherits="GKICMP.payment.EmployWageManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btn_Input').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'EmployWageImport.aspx', '', 680, 360, 3);
            });
        });
    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="聘用工资表"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td width="40" align="right">年份：</td>
                        <td width="90">
                            <asp:DropDownList ID="ddl_WYear" runat="server"></asp:DropDownList>
                        </td>
                        <td align="right" width="60">月份：</td>
                        <td width="90">
                            <asp:DropDownList ID="ddl_WMonth" runat="server"></asp:DropDownList>
                        </td>
                        <td align="right" width="40">姓名：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_TIDName" Text="" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt">
                <tbody>
                    <tr>
                        <td align="right" valign="middle">
                            <asp:Button ID="btn_Input" runat="server" Text="导入"   CssClass="listbtncss listinput" />
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="table">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfoc">
                    <tbody>
                        <tr>
                            <th width="5%" align="center" rowspan="2">
                                <label class="wxz" id="checkalll">
                                    <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)" /></label></th>
                            <th align="center" rowspan="2">年份</th>
                            <th align="center" rowspan="2">月份</th>
                            <th align="center" rowspan="2">姓名</th>
                            <th align="center" colspan="4">工资部分</th>
                            <th align="center" rowspan="2">应发工资</th>
                            <th align="center" colspan="6">代扣部分</th>
                            <th align="center" rowspan="2">工会扣除0.5%</th>
                            <th align="center" rowspan="2">实发工资</th>
                        </tr>
                        <tr>
                            <th>基本工资</th>
                            <th>岗位工资</th>
                            <th>学历工资</th>
                            <th>上月绩效工资</th>
                            <th>养老保险8%</th>
                            <th>住房公积金12%</th>
                            <th>失业保险0.5%</th>
                            <th>大病救助</th>
                            <th>医保2%</th>
                            <th>小计</th>
                        </tr>
                        <asp:Repeater runat="server" ID="rp_List">
                            <ItemTemplate>
                                <tr>
                                    <td style="width: 5px">
                                        <label class="wxz" id='ck_<%#Eval("SID")%>l'>
                                            <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("SID")%>' id='ck_<%#Eval("SID") %>' /></label>
                                    </td>
                                    <td><%#Eval("WYear")%></td>
                                    <td><%#Eval("WMonth")%></td>
                                    <td><%#Eval("TIDName")%></td>
                                    <td><%#Eval("Allowance")%></td>
                                    <td><%#Eval("PostWage")%></td>
                                    <td><%#Eval("SalaryScale")%></td>
                                    <td><%#Eval("BasicPay")%></td>
                                    <td><%#Eval("ShouldWage")%></td>
                                    <td><%#Eval("Insurance")%></td>
                                    <td><%#Eval("Accumulation")%></td>
                                    <td><%#Eval("Unemployment")%></td>
                                    <td><%#Eval("Serious")%></td>
                                    <td><%#Eval("MedicalFee")%></td>
                                    <td><%#Eval("Withhold")%></td>
                                    <td><%#Eval("Union")%></td>
                                    <td><%#Eval("ActualWages") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr runat="server" id="tr_null">
                            <td colspan="17">暂无记录</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>


