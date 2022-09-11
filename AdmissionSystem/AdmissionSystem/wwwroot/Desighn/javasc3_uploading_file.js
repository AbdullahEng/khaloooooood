// Design By
// - https://dribbble.com/shots/13992184-File-Uploader-Drag-Drop

// Select Upload-Area
const uploadArea3 = document.querySelector('#uploadArea3')

// Select Drop-Zoon Area
const dropZoon3 = document.querySelector('#dropZoon3');

// Loading Text
const loadingText3 = document.querySelector('#loadingText3');

// Slect File Input 
const fileInput3 = document.querySelector('#fileInput3');

// Select Preview Image
const previewImage3 = document.querySelector('#previewImage3');

// File-Details Area
const fileDetails3 = document.querySelector('#fileDetails3');

// Uploaded File
const uploadedFile3 = document.querySelector('#uploadedFile3');

// Uploaded File Info
const uploadedFileInfo3 = document.querySelector('#uploadedFileInfo3');

// Uploaded File  Name
const uploadedFileName3 = document.querySelector('.uploaded-file__name3');

// Uploaded File Icon
const uploadedFileIconText3 = document.querySelector('.uploaded-file__icon-text');

// Uploaded File Counter
const uploadedFileCounter3= document.querySelector('.uploaded-file__counter3');

// ToolTip Data
const toolTipData3 = document.querySelector('.upload-area__tooltip-data3');

// Images Types
const imagesTypes3 = [
  "jpeg",
  "png",
  "svg",
  "gif"
];

// Append Images Types Array Inisde Tooltip Data
toolTipData3.innerHTML = [...imagesTypes3].join(', .');

//// When (drop-zoon) has (dragover) Event 
//dropZoon3.addEventListener('dragover', function (event) {
//  // Prevent Default Behavior 
//  event.preventDefault();

//  // Add Class (drop-zoon--over) On (drop-zoon)
//  dropZoon3.classList.add('drop-zoon--over');
//});

//// When (drop-zoon) has (dragleave) Event 
//dropZoon3.addEventListener('dragleave', function (event) {
//  // Remove Class (drop-zoon--over) from (drop-zoon)
//  dropZoon3.classList.remove('drop-zoon--over');
//});

//// When (drop-zoon) has (drop) Event 
//dropZoon3.addEventListener('drop', function (event) {
//  // Prevent Default Behavior 
//  event.preventDefault();

//  // Remove Class (drop-zoon--over) from (drop-zoon)
//  dropZoon3.classList.remove('drop-zoon--over');

//  // Select The Dropped File
//  const file3 = event.dataTransfer.files[0];

//  // Call Function uploadFile(), And Send To Her The Dropped File :)
//  uploadFile3(file3);
//});

// When (drop-zoon) has (click) Event 
dropZoon3.addEventListener('click', function (event) {
  // Click The (fileInput)
  fileInput3.click();
});

// When (fileInput) has (change) Event 
fileInput3.addEventListener('change', function (event) {
  // Select The Chosen File
  const file = event.target.files[0];

  // Call Function uploadFile(), And Send To Her The Chosen File :)
  uploadFile3(file);
});

// Upload File Function
function uploadFile3(file) {
  // FileReader()
  const fileReader3= new FileReader();
  // File Type 
  const fileType3 = file.type;
  // File Size 
  const fileSize3= file.size;

  // If File Is Passed from the (File Validation) Function
  if (fileValidate3(fileType3, fileSize3)) {
    // Add Class (drop-zoon--Uploaded) on (drop-zoon)
    dropZoon3.classList.add('drop-zoon--Uploaded');

    // Show Loading-text
    loadingText3.style.display = "block";
    // Hide Preview Image
    previewImage3.style.display = 'none';

    // Remove Class (uploaded-file--open) From (uploadedFile)
    uploadedFile3.classList.remove('uploaded-file--open');
    // Remove Class (uploaded-file__info--active) from (uploadedFileInfo)
    uploadedFileInfo3.classList.remove('uploaded-file__info3--active');

    // After File Reader Loaded 
    fileReader3.addEventListener('load', function () {
      // After Half Second 
      setTimeout(function () {
        // Add Class (upload-area--open) On (uploadArea)
        uploadArea3.classList.add('upload-area--open');

        // Hide Loading-text (please-wait) Element
        loadingText3.style.display = "none";
        // Show Preview Image
        previewImage3.style.display = 'block';

        // Add Class (file-details--open) On (fileDetails)
        fileDetails3.classList.add('file-details--open');
        // Add Class (uploaded-file--open) On (uploadedFile)
        uploadedFile3.classList.add('uploaded-file--open');
        // Add Class (uploaded-file__info--active) On (uploadedFileInfo)
        uploadedFileInfo3.classList.add('uploaded-file__info3--active');
      }, 500); // 0.5s

      // Add The (fileReader) Result Inside (previewImage) Source
      previewImage3.setAttribute('src', fileReader3.result);

      // Add File Name Inside Uploaded File Name
      uploadedFileName3.innerHTML = file.name;

      // Call Function progressMove();
      progressMove3();
    });

    // Read (file) As Data Url 
    fileReader3.readAsDataURL(file);
  } else { // Else

    this; // (this) Represent The fileValidate(fileType, fileSize) Function

  };
};

// Progress Counter Increase Function
function progressMove3() {
  // Counter Start
  let counter = 0;

  // After 600ms 
  setTimeout(() => {
    // Every 100ms
    let counterIncrease3 = setInterval(() => {
      // If (counter) is equle 100 
      if (counter === 100) {
        // Stop (Counter Increase)
        clearInterval(counterIncrease3);
      } else { // Else
        // plus 10 on counter
        counter = counter + 10;
        // add (counter) vlaue inisde (uploadedFileCounter)
        uploadedFileCounter3.innerHTML = `${counter}%`
      }
    }, 100);
  }, 600);
};


// Simple File Validate Function
function fileValidate3(fileType3, fileSize3) {
  // File Type Validation
  let isImage3 = imagesTypes3.filter((type) => fileType3.indexOf(`image/${type}`) !== -1);

  // If The Uploaded File Type Is 'jpeg'
  if (isImage3[0] === 'jpeg') {
    // Add Inisde (uploadedFileIconText) The (jpg) Value
    uploadedFileIconText3.innerHTML = 'jpg';
  } else { // else
    // Add Inisde (uploadedFileIconText) The Uploaded File Type 
    uploadedFileIconText3.innerHTML = isImage3[0];
  };

  // If The Uploaded File Is An Image
  if (isImage3.length !== 0) {
    // Check, If File Size Is 2MB or Less
    if (fileSize3 <= 2000000) { // 2MB :)
      return true;
    } else { // Else File Size
      //return alert('Please Your File Should be 2 Megabytes or Less');
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Your File Should be 2 Megabytes or Less',

        })
        document.getElementsByClassName("hide_bar3")[0].hidden = true;
    };
  } else { // Else File Type
    //return alert('Please make sure to upload An Image File Type');
      Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Please make sure to upload An Image File Type',

      })
      document.getElementsByClassName("hide_bar3")[0].hidden = true;
  };
};

// :)