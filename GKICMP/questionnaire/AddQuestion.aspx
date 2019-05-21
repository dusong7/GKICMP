<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddQuestion.aspx.cs" Inherits="GKICMP.questionnaire.AddQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园教务管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript" src="../js/AddOption.js"></script>
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
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_QID" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">问卷题目</th>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" width="900px">
                            <asp:TextBox ID="txt_QuestName" runat="server" Width="700px" datatype="*" nullmsg="请填写问卷题目"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_Type" runat="server" onchange="fun_Show(this)">
                                <asp:ListItem Value="0">单选</asp:ListItem>
                                <asp:ListItem Value="1">多选</asp:ListItem>
                                <asp:ListItem Value="2">问答题</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="left" colspan="4">题目选项</th>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div id="t_view">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo" id="addoption">
                                    <tr>
                                        <td>
                                            <input type="text" name="option" size="100" /></td>
                                        <td>
                                            <img alt="" id="IB1_Add" src="../images/addq.png" onclick="Fun_AddOption()" />&nbsp;
                                    <img alt="" id="IB1_Del" src="../images/delq.png" onclick="return confirm('至少保留两项！')" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <input type="text" name="option" size="100" />
                                        </td>
                                        <td>
                                            <img alt="" id="IB2_Add" src="../images/addq.png" onclick="Fun_AddOption()" />&nbsp;
                                    <img alt="" id="IB2_Del" src="../images/delq.png" onclick="return confirm('至少保留两项！')" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
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




