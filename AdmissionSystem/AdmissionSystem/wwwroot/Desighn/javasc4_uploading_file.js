// Design By
// - https://dribbble.com/shots/13992184-File-Uploader-Drag-Drop

// Select Upload-Area
const uploadArea4 = document.querySelector('#uploadArea4')

// Select Drop-Zoon Area
const dropZoon4= document.querySelector('#dropZoon4');

// Loading Text
const loadingText4 = document.querySelector('#loadingText4');

// Slect File Input 
const fileInput4 = document.querySelector('#fileInput4');

// Select Preview Image
const previewImage4 = document.querySelector('#previewImage4');

// File-Details Area
const fileDetails4 = document.querySelector('#fileDetails4');

// Uploaded File
const uploadedFile4 = document.querySelector('#uploadedFile4');

// Uploaded File Info
const uploadedFileInfo4 = document.querySelector('#uploadedFileInfo4');

// Uploaded File  Name
const uploadedFileName4 = document.querySelector('.uploaded-file__name4');

// Uploaded File Icon
const uploadedFileIconText4 = document.querySelector('.uploaded-file__icon-text');

// Uploaded File Counter
const uploadedFileCounter4 = document.querySelector('.uploaded-file__counter4');

// ToolTip Data
const toolTipData4 = document.querySelector('.upload-area__tooltip-data4');

// Images Types
const imagesTypes4 = [
  "jpeg",
  "png",
  "svg",
  "gif"
];

// Append Images Types Array Inisde Tooltip Data
toolTipData4.innerHTML = [...imagesTypes4].join(', .');

//// When (drop-zoon) has (dragover) Event 
//dropZoon4.addEventListener('dragover', function (event) {
//  // Prevent Default Behavior 
//  event.preventDefault();

//  // Add Class (drop-zoon--over) On (drop-zoon)
//  dropZoon4.classList.add('drop-zoon--over');
//});

//// When (drop-zoon) has (dragleave) Event 
//dropZoon4.addEventListener('dragleave', function (event) {
//  // Remove Class (drop-zoon--over) from (drop-zoon)
//  dropZoon4.classList.remove('drop-zoon--over');
//});

//// When (drop-zoon) has (drop) Event 
//dropZoon4.addEventListener('drop', function (event) {
//  // Prevent Default Behavior 
//  event.preventDefault();

//  // Remove Class (drop-zoon--over) from (drop-zoon)
//  dropZoon4.classList.remove('drop-zoon--over');

//  // Select The Dropped File
//  const file4 = event.dataTransfer.files[0];

//  // Call Function uploadFile(), And Send To Her The Dropped File :)
//  uploadFile4(file4);
//});

// When (drop-zoon) has (click) Event 
dropZoon4.addEventListener('click', function (event) {
  // Click The (fileInput)
  fileInput4.click();
});

// When (fileInput) has (change) Event 
fileInput4.addEventListener('change', function (event) {
  // Select The Chosen File
  const file = event.target.files[0];

  // Call Function uploadFile(), And Send To Her The Chosen File :)
  uploadFile4(file);
});

// Upload File Function
function uploadFile4(file) {
  // FileReader()
  const fileReader4 = new FileReader();
  // File Type 
  const fileType4= file.type;
  // File Size 
  const fileSize4 = file.size;

  // If File Is Passed from the (File Validation) Function
  if (fileValidate4(fileType4, fileSize4)) {
    // Add Class (drop-zoon--Uploaded) on (drop-zoon)
    dropZoon4.classList.add('drop-zoon--Uploaded');

    // Show Loading-text
    loadingText4.style.display = "block";
    // Hide Preview Image
    previewImage4.style.display = 'none';

    // Remove Class (uploaded-file--open) From (uploadedFile)
    uploadedFile4.classList.remove('uploaded-file--open');
    // Remove Class (uploaded-file__info--active) from (uploadedFileInfo)
    uploadedFileInfo4.classList.remove('uploaded-file__info4--active');

    // After File Reader Loaded 
    fileReader4.addEventListener('load', function () {
      // After Half Second 
      setTimeout(function () {
        // Add Class (upload-area--open) On (uploadArea)
        uploadArea4.classList.add('upload-area--open');

        // Hide Loading-text (please-wait) Element
        loadingText4.style.display = "none";
        // Show Preview Image
        previewImage4.style.display = 'block';

        // Add Class (file-details--open) On (fileDetails)
        fileDetails4.classList.add('file-details--open');
        // Add Class (uploaded-file--open) On (uploadedFile)
        uploadedFile4.classList.add('uploaded-file--open');
        // Add Class (uploaded-file__info--active) On (uploadedFileInfo)
        uploadedFileInfo4.classList.add('uploaded-file__info4--active');
      }, 500); // 0.5s

      // Add The (fileReader) Result Inside (previewImage) Source
      previewImage4.setAttribute('src', fileReader4.result);

      // Add File Name Inside Uploaded File Name
      uploadedFileName4.innerHTML = file.name;

      // Call Function progressMove();
      progressMove4();
    });

    // Read (file) As Data Url 
    fileReader4.readAsDataURL(file);
  } else { // Else

    this; // (this) Represent The fileValidate(fileType, fileSize) Function

  };
};

// Progress Counter Increase Function
function progressMove4() {
  // Counter Start
  let counter = 0;

  // After 600ms 
  setTimeout(() => {
    // Every 100ms
    let counterIncrease4 = setInterval(() => {
      // If (counter) is equle 100 
      if (counter === 100) {
        // Stop (Counter Increase)
        clearInterval(counterIncrease4);
      } else { // Else
        // plus 10 on counter
        counter = counter + 10;
        // add (counter) vlaue inisde (uploadedFileCounter)
        uploadedFileCounter4.innerHTML = `${counter}%`
      }
    }, 100);
  }, 600);
};


// Simple File Validate Function
function fileValidate4(fileType4, fileSize4) {
  // File Type Validation
  let isImage4 = imagesTypes4.filter((type) => fileType4.indexOf(`image/${type}`) !== -1);

  // If The Uploaded File Type Is 'jpeg'
  if (isImage4[0] === 'jpeg') {
    // Add Inisde (uploadedFileIconText) The (jpg) Value
    uploadedFileIconText4.innerHTML = 'jpg';
  } else { // else
    // Add Inisde (uploadedFileIconText) The Uploaded File Type 
    uploadedFileIconText4.innerHTML = isImage4[0];
  };

  // If The Uploaded File Is An Image
  if (isImage4.length !== 0) {
    // Check, If File Size Is 2MB or Less
    if (fileSize4 <= 2000000) { // 2MB :)
      return true;
    } else { // Else File Size
      //return alert('Please Your File Should be 2 Megabytes or Less');
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Your File Should be 2 Megabytes or Less',

        })
        document.getElementsByClassName("hide_bar4")[0].hidden = true;
    };
  } else { // Else File Type
    //return alert('Please make sure to upload An Image File Type');
      Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Please make sure to upload An Image File Type',

      })
      document.getElementsByClassName("hide_bar4")[0].hidden = true;
  };
};

// :)