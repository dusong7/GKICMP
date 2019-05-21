<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OverTimeEdit.aspx.cs" Inherits="GKICMP.office.OverTimeEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
     <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/js.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });

        function showbox() {
            var lid = document.getElementById("hf_LID").value;
            var a = document.getElementById("txt_Begin").value;
            //var b = document.getElementById("txt_End").value;
            //var c = document.getElementById("txt_Users").value;
            var d = document.getElementById("txt_OMark").value;
            if (a == ""  || d == "") {
                alert("请将带'*'的填写完整后选择审核人");
                return false;
            }
            else {
                return parent.openbox('S_id', 'LeaveAuditUsers.aspx', '&lid=' + lid + '&flag=3', 540, 350, 50);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btn_Search" runat="server" Text="Button" OnClick="btn_Search_Click" Style="display: none" />
        <asp:HiddenField runat="server" ID="hf_LID" />
        <asp:HiddenField runat="server" ID="hf_Url" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">加班信息</th>
                    </tr>
                    <tr id="trSubject" runat="server">
                       
                        <td align="right" width="100px">加班日期：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_Begin" runat="server" datatype="*" Width="140px" nullmsg="请选择加班日期" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})" ></asp:TextBox>
                         <%--   至
                            <asp:TextBox ID="txt_End" runat="server" datatype="*" Width="165px" nullmsg="请选择结束日期" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm',minDate:'#F{$dp.$D(\'txt_Begin\')}'})" ></asp:TextBox>
                            <span style="color: Red; float: none">*</span>--%></td>

                    </tr>
                    <tr>
                       <%-- <td align="right">天数：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_ODays" runat="server" Width="85px"  CssClass="searchbg"></asp:TextBox><span style="color: Red; float: none">*</span>
                        </td>--%>
                        <td align="right">加班类型：</td>
                        <td align="left" colspan="3">
                            <asp:DropDownList ID="ddl_OType" runat="server" datatype="ddl" errormsg="请选择加班类型"></asp:DropDownList><span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                      <tr>
                        <td align="right">参与人员：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_Users" runat="server" name="txt_Users" onlyLeafCheck="true" multiple="true" multiline="true" url="../ashx/Tea.ashx?method=TeaL" CssClass="easyui-combotree" Height="70px" Style="resize: none" Rows="6" TextMode="MultiLine" Width="90%"></asp:TextBox>
                            <span style="color: Red; float: none">*</span> </td>
                    </tr>
                    
                    <tr>
                        <td align="right">加班事由：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_OMark" runat="server" CssClass="searchbg" datatype="*" nullmsg="请填写加班事由" Height="70px" Style="resize: none" Rows="6" TextMode="MultiLine" Width="90%"></asp:TextBox>
                            <span style="color: Red; float: none">*</span> </td>
                    </tr>
                    <tr runat="server" id="traudit">
                        <td align="right">加班审核人：</td>
                        <td align="left" colspan="3">
                            <asp:Repeater ID="rp_List" runat="server">
                                <ItemTemplate>
                                    <span><%#Eval("AuditName") %>
                                        <asp:LinkButton ID="lbtn_Delete" OnClientClick="return  confirm('您确认删除选中的信息吗？');" CommandArgument='<%#Eval("LAID")%>' runat="server" OnClick="lbtn_Delete_Click"><img src="../images/del.png" /></asp:LinkButton>
                                    </span>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Literal runat="server" ID="ltl_Name" Text="暂无人员"></asp:Literal>
                            <img src="../images/selectbtn.png" onclick="return showbox();" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>


