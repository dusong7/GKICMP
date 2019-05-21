<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LessonDetail.aspx.cs" Inherits="GKICMP.lessonplan.LessonDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
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
        function getfile() {
            var hflogo = $id("hf_GraduatePhoto");
            var careful = $id("divimg").getElementsByTagName("input");
            hflogo.value = careful.length;
        }
    </script>
    <style>        #jspjinfo tr:nth-child(2n+1) td {
            background: none;
        }
#jspjinfo td {
    line-height: 39px;
    border-top: #000000 1px solid;
    border-left: #000000 1px solid;
    padding-left: 10px;
    padding-right: 10px;
}
#jspjinfo  th {
     color: black; 
    font-size: 14px;
    font-weight: bold;
    text-indent: 16px;
    /* border-bottom: 1px solid #3fa96b; */
    line-height: 25px;
    border-top: #e4e4e4 1px solid;
    border-left: #e4e4e4 1px solid;
}

#jspjinfo td:last-child {
    border-right: #000000 1px solid;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_face" runat="server" Value="" />
        <div class="listcent pad0" id="jspjinfo" runat="server" align="center">
            <asp:Repeater ID="rp_List" runat="server">
                <ItemTemplate>
                    <table width="800" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                        <tbody>
                            <tr>
                                <th colspan="4" align="center"><%=SchoolName%><%=Year%>学年度第<%=Term==1?"一":"二"%>学期<%#Eval("lname")%><%#Convert.ToInt32( Eval("LType"))==370?"社团活动":"体验课程"%>实施记录<br />
                                    <%#Convert.ToInt32( Eval("LType"))==370? "主讲人："+Eval("SpeakerNames")+"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;助教："+Eval("AssistantNames") :" 班级："+Eval("ClaIDName")+"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;执教教师："+Eval("SpeakerNames").ToString().Replace(',','/') %>
                                    <%--班级：<%#Eval("ActivityAddress") %>   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 执教教师：    <%#Eval("UserNames").ToString().Replace(',','/') %>  </th>--%>
                            </tr>
                            <tr>
                                <td align="right" width="120">活动时间：</td>
                                <td align="left"><%#Eval("PDate","{0:yyyy-MM-dd}") %></td>
                                <td align="right" width="120">活动地点：</td>
                                <td align="left"><%#Eval("ActivityAddress") %></td>
                            </tr>
                            <tr>
                                <td align="right" width="120">活动内容(主题)：</td>
                                <td align="left" colspan="3"><%#Eval("AContent") %></td>
                            </tr>
                            <tr>
                                <td align="right" width="120">活动目标：</td>
                                <td align="left" colspan="3"><%#Eval("ActivityTarget") %></td>
                            </tr>
                            <tr>
                                <td align="right" width="120">活动准备：</td>
                                <td align="left" colspan="3"><%#Eval("ActivityPre") %></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">活动安排</td>
                            </tr>
                            <tr>
                                <td colspan="4"><%#Eval("ActivityContent") %></td>
                            </tr>

                        </tbody>
                    </table>
                </ItemTemplate>
            </asp:Repeater></div>
        <div align="center">
            <asp:Button ID="btn_Sumbit" runat="server" Text="导出"  CssClass="submit" OnClick="btn_Sumbit_Click" />
             <asp:Button ID="btn_Return" runat="server" Text="返回" CssClass="editor" OnClick="btn_Return_Click" />
        </div>
    </form>
</body>
</html>


