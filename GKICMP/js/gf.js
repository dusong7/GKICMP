var box1,msg;  
window.onload=function(){  
    box1=document.getElementById("box1");  
    msg=document.getElementById("msg");  
    box1.ondragover=function(e){  
        e.preventDefault();  
    }  
    box1.ondrop=function(e){/*����ͼƬʱ*/  
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
  
function getObj(e){/*��ӡ�϶�ʱ�ĸ��ֲ���*/    
    var s="";    
    for(var k in e){    
        s+=k+":"+e[k]+"</br>";    
    }    
    msg.innerHTML=s;    
}    