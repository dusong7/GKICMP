<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubstituteAdd.aspx.cs" Inherits="GKICMP.educational.SubstituteAdd" %>

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
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
 
        $(function () {
            $("#tab").find("td").click(function () {
                $("#tab").find("td").css("background", "none");
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
        function CellText(innerHtml) {
            //$("#tab").find("td").css("background", "none");
            //$(this).css("background", "#FF0004")
            var scid = innerHtml.substring(innerHtml.indexOf(":a:c") + 4, innerHtml.indexOf(":b:c"));
            var date = innerHtml.substring(innerHtml.indexOf(":b:c") + 4, innerHtml.indexOf("xy"));
            var claid = innerHtml.substring(innerHtml.indexOf("xy") + 2, innerHtml.indexOf("</label>"));
            if (scid != "" && scid != null) {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'SubstituteSet.aspx', 'jc=' + scid + "&date=" + date + "&scid=" + claid, 700, 700, 2);
            }
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="listinfo">
                <tbody>
                    <tr>
                        <th style="text-align: left;" width="350px">所调课日期：
                            <asp:TextBox ID="txt_TKDate" runat="server" datatype="*" nullmsg="请填写代课开始时间" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </th>
                        <th align="left"><asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" /></th>
                    </tr>
                    <tr style="height: 16px;">
                        <td colspan="2">
                            <asp:Table ID="tab" runat="server" Style="text-align: center; width: 100%;"></asp:Table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">调课说明：<br />
                            <span style="color: red">1.调课日期默认为当前周，请仔细核对日期;<br />
                                2.此日期为自己所调课的日期。
                            </span>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
 

