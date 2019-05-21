<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuestionResult.aspx.cs" Inherits="GKICMP.questionnaire.QuestionResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <style>
        .percent {
            width: 152px;
            height: 15px;
            display: block;
            border: 1px solid #e5e5e5;
            border-radius: 2px;
            float: left;
            position: relative;
            top: 5px;
            margin-right: 5px;
        }

        .percentbar {
            background: url(../images/vote_cl_v2.png) left center no-repeat;
            margin-left: 1px;
            height: 14px;
        }

        .editor {
            width: 98px;
            height: 39px;
            color: #fff;
            border: none;
            background: url(../images/green_sb_09.png);
            font-size: 18px;
            margin: 10px;
            padding: 0px;
            text-indent: 0px;
            text-align: center;
        }

        .auto-style1 {
            height: 39px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <div class="listcent pad0">

            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <asp:Repeater runat="server" ID="rp_List" OnItemDataBound="rpList_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td colspan="3" style="text-align: left; text-indent: 10px">
                                    <span align="left">第<%# Container.ItemIndex + 1%>题:</span>
                                    <span><%#Eval("SubContent")%>:</span><span>[<%#getType(Eval("SubType"))%>]</span></td>
                                <asp:HiddenField ID="hf_uid" runat="server" Value='<%#Eval("QSID") %>' />
                            </tr>

                            <asp:Repeater runat="server" ID="rp_ListResult">
                                <HeaderTemplate>
                                    <tr>
                                        <td style="background: #e0e0e0; width: 30%">选项</td>
                                        <td style="background: #e0e0e0; width: 10%">小计</td>
                                        <td style="background: #e0e0e0; width: 50%">比例</td>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("OptionContent")%></td>
                                        <td><%#Eval("OptionResult")%></td>
                                        <td style="text-align: left">
                                            <div class="percent">
                                                <div class="percentbar" <%#GetWidth(Eval("Persent"))%>></div>
                                            </div>
                                            <%#Eval("Persent")%></td>
                                        <%-- <td>1</td>
                                    <td>2</td>
                                    <td>3</td>--%>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr style="background: #e0e0e0;">
                                        <td>投票总人数
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltl_Count" runat="server"></asp:Literal></td>
                                        <td></td>
                                    </tr>
                                </FooterTemplate>
                            </asp:Repeater>
                            <asp:Repeater runat="server" ID="rp_ListAnswer">
                                <ItemTemplate>
                                    <tr>
                                        <td colspan="3" style="text-align: left; text-indent: 20px"><%# Container.ItemIndex + 1%>.<%#Eval("OID")%></td>
                                        <%-- <td>1</td>
                                    <td>2</td>
                                    <td>3</td>--%>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td class="auto-style1">暂无记录</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                            <asp:Button ID="btn_Back" runat="server" Text="返回" CssClass="editor" OnClick="btn_Back_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>


