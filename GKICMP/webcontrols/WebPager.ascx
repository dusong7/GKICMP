<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebPager.ascx.cs" Inherits="GKICMP.webcontrols.WebPager" %>
<div class="fy">
    共<span class="number"><asp:Literal ID="ltlRecordCount" runat="server" Text="0"></asp:Literal></span>条记录 每页<span class="number"><asp:Literal ID="ltlPageSize" runat="server" Text="10"></asp:Literal></span>条 共 <span class="number">
        <asp:Literal ID="ltlPageCount" runat="server"></asp:Literal></span> 页                    
                            <asp:LinkButton ID="lbtnPrevious" runat="server" OnCommand="ToggleCommon_Click"
                                CommandArgument="previous">  上一页</asp:LinkButton>
    <asp:LinkButton ID="lbtnNext" runat="server" OnCommand="ToggleCommon_Click"
        CommandArgument="next">下一页</asp:LinkButton>
    <asp:LinkButton ID="lbtnFirst" runat="server" OnCommand="ToggleCommon_Click" CommandArgument="first"> 首页</asp:LinkButton>
    <asp:LinkButton ID="lbtnLast" runat="server" OnCommand="ToggleCommon_Click" CommandArgument="last">  末页</asp:LinkButton>
    跳转到
           <asp:TextBox ID="txtCurrentPage" CssClass="tzbg" runat="server" MaxLength="4"
               Width="30px"></asp:TextBox>页              
       <asp:Button ID="ibtnGo" runat="server" Text="跳转" OnCommand="ToggleCommon_Click" CommandArgument="go" CssClass="tzbt" />
    <asp:RegularExpressionValidator ID="revCurrentPage" runat="server" ControlToValidate="txtCurrentPage"
    ValidationExpression="\d*" SetFocusOnError="true"></asp:RegularExpressionValidator>
<asp:RangeValidator ID="rvCurrentPage" runat="server" ControlToValidate="txtCurrentPage"
    SetFocusOnError="true" Type="Integer"></asp:RangeValidator>
</div>

