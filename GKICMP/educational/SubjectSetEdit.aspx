<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubjectSetEdit.aspx.cs" Inherits="GKICMP.educational.SubjectSetEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园考试管理</title>
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

        function CheckDateTime(str) {
            var reg = /^(\d+)-(\d{1,2})-(\d{1,2}) (\d{1,2}):(\d{1,2})$/;
            var r = str.match(reg);
            if (r == null) return false;
            r[2] = r[2] - 1;
            var d = new Date(r[1], r[2], r[3], r[4], r[5]);
            if (d.getFullYear() != r[1]) return false;
            if (d.getMonth() != r[2]) return false;
            if (d.getDate() != r[3]) return false;
            if (d.getHours() != r[4]) return false;
            if (d.getMinutes() != r[5]) return false;
            return true;
        }

        function showokwin() {
            var cid = document.getElementById("ddl_CID").value;
            var eid = document.getElementById("hf_EID").value;
            var examdate = document.getElementById("txt_ExamDate").value;
            examdate = examdate.substring(0, 10);
            var begindate = examdate + " " + document.getElementById("txt_BeginTime").value;
            var enddate = examdate + " " + document.getElementById("txt_EndTime").value;
            var zzbegin = $val("hf_begin");
            var zcend = $val("hf_end");
            var sorder = document.getElementById("txt_Sorder").value;
            if (CheckDateTime(begindate) == false) {
                alert("考试开始时间填写错误");
                return;
            }
            if (CheckDateTime(enddate) == false) {
                alert("考试结束时间填写错误");
                return;
            }
            if (Date.parse(begindate.replace("-", "/")) < Date.parse(zzbegin.replace("-", "/"))) {
                alert("科目考试开始时间不能小于考试开始时间,考试开始时间为" + zzbegin);
                return false;
            }
            if (Date.parse(enddate.replace("-", "/")) > Date.parse(zcend.replace("-", "/"))) {
                alert("科目考试结束时间不能大于考试结束时间,考试结束时间为" + zcend);
                return false;
            }
            if (Date.parse(enddate.replace("-", "/")) <= Date.parse(begindate.replace("-", "/"))) {
                alert("科目考试结束时间不能小于科目考试开始时间");
                return false;
            }
            var aresult = true;
            $.ajax({
                url: "../ashx/ExamSubjectHandler.ashx",
                cache: false,
                type: "GET",
                async: false,
                data: "method=SubjectAdd&cid=" + cid + "&eid=" + eid + "&begindate=" + begindate + "&enddate=" + enddate +"&order="+sorder,
                dataType: "json",
                success: function (data) {
                    if (data.result == "fail") {
                        aresult = false;
                    }
                    else if (data.result == "-2")
                    {
                        alert("此科目已添加，请选择其他科目。");
                        return;
                    }
                }
            });
            if (!aresult) {
                alert("系统提示：这段日期已有考试请重新录入");
                return;
            }
            else {
                alert('提交成功！');
                window.parent.document.getElementById("btnsear").click();
                // window.opener.document.getElementById("name");
                //$.opener().document.getElementById('btnsear').click();
                $.close("A_id");
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_EID" />
        <asp:HiddenField runat="server" ID="hf_begin" />
        <asp:HiddenField runat="server" ID="hf_end" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <td align="right" width="100px">考试科目</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_CID" datatype="ddl" errormsg="请选择考试科目" ></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">考试日期</td>
                        <td align="left">
                            <asp:TextBox ID="txt_ExamDate" runat="server" datatype="*" nullmsg="请选择考试日期" CssClass="searchbg" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">考试时间</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txt_BeginTime" Width="75px" datatype="*" nullmsg="请填写考试开始时间" onclick="WdatePicker({skin:'whyGreen',dateFmt:'HH:mm'})"></asp:TextBox>--
                            <asp:TextBox runat="server" ID="txt_EndTime" Width="75px" datatype="*" nullmsg="请填写考试结束时间" onclick="WdatePicker({skin:'whyGreen',dateFmt:'HH:mm'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">排序</td>
                        <td align="left">
                            <asp:TextBox ID="txt_Sorder" runat="server" datatype="zeronum" nullmsg="请填写正确的序号" CssClass="searchbg" Text="0" ></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="showokwin()" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

