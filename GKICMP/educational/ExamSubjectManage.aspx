<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExamSubjectManage.aspx.cs" Inherits="GKICMP.educational.ExamSubjectManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园教务管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <%--<link href="../css/demo.css" rel="stylesheet" />--%>
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
            return openbox('A_id', 'SubjectSetEdit.aspx?eid=' + eid, '', 800, 300, 64);
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_EID" />
        <asp:HiddenField runat="server" ID="hf_ERID1" />
        <asp:HiddenField runat="server" ID="hf_OldERID" />
        <asp:HiddenField runat="server" ID="hf_OldESID" />
        <asp:HiddenField runat="server" ID="hf_OldUID" />
        <asp:HiddenField runat="server" ID="hf_examroom" />
        <asp:ImageButton ID="btnsear" runat="server" OnClick="imgbtn_inquiry_Click" Style="display: none" />
        <div class="listcent">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo1">
                <tbody>
                    <tr>
                        <th align="left">
                            <div class="xxsm">
                                <ul>
                                    <li><a href="ExamEdit.aspx?id=<%=EID%>">考试信息</a></li>
                                    <li class="selected"><a href="ExamSubjectManage.aspx?id=<%=EID%>">考试设置</a></li>
                                    <li><a href="SeatingSequenceManage.aspx?id=<%=EID%>">考场座位表</a></li>
                                    <li><a href="InvigilatorManage.aspx?id=<%=EID %>">监考表</a></li>
                                </ul>
                            </div>
                        </th>
                    </tr>
                </tbody>
            </table>
            <div class="listcent pad0">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                    <tbody>
                        <tr>
                            <th colspan="2" align="left">科目安排</th>
                        </tr>
                        <tr>
                            <td align="left">
                                <img src="../images/addfile.gif" onclick="showbox()" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <table width="99%" id="tb_Right" style="border: 1px">
                                    <tr style="text-align: center">
                                        <td style="font-weight: bold;">考试科目
                                        </td>
                                        <td style="font-weight: bold;">开始时间
                                        </td>
                                        <td style="font-weight: bold;">结束时间
                                        </td>
                                        <td style="font-weight: bold;">阅卷老师
                                        </td>
                                        <td style="font-weight: bold; width: 5%">操作
                                        </td>
                                    </tr>
                                    <asp:Repeater runat="server" ID="rp_List" OnItemDataBound="rp_List_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td align="center"><%#Eval("CourseName") %></td>
                                                <asp:HiddenField ID="hf_CIDS" runat="server" Value='<%#Eval("CID") %>' />
                                                <td align="center"><%#Eval("BeginDate","{0:yyyy-MM-dd HH:mm}") %></td>
                                                <td align="center"><%#Eval("EndDate","{0:yyyy-MM-dd HH:mm}") %></td>

                                                <td align="center">
                                                    <asp:TextBox ID="txt_TIDS" cascadeCheck="false" runat="server" multiline="true" multiple="true" name="Tearcher" onlyLeafCheck="true" url="../ashx/ClassRoomList.ashx?method=TList" CssClass="easyui-combotree" TextMode="MultiLine" Height="30px" Width="300px"></asp:TextBox></td>

                                                <td align="center">
                                                    <asp:LinkButton ID="lbtn_Delete" runat="server" ToolTip="删除" CommandArgument='<%#Eval("ESID") %>' OnClientClick="return confirm('确认删除选中信息');" OnClick="lbtn_Delete_Click">
                                                    <img src="../images/d13.png" />
                                                    </asp:LinkButton>
                                                </td>

                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <tr runat="server" id="tr_null">
                                        <td colspan="5" align="center">暂无记录</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <th colspan="2" align="left">监考教师安排</th>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Button ID="Button1" runat="server" Text="分配教师" OnClick="Button1_Click" /><asp:TextBox ID="txt_TCount" runat="server" Text="2" datatype="zheng" Width="25px" nullmsg="请选择监考教师数"  ></asp:TextBox><span style="color:red">监考教师数量，默认2位教师，可修改数量</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <table width="99%" style="border: 1px" id="print">
                                    <tr style="text-align: center">
                                        <td style="font-weight: bold;">考场
                                        </td>
                                        <td style="font-weight: bold;">考试科目及监考教师
                                        </td>
                                        <td style="font-weight: bold;">考场号
                                        </td>
                                        <td style="font-weight: bold;">考生数
                                        </td>
                                    </tr>
                                    <asp:Repeater runat="server" ID="rp_ExamRoom" OnItemDataBound="rp_ExamRoom_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td align="center">第<%#Eval("RoomNum") %>考场（<%#Eval("CRIDName") %>）
                                                <asp:HiddenField runat="server" ID="hf_ERID" Value='<%#Eval("ERID") %>' />
                                                </td>
                                                <td>
                                                    <table width="100%">
                                                        <asp:Repeater runat="server" ID="rp_Subject" OnItemDataBound="rp_Subject_ItemDataBound">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td align="center" width="200px">
                                                                        <%#Eval("CourseName") %>
                                                                【<%#Eval("BeginDate","{0:HH:mm}") %>-<%#Eval("EndDate","{0:HH:mm}") %>】
                                                                    <asp:HiddenField runat="server" ID="hf_CID" Value='<%#Eval("CID") %>' />
                                                                    </td>
                                                                    <td align="left" width="480px">
                                                                        <%-- <asp:HiddenField runat="server" ID="hf_ETID" Value='<%#Eval("ETID") %>' />
                                                                    <asp:DropDownList runat="server" ID="ddl_TID" OnSelectedIndexChanged="ddl_TID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>--%>
                                                                        <asp:TextBox ID="txt_TID" cascadeCheck="false" runat="server" multiline="true" multiple="true" name="Tearcher" onlyLeafCheck="true" url="../ashx/ClassRoomList.ashx?method=TList" CssClass="easyui-combotree" TextMode="MultiLine" Height="30px" Width="300px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </table>
                                                </td>
                                                <td align="center">第<asp:TextBox ID="txt_ClassRoom" runat="server" Text='<%#Eval("RoomNum") %>' Width="30"></asp:TextBox>考场
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txt_StuNum" runat="server" Text='<%#Eval("StuNum") %>' Width="30"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" align="center">
                                <asp:Button ID="btn_Submit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Submit_Click" />
                                <%-- <input type="button" class="submit" value="打印" onclick="print()" />--%>
                                <%--<asp:Button ID="btn_OutPut" runat="server" Text="打印" CssClass="submit" OnClick="btn_OutPut_Click" />--%>
                                <asp:Button ID="btn_Cancel" runat="server" Text="返回" CssClass="editor" OnClick="btn_Cancel_Click" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
    </form>
    <%-- <script>
        function print()
        {
            
            //document.body.innerHTML = document.getElementById('print').innerHTML;
            WindowPrint.execwb(7, 1);
            //window.print();

            //alert("打印");
        }
    </script>--%>
</body>
</html>

