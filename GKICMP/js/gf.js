var box1,msg;  
window.onload=function(){  
    box1=document.getElementById("box1");  
    msg=document.getElementById("msg");  
    box1.ondragover=function(e){  
        e.preventDefault();  
    }  
    box1.ondrop=function(e){/*放置图片时*/  
        e.preventDefault();  
        getObj(e);  
        var f=e.dataTransfer.files[0];  
        var fr=new FileReader();  
          
        fr.onload=function(e){  
              
            getObj(e.target);  
            box1.innerHTML="<img src=\""+fr.result+"\"/>";  
        }  
        fr.readAsDataURL(f);  
    }  
  
      
      
}  
  
function getObj(e){/*打印拖动时的各种参数*/    
    var s="";    
    for(var k in e){    
        s+=k+":"+e[k]+"</br>";    
    }    
    msg.innerHTML=s;    
}    