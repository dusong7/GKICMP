<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetEdit.aspx.cs" Inherits="ICMP.assetmanage.AssetEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <script src="../EasyUI/jquery.easyui.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
        function getfile() {
            var hflogo = $id("hf_SImage");
            var careful = $id("divimg").getElementsByTagName("input");
            hflogo.value = careful.length;
            alert('hh')
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_face" runat="server" Value="" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">
                            <asp:Literal ID="ltl" runat="server"></asp:Literal>登记信息</th>
                    </tr>
                    <tr>
                        <td align="right">所属项目：</td>
                        <td>
                            <asp:DropDownList ID="ddl_ProName" Width="80%" runat="server"></asp:DropDownList>
                        </td>
                        <td align="right" width="120">
                            <asp:Literal ID="lbl_Number" runat="server"></asp:Literal>编号：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_DataDesc" runat="server" datatype="*1-50" nullmsg="请填写编号" CssClass="searchbg"
                                MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>

                        <td align="right" width="120">
                            <asp:Literal ID="lbl_Name" runat="server"></asp:Literal>名称：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_AssetName" runat="server" datatype="*1-50" nullmsg="请填写名称" CssClass="searchbg"
                                MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">
                            <asp:Literal ID="lbl_Sum" runat="server"></asp:Literal>数量：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_AssetNum" runat="server" datatype="zheng" nullmsg="请填写数量" CssClass="searchbg"
                                MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">
                            <asp:Literal ID="lbl_Type" runat="server"></asp:Literal>分类：</td>
                        <td align="left">
                            <%--<asp:DropDownList ID="ddl_DataType" runat="server" datatype="ddl" errormsg="请选择分类"></asp:DropDownList>--%>
                            <%if (Flag == 1) { %> 
                                 <asp:TextBox ID="txt_DataType1" cascadeCheck="false" runat="server"  name="Series" onlyLeafCheck="true" url="../ashx/GetBaseDate.ashx?method=GetAssetType&flag=1" CssClass="easyui-combotree"></asp:TextBox><% }%>
                                <%else{ %> 
                                <asp:TextBox ID="txt_DataType2" cascadeCheck="false" runat="server"   name="Series" onlyLeafCheck="true" url="../ashx/GetBaseDate.ashx?method=GetAssetType&flag=2" CssClass="easyui-combotree"></asp:TextBox><% }%>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">规格型号：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_SpecificationModel" runat="server" datatype="*1-50" nullmsg="请填写规格型号" CssClass="searchbg"
                                MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">品牌：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_Brand" runat="server" datatype="*1-50" nullmsg="请填写品牌" CssClass="searchbg"
                                MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">供应商：</td>
                        <td align="left">

                            <asp:DropDownList ID="ddl_Suppliers" runat="server" datatype="ddl" errormsg="请选择供应商"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>

                        </td>

                    </tr>
                    <tr>
                        <td align="right" width="120">价值：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_APrice" runat="server" datatype="bigzero" nullmsg="请填写单价" CssClass="searchbg"
                                MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">计量单位：</td>
                        <td align="left">

                            <asp:DropDownList ID="ddl_AUnit" runat="server" datatype="ddl" errormsg="请选择计量单位"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>

                        </td>
                    </tr>
                    <tr runat="server" id="AGroup"> 
                        <td align="right" width="120">资产分组：</td>
                        <td align="left" colspan="3">
                            <div class="sel" style="float: left">
                                <asp:DropDownList ID="ddl_AssetGroup" runat="server" datatype="ddl" errormsg="请选择资产分组"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                               </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">购置时间：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BuyDate" runat="server" Style="width: 130px" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="*" nullmsg="请填写购置时间"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">计划使用年限：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_PlanYear" runat="server" datatype="zheng" nullmsg="请填写计划使用年限" CssClass="searchbg"
                                MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">采购人：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BuyUser" runat="server" datatype="*1-50" nullmsg="请填写采购人" CssClass="searchbg"
                                MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">
                            <asp:Literal runat="server" ID="ltl_AE" />时间：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_CreateDate" runat="server" Style="width: 130px" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">物品图片：</td>
                        <td colspan="3">
                            <asp:Image ID="img_SImage" runat="server" Width="120px" Height="100px" />
                            <div id="divimg">
                                <asp:FileUpload ID="fl_SImage" runat="server" onchange="if(this.value)judgepic(this.value,this);" />
                            </div>
                            <asp:HiddenField ID="hf_SImage" runat="server" />

                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" width="120">所属校区：</td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddl_CID" runat="server" datatype="ddl" errormsg="请选择校区"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" valign="top" width="120">物品描述：</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_AssetMark" TextMode="MultiLine" runat="server" MaxLength="100"
                                Rows="6" Width="70%" Height="100px" CssClass="MultiLinebg"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

