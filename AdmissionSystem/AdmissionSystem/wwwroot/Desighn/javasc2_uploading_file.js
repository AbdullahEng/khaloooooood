// Design By
// - https://dribbble.com/shots/13992184-File-Uploader-Drag-Drop

// Select Upload-Area
const uploadArea2 = document.querySelector('#uploadArea2');

// Select Drop-Zoon Area
const dropZoon2 = document.querySelector('#dropZoon2');

// Loading Text
const loadingText2 = document.querySelector('#loadingText2');

// Slect File Input 
const fileInput2 = document.querySelector('#fileInput2');

// Select Preview Image
const previewImage2 = document.querySelector('#previewImage2');

// File-Details Area
const fileDetails2 = document.querySelector('#fileDetails2');

// Uploaded File
const uploadedFile2 = document.querySelector('#uploadedFile2');

// Uploaded File Info
const uploadedFileInfo2 = document.querySelector('#uploadedFileInfo2');

// Uploaded File  Name
const uploadedFileName2 = document.querySelector('.uploaded-file__name2');

// Uploaded File Icon
const uploadedFileIconText2 = document.querySelector('.uploaded-file__icon-text');

// Uploaded File Counter
const uploadedFileCounter2 = document.querySelector('.uploaded-file__counter2');

// ToolTip Data
const toolTipData2 = document.querySelector('.upload-area__tooltip-data2');

// Images Types
const imagesTypes2 = [
  "jpeg",
  "png",
  "svg",
  "gif"
];

// Append Images Types Array Inisde Tooltip Data
toolTipData2.innerHTML = [...imagesTypes2].join(', .');

//// When (drop-zoon) has (dragover) Event 
//dropZoon2.addEventListener('dragover', function (event) {
//  // Prevent Default Behavior 
//  event.preventDefault();

//  // Add Class (drop-zoon--over) On (drop-zoon)
//  dropZoon2.classList.add('drop-zoon--over');
//});

//// When (drop-zoon) has (dragleave) Event 
//dropZoon2.addEventListener('dragleave', function (event) {
//  // Remove Class (drop-zoon--over) from (drop-zoon)
//  dropZoon2.classList.remove('drop-zoon--over');
//});

//// When (drop-zoon) has (drop) Event 
//dropZoon2.addEventListener('drop', function (event) {
//  // Prevent Default Behavior 
//  event.preventDefault();

//  // Remove Class (drop-zoon--over) from (drop-zoon)
//  dropZoon2.classList.remove('drop-zoon--over');

//  // Select The Dropped File
//  const file2 = event.dataTransfer.files[0];

//  // Call Function uploadFile(), And Send To Her The Dropped File :)
//  uploadFile2(file2);
//});

// When (drop-zoon) has (click) Event 
dropZoon2.addEventListener('click', function (event) {
  // Click The (fileInput)
  fileInput2.click();
});

// When (fileInput) has (change) Event 
fileInput2.addEventListener('change', function (event) {
  // Select The Chosen File
  const file2 = event.target.files[0];

  // Call Function uploadFile(), And Send To Her The Chosen File :)
  uploadFile2(file2);
});

// Upload File Function
function uploadFile2(file) {
  // FileReader()
  const fileReader2 = new FileReader();
  // File Type 
  const fileType2 = file.type;
  // File Size 
  const fileSize2 = file.size;

  // If File Is Passed from the (File Validation) Function
  if (fileValidate2(fileType2, fileSize2)) {
    // Add Class (drop-zoon--Uploaded) on (drop-zoon)
    dropZoon2.classList.add('drop-zoon--Uploaded');

    // Show Loading-text
    loadingText2.style.display = "block";
    // Hide Preview Image
    previewImage2.style.display = 'none';

    // Remove Class (uploaded-file--open) From (uploadedFile)
    uploadedFile2.classList.remove('uploaded-file--open');
    // Remove Class (uploaded-file__info--active) from (uploadedFileInfo)
    uploadedFileInfo2.classList.remove('uploaded-file__info2--active');

    // After File Reader Loaded 
    fileReader2.addEventListener('load', function () {
      // After Half Second 
      setTimeout(function () {
        // Add Class (upload-area--open) On (uploadArea)
        uploadArea2.classList.add('upload-area--open');

        // Hide Loading-text (please-wait) Element
        loadingText2.style.display = "none";
        // Show Preview Image
        previewImage2.style.display = 'block';

        // Add Class (file-details--open) On (fileDetails)
        fileDetails2.classList.add('file-details--open');
        // Add Class (uploaded-file--open) On (uploadedFile)
        uploadedFile2.classList.add('uploaded-file--open');
        // Add Class (uploaded-file__info--active) On (uploadedFileInfo)
        uploadedFileInfo2.classList.add('uploaded-file__info2--active');
      }, 500); // 0.5s

      // Add The (fileReader) Result Inside (previewImage) Source
      previewImage2.setAttribute('src', fileReader2.result);

      // Add File Name Inside Uploaded File Name
      uploadedFileName2.innerHTML = file.name;

      // Call Function progressMove();
      progressMove2();
    });

    // Read (file) As Data Url 
    fileReader2.readAsDataURL(file);
  } else { // Else

    this; // (this) Represent The fileValidate(fileType, fileSize) Function

  };
};

// Progress Counter Increase Function
function progressMove2() {
  // Counter Start
  let counter = 0;

  // After 600ms 
  setTimeout(() => {
    // Every 100ms
    let counterIncrease2 = setInterval(() => {
      // If (counter) is equle 100 
      if (counter === 100) {
        // Stop (Counter Increase)
        clearInterval(counterIncrease2);
      } else { // Else
        // plus 10 on counter
        counter = counter + 10;
        // add (counter) vlaue inisde (uploadedFileCounter)
        uploadedFileCounter2.innerHTML = `${counter}%`
      }
    }, 100);
  }, 600);
};


// Simple File Validate Function
function fileValidate2(fileType2, fileSize2) {
  // File Type Validation
  let isImage2 = imagesTypes2.filter((type) => fileType2.indexOf(`image/${type}`) !== -1);

  // If The Uploaded File Type Is 'jpeg'
  if (isImage2[0] === 'jpeg') {
    // Add Inisde (uploadedFileIconText) The (jpg) Value
    uploadedFileIconText2.innerHTML = 'jpg';
  } else { // else
    // Add Inisde (uploadedFileIconText) The Uploaded File Type 
    uploadedFileIconText2.innerHTML = isImage2[0];
  };

  // If The Uploaded File Is An Image
  if (isImage2.length !== 0) {
    // Check, If File Size Is 2MB or Less
    if (fileSize2 <= 2000000) { // 2MB :)
      return true;
    } else { // Else File Size
     // return alert('Please Your File Should be 2 Megabytes or Less');
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'يجب إختيار صورة أقل من 2 ميغا',

        })
        document.getElementsByClassName("hide_bar2")[0].hidden = true;
    };
  } else { // Else File Type
      /*return alert('Please make sure to upload An Image File Type');*/
      Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'تأكد من إختيارك صورة وليس ملف أخر',

      })
      document.getElementsByClassName("hide_bar2")[0].hidden = true;
  };
};

// :)