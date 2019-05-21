<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppRepairDetail.aspx.cs" Inherits="GKICMP.app.AppRepairDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <link href="../appcss/mui.min.css" rel="stylesheet" />
    <link href="../appcss/mui.css" rel="stylesheet" />
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <link rel="stylesheet" href="../appcss/iconfont.css" />
    <link href="../appcss/mui.picker.css" rel="stylesheet" />
    <link href="../appcss/mui.poppicker.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../appjs/mui.min.js"></script>
    <script src="../appjs/mui.picker.js"></script>
    <script src="../appjs/mui.poppicker.js"></script>
    <title>在线报修</title>
    <%--<script>
     $(function () {
        // $.ajaxSettings.async = false;
         var url = "../ashx/GetBaseDate.ashx?method=GetUser&data=js";
         $.getJSON(url, function (data) {
             $('#Series').combotree({
                 data: data.data,
                 multiple: false,
                 onlyleaf: true,
                 onSelect: function (node) {
                     //返回树对象  
                     var tree = $(this).tree;
                     //选中的节点是否为叶子节点,如果不是叶子节点,清除选中  
                     var isLeaf = tree('isLeaf', node.target);
                     if (!isLeaf) {
                         //清除选中  
                         $('#Series').combotree('clear');
                     }
                     else
                     {
                         document.getElementById("hf_SelectedValue").value = node.id;
                         document.getElementById("hf_PValue").value = node.Parent.id;
                         //alert(document.getElementById("hf_SelectedValue").value)
                     }
                 }
             });
         });

        });
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_SelectedValue" runat="server" />
        <asp:HiddenField ID="hf_PValue" runat="server" />
        <div class="mui-content">
            <div class="mui-content-padded w100">
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>资产编号</label>
                        <asp:TextBox ID="txt_DataDesc" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>类别</label>
                        <asp:TextBox ID="txt_Type" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>品牌</label>
                        <asp:TextBox ID="txt_Brand" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>规格型号</label>
                        <asp:TextBox ID="txt_SpecificationModel" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>计量单位</label>
                       <asp:TextBox ID="txt_AUnit" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>供应商</label>
                       <asp:TextBox ID="txt_Suppliers" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>置购日期</label>
                       <asp:TextBox ID="txt_BuyDate" runat="server"></asp:TextBox>
                    </div>
                </div>
                 <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>质保到期</label>
                        <asp:TextBox ID="txt_PlanYear" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>报修设备</label>
                        <asp:TextBox ID="txt_RepairObj" runat="server" CssClass="mui-icon-location"></asp:TextBox>
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>受理部门</label>
                        <asp:TextBox runat="server" name="shpdep" ID="txt_Dep" placeholder="请选择部门"></asp:TextBox>
                        <asp:HiddenField ID="hf_Dep" runat="server" />
                        <asp:Button ID="btn_SearchUser" runat="server" OnClick="btn_SearchUser_Click" />
                    </div>
                </div>

                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>受理人员</label>
                        <asp:TextBox runat="server" name="shpuser" ID="txt_User" placeholder="请选择人员"></asp:TextBox>
                        <asp:HiddenField ID="hf_User" runat="server" />
                    </div>
                </div>
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>维修单位</label>
                        <asp:TextBox runat="server" name="shpdep" ID="txt_D" placeholder="请选择单位"></asp:TextBox>
                        <asp:HiddenField ID="hf_D" runat="server" />
                    </div>
                </div>
                <div class="textarea-div">
                    <div class="mui-input-group hybt linght40">
                        <p>故障描述</p>
                        <asp:TextBox ID="txt_RepairContent" TextMode="MultiLine" runat="server" MaxLength="200" Rows="3" placeholder="请在此填写故障内容"></asp:TextBox>
                    </div>
                </div>

                 <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>附件</label>
                        <asp:FileUpload ID="fl_File" runat="server" />
                        <asp:HiddenField ID="hf_File" runat="server" />
                    </div>
                    
                </div>
                <asp:Button ID="btn_Sumbit" runat="server" Text="提交" class="mui-btn mui-btn-primary mui-btn-block bgcolor" OnClick="btn_Sumbit_Click" />
            </div>
            <nav class="mui-bar mui-bar-tab">
               <a href="/phone" class="mui-tab-item ">
                <span class="mui-icon mui-icon-home"></span>
                <span class="mui-tab-label">网站</span>
            </a>
                <a class="mui-tab-item">
                    <span class="mui-icon iconfont icon-wd"></span>
                    <span class="mui-tab-label">我的</span>
                </a>
                <a class="mui-tab-item">
                    <span class="mui-icon iconfont icon-bj"></span>
                    <span class="mui-tab-label">班级</span>
                </a>
                <a href="AppMain.aspx" class="mui-tab-item mui-active">
                    <span class="mui-icon iconfont icon-zhxy"></span>
                    <span class="mui-tab-label">智慧校园</span>
                </a>
            </nav>
        </div>
        <asp:Literal ID="ltl_User" runat="server"></asp:Literal>
    </form>
    <script>
        (function ($, doc) {
            $.init();
            $.ready(function () {
                var userPicker = new $.PopPicker();
                // userPicker.setData([]);
                $.ajax({
                    url: "../ashx/GetBaseDate.ashx",
                    cache: false, type: "GET",
                    data: "method=GetDepAPP&data=js",
                    dataType: "json",
                    success: function (d) {
                        userPicker.setData(
                        d.data
                        );
                    },
                    error: function () { alert("查询出错，请稍候再试"); }
                });
                var showUserPickerButton = doc.getElementById('txt_Dep');
                var userResult = doc.getElementById('txt_Dep');
                var userCustName = doc.getElementById('hf_Dep');
                showUserPickerButton.addEventListener('tap', function (event) {
                    userPicker.show(function (items) {
                        userResult.value = items[0].text;
                        userCustName.value = items[0].value;
                        document.getElementById("btn_SearchUser").click();
                    });
                }, false);


                var userPicker1 = new $.PopPicker();
                // userPicker.setData([]);
                $.ajax({
                    url: "../ashx/GetDataByApp.ashx",
                    cache: false, type: "GET",
                    data: "method=GetSupp",
                    dataType: "json",
                    success: function (d) {
                        userPicker1.setData(
                        d.data
                        );
                    },
                    error: function () { alert("查询出错，请稍候再试"); }
                });
                var showUserPickerButton = doc.getElementById('txt_D');
                var userResult1 = doc.getElementById('txt_D');
                var userCustName1 = doc.getElementById('hf_D');
                showUserPickerButton.addEventListener('tap', function (event) {
                    userPicker1.show(function (items) {
                        userResult1.value = items[0].text;
                        userCustName1.value = items[0].value;
                    });
                }, false);

            });
        })(mui, document);
        mui('body').on('tap', 'a', function () { document.location.href = this.href; });
    </script>
</body>
</html>
