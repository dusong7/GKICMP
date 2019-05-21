<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyQuestionEdit.aspx.cs" Inherits="GKICMP.studentpage.MyQuestionEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <title>智慧校园行政办公平台</title>
    <link href="../css/style.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
</head>

<body>
    <form id="form1" runat="server">

        <ul>
            <asp:Repeater ID="rpListQ" runat="server" OnItemDataBound="rpListQ_ItemDataBound">
                <ItemTemplate>
                    <asp:HiddenField ID="hf_QSID" runat="server" Value='<%#Eval("QSID") %>' />
                    <li>
                        <ul>
                            <li>
                                <%# Container.ItemIndex + 1%>.<%#Eval("SubContent") %>                                 
                            </li>
                            <li>
                                <asp:RadioButtonList ID="rbl_List" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:RadioButtonList>
                                <asp:CheckBoxList ID="chk_List" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
                                <asp:TextBox ID="txt_List" runat="server" TextMode="MultiLine" Rows="6" Style="width: 890px; resize: none;"></asp:TextBox>
                            </li>

                        </ul>

                    </li>
                </ItemTemplate>
            </asp:Repeater>
            <li>
                <asp:Button ID="btn_Sumbit" runat="server" Text="提  交" CssClass="btn_add" OnClick="btn_Sumbit_Click" />
            </li>
        </ul>
    </form>
</body>
</html>
