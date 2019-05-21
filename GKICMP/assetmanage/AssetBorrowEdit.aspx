<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetBorrowEdit.aspx.cs" Inherits="GKICMP.assetmanage.AssetBorrowEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
     <script src="../js/jquery-1.8.2.min.js"></script>
     <script src="../js/jquery.min.js"></script>
     <script src="../js/jquery.easyui.min.js"></script>
     <link href="../css/easyui.css" rel="stylesheet" />
     <link href="../css/demo.css" rel="stylesheet" />

   
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript">
        $(function () {
            //$('#TeacherName').combotree({
            //    onSelect: function (node) {
            //        var val = node.id;
            //        document.getElementById("hf_SelectedValue").value = val;
            //    }
            //});
            jQuery("#form1").Validform();
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField ID="hf_SelectedValue" runat="server"  />
        <asp:HiddenField ID="hf_CssFlag" runat="server" />
        <asp:HiddenField ID="hf_IDCard" runat="server" />
        <asp:HiddenField ID="hf_Images" runat="server" />

        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">
                            <asp:Literal runat="server" ID="ltl_Title"></asp:Literal>信息
                        </th>
                    </tr>
                    <tr>
                        <td align="right" width="120"><asp:Literal runat="server" ID="ltl_Name"></asp:Literal>人</td>
                        <td align="left" colspan="3">
                            <%-- <input id="TeacherName" name="TeacherName" style="width: 90%;" class="easyui-combotree" runat="server"/>
                             <span style="color: Red; float: none">*</span>--%>
                              <asp:TextBox ID="Series"  runat="server" name="Series"  url="../ashx/Tea.ashx?method=TeaL" CssClass="easyui-combotree"    Width="80%"></asp:TextBox>
                        </td>
                    </tr>

                     <tr>
                        <td align="right" width="120"> 
                            <asp:Literal ID="ltl_AssetNum" runat="server"></asp:Literal>数量
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txt_AssetNum"  datatype="zeronum" nullmsg="请填写数量"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                         <td align="right" width="120"> <asp:Literal ID="ltl_UserDate" runat="server"></asp:Literal>日期</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txt_UserDate"  onfocus="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请选择合同开始日期"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                        
                    </tr>

                    <tr>
                         <td align="right" width="120"><asp:Literal ID="ltl_ABMak" runat="server"></asp:Literal>说明</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_ABMark" TextMode="MultiLine" runat="server" MaxLength="100"
                                Rows="6" Width="70%" Height="100px" CssClass="MultiLinebg">
                            </asp:TextBox>
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
    <script>
        $(function () {
            $('#Series').combotree({
                onSelect: function (node) {
                    if (typeof (node.children) != "undefined") {
                        alert("不能选择部门名称");
                        document.getElementsById("Series").value = ""
                    }
                }
            });
            jQuery("#form1").Validform();
        });
    </script>
</body>
</html>
