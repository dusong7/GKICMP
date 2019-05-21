<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkPlanEdit.aspx.cs" Inherits="GKICMP.office.WorkPlanEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
     <link href="../css/demo.css" rel="stylesheet" />
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/green_formcss.css" rel="stylesheet" />
     <script src="../js/jquery.min.js"></script>
    <script src="../js/js.js"></script>
  
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
      <script src="../js/Validform_v5.3.2.js"></script>
    <script>
        $(function () {
            if ($("#cb_IsWeb").is(":checked"))
            { document.getElementById("ddl_WebMenu").style.display = "table-row"; }
            else {
                document.getElementById("ddl_WebMenu").style.display = "none";
            };
            $("#cb_IsWeb").change(function () {
                if ($(this).is(":checked"))
                { document.getElementById("ddl_WebMenu").style.display = "table-row"; }
                else
                { document.getElementById("ddl_WebMenu").style.display = "none"; }
            });
        })

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_NID" runat="server" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">工作计划信息</th>
                    </tr>
                    <tr>
                        <td align="right">学年度/学期：</td>
                        <td align="left">
                           <asp:TextBox ID="txt_EYear" runat="server"  datatype="*" nullmsg="请填写学年度" CssClass="searchbg"
                                MaxLength="100">
                           </asp:TextBox>
                            <asp:DropDownList ID="ddl_Term" runat="server" Height="30px"></asp:DropDownList>
                            <asp:TextBox ID="txt_WeekNum" runat="server"  datatype="bigzero" nullmsg="请填写周数" CssClass="searchbg" MaxLength="100"></asp:TextBox>周
                             <span style="color: Red; float: none">*</span>
                        </td>
                        <td colspan="2">
                              <style>
                                .edilab label {
                                    float: none;
                                }

                                .edilab input {
                                    height: 13px;
                                }

                                .auto-style1 {
                                    height: 16px;
                                }
                            </style>
                            <asp:CheckBox ID="cb_IsWeb" Class="edilab" runat="server" Text="是否更新到网站" />&nbsp&nbsp&nbsp
                            <asp:DropDownList ID="ddl_WebMenu" runat="server" ></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">内容：</td>
                        <td colspan="3">
                            <asp:TextBox ID="txt_ExamName" runat="server" Style="width: 90%;height:50px" datatype="*" nullmsg="请填写内容" CssClass="searchbg"
                                TextMode="MultiLine"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right" width="10%">开始时间：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_BeginDate" runat="server" Style="width: 175px;" onclick="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请选择开始时间" CssClass="searchbg" MaxLength="100"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="10%">结束时间：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_EndDate" runat="server" Style="width: 175px;" onclick="WdatePicker({skin:'whyGreen'})" datatype="*" nullmsg="请选择结束时间" CssClass="searchbg" MaxLength="100" ckdate="txt_BeginDate"></asp:TextBox>
                             <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">参与人：</td>
                        <td align="left" colspan="3">
                             <input id="AllUsersID" name="AllUsersID" style="width: 90%;height:40px" multiline="true"  multiple="true" class="easyui-combotree" runat="server" />
                             <span style="color: Red; float: none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">部门：</td>
                        <td align="left">
                             <input id="DepID" name="DepID" style="width: 90%;height:40px" class="easyui-combotree" runat="server" />
                           <%-- <asp:TextBox ID="txt_EndPage" runat="server" datatype="zheng" nullmsg="请填写结束页码" CssClass="searchbg" MaxLength="100"></asp:TextBox>--%>
                           <%-- <span style="color: Red; float: none">*</span>--%>
                        </td>
                        <td align="right">责任人：</td>
                        <td align="left">

                            <input id="DutyUser" name="DutyUser" style="width: 90%;height:40px" class="easyui-combotree" runat="server" />
                            <%--<asp:DropDownList ID="ddl_URoles" runat="server" datatype="ddl" nullmsg="请选择本人角色"></asp:DropDownList>--%>
                          <%--  <span style="color: Red; float: none">*</span>--%>
                        </td>
                    </tr>
                    <tr id="IsWeb">
                        <td colspan="4">
                            
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClientClick="SetValue()" OnClick="btn_Sumbit_Click" />
                            <%--<input type="button" name="button" id="cancell" value="取消" class="editor" onclick=' $.close("A_id");' />--%>
                            <input type="button" name="button" id="cancell" value="取消" class="editor" onclick='javascript: window.history.back(-1);' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        
        <asp:HiddenField ID="hf_DepID" runat="server" />
        <asp:HiddenField ID="hf_DutyUser" runat="server" />
        <asp:HiddenField ID="hf_AlluserID" runat="server" />
        <asp:HiddenField ID="hf_AllUsersText" runat="server" /><asp:Literal ID="ltl_Get" runat="server"></asp:Literal>
    </form>
    <script>
        //function check() {
        //    if ($("#hf_DutyUser").val() == "") { alert("请选择责任人"); return false; }
        //    if ($("#hf_DepID").val() == "") { alert("请选择部门"); return false; }
        //}
        $(function () {
            $.ajax({
                url: "../ashx/GetBaseDate.ashx",
                cache: false, type: "GET",
                data: "method=GetDep&data=js",
                dataType: "json",
                async:false,
                success: function (d) {
                    $('#DepID').combotree({ data: d.data, multiple: false, });
                    //var c = $("#hf_DepID").val(); $('#DepID').combotree('setValues', [c]);
                },
                error: function () { alert("查询出错，请稍候再试"); }
            });
            $.ajax({
                url: "../ashx/GetBaseDate.ashx",
                cache: false, type: "GET",
                data: "method=GetUser&data=js&all=1",
                dataType: "json",
                async: false,
                success: function (d) {
                    $('#DutyUser').combotree({ data: d.data, multiple: false, onlyLeafCheck: true,  });
                    $('#AllUsersID').combotree({ data: d.data,checked:true, multiple: true, /*onlyLeafCheck: true,*//*multiline: true,*/ });
                    //var a = $("#hf_AlluserID").val().split(',');
                    //var c = $("#hf_DutyUser").val();
                    //$('#AllUsers').combotree('setValues', $("#hf_AlluserID").val().split(','));
                    //$('#DutyUser').combotree('setValues', [$("#hf_DutyUser").val()]);
                },
                error: function () { alert("查询出错，请稍候再试"); }
            });
            $('#DutyUser').combotree({
                onSelect: function (node)
                {
                    var tree = $(this).tree;
                    //选中的节点是否为叶子节点,如果不是叶子节点,清除选中  
                    var isLeaf = tree('isLeaf', node.target);
                    if (!isLeaf) {
                        //清除选中  
                        $('#DutyUser').combotree('clear');
                    }
                    else {
                        document.getElementById("hf_DutyUser").value = node.id;
                        //alert(document.getElementById("hf_SelectedValue").value)
                    }
                    //var val = node.id;
                    //document.getElementById("hf_DutyUser").value = val;
                }
            });
            $('#DepID').combotree({
                onSelect: function (node) {
                    var tree = $(this).tree;
                    //选中的节点是否为叶子节点,如果不是叶子节点,清除选中  
                    var isLeaf = tree('isLeaf', node.target);
                    if (!isLeaf) {
                        //清除选中  
                        $('#DepID').combotree('clear');
                    }
                    else {
                        document.getElementById("hf_DepID").value = node.id;
                        //alert(document.getElementById("hf_SelectedValue").value)
                    }
                  //  var val = node.id; document.getElementById("hf_DepID").value = val;
                }
            });
            //$('#AllUsers').combotree({
            //    onSelect: function (node) {
            //        alert(node.text);
            //        var val = node.id;
            //        document.getElementById("hf_DepID").value = val;
            //    }
            //});
            jQuery("#form1").Validform();
        });
        $(function () {
            var c = $("#hf_DepID").val(); $('#DepID').combotree('setValues', [c]);
            var all = $("#hf_AlluserID").val();
            if (all == '')
                $('#AllUsersID').combotree('setValues', '0');
            else
                $('#AllUsersID').combotree('setValues', $("#hf_AlluserID").val().split(','));
            $('#DutyUser').combotree('setValues', [$("#hf_DutyUser").val()]);
        });
    </script>
    <script>
        function SetValue() {
                var U = new Array();
                var A = new Array();
               // var t = $("#AllUsersID").combotree("tree")
                $($("#AllUsersID").combotree("tree").tree("getChecked")).each(function () {
                    if (this.children == null && $("#AllUsersID").combotree("tree").tree("find", this.id) != null) {
                        U.push(this.id); A.push(this.text);
                    };
                });
                document.getElementById("hf_AlluserID").value = U;
                document.getElementById("hf_AllUsersText").value = A;
        };
    </script>
</body>
</html>







