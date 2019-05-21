

function GetURL(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;

    //var params = decodeURI(window.location.search);        /* 截取？号后面的部分*/
    //var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    //var r = params.substr(1).match(reg);
    //if (r != null) return unescape(r[2]); return null;

}

//获取 url 后的参数值
//function GetURL(name) {
//    var paraArr = location.search.substring(1).split('&');
//    for (var i = 0; i < paraArr.length; i++) {
//        if (name == paraArr[i].split('=')[0]) {
//            return paraArr[i].split('=')[1];
//        }
//    }
//    return '';
//}

function getClass(tagName, parentClassName, className) {

    var tags = document.getElementsByTagName(tagName);//获取标签   
    var tagArr = [];//用于返回类名为className的元素
    for (var i = 0; i < tags.length; i++) {
        if (tags[i].className.indexOf(className) >= 0 && tags[i].parentElement.className == parentClassName) {

            tagArr[tagArr.length] = tags[i];//保存满足条件的元素
        }
    }
    return tagArr;

}

function InitNode(nodeName, nodeClass) {
    var node = document.createElement(nodeName);
    if (nodeClass != "" && nodeClass != null)
        node.className = nodeClass;
    return node;
}

