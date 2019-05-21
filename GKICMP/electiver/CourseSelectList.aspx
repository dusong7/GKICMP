<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseSelectList.aspx.cs" Inherits="GKICMP.electiver.CourseSelectList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>智慧校园基础管理平台</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
</head>
<body>
    <form runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_DID" runat="server" />
        <div class="listcent pad0" style="width:98%;min-width:98%; box-sizing:border-box">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th align="center" width="100px">班级</th>
                        <th align="center" width="100px">学生姓名</th>
                        <th align="center" width="100px">课程</th>
                        
                        <th align="center" width="100px"><%=(Flag==1?"选课时间":"退课时间")%></th>
                        <th align="center" width="100px">班级</th>
                        <th align="center" width="100px">学生姓名</th>
                        <th align="center" width="100px">课程</th>
                        <th align="center" width="100px"><%=(Flag==1?"选课时间":"退课时间")%></th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <%     v = v + 1;
                                   if (v % 2 == 1)
                                   {%>
                            <tr>
                                <%
                                   }  
                                %>
                                <td  width="100px"><%#Eval("DepName")%></td>
                                <td  width="100px"><%#Eval("StuIDName")%></td>
                                <td  width="100px"><%#Eval("CorseIDName")%></td>
                                <td  width="100px"><%#Flag==1? Eval("EleDate","{0:yyyy-MM-dd HH:mm:ss}"):Eval("BackDate","{0:yyyy-MM-dd HH:mm:ss}")%></td>
                                <%if (v % 2 == 0)
                                  {%>
                            </tr>
                            <%}%>
                            <%if (v == x && v % 2 == 1)
                              {%>
                            <td  width="100px"></td>
                            <td  width="100px"></td>
                            <td  width="100px"></td>
                            <td  width="100px"></td>
                            <%}%>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="8">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>




