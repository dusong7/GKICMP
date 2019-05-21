<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wx.aspx.cs" Inherits="GKICMP.test.wx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="http://res.wx.qq.com/open/js/jweixin-1.2.0.js"></script>
    <script>
        wx.config({
            beta: true,// 必须这么写，否则在微信插件有些jsapi会有问题
            debug: true, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
            //appId: 'wxe0b787e4eaa1102c', // 必填，企业微信的cropID
            //timestamp: '1504534811', // 必填，生成签名的时间戳
            //nonceStr: 'whgk', // 必填，生成签名的随机串
            //signature: 'c4a47c7a2be3e97cd5d6a5313b1b717173c9c65b',// 必填，签名，见附录1
            appId: 'wxe0b787e4eaa1102c', // 必填，企业微信的cropID
            timestamp: '<%=timestamp%>', // 必填，生成签名的时间戳
            nonceStr: '<%=nonceStr%>', // 必填，生成签名的随机串
            signature: '<%=signature%>',// 必填，签名，见附录1
            jsApiList: ['getLocation'] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
        });
        wx.ready(function () {
            alert("123");
            wx.getLocation({
                type: 'wgs84', // 默认为wgs84的gps坐标，如果要返回直接给openLocation用的火星坐标，可传入'gcj02'
                success: function (res) {
                    var latitude = res.latitude; // 纬度，浮点数，范围为90 ~ -90
                    var longitude = res.longitude; // 经度，浮点数，范围为180 ~ -180。
                    var speed = res.speed; // 速度，以米/每秒计
                    var accuracy = res.accuracy; // 位置精度
                    alert(latitude + ',' + longitude);
                },
                error: function (res) { alert("9999"); }
            });


            wx.invoke("selectEnterpriseContact", {
                "fromDepartmentId": -1,// 必填，-1表示打开的通讯录从自己所在部门开始展示, 0表示从最上层开始
                "mode": "single",// 必填，选择模式，single表示单选，multi表示多选
                "type": ["department", "user"],// 必填，选择限制类型，指定department、user中的一个或者多个
                "selectedDepartmentIds": [2, 3],// 非必填，已选部门ID列表
                "selectedUserIds": ["lisi", "lisi2"]// 非必填，已选用户ID列表
            }, function (res) {
                if (res.err_msg == "selectEnterpriseContact:ok") {
                    var selectedDepartmentList = res.result.departmentList;// 已选的部门列表
                    for (var i = 0; i < selectedDepartmentList.length; i++) {
                        var department = selectedDepartmentList[i];
                        var departmentId = department.id;// 已选的单个部门ID
                        var departemntName = department.name;// 已选的单个部门名称
                    }
                    var selectedUserList = res.result.userList; // 已选的成员列表
                    for (var i = 0; i < selectedUserList.length; i++) {
                        var user = selectedUserList[i];
                        var userId = user.id; // 已选的单个成员ID
                        var userName = user.name;// 已选的单个成员名称
                        var userAvatar = user.avatar;// 已选的单个成员头像
                        wx.openEnterpriseChat({
                            userIds: userId,    // 必填，参与会话的成员列表。格式为userid1;userid2;...，用分号隔开，最大限制为2000个。userid单个时为单聊，多个时为群聊。
                            groupName: '',  // 必填，会话名称。单聊时该参数传入空字符串""即可。
                            success: function (res) {
                                // 回调
                            },
                            fail: function (res) {
                                if (res.errMsg.indexOf('function not exist') > -1) {
                                    alert('版本过低请升级')
                                }
                            }
                        });
                    }
                }
            }
);
            //alert("88");

//            wx.invoke("selectEnterpriseContact", {
//                "fromDepartmentId": -1,// 必填，-1表示打开的通讯录从自己所在部门开始展示, 0表示从最上层开始
//                "mode": "single",// 必填，选择模式，single表示单选，multi表示多选
//                "type": ["department", "user"],// 必填，选择限制类型，指定department、user中的一个或者多个
//                //"selectedDepartmentIds": [2, 3],// 非必填，已选部门ID列表
//                //"selectedUserIds": ["lisi", "lisi2"]// 非必填，已选用户ID列表
//            }, function (res) {
//                alert("888");
//                if (res.err_msg == "selectEnterpriseContact:ok") {
//                    var selectedDepartmentList = res.result.departmentList;// 已选的部门列表
//                    for (var i = 0; i < selectedDepartmentList.length; i++) {
//                        var department = selectedDepartmentList[i];
//                        var departmentId = department.id;// 已选的单个部门ID
//                        var departemntName = department.name;// 已选的单个部门名称
//                    }
//                    var selectedUserList = res.result.userList; // 已选的成员列表
//                    alert("999");
//                    for (var i = 0; i < selectedUserList.length; i++) {
//                        var user = selectedUserList[i];
//                        var userId = user.id; // 已选的单个成员ID
//                        var userName = user.name;// 已选的单个成员名称
//                        var userAvatar = user.avatar;// 已选的单个成员头像
//                    }
//                }
//            }
//);
           
            // config信息验证后会执行ready方法，所有接口调用都必须在config接口获得结果之后，config是一个客户端的异步操作，所以如果需要在页面加载时就调用相关接口，则须把相关接口放在ready函数中调用来确保正确执行。对于用户触发时才调用的接口，则可以直接调用，不需要放在ready函数中。
        });
        wx.error(function (res) {
            alert("456");
            // config信息验证失败会执行error函数，如签名过期导致验证失败，具体错误信息可以打开config的debug模式查看，也可以在返回的res参数中查看，对于SPA可以在这里更新签名。
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
