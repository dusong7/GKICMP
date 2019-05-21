(function () {
    $j2.fn.jCarouselLite = function (o) {
        o = $j2.extend({
            btnPrev: null,
            btnNext: null,
            btnGo: null,
            mouseWheel: false,
            auto: null,
            speed: 1000,
            easing: null,
            vertical: false,
            circular: true,
            visible: 3,
            start: 0,
            scroll: 1,
            beforeStart: null,
            afterEnd: null
        },
        o || {});
        return this.each(function () {
            var b = false,
            animCss = o.vertical ? "top" : "left",
            sizeCss = o.vertical ? "height" : "width";
            var c = $j2(this),
            ul = $j2("ul", c),
            tLi = $j2("li", ul),
            tl = tLi.size(),
            v = o.visible;
            if (o.circular) {
                ul.prepend(tLi.slice(tl - v - 1 + 1).clone()).append(tLi.slice(0, v).clone());
                o.start += v
            }
            var f = $j2("li", ul),
            itemLength = f.size(),
            curr = o.start;
            c.css("visibility", "visible");
            f.css({
                overflow: "hidden",
                float: o.vertical ? "none" : "left"
            });
            ul.css({
                margin: "0",
                padding: "0",
                position: "relative",
                "list-style-type": "none",
                "z-index": "1"
            });
            c.css({
                overflow: "hidden",
                position: "relative",
                "z-index": "2",
                left: "0px"
            });
            var g = o.vertical ? height(f) : width(f);
            var h = g * itemLength;
            var j = g * v;
            f.css({
                width: f.width(),
                height: f.height()
            });
            ul.css(sizeCss, h + "px").css(animCss, -(curr * g));
            c.css(sizeCss, j + "px");
            if (o.btnPrev) $j2(o.btnPrev).click(function () {
                return go(curr - o.scroll)
            });
            if (o.btnNext) $j2(o.btnNext).click(function () {
                return go(curr + o.scroll)
            });
            if (o.btnGo) $j2.each(o.btnGo,
            function (i, a) {
                $j2(a).click(function () {
                    return go(o.circular ? o.visible + i : i)
                })
            });
            if (o.mouseWheel && c.mousewheel) c.mousewheel(function (e, d) {
                return d > 0 ? go(curr - o.scroll) : go(curr + o.scroll)
            });
            if (o.auto) setInterval(function () {
                go(curr + o.scroll)
            },
            o.auto + o.speed);
            function vis() {
                return f.slice(curr).slice(0, v)
            };
            function go(a) {
                if (!b) {
                    if (o.beforeStart) o.beforeStart.call(this, vis());
                    if (o.circular) {
                        if (a <= o.start - v - 1) {
                            ul.css(animCss, -((itemLength - (v * 2)) * g) + "px");
                            curr = a == o.start - v - 1 ? itemLength - (v * 2) - 1 : itemLength - (v * 2) - o.scroll
                        } else if (a >= itemLength - v + 1) {
                            ul.css(animCss, -((v) * g) + "px");
                            curr = a == itemLength - v + 1 ? v + 1 : v + o.scroll
                        } else curr = a
                    } else {
                        if (a < 0 || a > itemLength - v) return;
                        else curr = a
                    }
                    b = true;
                    ul.animate(animCss == "left" ? {
                        left: -(curr * g)
                    } : {
                        top: -(curr * g)
                    },
                    o.speed, o.easing,
                    function () {
                        if (o.afterEnd) o.afterEnd.call(this, vis());
                        b = false
                    });
                    if (!o.circular) {
                        $j2(o.btnPrev + "," + o.btnNext).removeClass("disabled");
                        $j2((curr - o.scroll < 0 && o.btnPrev) || (curr + o.scroll > itemLength - v && o.btnNext) || []).addClass("disabled")
                    }
                }
                return false
            }
        })
    };
    function css(a, b) {
        return parseInt($j2.css(a[0], b)) || 0
    };
    function width(a) {
        return a[0].offsetWidth + css(a, 'marginLeft') + css(a, 'marginRight')
    };
    function height(a) {
        return a[0].offsetHeight + css(a, 'marginTop') + css(a, 'marginBottom')
    }
})(jQuery);

$j2(function () {
    $j2("#botton-scroll").jCarouselLite({
        btnNext: ".next",
        btnPrev: ".prev"
    });
});

$j2(function () {
    $j2('#top-menu li').hover(function () {
        $j2('ul', this).slideDown(200);
    },
    function () {
        $j2('ul', this).slideUp(200);
    });
});

$j2(function () {
    $j2(".click").click(function () {
        $j2("#panel").slideToggle("slow");
        $j2(this).toggleClass("active");
        return false;
    });
});

$j2(function () {
    $j2('.fade').hover(function () {
        $j2(this).fadeTo("slow", 0.5);
    },
    function () {
        $j2(this).fadeTo("slow", 5);
    });
}); //Ò»Á÷ËØ²ÄÍøwww.16sucai.com
