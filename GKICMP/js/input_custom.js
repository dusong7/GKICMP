// JavaScript Document
///*radio样式开始

    var obj = document.getElementsByTagName("input");
    for (var i = 0,
    len = obj.length; i < len; i++) {
        var comp = obj[i];
        if (comp.type == 'radio') {
            var radio0 = document.getElementById(comp.id);
            if (radio0.checked) {
                document.getElementById(comp.id + "l").className = "ryxz";
            }
        }
    }

function rdjxz(thisname, thisid) {
    var rche = document.getElementsByName(thisname);
    for (var i = 0,
    len = rche.length; i < len; i++) {
        var comp = rche[i];
        if (comp.id == thisid) {
            document.getElementById(comp.id + "l").className = "ryxz";
        } else {
            document.getElementById(comp.id + "l").className = "rwxz";
        }
    }
}
///*radio样式结束*/
//*checkbox样式开始*/
var obj = document.getElementsByTagName("input");
for (var i = 0,
len = obj.length; i < len; i++) {
    var comp = obj[i];
    if (comp.type == 'checkbox') {
        var radio0 = document.getElementById(comp.id);
        if (radio0.checked) {
            //alert(comp.id+"l")
            document.getElementById(comp.id + "l").className = "yxz";
        }
    }
}
function setid(thisid) {
    var checkid = document.getElementById("hf_CheckIDS").value;
    var thische = document.getElementById(thisid);
    if (thische.checked) {
        checkid = checkid + thisid.replace('ck_', '') + ",";
        document.getElementById(thisid + "l").className = "yxz";
    } else {
        document.getElementById(thisid + "l").className = "wxz";
        checkid = checkid.replace(thisid.replace('ck_', '') + ",", '');
    }
    checkid = checkid.replace(thisid + ",", '');
    document.getElementById("hf_CheckIDS").value = checkid;
    //alert(document.getElementById("hf_CheckIDS").value);
}
///*checkbox样式结束*/
//全选js事件开始
function qx(thisname, thisid) {
    var rche = document.getElementsByName(thisname);
    var rid = document.getElementById(thisid);
    document.getElementById("hf_CheckIDS").value = "";
    var checkid = "";
    var val = null;
    if (rid.checked) {

        for (var i = 0,
        len = rche.length; i < len; i++) {
            var comp = rche[i];
            checkid = checkid + comp.id.replace('ck_', '') + ",";
            document.getElementById(comp.id).checked = "checked";
            document.getElementById(comp.id + "l").className = "yxz";

        }
    } else {
        for (var i = 0,
        len = rche.length; i < len; i++) {
            var comp = rche[i];
            checkid = checkid.replace(comp.id.replace('ck_', '') + ",", '');
            document.getElementById(comp.id).checked = "";
            document.getElementById(comp.id + "l").className = "wxz";
        }
    }
    checkid = checkid.replace(thisid + ",", '');
    document.getElementById("hf_CheckIDS").value = checkid;
    //alert(document.getElementById("hf_CheckIDS").value);
}//全选js事件结束