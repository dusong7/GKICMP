<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyClassSchedule.aspx.cs" Inherits="GKICMP.studentpage.MyClassSchedule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园学生管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        var type = window.location.href.split("?");
        function CellText(innerHtml) {
            var scid = innerHtml.substring(innerHtml.indexOf(":a:c") + 4, innerHtml.indexOf(":b:c"));
            if (scid != "" && scid != null) {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'SelectCourse.aspx', 'scid=' + scid, 750, 500, 49);
            }
        }
        function say() {
            document.getElementById('btn_Freshen').click();
        }
    </script>
    <style type="text/css">
        .listadd {
            border: 1px solid #25a161;
            border-radius: 2px;
            background: #48bd81;
            color: #FFFFFF;
            width: 65px;
            height: 26px;
            line-height: 24px;
            text-align: center;
            padding: 0px;
            margin-right: 13px;
            font-size: 14px;
        }

        .listoutput {
            border: 1px solid #ff772d;
            border-radius: 2px;
            background: #ff9a37;
            color: #FFFFFF;
            width: 65px;
            height: 26px;
            line-height: 24px;
            text-align: center;
            padding: 0px;
            margin-right: 13px;
            font-size: 14px;
        }

        .listinfo td {
            line-height: 50px;
        }

        #lbl td:hover {
            background: #C4C6C8;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span>我的学习<span>></span>我的课表
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="listinfo">
                <tbody>
                    <tr>
                        <th style="text-align: left;">当前班级：<asp:Literal runat="server" ID="ltl_NowClass"></asp:Literal>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btn_Freshen"  CssClass="listbtncss listadd" runat="server" Text="刷新" OnClick="btn_Freshen_Click" Style="display: none;" />&nbsp;&nbsp;
                           <%-- <asp:Button ID="btn_OutPut"CssClass="listbtncss listoutput" runat="server" Text="导出"  OnClick="btn_OutPut_Click" />--%>
                        </th>
                    </tr>
                    <tr style="height: 16px;">
                        <td>
                            <%--<asp:Label ID="lbl" runat="server" Style="margin-right: 0px;"></asp:Label>--%>
                            <asp:Table ID="tab" runat="server" Style="text-align: center; width: 100%;"></asp:Table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
