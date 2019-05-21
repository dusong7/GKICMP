<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetDepreciation.aspx.cs" Inherits="GKICMP.assetmanage.AssetDepreciation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />

    <script src="../js/jquery.min.js"></script>
    <script src="../EasyUI/jquery.easyui.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btn_Add').click(function () {
                var flag = document.getElementById("hf_Flag").value;
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                if (flag == 1) {
                    return openbox('A_id', 'AssetEdit.aspx', 'flag=' + flag, 900, 660, -1);
                }
                else {
                    return openbox('A_id', 'AssetEditOffice.aspx', 'flag=' + flag, 900, 660, -1);
                }
            });
        });
        function assrateinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'AssetDepreRate.aspx', 'id=' + id, 700, 260, 0);
        }
        function viewinfo(e) {
            var flag = document.getElementById("hf_Flag").value;
            var id = $(e).next().next().val();
            return openbox('A_id', 'AssetDetail.aspx', 'id=' + id + '&flag=' + flag, 900, 460, 4);
        }
    </script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField runat="server" ID="hf_Flag" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="资产折旧"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">资产名称：</td>
                        <td width="200">
                            <asp:TextBox ID="txt_AssetName" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="100">资产分类：</td>
                        <td width="200">
                            <div class="sel" style="float: left">
                                <asp:TextBox ID="txt_DataType1" cascadeCheck="false" runat="server" name="Series" onlyLeafCheck="true" url="../ashx/GetBaseDate.ashx?method=GetAssetType&flag=1" CssClass="easyui-combotree"></asp:TextBox>
                            </div>
                        </td>
                        <td align="right" width="80">停止日期：</td>
                        <td width="200">
                            <asp:TextBox ID="txt_BeginDate" runat="server" onclick="WdatePicker({skin:'whyGreen'})" Width="75px"></asp:TextBox>--
                            <asp:TextBox ID="txt_EndDate" runat="server" onclick="WdatePicker({skin:'whyGreen'})" Width="75px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <%--<table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt">
                <tbody>
                    <tr>
                        <td align="right" valign="middle">
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
                            <asp:Button ID="btn_Input" runat="server" Text="导入"   CssClass="listbtncss listinput" />
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>--%>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <%--<th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)"></label></th>--%>
                        <th align="center">资产分类</th>
                        <th align="center">资产名称</th>
                        <th align="center">资产数量</th>
                        <th align="center">资产单位</th>
                        <th align="center">购置时间</th>
                        <th align="center">价值</th>
                        <th align="center">残值率（%）</th>
                        <th align="center">残值</th>
                        <th align="center">折旧年限</th>
                        <th align="center">年折旧额</th>
                        <th align="center">月折旧额</th>
                        <th align="center">累计折旧</th>
                        <th align="center">净值</th>
                        <th align="center">停止日期</th>
                        <th align="center">停止折旧</th>
                        <th width="100px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <%--<td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("AID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("AID") %>' <%#GetState(Eval("IsReport")) %> id='ck_<%#Eval("AID") %>' /></label>
                                </td>--%>
                                <td><%#Eval("TypeName")%></td>
                                <td><%#Eval("AssetName")%></td>
                                <td><%#Eval("AssetNum")%></td>
                                <td><%#Eval("AUnitName") %></td>
                                <td><%#Eval("BuyDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("APrice")%></td>
                                <td><%#GetAssRate(Eval("AssRate")) %></td>
                                <td><%#Eval("RatePrice","{0:N2}") %></td>
                                <td><%#Eval("PlanYear") %></td>
                                <td><%#Eval("YearPrice","{0:N2}") %></td>
                                <td><%#Eval("MonthPrice","{0:N2}") %></td>
                                <td><%#Eval("SumRatePrice","{0:N2}") %></td>
                                <td><%#Eval("LastValue") %></td>
                                <td><%#Eval("LastDate","{0:yyyy-MM-dd}") %></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot>(Eval("IsStopRate")) %></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_AssRate" runat="server" CssClass="listbtn btneditcolor" ToolTip="残值率" OnClientClick='return assrateinfo(this);'>残值率</asp:LinkButton>
                                    <asp:LinkButton ID="lbtn_StopRate" runat="server" CssClass="listbtn btnreportncolor" ToolTip="停止折旧" CommandArgument='<%#Eval("AID") %>' OnClick="lbtn_StopRate_Click">停止折旧</asp:LinkButton>
                                    <%--<asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细" OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>--%>
                                    <asp:HiddenField ID="hf_SelectID1" Value='<%#Eval("AID") %>' runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="16">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>
