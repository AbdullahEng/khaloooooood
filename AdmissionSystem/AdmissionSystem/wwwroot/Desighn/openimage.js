
//Get the modal
var modal = document.getElementById('myModal');

// Get the image and insert it inside the modal - use its "alt" text as a caption
var img = document.getElementById('myImg');
var modalImg = document.getElementById("img01");
var captionText = document.getElementById("caption");
img.onclick = function(){
  modal.style.display = "block";
  modalImg.src = this.src;
  captionText.innerHTML = this.alt;
}

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks on <span> (x), close the modal
span.onclick = function() {
  modal.style.display = "none";
}

// Get the modal
var modal2 = document.getElementById('myModal2');

// Get the image and insert it inside the modal - use its "alt" text as a caption
var img2 = document.getElementById('myImg2');
var modalImg2 = document.getElementById("img012");
var captionText2 = document.getElementById("caption2");
img2.onclick = function(){
  modal2.style.display = "block";
  modalImg2.src = this.src;
  captionText2.innerHTML = this.alt;
}

// Get the <span> element that closes the modal
var span2 = document.getElementsByClassName("close2")[0];

// When the user clicks on <span> (x), close the modal
span2.onclick = function() {
  modal2.style.display = "none";
}
// Get the modal
var modal3 = document.getElementById('myModal3');

// Get the image and insert it inside the modal - use its "alt" text as a caption
var img3 = document.getElementById('myImg3');
var modalImg3 = document.getElementById("img013");
var captionText3 = document.getElementById("caption3");
img3.onclick = function(){
  modal3.style.display = "block";
  modalImg3.src = this.src;
  captionText3.innerHTML = this.alt;
}

// Get the <span> element that closes the modal
var span3 = document.getElementsByClassName("close3")[0];

// When the user clicks on <span> (x), close the modal
span3.onclick = function() {
  modal3.style.display = "none";
}
// Get the modal
var modal4 = document.getElementById('myModal4');

// Get the image and insert it inside the modal - use its "alt" text as a caption
var img4 = document.getElementById('myImg4');
var modalImg4 = document.getElementById("img014");
var captionText4 = document.getElementById("caption4");
img4.onclick = function(){
  modal4.style.display = "block";
  modalImg4.src = this.src;
  captionText4.innerHTML = this.alt;
}

// Get the <span> element that closes the modal
var span4 = document.getElementsByClassName("close4")[0];

// When the user clicks on <span> (x), close the modal
span4.onclick = function() {
  modal4.style.display = "none";
}


