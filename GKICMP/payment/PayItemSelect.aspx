<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayItemSelect.aspx.cs" Inherits="GKICMP.payment.PayItemSelect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/choice.js"></script>
    <style>
        .edilab label {
            float: none;
        }

        .edilab input {
            height: 13px;
        }
    </style>

    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });

        function showokwin() {
            var els = document.getElementById("cbl_Button");
            var vals = '';
            if (els != null) {
                var chks = els.getElementsByTagName("input");
                for (var k = 0, len = chks.length; k < len; k++) {
                    var chk = chks[k];
                    if (chk != null && chk.type == 'checkbox' && chk.checked) {
                        //console.log(chk.parentNode.attributes["myvalue"].nodeValue);
                        vals += ',' + chk.parentNode.attributes["myvalue"].nodeValue;
                        //vals+= ',' + chk.attr("myValue");
                    }
                }

            }
            if (vals.length > 1)
                vals = vals.substring(1);

            var aresult = true;
            $.ajax({
                url: "../ashx/PayItemSelectHandler.ashx",
                cache: false,
                type: "GET",
                async: false,
                data: "method=Add&ppid=" + document.getElementById("hf_PPID").value + "&button=" + encodeURI(vals),
                dataType: "json",
                success: function (data) {
                    if (data.result == "fail") {
                        aresult = false;
                    }
                }
            });
            if (!aresult)
            {
                alert("系统提示：提交失败或缴费项名称已存在");

              <%-- var a = "<%=Get()%>";--%>
                eval("<%=Get()%>");
                return;
            }
            else {
                alert('提交成功！');
                $.opener("A_id").document.getElementById('btnsear').click();
                $.close("Add_id");
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_face" runat="server" />
        <asp:HiddenField runat="server" ID="hf_PPID" />
      <%--  <asp:ImageButton ID="btnsear" runat="server" OnClick="imgbtn_inquiry_Click" Style="display: none" />--%>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <td align="right" width="120">缴费项</td>
                        <td align="left">
                            <asp:CheckBoxList ID="cbl_Button" CssClass="edilab" runat="server" RepeatDirection="Horizontal" RepeatColumns="10" RepeatLayout="Flow">
                            </asp:CheckBoxList>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="4" align="center">
                            <%--<asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                            --%>
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="showokwin()" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("Add_id");' />
                        </td>
                    </tr>

                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
