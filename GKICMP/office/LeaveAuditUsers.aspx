<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveAuditUsers.aspx.cs" Inherits="GKICMP.office.LeaveAuditUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">

        function getvalue(a) {
            var cid = document.getElementById("hf_CheckIDS").value;
            if (cid == "") {
                alert("请选择人员");
                return false;

            }
            var iscurrent = 0;
            if ($("#cb_IsCurrent").is(":checked"))
                iscurrent = 1;
            var cname = $(a).next().val();
            var state = $val("hf_state");
            var lid = document.getElementById("hf_LID").value;

            var aresult = 0;
            $.ajax({
                url: "../ashx/LeaveAuditUserHandler.ashx",
                cache: false,
                type: "GET",
                async: false,
                data: "method=AddLeaveAuditUser&uid=" + cid + "&lid=" + lid + '&state=' + state + "&iscur=" + iscurrent,
                dataType: "json",
                success: function (data) {
                    if (data.result == "fail") {
                        aresult = -1;
                    }
                    if (data.result == "same") {
                        aresult = -2;
                    }
                }
            });
            if (aresult == -1) {
                alert("系统提示：提交失败");
                return;
            }
            else if (aresult == -2) {
                alert("系统提示：此审核人已存在，请重新选择");
                return;
            }
            else {
                $.opener("A_id").document.getElementById('btn_Search').click();
            }
            $.close("S_id");
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 29px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_Flag" runat="server" />
        <asp:HiddenField ID="hf_LID" runat="server" />
        <asp:HiddenField ID="hf_state" runat="server" />
        <div class="listcent pad0" style="min-width: 100px">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">请假信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">审核人：</td>
                        <td align="left" class="auto-style1">
                            <ul id="cbl_Role" class="edilab">
                                <asp:Repeater runat="server" ID="rp_List">
                                    <ItemTemplate>
                                        <li>
                                            <label class="wxz" id='ck_<%#Eval("UID")%>l'>
                                                <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("UID") %>' id='ck_<%#Eval("UID") %>' />
                                                <%#Eval("DepName")%></label><%#Eval("RealName")%></li>



                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </td>
                    </tr>
                    <tr runat="server" id="tr_null">
                        <td colspan="3">系统暂未设置审核人，情联系系统管理员</td>
                    </tr>
                    <tr runat="server" id="tr1">
                        <td align="right" width="100px">是否与签：</td>
                        <td>
                       <ul id="cbl_Role1" class="edilab">
                           <li>
                               <label class="wxz" id='cb_IsCurrentl'>
                                   <asp:CheckBox ID="cb_IsCurrent" onclick="setid(this.id)" runat="server" /></label></li>

                       </ul>
                        </td>
                    </tr>
                    <tr>
                         <td colspan="2" style="line-height:20px">
                            <span style="color:red;">操作说明：1.此操作多选为同一级审核,没有先后关系；<br />
                                2.如勾选，则选择中的审核人必须全部审核才能进入到下一级；<br />
                                3.不勾选，则选择的审核人中只要有一人审核通过，则进入到下一级</span>
                    </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="确定" CssClass="listbtncss listadd" OnClientClick='getvalue()' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

