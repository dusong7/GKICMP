<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScoreManage.aspx.cs" Inherits="GKICMP.educational.ScoreManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园教务管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });

        function showbox() {
            var eid = document.getElementById("hf_EID").value;
            return openbox('A_id', 'ScoreImport.aspx?eid=' + eid, '', 800, 500, 64);
        }
    </script>
    <style>
        .listinfo td {
            line-height: 30px;
        }

        .listinfo tr:nth-child(2n+1) td {
            background: none;
        }

        table tr:last-child td {
            border-bottom: #e4e4e4 1px solid;
        }

        table tr td:last-child {
            border-right: #e4e4e4 1px solid;
        }

        .auto-style1 {
            height: 36px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_EID" />
      <%--  <asp:HiddenField runat="server" ID="hf_ERID1" />
        <asp:HiddenField runat="server" ID="hf_OldERID" />
        <asp:HiddenField runat="server" ID="hf_OldESID" />
        <asp:HiddenField runat="server" ID="hf_OldUID" />
        <asp:HiddenField runat="server" ID="hf_examroom" />--%>
        <div class="listcent pad0">
            <table id="td" runat="server" width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="2" align="left">考试成绩</th>
                    </tr>
                    <tr>
                        <td align="left">
                           <%-- <img src="../images/addfile.gif" onclick="showbox()" />--%>
                            <input type="button" id="btn_Import" value="导入" onclick="showbox()" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">

                            <table width="99%" id="tb_Right" style="border: 1px">
                                <tr style="text-align: center">
                                    <asp:Literal ID="ltl_Header" runat="server"></asp:Literal>
                                </tr>
                                <asp:Literal ID="ltl_Rows" runat="server">
                                </asp:Literal>
                                <tr runat="server" id="tr_null">
                                    <td colspan="4" align="center"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%--<tr>
                        <td align="left">

                            <table width="99%" style="border: 1px">
                                <tr style="text-align: center">
                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                </tr>
                                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("UName")%></td>
                                            <asp:Repeater ID="Repeater" runat="server">
                                                <ItemTemplate>
                                                    <td>
                                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                    </td>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>--%>

                    <tr>
                        <td colspan="5" align="center">
                            <asp:Button ID="btn_Submit" runat="server" Text="提交" CssClass="submit" OnClientClick="return aa()" OnClick="btn_Submit_Click" />
                            <%--<input type="button" class="editor" id="return" value="返回" onclick='javascript: window.history.back(-1);' />--%>
                            <%--<asp:Button ID="btn_OutPut" runat="server" Text="导出"  CssClass="submit" OnClick="btn_OutPut_Click" />--%>
                            <asp:Button ID="btn_Cancel" runat="server" Text="返回" CssClass="editor" OnClick="btn_Cancel_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:HiddenField ID="hf_Value" runat="server" />
        </div>
    </form>
    <script>
        function aa() {
            var inputid = "";
            var inputArray = $("input[type='text']");//取到所有的input text 并且放到一个数组中  
            inputArray.each(//使用数组的循环函数 循环这个input数组  
                function () {
                    var input = $(this);//循环中的每一个input元素  
                    inputid += input.attr("id") + ":" + $('#' + input.attr("id")).val() + ",";//查看循环中的每一个input的id  
                }

            )
            document.getElementById("hf_Value").value = inputid
            return true;
        }
    </script>
</body>
</html>


