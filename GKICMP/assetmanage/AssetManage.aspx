<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetManage.aspx.cs" Inherits="GKICMP.assetmanage.AssetManage" %>

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
                    return openbox('A_id', 'AssetEdit.aspx', 'flag=' + flag, 900, 720, -1);
                }
                else {
                    return openbox('A_id', 'AssetEditOffice.aspx', 'flag=' + flag, 900, 660, -1);
                }
            });
            $('#btn_Input').click(function () {
                //var flag = document.getElementById("hf_Flag").value;
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'AssetImport.aspx', '', 900, 500, -1);
            });
        });
        function editinfo(e) {
            var flag = document.getElementById("hf_Flag").value;
            var id = $(e).next().val();
            if (flag == 1) {
                return openbox('A_id', 'AssetEdit.aspx', 'id=' + id + '&flag=' + flag, 900, 660, 0);
            }
            else {
                return openbox('A_id', 'AssetEditOffice.aspx', 'id=' + id + '&flag=' + flag, 900, 660, 0);
            }
        }
        function viewinfo(e) {
            var flag = document.getElementById("hf_Flag").value;
            var id = $(e).next().val();
            return openbox('A_id', 'AssetDetail.aspx', 'id=' + id + '&flag=' + flag, 900, 460, 4);
        }

        //耗材领用
        function borrowinfo(e) {
            var id = $(e).next().val();
            var assetNum = $(e).next().next().val();
            var flag = document.getElementById("hf_Flag").value;
            if (assetNum <= 0) {
                alert('耗材数量为0,不允许领用');
                return false;
            }
            else {
                //return openbox('A_id', 'AssetBorrowEdit.aspx', 'id=' + id + '&flag=' + flag, 900, 400, 17);
                return openbox('A_id', 'AssetBorrowEdit.aspx', 'id=' + id + '&flag=' + flag + '&abflag=2', 900, 400, 17);
            }
        }

        //资产借出
        function backinfo(e) {
            var id = $(e).next().val();
            var assetNum = $(e).next().next().val();
            var flag = document.getElementById("hf_Flag").value;
            if (assetNum <= 0) {
                alert('资产数量为0,不允许借出');
                return false;
            }
            else {
                //return openbox('A_id', 'AssetBorrowEdit.aspx', 'id=' + id + '&flag=' + flag, 900, 400, 18);
                return openbox('A_id', 'AssetBorrowEdit.aspx', 'id=' + id + '&flag=' + flag + '&abflag=1', 900, 400, 18);
            }
        }
        //资产领用
        function getinfo(e) {
            var id = $(e).next().val();
            var assetNum = $(e).next().next().val();
            var flag = document.getElementById("hf_Flag").value;
            if (assetNum <= 0) {
                alert('资产数量为0,不允许借出');
                return false;
            }
            else {
                //return openbox('A_id', 'AssetBorrowEdit.aspx', 'id=' + id + '&flag=2' , 900, 400, 18);
                return openbox('A_id', 'AssetBorrowEdit.aspx', 'id=' + id + '&flag=' + flag + '&abflag=3', 900, 400, 18);
            }
        }

        //资产报废
        function scrapinfo(e) {
            var id = $(e).next().val();
            var flag = document.getElementById("hf_Flag").value;
            var assetNum = $(e).next().next().val();
            if (assetNum <= 0) {
                alert('资产数量为0不允许报废');
                return false;
            } else {
                return openbox('A_id', 'ScrapEdit.aspx', 'id=' + id + '&flag=' + flag, 900, 400, 65);
            }
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
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="资产管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td align="right" width="60">
                            <asp:Label ID="lbl_Number" runat="server"></asp:Label>编号：</td>
                        <td width="200">
                            <asp:TextBox ID="txt_DataDesc" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">
                            <asp:Label ID="lbl_Name" runat="server"></asp:Label>名称：</td>
                        <td width="200">
                            <asp:TextBox ID="txt_AssetName" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="100">
                            <asp:Label ID="lbl_Type" runat="server"></asp:Label>分类：</td>
                        <td width="200">
                            <div class="sel" style="float: left">
                                <%--   <asp:DropDownList ID="ddl_DataType" runat="server"></asp:DropDownList>--%>
                                <%if (Flag == 1)
                                  { %>
                                <asp:TextBox ID="txt_DataType1" cascadeCheck="false" runat="server" name="Series" onlyLeafCheck="true" url="../ashx/GetBaseDate.ashx?method=GetAssetType&flag=1" CssClass="easyui-combotree"></asp:TextBox><% }%>
                                <%else
                                  { %>
                                <asp:TextBox ID="txt_DataType2" cascadeCheck="false" runat="server" name="Series" onlyLeafCheck="true" url="../ashx/GetBaseDate.ashx?method=GetAssetType&flag=2" CssClass="easyui-combotree"></asp:TextBox><% }%>
                            </div>
                        </td>
                         <td align="right" width="60">资产分组</td>
                        <td  id="AssetGroup" runat="server">
                             <div class="sel" style="float: left">
                            <asp:DropDownList ID="ddl_AssetGroup" runat="server"></asp:DropDownList>
                                 </div>
                        </td>
                         <td align="right" width="60">是否上报</td>
                        <td  id="IsReport" runat="server">
                             <div class="sel" style="float: left">
                            <asp:DropDownList ID="ddl_Report" runat="server">
                                <asp:ListItem Value="-2">--请选择--</asp:ListItem>
                                 <asp:ListItem Value="1">已上报</asp:ListItem>
                                 <asp:ListItem Value="0">未上报</asp:ListItem>
                            </asp:DropDownList>
                                 </div>
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
                            <span style="color: red; float: left; margin-left: 20px; font-size: 14px; font-weight: bold">
                                <asp:Literal ID="ltl_Sum" runat="server"></asp:Literal></span>
                            <asp:Button ID="btn_Add" runat="server" Text="添加"  CssClass="listbtncss listadd" />
                            <asp:Button ID="btn_Delete" runat="server" Text="删除"  CssClass="listbtncss listdel" OnClick="btn_Delete_Click" />
                              <asp:Button ID="lbtn_Report" runat="server" Text="上报"   CssClass="listbtncss listreport"   OnClick="lbtn_MoreSB_Click" />
                            <asp:Button ID="btn_Input" runat="server" Text="导入"   CssClass="listbtncss listinput" />
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)"></label></th>
                        <th align="center">资产大类
                        </th>
                        <th align="center">
                            <asp:Label ID="lbl_Type1" runat="server"></asp:Label>分类</th>
                        <th align="center">
                            <asp:Label ID="lbl_Name1" runat="server"></asp:Label>名称</th>
                        <th align="center">
                            <asp:Label ID="lbl_Number1" runat="server"></asp:Label>编号</th>
                        <th align="center">
                            <asp:Label ID="lbl_Sum" runat="server"></asp:Label>数量</th>
                        <th align="center">品牌</th>
                        <th align="center">规格型号</th>
                        <th align="center">价值</th>
                        <th align="center">供应商</th>
                        <th align="center">购置时间</th>
                        <th align="center">所属校区</th>
                        <th align="center">资产分组</th>
                        <th align="center">是否上报</th>
                        <th width="100px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("AID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("AID") %>' <%#GetState(Eval("IsReport")) %> id='ck_<%#Eval("AID") %>' /></label>
                                </td>
                                <td><%#Eval("MaxTypeName") %></td>
                                <td><%#Eval("TypeName")%></td>
                                <td><%#Eval("AssetName")%></td>
                                <td><%#Eval("DataDesc")%></td>
                                <td><%#Eval("AssetNum")%></td>
                                <td><%#Eval("Brand")%></td>
                                <td><%#Eval("SpecificationModel")%></td>
                                <td><%#Eval("APrice")%></td>
                                <td><%#Eval("SuppliersName")%></td>
                                <td><%#Eval("BuyDate","{0:yyyy-MM-dd}")%></td>
                                <td><%#Eval("CName")%></td>
                                <td><%#Eval("AssetGroupName")%></td>
                                <td><%#Eval("IsReport").ToString()=="0"?"<span style='color:red'>未上报</span>":"已上报"%></td>
                                <td>
                                    <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor" Visible='<%#Eval("IsReport").ToString()=="1" ? false:true %>' ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField9" Value='<%#Eval("AID") %>' runat="server" />
                                    <%--<asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="listbtn btneditcolor"  Visible='<%#GetAcceptName(Eval("IsReport"),Flag)%>'  ToolTip="编辑" OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>--%>
                                    <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="listbtn btndetialcolor" ToolTip="详细" OnClientClick='return viewinfo(this);'>详细</asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField7" Value='<%#Eval("AID") %>' runat="server" />
                                    <asp:LinkButton ID="lbtn_Scrap" runat="server" CssClass="listbtn btnreportncolor" Visible='<%#Eval("Flag").ToString()=="2" ? false:true %>' ToolTip="报废" OnClientClick='return scrapinfo(this);'>报废</asp:LinkButton>
                                    <asp:HiddenField ID="hf_SelectID1" Value='<%#Eval("AID") %>' runat="server" />
                                    <asp:HiddenField ID="hf_AssetNum" Value='<%#Eval("AssetNum") %>' runat="server" />

                                    <%--耗材领用--%>
                                    <asp:LinkButton ID="lbtn_Borrow" runat="server" CssClass="listbtn btndetialcolor" Visible='<%#Eval("Flag").ToString()=="1" ? false:true %>' ToolTip="领用" OnClientClick='return borrowinfo(this);'>领用</asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField1" Value='<%#Eval("AID") %>' runat="server" />
                                    <asp:HiddenField ID="HiddenField2" Value='<%#Eval("AssetNum") %>' runat="server" />

                                    <%--资产领用--%>
                                    <asp:LinkButton ID="lbtn_get" runat="server" CssClass="listbtn btndetialcolor" Visible='<%#Eval("Flag").ToString()=="1" ? true:false %>' ToolTip="领用" OnClientClick='return getinfo(this);'>领用</asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField5" Value='<%#Eval("AID") %>' runat="server" />
                                    <asp:HiddenField ID="HiddenField6" Value='<%#Eval("AssetNum") %>' runat="server" />

                                    <%--资产借出--%>
                                    <asp:LinkButton ID="lbtn_Back" runat="server" CssClass="listbtn btneditcolor" Visible='<%#Eval("Flag").ToString()=="2" ? false:true %>' ToolTip="借出" OnClientClick='return backinfo(this);'>借出</asp:LinkButton>
                                    <asp:HiddenField ID="HiddenField3" Value='<%#Eval("AID") %>' runat="server" />
                                    <asp:HiddenField ID="HiddenField4" Value='<%#Eval("AssetNum") %>' runat="server" />

                                    <%--<asp:LinkButton ID="lbtn_Report"  runat="server" CssClass="listbtn btnreportncolor" Visible='<%#Eval("IsReport").ToString()=="1" ? false:true %>' ToolTip="上报" CommandArgument='<%#Eval("AID") %>' OnClick="lbtn_SB_Click" OnClientClick="return  confirm('您确认要上报该信息吗？');">上报</asp:LinkButton>--%>
                                    <asp:LinkButton ID="lbtn_Report" runat="server" CssClass="listbtn btnreportncolor" Visible='<%#GetAcceptName(Eval("IsReport"),Flag)%>' ToolTip="上报" CommandArgument='<%#Eval("AID") %>' OnClick="lbtn_SB_Click" OnClientClick="return  confirm('您确认要上报该信息吗？');">上报</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="15">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>

