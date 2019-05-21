<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayEdit.aspx.cs" Inherits="GKICMP.payment.PayEdit" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    
   <%-- <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>--%>

    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/common.js"></script>

     <style>
         .jfxm tr:last-child td {
          background:none}
         .listinfo label {
         margin-top:0px}
    </style>

    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
        
        function showbox() {
            var name = document.getElementById("txt_ProjectName").value;
            if (name == "" ) 
            {
                alert("请填写缴费项目名称后再录入缴费项");
                return;
            }
            else
            {
                var eid = document.getElementById("hf_PPID").value;
                return openbox('Add_id', 'PayItemSelect.aspx?eid=' + eid, '', 800, 340, -1);
            }
           
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_face" runat="server" Value="" />
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_Count" runat="server" />
        <asp:HiddenField runat="server" ID="hf_PPID" />
          <asp:ImageButton ID="btnsear" runat="server" OnClick="imgbtn_inquiry_Click" Style="display: none" />
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
                        <td align="left">

                            <table width="99%" id="tb_Right" class="jfxm">
                                 <tr>
                                    <td colspan="4">
                                       <img src="../images/addfile.gif" onclick="showbox()" />
                                        &nbsp;&nbsp; <span style="color: Red">注：请填写缴费项目名称后再录入缴费项</span>
                                    </td>
                                </tr>

                                <tr style="text-align: center">
                                    <td>缴费项</td>
                                    <td>缴费金额</td>
                                    <td colspan="2" style="width: 10%">操作</td>
                                </tr>
                                <asp:Repeater runat="server" ID="rp_List123">
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center"><%#Eval("PayName") %></td>
                                            <td align="center"><%#Eval("PayCount") %></td>
                                            <td align="center" colspan="2">
                                                <asp:LinkButton ID="lbtn_Delete" runat="server" ToolTip="删除" CommandArgument='<%#Eval("PIID") %>' OnClientClick="return confirm('确认删除选中信息');" OnClick="lbtn_Delete_Click">
                                                    <img src="../images/d13.png" />
                                                </asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr runat="server" id="tr_null">
                                    <td colspan="4" align="center">暂无记录</td>
                                </tr>
                            </table>


                        </td>
                    </tr>



                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                           <%-- <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />--%>
                             <input type="button" id="Cancell1" class="editor" value="取消" onclick="javascript: window.history.back(-1);" />
                        </td>
                    </tr>

                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

