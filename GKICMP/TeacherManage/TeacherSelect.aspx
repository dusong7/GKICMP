<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherSelect.aspx.cs" Inherits="GKICMP.teachermanage.TeacherSelect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <meta charset="utf-8">
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">
        function getvalue(a) {
            var cid = a.id;
            var cname = $(a).next().val();
            var usernum = $(a).next().next().val();
            var flag = document.getElementById("hf_flag").value;

            if (cid != "") {
                if (flag == 1) {//人事变动管理
                    $.opener("A_id").document.getElementById("hf_UID").value = cid;
                    $.opener("A_id").document.getElementById("txt_RealName").value = cname;
                    $.opener("A_id").document.getElementById("txt_UserNum").value = usernum;
                }
                else if (flag == 2) {//会议联系人
                    $.opener("A_id").document.getElementById("txt_LinkUser").value = cname;
                    $.opener("A_id").document.getElementById("hf_UserID").value = cid;
                }
                else if (flag == 3) {//课题负责人--班主任安排
                    $.opener("A_id").document.getElementById("txt_DutyUser").value = cname;
                    $.opener("A_id").document.getElementById("hf_UID").value = cid;
                }
                else if (flag == 4) {//论文作者
                    $.opener("A_id").document.getElementById("txt_Publisher").value = cname;
                    $.opener("A_id").document.getElementById("hf_UID").value = cid;
                }
                else if (flag == 5) {//考核管理
                    $.opener("A_id").document.getElementById("txt_RealName").value = cname;
                    $.opener("A_id").document.getElementById("hf_UID").value = cid;
                }
                else if (flag == 6) {//排课任课教师
                    $.opener("A_id").document.getElementById("txt_TeacherName").value = cname;
                    $.opener("A_id").document.getElementById("hf_TID").value = cid;
                }
                else if (flag == 10) {//合同选择教师
                    $.opener("A_id").document.getElementById("hf_TID").value = cid;
                    $.opener("A_id").document.getElementById("txt_TeacherName").value = cname;
                }
            }

            $.close("S_id");
        }
    </script>
</head>
<body>
     <form id="form1" runat="server">
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_flag" runat="server" />

        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span>系统管理<span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="用户管理"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>

                    <tr>
                        <td align="right" width="60">用户名：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_UserName" runat="server"></asp:TextBox>
                        </td>
                        <td align="right" width="60">姓名：</td>
                        <td width="150">
                            <asp:TextBox ID="txt_RealName" runat="server"></asp:TextBox>
                        </td>
                        <td width="120" align="right">用户类别：</td>
                        <td width="250">
                            <asp:DropDownList runat="server" ID="ddl_UserType"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)"></label></th>
                        <th align="center">用户名</th>
                        <th align="center">姓名</th>
                        <th align="center">性别</th>
                        <th align="center">民族</th>
                        <th align="center">身份证号码</th>
                        <th align="center">出生日期</th>
                        <th align="center">用户类型</th>
                        <th align="center">手机号码</th>
                        <th align="center">公司座机</th>
                        <th align="center">最近登录时间</th>
                        <th width="70px" align="center">操作</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5px">
                                    <a id='<%# DataBinder.Eval(Container.DataItem, "UID")%>' href="#" onclick='getvalue(this)'>
                                        <img src="../images/icons/accept.png" style="border: 0px; padding-top: 4px;" /></a>
                                    <asp:HiddenField ID="hfname" runat="server" Value='<%# Eval("RealName") %>' />
                                    <asp:HiddenField ID="hf_usernum" runat="server" Value='<%# Eval("RealName") %>' />
                                </td>
                                <td><%#Eval("UserName")%></td>
                                <td><%#Eval("RealName")%></td>
                                <td><%#GetName(Eval("UserSex"))%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.MZ>(Eval("Nation"))%></td>
                                <td><%#Eval("IDCard").ToString().Substring(0,4)+"******"+Eval("IDCard").ToString().Substring(14)%></td>
                                <td><%#Convert.ToDateTime( Eval("BirthDay")).ToString("yyyy-MM") %></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.UserType>(Eval("UserType"))%></td>
                                <td><%#Eval("CellPhone")%></td>
                                <td><%#Eval("CompanyNum")%></td>
                                <td><%#Eval("LastDate").ToString()==""?"":Eval("LastDate","{0:yyyy-MM-dd HH:mm:ss}")%></td>
                                <td>
                                    <div class="operationd">
                                        <asp:LinkButton ID="lbtn_Detail" runat="server" CssClass="viewa" Style="margin-left: 10px;" ToolTip="详细" OnClientClick='return viewinfo(this);'></asp:LinkButton>
                                        <asp:LinkButton ID="lbtn_Edit" runat="server" CssClass="editora" Style="margin-left: 10px;" ToolTip="编辑" OnClientClick='return editinfo(this);'></asp:LinkButton>
                                        <asp:HiddenField ID="hf_SelectID" Value='<%#Eval("UID") %>' runat="server" />
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="11">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>
