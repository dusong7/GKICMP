<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ElectiverCourseEdit.aspx.cs" Inherits="GKICMP.electiver.ElectiverCourseEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-3.1.1.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
        });
        function sumbit(a) {
            var ecid = getUrlParam("id");
            var eleid = getUrlParam("eleid");
            var cid = jQuery("#ddlCourseID  option:selected").val();
            var count = document.getElementById("txt_MaxCount").value;
            var grade='';
            jQuery("input[name^='cbl_Grade']").each(function () {
                if (this.checked) {
                    grade = grade + $(this).parent("span").attr("alt")+",";
                }
            });

            var aresult = 0;
            $.ajax({
                url: "../ashx/ElectiverCourse.ashx",
                cache: false,
                type: "post",
                async: false,
                data: { method: "Add", ecid: ecid, eleid: eleid, cid: cid, count: count, grade: grade },
                dataType: "json",
                success: function (data) {
                    if (data.result == "fail") {
                        aresult = -1;
                    }
                    else if (data.result == "repeat") {
                        aresult = -2;
                    }
                },
                error: function (data) {
                    alert(data.result)
            }
            });
            if (aresult == -1) {
                alert("系统提示：提交失败");
                return;
            }
            else if (aresult == -2) {
                alert("系统提示：系统中已存在，请勿重复添加");
                return;
            }
            else {
                alert("系统提示：提交成功");
                $.opener("A_id").document.getElementById('btnsear').click();
            }
            $.close("S_id");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
      <%--  <asp:Button ID="btn_Search" runat="server" Text="Button" OnClick="btn_Search_Click" Style="display: none" />--%>
        <asp:HiddenField runat="server" ID="hf_LID" />
        <asp:HiddenField runat="server" ID="hf_Url" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">课程设置</th>
                    </tr>
                    <tr id="trSubject" runat="server">
                        <td align="right">课程：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddlCourseID" runat="server" datatype="ddl" nullmsg="请选择课程"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="100px">最多人数：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_MaxCount" runat="server" datatype="zheng" Width="85px" nullmsg="请填写人数"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">年级：</td>
                        <td align="left" colspan="3" >
                            <style>
                                .edilab label {
                                    float: none;
                                }

                                .edilab input {
                                    height: 13px;
                                }
                            </style>
                            <asp:CheckBoxList ID="cbl_Grade" Class="edilab" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                   
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="sumbit()" />
                        <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("S_id");' />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>


