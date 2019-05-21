<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebPagerAPP.ascx.cs" Inherits="GKICMP.webcontrols.WebPagerAPP" %>

<div class="pagec">
    <div class="fenye">
        <asp:Literal ID="ltlPageSize" runat="server" Text="10" Visible="false"></asp:Literal>
        <asp:Literal ID="ltlPageCount" runat="server" Visible="false"></asp:Literal>
        <asp:TextBox ID="txtCurrentPage" runat="server" Visible="false"></asp:TextBox>
        <ul>
            <li width="64" align="center" class="buttonpage">
                <asp:LinkButton ID="lbtnFirst" runat="server" OnCommand="ToggleCommon_Click" CommandArgument="first"> 首页</asp:LinkButton>
            </li>
            <li width="64" align="center" class="buttonpage">
                <asp:LinkButton ID="lbtnPrevious" runat="server" OnCommand="ToggleCommon_Click"
                    CommandArgument="previous">  上一页</asp:LinkButton>
            </li>
            <li width="64" align="center" class="buttonpage">
                <asp:LinkButton ID="lbtnNext" runat="server" OnCommand="ToggleCommon_Click"
                    CommandArgument="next">下一页</asp:LinkButton>
            </li>
            <li width="64" align="center" class="buttonpage">
                <asp:LinkButton ID="lbtnLast" runat="server" OnCommand="ToggleCommon_Click" CommandArgument="last">  末页</asp:LinkButton>
            </li>
            <span>共<asp:Literal ID="ltlRecordCount" runat="server" Text="0"></asp:Literal>条记录</span>
        </ul>
    </div>
</div>
<asp:RegularExpressionValidator ID="revCurrentPage" runat="server" ControlToValidate="txtCurrentPage"
    ValidationExpression="\d*" SetFocusOnError="true"></asp:RegularExpressionValidator>
<asp:RangeValidator ID="rvCurrentPage" runat="server" ControlToValidate="txtCurrentPage"
    SetFocusOnError="true" Type="Integer"></asp:RangeValidator>
