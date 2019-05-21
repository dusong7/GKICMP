<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubjectDetail.aspx.cs" Inherits="GKICMP.questionnaire.SubjectDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />

    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <style>
        body {
            background-color: white;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">
                            <div class="xxsm">
                                <ul>
                                    <li><a href="QuestionnaireDetail.aspx?id=<%=QID %>">问卷信息</a></li>
                                    <li class="selected"><a>问卷题目</a></li>
                                </ul>
                            </div>
                        </th>
                    </tr>
                </tbody>
            </table>
            <ul>
                <asp:Repeater ID="rpListQ" runat="server" OnItemDataBound="rpListQ_ItemDataBound">
                    <ItemTemplate>
                        <asp:HiddenField ID="hf_QSID" runat="server" Value='<%#Eval("QSID") %>' />
                        <li>
                            <ul style="height: 80px;">
                                <li style="text-align: left; background-color: white;">
                                    <%# Container.ItemIndex + 1%>.<%#Eval("SubContent") %>：<span>[<%#getType(Eval("SubType"))%>]</span>
                                </li>
                                <li>
                                    <asp:Repeater runat="server" ID="rp_List">
                                        <ItemTemplate>
                                            <asp:Literal runat="server" ID="ltl_Value" Text='<%#Eval("OptionVlaue") %>'></asp:Literal>.<asp:Literal runat="server" ID="ltl_Content" Text='<%#Eval("OptionContent") %>'></asp:Literal>
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </li>

                            </ul>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <ul>
                <li>
                    <input type="button" name="button" id="cancell" value="返回" class="editor" onclick="window.location.href = 'QuestionnaireList.aspx';" />
                </li>
            </ul>
        </div>
    </form>
</body>
</html>

