<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherRegistryList.aspx.cs" Inherits="GKICMP.statistical.TeacherRegistryList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>
    <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        function InputData(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'SysUserImport.aspx', 'flag=' + id, 1100, 500, 3);
        }
        function editinfo(e) {
            var id = $(e).next().next().val();
            return openbox('A_id', 'SysUserEdit.aspx', 'id=' + id, 1100, 500, 0);
        }

        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'SysUserDetail.aspx', 'id=' + id + '&flag=1', 860, 470, 4);
        }

        function chooseop() {
            document.getElementById("div_choose").style.display = "block";
        }
        function choosecc() {
            document.getElementById("div_choose").style.display = "none";
        }

        $(function () {
            var spans = $(".div_choose li").click(function () {

                var id;
                if ($(this).hasClass('choose_this')) {
                    $(this).removeClass("choose_this");
                    xz_id = $(this).attr('id');
                    id = xz_id + "_1"
                    $("#" + xz_id + "_1").removeClass("choose_xx");
                }
                else {
                    var checkid = document.getElementById("hf_SelectedValue").value;
                    $(this).addClass("choose_this");
                    xz_id = $(this).attr('id');
                    id = xz_id + "_1";
                    $("#" + xz_id + "_1").addClass("choose_xx");
                    checkid = checkid + "," + id;
                    document.getElementById("hf_SelectedValue").value = checkid;
                }
            });
        });
        function setclass() {
            var val = document.getElementById("hf_SelectedValue").value;
            var a = val.substring(1, val.length);
            var v = a.split(',');
            for (var i = 0; i < v.length; i++) {
                var a = v[i];
                $("#" + a).addClass("choose_xx");
            }
        }
    </script>
    <style type="text/css">
        .ass li {
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_SelectedValue" runat="server" />
        <asp:HiddenField ID="hf_CheckIDS" runat="server" />
        <asp:HiddenField ID="hf_Page" runat="server" />
        <asp:HiddenField ID="hf_Flag" runat="server" />
        <div class="positionc">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="18" valign="left" height="30">
                        <span class="zcbz"></span></td>
                    <td class="positiona"><a>首页</a><span>></span>统计报表<span>></span><asp:Label ID="lbl_Menuname" runat="server" Text="教职工简明情况统计表"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="dvTab">
            <ul class="menuall">
                <li class='tab <%=Flag!=0?"activeTab":"" %>'><a href="TeacherRegistryList.aspx?flag=1">在编教师</a></li>
                <li class='tab <%=Flag==0?"activeTab":"" %>'><a href="TeacherRegistryList.aspx?flag=0">区聘教师</a></li>
            </ul>
            <div class="dv"></div>
        </div>
        <div class="div_choose" id="div_choose">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tbody>
                    <tr>
                        <td height="260" valign="top">
                            <div class="choose_title">选择查询条件<span onclick="choosecc()"><img src="../images/colsebtn.png" width="20" height="20"></span></div>
                            <ul class="ass">
                                <li id="uname" class="choose_this"><a><span>姓名</span></a></li>
                                <li id="campus" class="choose_this"><a><span>校区</span></a></li>
                                <li id="usex" class="choose_this"><a><span>性别</span></a></li>
                                <li id="nation" class="choose_this"><a><span>民族</span></a></li>
                                <li id="birthday" class="choose_this"><a><span>出生年月</span></a></li>
                                <li id="jobdate"><a><span>工作时间</span></a></li>
                                <li id="partydate"><a><span>入党时间</span></a></li>
                                <li id="postrole" class="choose_this"><a><span>行政职务</span></a></li>
                                <li id="politics" class="choose_this"><a><span>民主党派</span></a></li>
                                <li id="education"><a><span>学历</span></a></li>
                                <li id="course" class="choose_this"><a><span>所授科目</span></a></li>
                                <li id="currentprofessional"><a><span>专业技术职称</span></a></li>
                                <li id="idcard"><a><span>身份证号</span></a></li>
                                <li id="linknum"><a><span>联系方式</span></a></li>
                                <li id="email"><a><span>邮箱地址</span></a></li>
                                <div style="clear: both"></div>
                            </ul>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <div class="choose_btn" style="cursor: pointer"><span onclick="choosecc()">确认</span></div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent searclass">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="10">
                <tbody>
                    <tr>
                        <td>
                            <div class="div_choose_xx">
                                <li id="uname_1" class="choose_xx"><span>姓名：</span><span>
                                    <asp:TextBox ID="txt_RealName" runat="server" Width="171"></asp:TextBox></span>
                                </li>
                                <li id="campus_1" class="choose_xx"><span>校区：</span><span>
                                    <asp:DropDownList ID="ddl_Campus" runat="server"></asp:DropDownList></span>
                                </li>
                                <li id="usex_1" class="choose_xx"><span>性别：</span><span>
                                    <asp:DropDownList ID="ddl_TSex" runat="server"></asp:DropDownList></span>
                                </li>
                                <li id="nation_1" class="choose_xx"><span>民族：</span><span>
                                    <asp:DropDownList ID="ddl_Nation" runat="server"></asp:DropDownList></span>
                                </li>
                                <li id="birthday_1" class="choose_xx"><span>出生年月：</span><span>
                                    <asp:TextBox ID="txt_BeginDate" runat="server" Style="width: 75px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>—
                                    <asp:TextBox ID="txt_EndDate" runat="server" Style="width: 75px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox></span>
                                </li>
                                <li id="jobdate_1"><span>工作时间：</span><span>
                                    <asp:TextBox ID="txt_JBegin" runat="server" Style="width: 75px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>—
                                    <asp:TextBox ID="txt_JEnd" runat="server" Style="width: 75px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox></span>
                                </li>
                                <li id="partydate_1"><span>入党时间：</span><span>
                                    <asp:TextBox ID="txt_PBegin" runat="server" Style="width: 75px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>—
                                    <asp:TextBox ID="txt_PEnd" runat="server" Style="width: 75px" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox></span>
                                </li>
                                <li id="postrole_1" class="choose_xx"><span>行政职务：</span><span>
                                    <asp:TextBox runat="server" ID="txt_PostRole"></asp:TextBox></span>
                                </li>
                                <li id="politics_1" class="choose_xx"><span>民主党派：</span><span>
                                    <asp:DropDownList runat="server" ID="ddl_Politics"></asp:DropDownList></span>
                                </li>
                                <li id="education_1"><span>学历：</span><span>
                                    <asp:DropDownList runat="server" ID="ddl_Education"></asp:DropDownList></span>
                                </li>
                                <li id="course_1" class="choose_xx"><span>所授科目：</span><span>
                                    <asp:DropDownList ID="ddl_Course" runat="server"></asp:DropDownList></span>
                                </li>
                                <li id="currentprofessional_1"><span>专业技术职称：</span><span>
                                    <asp:DropDownList runat="server" ID="ddl_CurrentPro"></asp:DropDownList></span>
                                </li>
                                <li id="idcard_1"><span>身份证号：</span><span>
                                    <asp:TextBox runat="server" ID="txt_IDCard"></asp:TextBox></span>
                                </li>
                                <li id="linknum_1"><span>联系方式：</span><span>
                                    <asp:TextBox runat="server" ID="txt_LinkNum"></asp:TextBox>
                                </span>
                                </li>
                                <li id="email_1"><span>邮箱地址：</span><span>
                                    <asp:TextBox runat="server" ID="txt_Email"></asp:TextBox>
                                </span>
                                </li>
                            </div>
                        </td>
                        <td width="50" style="position: relative; cursor: pointer"><span onclick="chooseop();" class="sear_btn">更多查询条件>></span>
                            <br />
                            <asp:Button ID="btn_Search" runat="server" CssClass="btn" Text="查询" OnClick="btn_Search_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listbt">
                <tbody>
                    <tr>
                        <td align="left"></td>
                        <td align="right" valign="middle">
                            <asp:Button ID="btn_OutPut" runat="server" Text="导出"   CssClass="listbtncss listoutput" OnClick="btn_OutPut_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfoc">
                <tbody>
                    <tr>
                        <%--<th width="5%" align="center">
                            <label class="wxz" id="checkalll">
                                <input type="checkbox" name="checkbox" value="复选框" id="checkall" onclick="qx(this.name, this.id)"></label></th>--%>
                        <th align="center" rowspan="2">姓名</th>
                        <th align="center" rowspan="2">性别</th>
                        <th align="center" rowspan="2">民族</th>
                        <th align="center" rowspan="2">出生年月</th>
                        <th align="center" rowspan="2">工作时间</th>
                        <th align="center" rowspan="2">入党时间</th>
                        <th align="center" rowspan="2">行政职务</th>
                        <th align="center" rowspan="2">何民主党派</th>
                        <th align="center" colspan="2">文化程度</th>
                        <th align="center" rowspan="2">所授科目</th>
                        <th align="center" rowspan="2">专业技术职称</th>
                        <th align="center" rowspan="2">身份证号</th>
                        <th align="center" rowspan="2">联系方式</th>
                        <th align="center" rowspan="2">邮箱地址</th>
                    </tr>
                    <tr>
                        <th>学历</th>
                        <th>何时何校何专业</th>
                    </tr>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <tr>
                                <%--<td style="width: 5px">
                                    <label class="wxz" id='ck_<%#Eval("UID")%>l'>
                                        <input type="checkbox" name="checkbox" onclick="setid(this.id)" value='<%#Eval("UID") %>' id='ck_<%#Eval("UID") %>' <%#GetState(Eval("UserType")) %> /></label>
                                </td>--%>
                                <td><%#Eval("RealName")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XB>(Eval("TSex"))%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.MZ>(Eval("TNation"))%></td>
                                <td><%#Eval("Birthday","{0:yyyy-MM}")%></td>
                                <td><%#Eval("JodDate","{0:yyyy-MM-dd}") %></td>
                                <td><%#Eval("PartyTme","{0:yyyy-MM-dd}")=="1900-01-01"?"":Eval("PartyTme","{0:yyyy-MM-dd}") %></td>
                                <td><%#Eval("PostRole") %></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.ZZMM>(Eval("Politics"))%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XL>(Eval("Education")) %></td>
                                <td><%#Eval("Education").ToString()==""?"":"于"+Eval("OutDate","{0:yyyy年MM月dd日}")+"毕业于"+Eval("EduSchool")+Eval("EMajor")+"专业" %></td>
                                <td><%#Eval("CourseName")%></td>
                                <td><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.CurrentProfessional>(Eval("CurrentProfessional")) %></td>
                                <td><%#Eval("IDCardNum").ToString()==""?"暂无身份证信息":Eval("IDCardNum").ToString().Length>14?Eval("IDCardNum").ToString().Substring(0,4)+"******"+Eval("IDCardNum").ToString().Substring(14):"身份证有误，请修改"%></td>
                                <td><%#Eval("CellPhone")%></td>
                                <td><%#Eval("Email")%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server" id="tr_null">
                        <td colspan="15">暂无记录</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
    </form>
</body>
</html>

