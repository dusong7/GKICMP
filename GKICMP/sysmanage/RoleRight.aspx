<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleRight.aspx.cs" Inherits="GKICMP.sysmanage.RoleRight" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/common.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/roleselect.js" type="text/javascript"></script>

    <script type="text/javascript">
        function checkall(ele) {

            divs = jQuery("div[name=" + $(ele).next().val() + "]");
            //alert(divs);

            is = ele.checked;

            //alert(is);
            var ck = jQuery(ele).parent().prev().prev();
            //alert(ck);

            if (is == true) {
                ck.attr("checked", is);
            }

            for (i = 0; i < divs.length; i++) {
                ckconent = $(divs[i]).find("input:checkbox");
                for (j = 0; j < ckconent.length; j++) {
                    ckconent[j].checked = is;
                }
            }
        }
        function checkall1(ele) {

            divs = jQuery("div[name=" + $(ele).next().val() + "]");
            //alert(divs);

            is = ele.checked;

            //alert(is);
            var ck = jQuery(ele).parent().parent().prev().prev();
            //alert(ck);

            if (is == true) {
                ck.attr("checked", is);
            }

            for (i = 0; i < divs.length; i++) {
                ckconent = $(divs[i]).find("input:checkbox");
                for (j = 0; j < ckconent.length; j++) {
                    ckconent[j].checked = is;
                }
            }
        }
        function checkis(ele) {
            //divs = jQuery("span[name=" + $(ele).next().val() + "]");
            //alert(divs);

            is = ele.checked;

            //alert(is);
            var ck = jQuery(ele).parent().parent().prev().prev();
            //alert(ck);

            if (is == true) {
                ck.attr("checked", is);
            }
            //is = ele.checked;
            //if (is == true) {
            //    jQuery(ele).parent().parent().prev().prev().attr("checked", is);
            //    jQuery(ele).parent().parent().parent().prev().prev().attr("checked", is);
            //}
        }
    </script>
    <style>
        input {
            border: 1px solid #79A3E2;
            height: 26px;
            border-radius: 2px;
            text-indent: 5px;
        }

        .listcent {
            width: 98%;
            border: 1px solid #79A3E2;
            border-radius: 2px;
            margin: auto;
            margin-top: 15px;
            box-shadow: 0px 0 0px red, /*左边阴影*/ 0px 0 0px yellow, /*右边阴影*/ 0 0px 0px blue, /*顶部阴影*/ 0 5px 15px #dadada;
            padding: 0px;
        }

        .listinfo {
            background: #fff;
        }

            .listinfo th {
                color: #508CE4;
                font-size: 14px;
                font-weight: bold;
                text-indent: 16px;
                border-bottom: 1px solid #4782E0;
                line-height: 46px;
            }

            .listinfo td {
                line-height: 39px;
                border-top: #e4e4e4 1px solid;
                border-left: #e4e4e4 1px solid;
                padding-left: 10px;
                padding-right: 10px;
            }

            .listinfo tr:nth-child(2n+1) td {
                background: #f5f5f5;
            }

            .listinfo tr:last-child td {
                background: #fff;
            }

        .submit {
            width: 98px;
            height: 39px;
            color: #fff;
            border: none;
            background: url(../images/green_sb_07.png);
            font-size: 18px;
            margin: 10px;
            padding: 0px;
            text-indent: 0px;
            text-align: center;
        }

        .editor {
            width: 98px;
            height: 39px;
            color: #fff;
            border: none;
            background: url(../images/green_sb_09.png);
            font-size: 18px;
            margin: 10px;
            padding: 0px;
            text-indent: 0px;
            text-align: center;
        }
        /*.checkcss {
         padding-left:30px !important}
        .checkcss div{
       line-height:30px; padding-left:10px}
            .checkcss input {
             position:absolute; margin:0px; margin-top:3px; margin-left:-20px}
            .checkcss span {
            display:block; float:left; margin-right:35px}*/
        .listinfo label {
            float: none;
        }

        input {
            height: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="2" align="left" style="color: #4ec62c; font-size: 14px; font-weight: bold; text-indent: 16px; border-bottom: 1px solid #4782E0; line-height: 46px">角色权限
                        </th>
                    </tr>
                    <tr>
                        <td align="right" width="100">角色名称
                        </td>
                        <td align="left">
                            <asp:Label ID="lblrolename" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">角色权限</td>
                        <td align="left" class="checkcss">
                            <asp:Repeater ID="rpmodule" runat="server" OnItemDataBound="rpmodule_ItemDataBound">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk_fid" runat="server" onclick="checkall(this)" Checked='<%# Eval("RoleID").ToString() == "" ? false : true%>' />
                                    <%#Eval("ModuleName")%>
                                    <asp:HiddenField ID="hffid" runat="server" Value='<%#Eval("ModuleID") %>' />
                                    <div name='<%#Eval("ModuleID") %>'>
                                        <asp:Repeater ID="rpnextModule" runat="server" OnItemDataBound="rpnextModule_ItemDataBound">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_fid" runat="server" onclick="checkall(this)" Checked='<%# Eval("RoleID").ToString() == "" ? false : true%>' />
                                                <asp:HiddenField ID="hfsid" runat="server" Value='<%#Eval("ModuleID") %>' />
                                                <%#Eval("ModuleName") %>&nbsp;&nbsp;
                                    <asp:CheckBoxList ID="chkl_tid" runat="server" CssClass="edilab" onclick="buttonlistlast(this);" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow">
                                    </asp:CheckBoxList>
                                                <div name='<%#Eval("ModuleID") %>'>
                                                    <asp:Repeater ID="rplastModule" runat="server" OnItemDataBound="rpbuttonModule_ItemDataBound">
                                                        <ItemTemplate>
                                                            <div style="margin-left: 20px;" name='<%#Eval("ModuleID") %>'>
                                                                <asp:CheckBox ID="chk_tid" runat="server" onclick="checkall1(this)" Checked='<%# Eval("RoleID").ToString() == "" ? false : true%>' />
                                                                <asp:HiddenField ID="hftid" runat="server" Value='<%#Eval("ModuleID") %>' />
                                                                <%#Eval("ModuleName") %>&nbsp;&nbsp;
                                                    <asp:CheckBoxList ID="chkl_tid" runat="server" onclick="buttonlistlast(this);" RepeatDirection="Horizontal"
                                                        RepeatLayout="Flow">
                                                    </asp:CheckBoxList>
                                                                <div name='<%#Eval("ModuleID") %>'>
                                                                    <asp:Repeater ID="rpendModule" runat="server" OnItemDataBound="rpbuttonModuleb_ItemDataBound">
                                                                        <ItemTemplate>
                                                                            <div style="margin-left: 20px;" name='<%#Eval("ModuleID") %>'>

                                                                                <%--   <asp:CheckBox ID="chk_tid" runat="server" onclick="checkis(this)" Checked='<%# Eval("RoleID").ToString() == "" ? false : true%>' />
                                                                                <asp:HiddenField ID="hflid" runat="server" Value='<%#Eval("ModuleID") %>' />
                                                                                <%#Eval("ModuleName") %></span> --%>
                                                                                <asp:CheckBox ID="chk_tid" runat="server" onclick="checkall1(this)" Checked='<%# Eval("RoleID").ToString() == "" ? false : true%>' />
                                                                                <asp:HiddenField ID="hflid" runat="server" Value='<%#Eval("ModuleID") %>' />
                                                                                <%#Eval("ModuleName") %></span> 
                                                   <span>
                                                       <asp:CheckBoxList ID="chkl_tid" runat="server" onclick="checkis(this);" RepeatDirection="Horizontal"
                                                           RepeatLayout="Flow">
                                                       </asp:CheckBoxList></apn>

                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                    <div style="clear: both"></div>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
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
</body>
</html>

