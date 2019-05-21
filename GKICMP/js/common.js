//==关闭窗口
function winclose(ucid) {
    var uc = "";
    if (arguments.length > 0) {
        uc = ucid + "_";
    }
    if (parent.document.getElementById(uc + "btn_Search")) {
        parent.document.getElementById(uc + "btn_Search").click();
    }
    else {
        parent.location.reload();
    }
}
function Refresh() {
    if (parent.document.getElementById("btn_Search")) {
        parent.document.getElementById("btn_Search").click();
    }
    else {
        parent.location.reload();
    }



}