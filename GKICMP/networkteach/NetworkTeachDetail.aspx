<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NetworkTeachDetail.aspx.cs" Inherits="GKICMP.networkteach.NetworkTeachDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <%--<script src="../js/jquery.min.js"></script--%>
    <title>智慧校园行政办公平台</title>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />

    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_MID" runat="server" Value="" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">网络课程信息</th>
                    </tr>
                    <tr>
                        <td align="right" width="80">课程名称</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="txt_NTTName" runat="server"></asp:Literal>
                        </td> </tr>
                    <tr>
                        <td align="right" width="80">适合年级</td>
                        <td align="left" >
                            <asp:Literal ID="ddl_EPID" runat="server"></asp:Literal>
                        </td>
                        <td align="right">所属课程</td>
                        <td align="left">
                            <asp:Literal ID="ddl_CID" runat="server"></asp:Literal>
                        </td> 
                    </tr>
                     <tr>
                        <td align="right">可见班级</td>
                        <td align="left" colspan="3">
                            <asp:Literal ID="cbl_Class" runat="server"></asp:Literal>
                        </td> 
                    </tr>
                    <tr>
                        <td align="right">在线开始时间</td>
                        <td>
                            <asp:Literal ID="txt_TeaBegin" runat="server"></asp:Literal>
                        </td>
                   
                        <td align="right">在线结束时间</td>
                        <td >
                            <asp:Literal ID="txt_TeaEnd" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">是否允许交流</td>
                        <td colspan="3">
                            <asp:Literal ID="cb_IsOrNot" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">上传人</td>
                        <td >
                            <asp:Literal ID="ltl_CreateName" runat="server"></asp:Literal>
                        </td>
                        <td align="right">上传时间</td>
                        <td >
                            <asp:Literal ID="ltl_CreateDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                     <tr>
                        <td align="right">资源附件</td>
                        <td colspan="3">
                            <asp:LinkButton ID="lbtn_Sourse"  runat="server"   OnClick="lbtn_Sourse_Click"><%=GetName()%></asp:LinkButton>
                        </td>
                    </tr>
                    
                </tbody>
            </table>
        </div>
    </form>
    
    
</body>
</html>

