//------------- charts.js -------------//
$(document).ready(function() {

	//get object with colros from plugin and store it.
	var objColors = $('body').data('sprFlat').getColors();
	var colours = {
		white: objColors.white,
		dark: objColors.dark,
		red : objColors.red,
		blue: objColors.blue,
		green : objColors.green,
		yellow: objColors.yellow,
		brown: objColors.brown,
		orange : objColors.orange,
		purple : objColors.purple,
		pink : objColors.pink,
		lime : objColors.lime,
		magenta: objColors.magenta,
		teal: objColors.teal,
		textcolor: '#5a5e63',
		gray: objColors.gray
	}

	//generate random number for charts
	randNum = function(){
		return (Math.floor( Math.random()* (1+150-50) ) ) + 80;
	}
	
	//$(function () {
	//    $.ajaxSettings.async = false;
	//    var options = {
	//        series: {
	//            pie: {
	//                show: true,
	//                innerRadius: 0.55,
	//                highlight: {
	//                    opacity: 0
	//                },
	//                radius: 1,
	//                stroke: {
	//                    width: 10
	//                },
	//                startAngle: 2.15
	//            }
	//        },
	//        legend: {
	//            show: true,
	//            labelFormatter: function (label, series) {
	//                return '<div style="font-weight:bold;font-size:13px;">' + label + '</div>'
	//            },
	//            labelBoxBorderColor: null,
	//            margin: 50,
	//            width: 20,
	//            padding: 1
	//        },
	//        grid: {
	//            hoverable: true,
	//            clickable: true,
	//        },
	//        tooltip: true, //activate tooltip
	//        tooltipOpts: {
	//            content: "%s : %y.0人" ,
	//            shifts: {
	//                x: -30,
	//                y: -50
	//            },
	//            theme: 'dark',
	//            defaultTheme: false
	//        }
	//    };
	//    $.get("../ashx/StatisticsHandler.ashx?method=Age", function (dd) {

	//        //var a = dd.result;
	//        //alert(a);
	//        var data = [
    //     { label: "25岁以下", data: dd.S25, color: "#5A5AAD" },
    //     { label: "26-30岁", data: dd.S26, color: "#009966" },
    //     { label: "31-35岁", data: dd.S31, color: "#FF6600" },
    //     { label: "36-40岁", data: dd.S36, color: "#666666" },
    //     { label: "41-45岁", data: dd.S41, color: "#EAC100" },
    //     { label: "46-50岁", data: dd.S46, color: "#336699" },
    //     { label: "51-55岁", data: dd.S51, color: "#FF6666" },
    //     { label: "56-60岁", data: 1, color: "#2894FF" }
	//        ];
	//        $.plot($("#donut-chart"), data, options);
	//    }, "json");

	  


	//});
	//$(function () {
	//    $.ajaxSettings.async = false;
	//    //some data
	//    var d1 = [];
	//    //for (var i = 0; i <= 10; i += 1)
	//    //    d1.push([i, parseInt(Math.random() * 30)]);

	//    var d2 = [];
	//    //for (var i = 0; i <= 10; i += 1)
	//    //    d2.push([i, parseInt(Math.random() * 30)]);

	//    var d3 = []; var d4 = [];
	//    //for (var i = 0; i <= 10; i += 1)
	//    //    d3.push([i, parseInt(Math.random() * 30)]);
	//    var d5=[];
	//    $.getJSON("../ashx/StatisticsHandler.ashx?method=Edu", function (dd) {
	//        $.each(dd.comments, function (i, item) {
	//            d1.push([i, item.YJS]);
	//            d2.push([i, item.BK]);
	//            d3.push([i, item.DZ]);
	//            d4.push([i, item.ZS]);
	//            d5.push([i,item.DName]);
	//        });
	//    });
	//    var ds = new Array();
	   
	//    ds.push({
	//        label: "研究生",
	//        data: d1,
     
	//        bars: { order: 1 }
	//    });
	//    ds.push({
	//        label: "本科",
	//        data: d2,
	//        bars: { order: 2 }
	//    });
	//    ds.push({
	//        label: "大专",
	//        data: d3,
	//        bars: { order: 3 }
	//    });
	//    ds.push({
	//        label: "中师",
	//        data: d4,
	//        bars: { order: 4 }
	//    });
	//    //var stack = 0, bars = false, lines = false, steps = false;
	//    //for (var i = 0; i < 8; i++) {
	//    //    d1.push([new Date(Date.today().add(i).days()).getTime(), randNum()]);
	//    //}
	//    //var tickSize = [1, "day"];
	//    //var tformat = "%d/%m/%y";
	//    //var chartMinDate = d1[0][0]; //first day
	//    //var chartMaxDate = d1[7][0];//last day
	//    var options = {
	//        bars: {
	//            show: true,
	//            barWidth: 0.2,
	//            fill: 1
	//        },
	//        xaxis: {
	//           // mode: "text",
	//           // mode: d5,
	//            tickFormatter:"string",
	//           // mode: "time",
	//            //minTickSize: tickSize,
	//            //timeformat: tformat,
	//            ticks: d5,
	//           // max: d5[1],
	//            tickLength: 0,
	            
	//        },
	//        grid: {
	//            show: true,
	//            aboveData: false,
	//            color: colours.textcolor,
	//            labelMargin: 5,
	//            axisMargin: 0,
	//            borderWidth: 0,
	//            borderColor: null,
	//            minBorderMargin: 5,
	//            clickable: true,
	//            hoverable: true,
	//            autoHighlight: false,
	//            mouseActiveRadius: 20
	//        },
	//        series: {
	//            stack: null
	//        },
	//        legend: { position: "ne" },
	//        colors: ["#339999", "#46A3FF", "#009966", "#FF9966"],
	//        tooltip: true, //activate tooltip
	//        tooltipOpts: {
	//            content: "%s : %y.0",
	//            shifts: {
	//                x: -30,
	//                y: -50
	//            }
	//        }
	//    };

	//    $.plot($("#ordered-bars-chart"), ds, options);
	//});
	
	

	

	//------------- Sparklines -------------//
	$('.sparkline-positive').sparkline([5,12,18,15,22, 14,26,28,32,34], {
		width: '55px',
		height: '20px',
		lineColor: colours.green,
		fillColor: false,
		spotColor: false,
		minSpotColor: false,
		maxSpotColor: false,
		lineWidth: 2
	});

	$('.sparkline-negative').sparkline([17,3,9,12,8,4,9,5,2,5], {
		width: '55px',
		height: '20px',
		lineColor: colours.red,
		fillColor: false,
		spotColor: false,
		minSpotColor: false,
		maxSpotColor: false,
		lineWidth: 2
	});

	$('.sparkline-bar-positive').sparkline([5,12,18,15,22, 14,26,28,32,34], {
		type: 'bar',
		width: '100%',
		height: '18px',
		barColor: colours.green,
	});

	$('.sparkline-bar-negative').sparkline([17,3,9,12,8,4,9,5,2,5], {
		type: 'bar',
		width: '100%',
		height: '18px',
		barColor: colours.red,
	});

	//------------- Sparklines in sidebar -------------//
	$('#usage-sparkline').sparkline([35,46,24,56,68, 35,46,24,56,68], {
		width: '180px',
		height: '30px',
		lineColor: colours.dark,
		fillColor: false,
		spotColor: false,
		minSpotColor: false,
		maxSpotColor: false,
		lineWidth: 2
	});

	$('#cpu-sparkline').sparkline([22,78,43,32,55, 67,83,35,44,56], {
		width: '180px',
		height: '30px',
		lineColor: colours.dark,
		fillColor: false,
		spotColor: false,
		minSpotColor: false,
		maxSpotColor: false,
		lineWidth: 2
	});

	$('#ram-sparkline').sparkline([12,24,32,22,15, 17,8,23,17,14], {
		width: '180px',
		height: '30px',
		lineColor: colours.dark,
		fillColor: false,
		spotColor: false,
		minSpotColor: false,
		maxSpotColor: false,
		lineWidth: 2
	});

    //------------- Init pie charts -------------//
    //pass the variables to pie chart init function
    //first is line width, size for pie, animated time , and colours object for theming.
	initPieChart(10,40, 1500, colours);
	initPieChartPage(20,100,1500, colours);

 	
});

//Setup easy pie charts in sidebar
var initPieChart = function(lineWidth, size, animateTime, colours) {
	$(".pie-chart").easyPieChart({
        barColor: colours.dark,
        borderColor: colours.dark,
        trackColor: '#d9dde2',
        scaleColor: false,
        lineCap: 'butt',
        lineWidth: lineWidth,
        size: size,
        animate: animateTime
    });
}

//Setup easy pie charts in page
var initPieChartPage = function(lineWidth, size, animateTime, colours) {

	$(".easy-pie-chart").easyPieChart({
        barColor: colours.dark,
        borderColor: colours.dark,
        trackColor: colours.gray,
        scaleColor: false,
        lineCap: 'butt',
        lineWidth: lineWidth,
        size: size,
        animate: animateTime
    });
    $(".easy-pie-chart-red").easyPieChart({
        barColor: colours.red,
        borderColor: colours.red,
        trackColor: '#fbccbf',
        scaleColor: false,
        lineCap: 'butt',
        lineWidth: lineWidth,
        size: size,
        animate: animateTime
    });
    $(".easy-pie-chart-green").easyPieChart({
        barColor: colours.green,
        borderColor: colours.green,
        trackColor: '#b1f8b1',
        scaleColor: false,
        lineCap: 'butt',
        lineWidth: lineWidth,
        size: size,
        animate: animateTime
    });
    $(".easy-pie-chart-blue").easyPieChart({
        barColor: colours.blue,
        borderColor: colours.blue,
        trackColor: '#d2e4fb',
        scaleColor: false,
        lineCap: 'butt',
        lineWidth: lineWidth,
        size: size,
        animate: animateTime
    });
    $(".easy-pie-chart-teal").easyPieChart({
        barColor: colours.teal,
        borderColor: colours.teal,
        trackColor: '#c3e5e5',
        scaleColor: false,
        lineCap: 'butt',
        lineWidth: lineWidth,
        size: size,
        animate: animateTime
    });
    $(".easy-pie-chart-purple").easyPieChart({
        barColor: colours.purple,
        borderColor: colours.purple,
        trackColor: '#dec1f5',
        scaleColor: false,
        lineCap: 'butt',
        lineWidth: lineWidth,
        size: size,
        animate: animateTime
    });

}