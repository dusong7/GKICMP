<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ElectiverEdit.aspx.cs" Inherits="GKICMP.electiver.ElectiverEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").Validform();
            $("#cb_IsEstmate").change(function () {
                if ($(this).is(":checked"))
                { document.getElementById("IsEstmate").style.display = "table-row"; }
                else
                { document.getElementById("IsEstmate").style.display = "none"; }
            });
       
        });
        function Check(e,id)
        {

        }
        //$(function () {
        //    $("#ischange").change(function() { 
        //        alert("checked"); 
        //    }); 
        //});
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">选课任务信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">任务名称：</td>
                        <td align="left" width="400px;">
                            <asp:TextBox ID="txt_ElectiverName" runat="server" datatype="*1-100" nullmsg="请填写任务名称"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">学年度/学期：</td>
                        <td align="left" width="400px;">
                            <asp:Literal runat="server" ID="ltl_EYear"></asp:Literal>
                            <asp:Literal runat="server" ID="ltl_TermID"></asp:Literal>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" width="120">选课数限制：</td>
                        <td align="left">
                           
                            <asp:TextBox ID="txt_Ecount" runat="server" CssClass="searchbg" datatype="zhengnum" nullmsg="请填写选课数" >1</asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td  colspan="3"> 
                            <style>
                                .edilab label {
                                    float: none;
                                }

                                .edilab input {
                                    height: 13px;
                                }

                                .auto-style1 {
                                    height: 16px;
                                }
                            </style>
                            <%--<asp:CheckBox ID="cb_EIsAudit" Class="edilab" RepeatDirection="Horizontal" Text="是否审核" runat="server" />--%><asp:CheckBox ID="cb_IsEstmate" Text="是否预选" Class="edilab" runat="server" /><asp:CheckBox ID="cb_IsRelation" Text="是否关联" Class="edilab" runat="server" /></td>
                    </tr>

                    <tr id="IsEstmate" style="display:none">
                        <td align="right" width="120">预选开始时间：</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txt_EstimateBDate" datatype="*" nullmsg="请填写预选开始时间" onclick="WdatePicker({skin:'whyGreen',maxDate:'#F{$dp.$D(\'txt_EstimateEDate\')}'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">预选结束时间：</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txt_EstimateEDate" datatype="*" nullmsg="请填写预选结束时间" onclick="WdatePicker({skin:'whyGreen',minDate:'#F{$dp.$D(\'txt_EstimateBDate\')}'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" width="120">报名开始时间：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_EBegin" runat="server" CssClass="searchbg" datatype="*" nullmsg="请填写报名开始时间" onclick="WdatePicker({skin:'whyGreen',maxDate:'#F{$dp.$D(\'txt_EEnd\')}'})" ></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">报名结束时间：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_EEnd" runat="server" CssClass="searchbg" MaxLength="100" datatype="*" nullmsg="请填写报名结束时间" onclick="WdatePicker({skin:'whyGreen',minDate:'#F{$dp.$D(\'txt_EBegin\')}'})" ></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>

