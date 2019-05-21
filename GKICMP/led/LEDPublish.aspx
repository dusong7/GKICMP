<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LEDPublish.aspx.cs" Inherits="GKICMP.led.LEDPublish" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../utf8-net/ueditor.config.js"></script>
    <script src="../utf8-net/ueditor.all.js"></script>
    <style>
        .edilab label {
            float: none;
        }

        .edilab input {
            height: 13px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">发布内容信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">发布终端：</td>
                        <td align="left" >
                            <asp:DropDownList ID="ddl_LID" runat="server" >
                            </asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="100px">发布类型：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_Type" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_Type_SelectedIndexChanged">
                                <asp:ListItem Value="0">文字</asp:ListItem>
                                <asp:ListItem Value="1">文件</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr >
                        <td align="right" width="100px">发布内容：</td>
                        <td align="left" colspan="3">
                            <asp:LinkButton ID="lbtn_Sourse"  runat="server"  OnClick="lbtn_Sourse_Click"><%=name%></asp:LinkButton>
                            <asp:FileUpload ID="fl_UpFile" runat="server" style="display:none" /><asp:HiddenField ID="hf_UpFile" runat="server" /><asp:HiddenField ID="hf_IName" runat="server" />
                            <asp:TextBox runat="server" ID="txt_LText" Height="100px" Width="70%" TextMode="MultiLine" datatype="*" nullmsg="请输入发布内容"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">字体：</td>
                        <td align="left" colspan="3">
                            <asp:DropDownList ID="ddl_LFont" runat="server">
                                <asp:ListItem Value="宋体">宋体</asp:ListItem>
                                <asp:ListItem Value="仿宋">仿宋</asp:ListItem>
                                <asp:ListItem Value="黑体">黑体</asp:ListItem>
                                <asp:ListItem Value="楷体">楷体</asp:ListItem>
                                <asp:ListItem Value="微软雅黑">微软雅黑</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">字号：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_Size" runat="server">
                                <asp:ListItem Value="8">8</asp:ListItem>
                                <asp:ListItem Value="9">9</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="11">11</asp:ListItem>
                                <asp:ListItem Value="12" Selected="True">12</asp:ListItem>
                                <asp:ListItem Value="14">14</asp:ListItem>
                                <asp:ListItem Value="16">16</asp:ListItem>
                                <asp:ListItem Value="18">18</asp:ListItem>
                                <asp:ListItem Value="20">20</asp:ListItem>
                                <asp:ListItem Value="22">22</asp:ListItem>
                                <asp:ListItem Value="24">24</asp:ListItem>
                                <asp:ListItem Value="26">26</asp:ListItem>
                                <asp:ListItem Value="28">28</asp:ListItem>
                                <asp:ListItem Value="36">36</asp:ListItem>
                                <asp:ListItem Value="48">48</asp:ListItem>
                                <asp:ListItem Value="72">72</asp:ListItem>
                                <asp:ListItem Value="100">100</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: red;">*</span>
                        </td>
                        <td align="right">特效：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_LTX" runat="server"></asp:DropDownList>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right">速度：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddl_LVelocity" runat="server">
                                <asp:ListItem Value="1">1(最快)</asp:ListItem>
                                <asp:ListItem Value="1">2</asp:ListItem>
                                <asp:ListItem Value="3<">3</asp:ListItem>
                                <asp:ListItem Value="4" Selected="True">4</asp:ListItem>
                                <asp:ListItem Value="5<">5</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                                <asp:ListItem Value="7<">7</asp:ListItem>
                                <asp:ListItem Value="8">8</asp:ListItem>
                                <asp:ListItem Value="9<">9</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="11">11</asp:ListItem>
                                <asp:ListItem Value="12">12</asp:ListItem>
                                <asp:ListItem Value="13">13</asp:ListItem>
                                <asp:ListItem Value="14">14</asp:ListItem>
                                <asp:ListItem Value="15">15</asp:ListItem>
                                <asp:ListItem Value="16">16</asp:ListItem>
                                <asp:ListItem Value="17">17</asp:ListItem>
                                <asp:ListItem Value="18">18</asp:ListItem>
                                <asp:ListItem Value="19">19</asp:ListItem>
                                <asp:ListItem Value="20">20</asp:ListItem>
                                <asp:ListItem Value="21">21</asp:ListItem>
                                <asp:ListItem Value="22">22</asp:ListItem>
                                <asp:ListItem Value="23">23</asp:ListItem>
                                <asp:ListItem Value="24">24</asp:ListItem>
                                <asp:ListItem Value="25">25</asp:ListItem>
                                <asp:ListItem Value="26">26</asp:ListItem>
                                <asp:ListItem Value="27">27</asp:ListItem>
                                <asp:ListItem Value="28">28</asp:ListItem>
                                <asp:ListItem Value="29">29</asp:ListItem>
                                <asp:ListItem Value="30">30</asp:ListItem>
                                <asp:ListItem Value="31">31</asp:ListItem>
                                <asp:ListItem Value="32">32（最慢)</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red; float: none">*</span></td>
                    
                        <td align="right">停留时间： </td>
                        <td align="left">
                            <asp:TextBox ID="txt_LS" runat="server" name="Series" datatype="zheng" nullmsg="请填写停留时间">4</asp:TextBox>(1~255)
                            <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">开始日期： </td>
                        <td align="left">
                            <asp:TextBox ID="txt_Begin" runat="server" name="Series" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                        </td>
                    
                        <td align="right">结束日期： </td>
                        <td align="left">
                            <asp:TextBox ID="txt_End" runat="server" name="Series" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">开始时间： </td>
                        <td align="left">
                            <asp:TextBox ID="txt_BeginTime" runat="server" name="Series" onclick="WdatePicker({dateFmt:'HH:mm:ss'})" ></asp:TextBox>
                        </td>
                        <td align="right">结束时间： </td>
                        <td align="left">
                            <asp:TextBox ID="txt_EndTime" runat="server" name="Series" onclick="WdatePicker({dateFmt:'HH:mm:ss'})" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="SetValue()" OnClick="btn_Sumbit_Click" />
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick="$.close('A_id')" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>


