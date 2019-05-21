<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Res_Main.aspx.cs" Inherits="GKICMP.resourcesite.Res_Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>资源平台</title>
    <link href="../css/rourcecss.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script>
        function DownLoad(e) {
            $.ajaxSetup({
                async: false
            });
            var a = true;
            var erid = $(e).next().val();
            var psw = $(e).next().next().val();
            if (psw == "1") {
                var name = prompt("请输入密码", "");
                if (name != "" && name != null) {
                    jQuery.post("../ashx/SetDownLoad.ashx?id=" + erid + "&psw=" + name, function (data) {
                        if (data.result == "success") {
                            a = true;
                        }
                        else {
                            alert("密码错误");
                            a = false;
                        }
                    }, "json");
                }
                else {
                    a = false;
                }

            }
            else {
                jQuery.post("../ashx/SetDownLoad.ashx?id=" + erid, function (data) { });
                a = true;
            }
            return a;
        }
    </script>
</head>
<body>
    <form runat="server">
        <div style="margin-top: 10px;">
            <div class="rightcss">
                <div class="listtop">
                    <div class="titname">
                        资源筛选<span class="morecss"><asp:ImageButton ID="img_cz" runat="server" ImageUrl="../images/zy_3.png" OnClick="img_cz_Click" />
                        </span>
                    </div>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="chocss">
                        <tbody>
                            <tr>
                                <td width="102" align="right" valign="top">资源类型：</td>
                                <td valign="top">
                                    <ul>
                                        <li>
                                            <asp:LinkButton ID="lbtn_All" runat="server" Text="全部" CommandArgument="-2" OnClick="lbtn_All_Click"></asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="课件" CommandArgument="1" OnClick="lbtn_All_Click"></asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton ID="LinkButton2" runat="server" Text="教案" CommandArgument="2" OnClick="lbtn_All_Click"></asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton ID="LinkButton3" runat="server" Text="试卷" CommandArgument="3" OnClick="lbtn_All_Click"></asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton ID="LinkButton4" runat="server" Text="素材" CommandArgument="4" OnClick="lbtn_All_Click"></asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton ID="LinkButton5" runat="server" Text="微课程" CommandArgument="5" OnClick="lbtn_All_Click"></asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton ID="LinkButton6" runat="server" Text="其他" CommandArgument="6" OnClick="lbtn_All_Click"></asp:LinkButton></li>
                                    </ul>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="searcss">
                    <div class="numcss">
                        共找到
                        <asp:Literal ID="ltl_Count" runat="server"></asp:Literal>
                        个资源
                    </div>
                    <div class="inpcss">
                        <asp:Panel runat="server" DefaultButton="btn_Search">
                            <asp:TextBox ID="txt_All" runat="server" class="inputcss"></asp:TextBox>
                            <asp:Button ID="btn_Search" runat="server" Text="资源搜索" class="btncss" OnClick="btn_Search_Click" />
                        </asp:Panel>
                    </div>
                </div>
                <asp:Repeater ID="rp_List" runat="server">
                    <ItemTemplate>
                        <div class="listmre">
                            <div class="titname">
                                <img src='<%#GetPic(Eval("RFormat")) %>' class="zybs"><%#Eval("ResourseName") %>
                            </div>
                            <div class="infocss">
                                <span>资源分类：</span><span><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.EType>(Eval("EType")) %></span><span>资源学科：</span><span title="<%#Eval("CIDName") %>"><%#GetCutStr( Eval("CIDName"),2)%>资源</span>
                                <div style="float: left">
                                    <span><%#Eval("CreateDate","{0:yyyy.MM.dd}")%></span><span><%#GK.GKICMP.Common.CommonFunction.CountSize(int.Parse(Eval("RSize").ToString()))%></span><span style="width: 100px;"><%#(Eval("CreateUserName"))%></span><span>（<%#Eval("DownLoadNum")%>）</span>
                                    <div style="clear: both"></div>
                                </div>
                                <div class="dowcss">
                                    <asp:LinkButton ID="lbtn_DownLoad" runat="server" CommandArgument='<%#Eval ("Erid") %>' CommandName='<%#Eval("ResourseName") %>' OnClientClick="return DownLoad(this);" OnClick="lbtn_DownLoad_Click"><img src="../images/zy_7.png" /></asp:LinkButton>
                                    <asp:HiddenField ID="hf_erid" Value='<%#Eval("Erid") %>' runat="server" />
                                    <asp:HiddenField ID="hf_psw" Value='<%#Eval("ERPwd").ToString()!=""?"1":"0" %>' runat="server" />
                                    <asp:LinkButton ID="lbtn_Collection" runat="server" CommandArgument='<%#Eval ("Erid") %>' CommandName='<%#Eval("ResourseName") %>' OnClick="lbtn_Collection_Click"><img src="../images/dl-sc.png" /></asp:LinkButton>
                                </div>
                                <div style="clear: both"></div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div runat="server" id="tr_null" style="text-align: center">
                    暂无记录                        
                </div>
                <div class="listmre" style="border: none; text-align: right">
                    <div class="titname" style="font-size: 14PX;">
                        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
                    </div>
                </div>
                `
            </div>
        </div>
    </form>
</body>
</html>



