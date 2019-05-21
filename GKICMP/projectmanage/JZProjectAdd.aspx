<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JZProjectAdd.aspx.cs" Inherits="GKICMP.projectmanage.JZProjectAdd" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="utf-8">
    <title>教装项目采购申请</title>
   <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });

     </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">教装项目采购申请</th>
                    </tr>
                    <tr>
                        <td align="right">项目名称</td>
                        <td align="left" colspan="3">
                            <asp:TextBox runat="server" ID="txt_ProName" Width="90%" datatype="*" nullmsg="请填写项目名称"></asp:TextBox>
                             <span style="color: Red; float: none">*</span>
                        </td>
                       
                    </tr>
                    <tr>
                        <td align="right">资金来源</td>
                        <td align="left">
                            <div class="sel" style="float: left">
                                <asp:DropDownList ID="ddl_Financed" runat="server" datatype="ddl" errormsg="请选择资金来源"></asp:DropDownList>
                                <span style="color: Red; float: none">*</span>
                            </div>
                        </td>
                        <td align="right">项目概算</td>
                        <td align="left">
                            <asp:TextBox ID="txt_ProBudget" runat="server" datatype="bigzero" nullmsg="请填写资金预算"></asp:TextBox>
                             <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">项目类型</td>
                        <td align="left">
                            <div class="sel" style="float: left">
                                <asp:DropDownList ID="ddl_ProType" runat="server" datatype="ddl" errormsg="请选择项目类型" AutoPostBack="True" OnSelectedIndexChanged="ddl_ProType_SelectedIndexChanged">
                                </asp:DropDownList>
                                <span style="color: Red; float: none">*</span>
                            </div>
                        </td>
                        <td align="right">项目内容</td>
                        <td align="left">
                            <div class="sel" style="float: left">
                                <asp:DropDownList ID="ddl_ProContent" runat="server" datatype="ddl" errormsg="请选择项目内容">
                                </asp:DropDownList>
                                 <span style="color: Red; float: none">*</span>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" valign="top" class="note">建筑面积</td>
                        <td>
                            <asp:TextBox runat="server" ID="txt_ProArea" datatype="bigzero" nullmsg="请填写建筑面积"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" valign="top" class="note">数量</td>
                        <td>
                            <asp:TextBox runat="server" ID="txt_Amount" datatype="zheng" nullmsg="请填写数量"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="note">单位负责人</td>
                        <td>
                            <asp:TextBox runat="server" ID="txt_DepPerson" datatype="*" nullmsg="请填写单位负责人"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" valign="top" class="note">联系电话</td>
                        <td>
                            <asp:TextBox runat="server" ID="txt_DepLinkno" datatype="m" nullmsg="请填写联系电话"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="note">备注</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_ProDesc" TextMode="MultiLine" Rows="6" runat="server" Width="90%"></asp:TextBox>
                        </td>
                    </tr>

                     <tr runat="server" id="tr_file">
                        <td align="right">附件 </td>
                        <td align="left" colspan="3">
                            <table>
                                <asp:Repeater ID="rp_File" runat="server" OnItemCommand="rpaccess_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="lbn_load" CommandArgument='<%#Eval("PCFile") %>' CommandName="load"
                                                    runat="server"><%#getFileName(Eval("PCFile").ToString())%></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate> 
                                </asp:Repeater>
                            </table>
                            <asp:FileUpload ID="fl_UpFile" runat="server" onchange="if(this.value)judge(this.value,this);" />
                            <asp:HiddenField runat="server" ID="hf_file" />
                            <asp:HiddenField runat="server" ID="hf_RFile" />
                        </td>
                    </tr>


                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' /></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>





