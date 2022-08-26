var d = document;
var cross = d.getElementById("cross");
var advice = d.getElementById("advice");
advice.style.opacity = "1";
function createCookie(name, value, days) {
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        var expires = "; expires=" + date.toGMTString();
    }
    else
        var expires = "";
    document.cookie = name + "=" + value + expires + "; path=/";
}

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}


if (readCookie("done") == "yes") {
    advice.style.display = "none";
}

var loginBlock = d.getElementById("loginBlock");
var loginContent = d.getElementById("loginContent");
var bar = d.getElementById("bar");
var signupBlock = d.getElementById("signupBlock");
var signupContent = d.getElementById("signupContent");
var title = d.getElementById("title");
var text = d.getElementById("text");
var leftSide = d.getElementById("leftSide");
var rightSide = d.getElementById("rightSide");
var toggle = d.getElementById("toggle");
var loginText = d.getElementById("loginText");
var singupText = d.getElementById("signupText");
toggle.addEventListener("click", function () {
    if (loginBlock.style.marginLeft == "-600px") {
        loginBlock.style.marginLeft = "0px";
        bar.style.marginLeft = "calc(100% - 200px)";
        signupBlock.style.left = "100%";
        loginContent.style.marginLeft = "0px";
        rightSide.style.right = "0px";
        leftSide.style.left = "-300px";
        /*signupText.style.transform = "translate(-50%, -50%)";
        loginText.style.transform = "translate(-50%, -50%)";*/
        signupText.style.top = "50%";
        loginText.style.top = "-100%";
    }
    else {
        loginBlock.style.marginLeft = "-600px";
        bar.style.marginLeft = "0px";
        signupBlock.style.left = "200px";
        loginContent.style.marginLeft = "1000px";
        rightSide.style.right = "-300px";
        leftSide.style.left = "0px";
        /*signupText.style.transform = "translate(-50%, calc(-50% + 50px))";
        loginText.style.transform = "translate(-50%, calc(-50% + 50px))";*/
        signupText.style.top = "200%";
        loginText.style.top = "50%";
    }
    if (signupContent.style.marginLeft == "0px") {
        signupContent.style.marginLeft = "-800px";
    }
    else {
        signupContent.style.marginLeft = "0px";
    }
});
window.addEventListener("click",
    function () {
        if (readCookie("done") != "yes") {
            createCookie("done", "yes");
        }
        advice.style.opacity = "0";
        setTimeout(function () {
            advice.style.visibility = "hidden";
        }, 1500)
    });