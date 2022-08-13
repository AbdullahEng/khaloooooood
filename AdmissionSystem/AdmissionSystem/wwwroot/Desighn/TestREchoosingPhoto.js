let results=1;
function SimilarImageTest3(x,y,z,d){

    if(document.getElementById(x).value!=''){
        if(document.getElementById(y).value==''&&document.getElementById(z).value==''&& document.getElementById(d).value==''){
            results=1;


        }
       else if(document.getElementById(y).value!=''&& document.getElementById(z).value!=''&& document.getElementById(d).value!=''){
            if(document.getElementById(x).files[0].size!=document.getElementById(y).files[0].size&&
            document.getElementById(x).files[0].size!=document.getElementById(z).files[0].size&&
            document.getElementById(x).files[0].size!=document.getElementById(d).files[0].size){
            results=1;

        }else{

        results=0;
    } 
}    else if(document.getElementById(y).value!=''&& document.getElementById(z).value!=''&& document.getElementById(d).value==''){
    if(document.getElementById(x).files[0].size!=document.getElementById(y).files[0].size&&
            document.getElementById(x).files[0].size!=document.getElementById(z).files[0].size){
            results=1;

        }else{

        results=0;
    } 
}else if(document.getElementById(y).value!=''&& document.getElementById(z).value==''&& document.getElementById(d).value==''){
    if(document.getElementById(x).files[0].size!=document.getElementById(y).files[0].size){
    results=1;

}else{

results=0;
} 

}else if(document.getElementById(y).value==''&& document.getElementById(z).value!=''&& document.getElementById(d).value==''){
    if(document.getElementById(x).files[0].size!=document.getElementById(z).files[0].size){
    results=1;

}else{
results=0;
} 

}else if(document.getElementById(y).value==''&& document.getElementById(z).value==''&& document.getElementById(d).value!=''){
    if(document.getElementById(x).files[0].size!=document.getElementById(d).files[0].size){
    results=1;

}else{

results=0;
} 

} else if(document.getElementById(y).value!=''&&document.getElementById(z).value==''&&document.getElementById(d).value!=''){
    if(document.getElementById(x).files[0].size!=document.getElementById(y).files[0].size&&
            document.getElementById(x).files[0].size!=document.getElementById(d).files[0].size){
            results=1;

        }else{

        results=0;
    } 
}
else if(document.getElementById(y).value==''&&document.getElementById(z).value!=''&&document.getElementById(d).value!=''){
    if(document.getElementById(x).files[0].size!=document.getElementById(z).files[0].size&&
            document.getElementById(x).files[0].size!=document.getElementById(d).files[0].size){
            results=1;

        }else{

        results=0;
    } 
} 
  }  else if(document.getElementById(x).value=='')
    {

        results=1;
    }
      
  return results;
  
}