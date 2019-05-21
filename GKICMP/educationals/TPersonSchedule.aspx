<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TPersonSchedule.aspx.cs" Inherits="GKICMP.educationals.TPersonSchedule" %>

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
        function preview() {
            $("#div11").css("display", "block");
            $("#lbl_Teacher").css("display", "none");
            var prnhtml = ($("#aa").html());
            window.document.body.innerHTML = prnhtml;
            window.print();
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

        .listprint {
            border: 1px solid #4cb190;
            border-radius: 2px;
            background: #4cb190;
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
            line-height: 25px;
            padding-left: 0px;
            padding-right: 0px;
        }

        #lbl td:hover {
            background: #C4C6C8;
        }


        .content th {
            border-top: 1px solid #cdcecf;
            border-bottom: 1px solid #cdcecf;
            border-left: 1px solid #cdcecf;
        }

        .content td {
            /*min-width: 60px;*/
            Text-align: center;
            border-left: 1px solid #cdcecf;
            border-bottom: 1px solid #cdcecf;
            padding: 0px 4px;
        }

        .content th:last-child {
            border-right: 1px solid #cdcecf;
        }

        .content td:last-child {
            border-right: 1px solid #cdcecf;
        }

        .listcent .content .contd3 {
            color: #fff;
            background: #ef5d5d;
        }

        #lbl .content .contd3:hover {
            color: #fff;
            background: #ef5d5d;
        }

        #lbl .content .contd1:hover {
            color: #48bd81;
            background: #fff;
        }

        .content .contd1 {
            color: #48bd81;
            font-weight: bold;
        }

        .lxr {
            margin: 10px 0px 0px 10px;
            width: 200px;
        }

        .fileshowlist {
            float: left;
        }

        .lxr .filetitle {
            text-align: center;
            margin-left: 4px;
        }

        .filetitle {
            background: #c1ecbc;
            line-height: 30px;
        }

        .datanone {
            height: 112px;
            background: url(../images/nores.png) left center no-repeat;
            padding-left: 150px;
            width: 390px;
            margin: auto;
            padding-top: 50px;
            line-height: 2;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_uid" runat="server" />
        <div class="positionc" id="dv" runat="server" visible="false">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span><asp:Label ID="lbl_ParentMenu" runat="server" Text=""></asp:Label><span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="我的课表"></asp:Label></td>
                </tr>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="listinfo">
                <tbody>
                    <tr style="height: 16px;">
                        <td id="aa" runat="server" style="text-align: center;">
                            <div id="div11" style="display: none; text-align: center;">
                                <asp:Label runat="server" ID="lbl_top"></asp:Label>
                                <br />
                                <br />
                            </div>
                            <asp:Label runat="server" ID="lbl_Teacher" Style="font-size: 18px; font-family: 微软雅黑体; color: #48bd81; font-weight: bold; line-height: 50px;"></asp:Label>
                            <asp:Label ID="lbl" runat="server" Style="display: block"></asp:Label>
                        </td>
                    </tr>
                    <tr id="tran" runat="server">
                        <td style="text-align: center; padding-top: 15px; padding-bottom: 15px;">
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出" CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
                            &nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btn_Print" runat="server" Text="打印" CssClass="listprint" OnClientClick="preview()" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

