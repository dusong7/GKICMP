<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseContractEdit.aspx.cs" Inherits="GKICMP.purchase.PurchaseContractEdit" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <title>教装项目采购申请</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/select.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
        function getfile() {
            var hfface = $id("hf_UpFile");
            var divone = $id("more").getElementsByTagName("input");
            hfface.value = divone.length;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server"> 
         <asp:HiddenField ID="hf_Images" runat="server" />
        <asp:HiddenField ID="hf_FileID" runat="server" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left" >合同信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">采购项目</td>
                        <td align="left" colspan="3">
                            <asp:DropDownList ID="ddl_PID" runat="server" Width="85%" datatype="ddl" errormsg="请选择采购项目"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">合同名称</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_Name" runat="server" Width="85%" datatype="*" nullmsg="请填写合同名称" CssClass="searchbg" TextMode="MultiLine"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120" >合同编号</td>
                        <td align="left" colspan="3" >
                            <asp:TextBox ID="txt_BidNumber" runat="server" datatype="*" nullmsg="请填写合同编号" CssClass="searchbg" Width="85%" TextMode="MultiLine"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">甲方</td>
                        <td align="left">
                            <asp:TextBox ID="txt_PartyA" runat="server" datatype="*1-50" Width="85%" nullmsg="请填写甲方名称" CssClass="searchbg"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">乙方</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_PartyB" Width="85%"  runat="server"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="note">签订日期</td>
                        <td>
                            <asp:TextBox ID="txt_SignDate" runat="server" onfocus="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请填写签订日期" CssClass="searchbg" MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" valign="top" class="note">合同价格</td>
                        <td>
                            <asp:TextBox ID="txt_Price" runat="server" datatype="*1-50" nullmsg="请填写合同价格" CssClass="searchbg"
                                MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="note">施工工期</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_StartTime" runat="server" datatype="*1-50" nullmsg="请填写施工工期" CssClass="searchbg" MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span><span style="color: red">单位：天</span>
                        </td>

                    </tr>
                     <tr>
                        <td align="right" valign="top" class="note">维保周期</td>
                        <td >
                            <asp:TextBox ID="txt_ServerYears" runat="server" datatype="bigzero" nullmsg="请填写维保周期" CssClass="searchbg" MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span><span style="color: red">单位：年</span>
                        </td>
                          <td align="right" valign="top" class="note">维保开始日期</td>
                        <td >
                            <asp:TextBox ID="txt_ServerDate" runat="server"  nullmsg="请填写维保开始日期" onfocus="WdatePicker({skin:'whyGreen'})" datatype="*" CssClass="searchbg" MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span><span style="color: red"></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="note">维保联系人</td>
                        <td >
                            <asp:TextBox ID="txt_ServerLinkUser" runat="server" datatype="*"  nullmsg="请填写维保联系人" CssClass="searchbg" MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span><span style="color: red"></span>
                        </td>
                          <td align="right" valign="top" class="note">维保联系方式</td>
                        <td >
                            <asp:TextBox ID="txt_ServerPhone" runat="server"  nullmsg="请填写维保联系方式" onfocus="SetCanler()" datatype="*" CssClass="searchbg" MaxLength="50"></asp:TextBox>
                            <span style="color: Red; float: none">*</span><span style="color: red"></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="note">备注</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_PCDesc" TextMode="MultiLine" runat="server" MaxLength="100"
                                Rows="6" Width="99%" Height="100px" CssClass="MultiLinebg"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td align="right">附件：</td>
                        <td colspan="3">
                            <table>
                                <asp:Repeater ID="rp_File" runat="server" OnItemCommand="rpaccess_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="lbtn_load" CommandArgument='<%#Eval("AccessID") %>' CommandName="load"
                                                    runat="server"><%# Eval("AccessName")%></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ibtn_del" runat="server" ImageUrl="~/images/sq.png" CommandArgument='<%#Eval("AccessID") %>'
                                                    CommandName="del" OnClientClick='<%#"return delmessage(\"【"+Eval("AccessName")+"】\")" %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                            <div id="more">
                                <asp:FileUpload ID="fl_UpFile" runat="server" onchange="if(this.value)judge(this.value,this);" />
                                <img src="../images/addfile.gif" alt="" style='cursor: pointer; margin-bottom: -3px'
                                    onclick="addfile('more')" />
                            </div>
                            <asp:HiddenField ID="hf_UpFile" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click"  OnClientClick="return getfile()" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>








