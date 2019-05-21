
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayProjectEdit.aspx.cs" Inherits="GKICMP.payment.PayProjectEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />


    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/ImgPreview.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
     <script src="../js/choice.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
    </script>
     <style>
        .edilab label {
                       float: none;
                      }
        .edilab input {
                   height: 13px;
                       }
         .jfxm tr:last-child td {
          background:none}
         .listinfo label {
         margin-top:0px}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_face" runat="server" Value="" />
         <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
         <asp:HiddenField ID="hf_Count" runat="server" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">缴费项目信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">缴费项目名称</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_ProjectName" runat="server" CssClass="searchbg" datatype="*" nullmsg="请填写缴费项目名称"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>

                    <tr>
                       <td align="right" width="120">缴费项</td>
                          <td align="left"  >
                              <%--<asp:CheckBoxList ID="cbl_Button" CssClass="edilab" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CheckBox_Click" RepeatDirection="Horizontal" RepeatColumns="10" RepeatLayout="Flow">

                              </asp:CheckBoxList>--%>

                          <table width="100%" border="0" cellspacing="0" cellpadding="0" class="jfxm">  
                            <tbody>

                                <tr>
                                    <th width="5%" align="center" style="padding-left: 11px;padding-right: 10px;">
                                        <label class="wxz" id="checkalll">
                                            <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)" >
                                        </label>
                                    </th>
                                    <th align="left" colspan="2" style=" text-indent:10px">缴费项</th>
                                    <th align="left" colspan="2" style=" text-indent:10px">缴费金额</th>
                                </tr>
                                <asp:Repeater runat="server" ID="rp_List" >
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <label class="wxz" id='ck_<%#Eval("PIID")%>l'>
                                                   <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("PIID")%>' id='ck_<%#Eval("PIID") %>'  /></label>
                                            </td>
                                            <td colspan="2"><%#Eval("PayName")%></td>
                                            <td colspan="2"><%#Eval("PayCount")%></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr runat="server" id="tr_null">
                                    <td colspan="4">暂无记录
                                    </td>
                                </tr>


                            </tbody>
                        </table>


                     </td>
                   </tr>


                   <%-- <tr>
                          <td align="right" width="120">缴费总金额</td>
                          <td align="left" colspan="3">
                              <asp:TextBox ID="txt_PayCount" runat="server" CssClass="searchbg"  MaxLength="50"></asp:TextBox>
                          </td>
                    </tr>--%>


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

