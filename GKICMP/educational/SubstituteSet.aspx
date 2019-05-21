<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubstituteSet.aspx.cs" Inherits="GKICMP.educational.SubstituteSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
<%--    <link href="../css/green_asyncbox.css" rel="stylesheet" />--%>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#tab1").find("td").click(function () {
                $("#tab1").find("td").css("background", "none");
                $(this).css("background", "#F5CCCC");
                //var scid = this.innerHtml.substring(this.innerHtml.indexOf(":a:c") + 4, this.innerHtml.indexOf(":b:c"));
                //var date = this.innerHtml.substring(this.innerHtml.indexOf(":b:c") + 4, this.innerHtml.indexOf("xy"));
                //var claid = this.innerHtml.substring(this.innerHtml.indexOf("xy") + 2, innerHtml.indexOf("</label>"));
                //if (scid != "" && scid != null) {
                //    //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                //    return openbox('A_id', 'SubstituteSet.aspx', 'jc=' + scid + "&date=" + date + "&scid=" + claid, 700, 700, 2);
                //}
            });

        });
        function CellText1(innerHtml) {
            document.getElementById("hf_TK").value = "";
            //var id = e.id;
            var scid = innerHtml.substring(innerHtml.indexOf(":a:c") + 4, innerHtml.indexOf(":b:c"));
            var time = innerHtml.substring(innerHtml.indexOf(":b:c") + 4, innerHtml.indexOf("xy"));
            var c = scid + "," + time;
            document.getElementById("hf_TK").value = c;
        }
    </script>
    <style>
        #btn_Search {
            width: 69px;
            height: 27px;
            border: none;
            background: url(../images/green_yjqh_19.png);
            padding: 0px;
            margin: 0px;
            color: #fff;
            font-size: 14px;
            text-align: left;
            text-indent: 10px;
            line-height: 27px;
        }
    </style>
    <style type="text/css">
        body {
            background: #fff;
        }

        #content {
            padding: 20px;
            background: #fff;
        }

        #tab1 {
            border-collapse: collapse;
        }

            #tab1 tr td {
                border: 1px solid #BFBFBF;
                text-align: center;
            }

            #tab1 tr:nth-child(2n) td {
                background: #F9F9F9;
            }
            input{ border:1px solid #94e7a3; height:26px; border-radius:2px; text-indent:5px}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="content" >
            <asp:HiddenField ID="hf_scid" runat="server" />
            <asp:HiddenField ID="hf_UserID" runat="server" />
            <asp:HiddenField ID="hf_cname" runat="server" />
            <asp:HiddenField ID="hf_TK" runat="server" />

            <table width="98%" border="0" cellspacing="0" cellpadding="0" >
                 <tbody>
                <tr>
                    <td colspan="3" style="line-height: 3;text-align:center;font-size:large"  >当前班级：<asp:Literal runat="server" ID="ltl_NowClass"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td width="50px" >调课日期：</td>
                    <td style="padding: 10px 0px">
                        <asp:TextBox ID="txt_TKDate" runat="server" datatype="*" nullmsg="请填写代课开始时间" onclick="WdatePicker({skin:'whyGreen'})" ></asp:TextBox>
                        <span style="color: Red; float: none">*</span>
                    </td>
                    <td align="left">
                        <asp:Button ID="btn_Search" runat="server"  Text="查询" OnClick="btn_Search_Click" /></td>
                </tr>
                <tr>
                    <td colspan="3" style="padding-bottom: 10px">
                        <asp:Table ID="tab1" runat="server" Width="99%"></asp:Table>
                    </td>
                </tr>
                <tr>
                    <td align="left">申请原因</td>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="txt_ApplyReason" runat="server" datatype="*" nullmsg="请填写申请原因" TextMode="MultiLine" CssClass="searchbg" Height="80px" Width="96%"></asp:TextBox>
                        <span style="color: Red; float: none">*</span></td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="return showokwin()" OnClick="btn_Sumbit_Click" />
                        <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                    </td>
                </tr>
                     </tbody>
            </table>
            
        </div>
    </form>
    <script>
        function showokwin() {
            if (document.getElementById("hf_TK").value == "") {
                alert("请选择调课科目");
                return false;
            }

        }
    </script>
</body>
</html>

