function getpages(data) {
    html = "";
    var total = data.Data.Total;
    if (total > pagesize) {
        var pagecount = Math.ceil(total / pagesize);
        html = html + "<a onclick=gettopend(0," + pagecount + ")>首页</a>";
        html = html + "<a onclick=getpageupdown(0," + pagecount + ")>上一页</a>";
        if (pagecount > 10) {
            if (nowpagelist > 1) {
                html = html + "<a onclick=getnext(0," + Math.ceil(pagecount / 10) + ")>...</a>";
            }
            var endcount = 10 * (nowpagelist - 1) + 10;
            endcount = endcount > pagecount ? pagecount : endcount;
            for (var i = 10 * (nowpagelist - 1) + 1; i <= endcount; i++) {
                if (i == nowpage) {
                    html = html + "<a style=\"color:red\">" + i + "</a>";
                } else {

                    html = html + "<a onclick=getpage(" + i + ")>" + i + "</a>";
                }
            }

            if (nowpagelist < Math.ceil(pagecount / 10)) {
                html = html + "<a onclick=getnext(1," + Math.ceil(pagecount / 10) + ")>...</a>";
            }
        } else {
            for (var i = 1; i <= pagecount; i++) {
                if (i == nowpage) {
                    html = html + "<a style=\"color:red\">" + i + "</a>";
                } else {

                    html = html + "<a onclick=getpage(" + i + ")>" + i + "</a>";
                }
            }
        }

        html = html + "<a onclick=getpageupdown(1," + pagecount + ")>下一页</a>";
        html = html + "<a  onclick=gettopend(1," + pagecount + ")>末页</a>共" + total + "条";
    }

    $("#pager").html(html);
}


function getnext(type, total) {
    if (type == 0) {
        if (nowpagelist > 1) {
            nowpagelist = nowpagelist - 1;
        }
    } else {
        if (nowpagelist < total) {
            nowpagelist = nowpagelist + 1;
        }
    }
    nowpage = (nowpagelist - 1) * 10 + 1;
    dopage();
}

function gettopend(type, pagecount) {
    if (type == 0) {
        nowpagelist = 1;
        getpage(1);
    } else {
        nowpagelist = Math.ceil(pagecount / 10);
        getpage(pagecount);
    }
}

function getpage(page) {
    nowpage = page;
    dopage();
}

function getpageupdown(type, pagecount) {
    if (type == 0) {
        if (nowpage > 1) {
            nowpage = nowpage - 1;
            nowpagelist = Math.ceil(nowpage / 10);
            dopage();
        }
    } else {
        if (nowpage < pagecount) {
            nowpage = nowpage + 1;
            nowpagelist = Math.ceil(nowpage / 10);
            dopage();
        }
    }
}