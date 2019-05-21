<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuestionnaireDetail.aspx.cs" Inherits="GKICMP.questionnaire.QuestionnaireDetail" %>

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
                        <th colspan="4" align="left">
                            <div class="xxsm">
                                <ul>
                                    <li class="selected"><a>问卷信息</a></li>
                                    <li><a href="SubjectDetail.aspx?id=<%=QID %>">问卷题目</a></li>
                                </ul>
                            </div>
                        </th>
                    </tr>
                    <tr>
                        <td align="right" width="120">问卷名称：</td>
                        <td align="left" colspan="3">
                            <asp:Literal runat="server" ID="ltl_QuestName"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">是否实名：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_IsName"></asp:Literal>
                        </td>
                        <td align="right" width="120">截止日期：</td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltl_LastDate"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">投票说明：</td>
                        <td align="left" colspan="3">
                            <asp:Literal runat="server" ID="ltl_Questxplain"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">投票人群：</td>
                        <td align="left" colspan="3">
                            <asp:Literal runat="server" ID="ltl_Role"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">创建人：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_CreateUser"></asp:Literal></td>
                        <td align="right">创建日期：</td>
                        <td>
                            <asp:Literal runat="server" ID="ltl_CreateDate"></asp:Literal></td>
                    </tr>
                     <tr>
                        <td colspan="4" align="center"> <input type="button" name="button" id="cancell" value="返回" class="editor" onclick="window.location.href = 'QuestionnaireList.aspx';" /></td>
                        
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

