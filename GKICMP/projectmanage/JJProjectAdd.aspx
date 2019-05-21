<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JJProjectAdd.aspx.cs" Inherits="GKICMP.projectmanage.JJProjectAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>基建项目申报表</title>
   <link href="../css/green_formcss.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/select.js"></script>
    <script src="../js/common.js"></script>
     <script type="text/javascript">
         jQuery(document).ready(function () {
             jQuery("#form1").Validform();
         });

     </script>
    <style>
      body{ line-height:1.5}
      td{ padding:10px}
        .submit {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">

          <div style="text-align:center; font-size:30px;">弋江区中小学基建项目申报表</div>
            <div style="float:left; font-size:22px">申报单位（公章）：
                <asp:Literal runat="server" ID="ltl_ApplyDep"></asp:Literal>
            </div>
            <div style="float:right; margin-right:20px; font-size:22px">时间：
                 <asp:Literal ID="ltl_ApplyDate" runat="server" ></asp:Literal>
            </div>

         <div style="clear:both"></div>

  <div style="background:#575757">
    <table width="100%" border="0" cellspacing="1" cellpadding="0" >
       <tbody>
            <tr>
              <td width="13%" align="center" bgcolor="#FFFFFF">项目名称</td>
                <td align="left" colspan="2" bgcolor="#FFFFFF">
                       <asp:TextBox ID="txt_ProName" runat="server" Width="80%" datatype="*" nullmsg="请填写项目名称"></asp:TextBox>
                    <span style="color: Red; float: none">*</span>
                </td>
              
              <td width="16%" align="center" bgcolor="#FFFFFF">实施地点</td>
                <td align="left" colspan="2" bgcolor="#FFFFFF">
                       <asp:TextBox ID="txt_BuildAddr" runat="server" Width="80%" datatype="*" nullmsg="请填写实施地点"></asp:TextBox>
                    <span style="color: Red; float: none">*</span>
                </td>
            </tr>

    <tr>
      <td align="center" bgcolor="#FFFFFF">建设内容</td>
              <td align="left" colspan="2" bgcolor="#FFFFFF">
                   <asp:TextBox ID="txt_BuildContent" runat="server" Width="80%" datatype="*" nullmsg="请填写建设内容"></asp:TextBox>
                  <span style="color: Red; float: none">*</span>
               </td>
      <td align="center" bgcolor="#FFFFFF">建设性质</td>
          <td colspan="2" align="left"  bgcolor="#FFFFFF">
             <asp:DropDownList runat="server" ID="ddl_BuildNature" datatype="ddl" errormsg="请选择建设性质"></asp:DropDownList>
              <span style="color: Red; float: none">*</span>
           </td>
   </tr>

    <tr>
      <td align="center" bgcolor="#FFFFFF">建筑面积<br>（平方米）</td>
        <td width="19%" align="left" bgcolor="#FFFFFF">
               <asp:TextBox ID="txt_Acreage" runat="server" datatype="*" nullmsg="请填写建筑面积" ></asp:TextBox>
            <span style="color: Red; float: none">*</span>
         </td>
    

      <td width="14%" bgcolor="#FFFFFF"><p align="center">层 数</p></td>
         <td align="left" bgcolor="#FFFFFF">
               <asp:TextBox ID="txt_Layers" runat="server" datatype="*" nullmsg="请填写层数"></asp:TextBox>
             <span style="color: Red; float: none">*</span>
         </td>
     

      <td width="8%" bgcolor="#FFFFFF"><p align="center">结 构</p></td>
        <td width="20%" align="LEFT" bgcolor="#FFFFFF">
               <asp:TextBox ID="txt_Structure" runat="server" datatype="*" nullmsg="请填写结构"></asp:TextBox>
            <span style="color: Red; float: none">*</span>
         </td>
    </tr>

    <tr>
      <td align="center" bgcolor="#FFFFFF">资金预算 <br/> 金  额</td>
       <td align="left" bgcolor="#FFFFFF">
               <asp:TextBox ID="txt_BudgetAmount" runat="server" datatype="*" nullmsg="请填写资金预算"></asp:TextBox>
           <span style="color: Red; float: none">*</span>
         </td>
       

      <%--<td align="center" bgcolor="#FFFFFF"><p align="center">资金 </p>来源</td>--%>
        <td align="center" bgcolor="#FFFFFF">资金来源</td>

      <td colspan="3" align="LEFT" bgcolor="#FFFFFF" >
          <asp:DropDownList runat="server" ID="ddl_BSources" datatype="ddl" errormsg="请选择资金来源"></asp:DropDownList>
          <span style="color: Red; float: none">*</span>
            </td>
    </tr>

    <tr>
      <td align="center" bgcolor="#FFFFFF">项目责任人</td>
        <td colspan="2" align="left" bgcolor="#FFFFFF">
               <asp:TextBox ID="txt_DutyUser" runat="server" datatype="*" nullmsg="请填写项目负责人"></asp:TextBox>
             <span style="color: Red; float: none">*</span>
         </td>
      <td align="center" bgcolor="#FFFFFF">项目责任人联系电话</td>
      <td colspan="2" align="left" bgcolor="#FFFFFF">
            <asp:TextBox ID="txt_DutyNO" runat="server" datatype="*" nullmsg="请填写项目责任人联系电话"></asp:TextBox>
             <span style="color: Red; float: none">*</span>
        </td>
    </tr>

    <tr>
    <td align="center" bgcolor="#FFFFFF">申请单位<br />
        负责人</td>
    <td colspan="2" align="left" bgcolor="#FFFFFF">
            <asp:TextBox ID="txt_Contractor" runat="server" datatype="*" nullmsg="请填写申请单位负责人"></asp:TextBox>
         <span style="color: Red; float: none">*</span>
        </td>
    <td align="center" bgcolor="#FFFFFF">单位负责人<br />
        电话</td>
        <td colspan="2" align="left" bgcolor="#FFFFFF">
            <asp:TextBox ID="txt_PhoneNumber" runat="server" datatype="*" nullmsg="请填写单位负责人电话"></asp:TextBox>
             <span style="color: Red; float: none">*</span>
        </td>
    </tr>

    <tr>
      <td align="center" bgcolor="#FFFFFF">建设理由</td>
        <td colspan="5" bgcolor="#FFFFFF">
               <asp:TextBox ID="txt_BuildReason" TextMode="MultiLine" runat="server" Rows="3" Width="80%" Height="50px" CssClass="MultiLinebg" datatype="*1-100" nullmsg="请填写建设理由"></asp:TextBox>
            <span style="color: Red; float: none">*</span>
         </td>
      
    </tr>

    <%--<tr>
      <td align="center" bgcolor="#FFFFFF">基 建 科<br>审查意见</td>
        <td colspan="5" align="center" bgcolor="#FFFFFF">
               <asp:Literal ID="ltl_Jjk" runat="server"></asp:Literal>
         </td>

       
      </tr>
    <tr>
      <td align="center" bgcolor="#FFFFFF">领 导 审<br>
        批 意 见</td>
        <td colspan="5" align="center" bgcolor="#FFFFFF">
               <asp:Literal ID="ltl_Lead" runat="server"></asp:Literal>
         </td>
    </tr>--%>

    <tr>
      <td align="center" bgcolor="#FFFFFF">备注</td>
     <td colspan="5" align="LEFT" bgcolor="#FFFFFF">
         <asp:TextBox ID="ltl_Arrangement" TextMode="MultiLine" runat="server" Rows="3" Width="80%" Height="50px" CssClass="MultiLinebg" ></asp:TextBox>
               
         </td>
      
     </tr>
    <tr>
        <td style="text-align: center"   bgcolor="#FFFFFF" colspan="6">
            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit"  OnClick="btn_Sumbit_Click" Height="40px" />
            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />
        </td>
    </tr>

  </tbody>
</table>
</div>


        </div>
    </form>
</body>
</html>

