// 选中父权限时 选中子权限
function onCheck(obj) {
    var node = obj.parentNode.parentNode.parentNode;
    var cb = node.getElementsByTagName("input");
    for (var i = 0; i < cb.length; i++) {
        if (cb[i].type == "checkbox") {
            cb[i].checked = obj.checked;
        }
    }
}
//选中子权限时 默认选中父权限
function resetPRule(obj) {
    var choose = false;
    var node = obj.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode;
    //alert(obj.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.id);
    var cb = node.getElementsByTagName("input");
    for (var i = 1; i < cb.length; i++) {
        if (cb[i].type == "checkbox") {
            if (cb[i].checked)
                choose = true;
        }
    }
    node.getElementsByTagName("input")[0].checked = choose;
}


//选中子权限时 默认选中父权限
function resetPRuleLast(obj) {
    var choose = false;

    var node1 = obj.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode;
    var cb1 = node1.getElementsByTagName("input");
    for (var i = 2; i < cb1.length; i++) {
        if (cb1[i].type == "checkbox") {
            if (cb1[i].checked)
                choose = true;
        }
    }
    node1.getElementsByTagName("input")[1].checked = choose;
    var node = obj.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode;

    var cb = node.getElementsByTagName("input");
    for (var i = 1; i < cb.length; i++) {
        if (cb[i].type == "checkbox") {
            if (cb[i].checked)
                choose = true;
        }
    }
    node.getElementsByTagName("input")[0].checked = choose;
}

// 选中子权限时 默认选中父权限
function buttonlist(obj) {
    var e = obj.getElementsByTagName("input");
    var choose = false;
    for (var i = 0; i < e.length; i++) {
        if (e[i].type == "checkbox") {
            if (e[i].checked) {
                choose = true;
            }
        }
    }

    obj.parentNode.getElementsByTagName("input")[1].checked = choose;
    var choose2 = false;
    var node = obj.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode;
    var cb = node.getElementsByTagName("input");
    for (var i = 3; i < cb.length; i++) {
        if (cb[i].type == "checkbox") {
            if (cb[i].checked)
                choose2 = true;
        }
    }
    node.getElementsByTagName("input")[0].checked = choose2;
}
function buttonlistlast(obj) {
    var e = obj.getElementsByTagName("input");
    var choose = false;
    for (var i = 0; i < e.length; i++) {
        if (e[i].type == "checkbox") {
            if (e[i].checked) {
                choose = true;
            }
        }
    }
    obj.parentNode.getElementsByTagName("input")[1].checked = choose;
    var choose2 = false;
    var node = obj.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode;
    var cb = node.getElementsByTagName("input");
    for (var i = 3; i < cb.length; i++) {
        if (cb[i].type == "checkbox") {
            if (cb[i].checked)
                choose2 = true;
        }
    }
    node.getElementsByTagName("input")[1].checked = choose2;

    var choose3 = false;
    var nodelist = obj.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode;
    var cblist = nodelist.getElementsByTagName("input");
    for (var i = 3; i < cblist.length; i++) {
        if (cblist[i].type == "checkbox") {
            if (cblist[i].checked)
                choose3 = true;
        }
    }
    nodelist.getElementsByTagName("input")[0].checked = choose3;
}