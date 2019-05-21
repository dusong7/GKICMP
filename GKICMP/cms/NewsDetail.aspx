<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsDetail.aspx.cs" Inherits="GKICMP.cms.NewsDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园门户管理平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_Flag" runat="server" />
        <div class="listcent pad0">
            <table width="100%" cellspacing="0" cellpadding="0" class="listinfo">
                <tr>
                    <th colspan="4" align="left">新闻详细信息
                    </th>
                </tr>
                <tr>
                    <td align="right">标题：
                    </td>
                    <td>
                        <asp:Literal runat="server" ID="ltl_NewsTitle"></asp:Literal>
                    </td>
                    <td align="right">作者：</td>
                    <td>
                        <asp:Literal ID="ltl_NAuthor" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td align="right">链接：</td>
                    <td>
                        <asp:Literal ID="ltl_LinkUrl" runat="server"></asp:Literal></td>
                    <td align="right">排序：</td>
                    <td>
                        <asp:Literal ID="ltl_NOrder" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td align="right">所属栏目：</td>
                    <td>
                        <asp:Literal ID="ltl_MID" runat="server"></asp:Literal></td>
                    <td align="right">浏览次数：</td>
                    <td>
                        <asp:Literal ID="ltl_ReadCount" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td align="right">来源：</td>
                    <td>
                        <asp:Literal ID="ltl_MSourse" runat="server"></asp:Literal></td>
                    <td align="right">标题颜色：</td>
                    <td style='background-color:<%=bg%>' >
                        <asp:Literal ID="ltl_NColor" runat="server" ></asp:Literal></td>
                </tr>
                <tr>
                    <td align="right">是否置顶：</td>
                    <td>
                        <asp:Literal ID="ltl_IsTop" runat="server"></asp:Literal></td>
                    <td align="right">是否推荐：</td>
                    <td>
                        <asp:Literal ID="ltl_MDescription" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td align="right" width="110px">是否特别推荐：</td>
                    <td>
                        <asp:Literal ID="ltl_IsRecommend" runat="server"></asp:Literal></td>
                    <td align="right" width="110px">是否图片新闻：</td>
                    <td>
                        <asp:Literal ID="ltl_IsImgNews" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td align="right">禁止发表评论：</td>
                    <td>
                        <asp:Literal ID="ltl_IsComment" runat="server"></asp:Literal></td>
                    <td align="right">状态：</td>
                    <td>
                        <asp:Literal ID="ltl_Nstate" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td align="right">主题：</td>
                    <td>
                        <asp:Literal ID="ltl_NTtitle" runat="server"></asp:Literal>
                    </td>
                    <td align="right">关键字：</td>
                    <td>
                        <asp:Literal ID="ltl_NKeyWords" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td align="right">发布日期：</td>
                    <td >
                        <asp:Literal ID="ltl_CreateDate" runat="server"></asp:Literal></td>
                     <td align="right">评论次数：</td>
                    <td >
                        <asp:Literal ID="ltl_CommentNumber" runat="server"></asp:Literal></td>
                </tr>


                <tr>
                     <td align="right">是否审核：</td>
                    <td >
                        <asp:Literal ID="ltl_Audit" runat="server"></asp:Literal>
                    </td>
                    <td align="right">缩略图：</td>
                    <td  >
                        <asp:Image ID="img_ImageUrl" runat="server" width="100" height="80" />
                    </td>
                   
                </tr>
                <tr id="audit" runat="server">
                     <td align="right">审核人：</td>
                    <td >
                        <asp:Literal ID="ltl_AduitUser" runat="server"></asp:Literal>
                    </td>
                    <td align="right">审核时间：</td>
                    <td >
                        <asp:Literal ID="ltl_AduitDate" runat="server"></asp:Literal>
                    </td>
                   
                </tr>
                <tr>
                    <td align="right">描述：</td>
                    <td colspan="3">
                        <asp:Literal ID="ltl_NDescription" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td align="right">内容：</td>
                    <td colspan="3">
                        <asp:Literal ID="ltl_NContent" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <%--<asp:Button runat="server" ID="btn_Cancel" Text="返回" class="editor" OnClick="btn_Cancel_Click" />--%>
                        <input id="btn_Back" type="button" value="返回" class="editor" onclick="window.history.go(-1)" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>


