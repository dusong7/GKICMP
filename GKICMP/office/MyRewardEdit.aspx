<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyRewardEdit.aspx.cs" Inherits="GKICMP.office.MyRewardEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
            jQuery("#form1").Validform();
        });
        function getfile() {
            var hfface = $id("hf_UpFile");
            var divone = $id("more").getElementsByTagName("input");
            hfface.value = divone.length;
        }

    </script>
</head>
<body>
   <form id="form1" runat="server">
        <asp:Literal ID="ltl_JQ" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField runat="server" ID="hf_SelectedValue" />
        <asp:HiddenField ID="hf_CssFlag" runat="server" />
        <asp:HiddenField ID="hf_Images" runat="server" />

        <asp:HiddenField ID="hf_face" runat="server" Value="" />
        <asp:HiddenField ID="hf_PID" runat="server" />
        <asp:HiddenField ID="hf_ID" runat="server" />
        <asp:HiddenField ID="hf_flag" runat="server" Value="2" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">获奖情况管理
                        </th>
                    </tr>
                    <tr>
                        <td align="right">奖励类别：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_RewardType" runat="server" datatype="ddl" errormsg="请选择奖励类别"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" >奖励名称</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txt_RewardName" MaxLength="50" datatype="*" nullmsg="请填写奖励名称"></asp:TextBox>
                            <span style="color: red;">*</span>
                        </td>
                       
                    </tr>

                    <tr>
                         <td align="right">获奖年月：</td>
                        <td align="left" >
                            <asp:TextBox ID="txt_PubDate" runat="server" MaxLength="50" datatype="*" nullmsg="请选择获奖年月" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">奖励级别：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_RGrade" runat="server" datatype="ddl" errormsg="请选择奖励级别"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">本人排名：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_Ranking" runat="server" datatype="ddl" errormsg="请选择本人排名"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right">授奖单位：</td>
                        <td align="left" >
                            <asp:TextBox ID="txt_Lunit" runat="server" datatype="*" nullmsg="请填写授奖单位" CssClass="searchbg"
                                MaxLength="50"></asp:TextBox><span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                   
                    <tr>
                        <td align="right">附件：</td>
                        <td align="left" colspan="3">
                             <table>
                                <asp:Repeater ID="rp_File" runat="server" OnItemCommand="rpaccess_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="lbn_load" CommandArgument='<%#Eval("RFile") %>' CommandName="load"
                                                    runat="server"><%#getFileName(Eval("RFile").ToString())%></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                            <div id="more">
                                <asp:FileUpload ID="fl_UpFile" runat="server" onchange="if(this.value)judge(this.value,this);" />
                            </div>
                            <asp:HiddenField ID="hf_UpFile" runat="server" />
                        </td>
                    </tr>


                </tbody>
            </table>
            <table width="100%" border="0">
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
                    </td>
                </tr>
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
