$(document).ready(function () {
	
	/*点击效果*/
	mui("body").on('tap', '.click', function (event) {  
		var _that=$(this);
		_that.addClass("act");
		setTimeout(function(){ _that.removeClass("act") }, 100);
}); 
	
//mui('nav').on('tap','a',function(){document.location.href=this.href;});	

	
		
})
