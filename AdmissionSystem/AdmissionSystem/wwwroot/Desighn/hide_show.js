    var x = 0;
    function myfunction()
    {
        if (x%2 == 0) {
             document.getElementById("myImg4").hidden=true;
           document.getElementsByClassName("ChooseImage")[0].hidden = false;
            document.getElementsByClassName("ButtonToggel")[0].textContent = " cancel";
            document.getElementsByClassName("hide_bar1")[0].hidden = true;
        }
        if(x%2!=0) {
             document.getElementById("myImg4").hidden=false;
           document.getElementsByClassName("ChooseImage")[0].hidden = true;
            document.getElementsByClassName("ButtonToggel")[0].textContent = "change the image";
            document.getElementById("fileInput").value = null;
            document.getElementsByClassName("hide_bar1")[0].hidden = true;
            document.getElementById("previewImage").src = "#";
        }
        x++;  
    }    
            var y = 0;
    function myfunction2()
    {      
        if (y%2 == 0) {
             document.getElementById("myImg").hidden=true;
           document.getElementsByClassName("ChooseImage2")[0].hidden = false;
            document.getElementsByClassName("ButtonToggel2")[0].textContent = " cancel";
            document.getElementsByClassName("hide_bar2")[0].hidden = true;
                }
        if(y%2!=0) {
             document.getElementById("myImg").hidden=false;
           document.getElementsByClassName("ChooseImage2")[0].hidden = true;
            document.getElementsByClassName("ButtonToggel2")[0].textContent = "change the image";
            document.getElementById("fileInput2").value = null;
            document.getElementsByClassName("hide_bar2")[0].hidden = true;
            document.getElementById("previewImage2").src = "#";
        }
        y++;  
    }
      var z = 0;
    function myfunction3()
    {
    if (z%2 == 0) {
             document.getElementById("myImg2").hidden=true;
           document.getElementsByClassName("ChooseImage3")[0].hidden = false;
        document.getElementsByClassName("ButtonToggel3")[0].textContent = "cancel";
        document.getElementsByClassName("hide_bar3")[0].hidden = true;
        
        }
        if(z%2!=0) {
             document.getElementById("myImg2").hidden=false;
           document.getElementsByClassName("ChooseImage3")[0].hidden = true;
            document.getElementsByClassName("ButtonToggel3")[0].textContent = "change the image";
            document.getElementById("fileInput3").value = null;
            document.getElementsByClassName("hide_bar3")[0].hidden = true;
            document.getElementById("previewImage3").src = "#";
        }
        z++;  
    }
            var d = 0;
    function myfunction4()
    {
        if (d%2 == 0) {
             document.getElementById("myImg3").hidden=true;
           document.getElementsByClassName("ChooseImage4")[0].hidden = false;
            document.getElementsByClassName("ButtonToggel4")[0].textContent = " cancel";
            document.getElementsByClassName("hide_bar4")[0].hidden = true;
        }
        if(d%2!=0) {
             document.getElementById("myImg3").hidden=false;
           document.getElementsByClassName("ChooseImage4")[0].hidden = true;
            document.getElementsByClassName("ButtonToggel4")[0].textContent = "change the image";
            document.getElementById("fileInput4").value = null;
            document.getElementsByClassName("hide_bar4")[0].hidden = true;
            document.getElementById("previewImage4").src = "#";
        }
        d++;  
}
function showbar4() {
    document.getElementsByClassName("hide_bar4")[0].hidden = false;
}

function showbar3() {
    document.getElementsByClassName("hide_bar3")[0].hidden = false;
}

function showbar2() {
    document.getElementsByClassName("hide_bar2")[0].hidden = false;
}

function showbar1() {
    document.getElementsByClassName("hide_bar1")[0].hidden = false;
}


function hideimageandbar1() {
    document.getElementsByClassName("hide_bar1")[0].hidden = true;
    document.getElementById("previewImage").src = "#";
}

function hideimageandbar2() {
    document.getElementsByClassName("hide_bar2")[0].hidden = true;
    document.getElementById("previewImage2").src = "#";
}

function hideimageandbar3() {
    document.getElementsByClassName("hide_bar3")[0].hidden = true;
    document.getElementById("previewImage3").src = "#";
}

function hideimageandbar4() {
    document.getElementsByClassName("hide_bar4")[0].hidden = true;
    document.getElementById("previewImage4").src = "#";
}