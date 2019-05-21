
function isEmail(name) {
    var pattern = /^(\w)+(\.\w+)*@(\w)+((\.\w+)+)$/;
    return pattern.test(name);
}
function isPhoneNo(phone) {
    var pattern = /^1[3456789]\d{9}$ /;
    return pattern.test(phone);
}

function isTel(card) {
    var pattern = /^(\d{3,4}\)|\d{3,4}-|\s)?\d{7,14}/;
    return pattern.test(card);
}

function onclickinput() {
    pmcontent = $("#pmcontent").val();
    thislink = $("#thislink").val();
    realname = $("#realname").val();
    if (pmcontent == null || pmcontent == undefined || pmcontent == '') {
        alert("请输入邮件内容");
        return;
    }
    else if (realname == null || realname == undefined || realname == '') {
        alert("请输入联系人");
        return;
    }
    else if (isPhoneNo(thislink) == false && isTel(thislink) == false && isEmail(thislink) == false)
    {
        alert("请输入正确的联系方式!只能输入手机、电话或邮箱");
        return;
    };
    $.getJSON("/Index/PrinMailbox?pmcontent=" + pmcontent + "&link=" + thislink + "&realname=" + realname, null, function (item) {
        if (item != null && item == "success") {
            alert("邮件发送成功");
            window.location.href = "/phone";
        }
    });
}