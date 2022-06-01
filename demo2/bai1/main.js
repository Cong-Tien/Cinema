// câu 1: cach 1: jacascrip
function js_style(){
    document.getElementById("text").style.color = "pink";
    document.getElementById("text").style.fontSize = "30px";
}
// Câu 1: cách 2: su dung jquery
function jquery_style(){

   $("#text").css("color", "red");
  $("#text").css("fontSize", "50px");
}

// Câu 2 cách 1
function getFormvalue(){
    var  firstname =  document.forms["form1"]["fname"].value;
    var  lastname =  document.forms["form1"]["lname"].value;
    alert("Full name là: "+ firstname +" "+ lastname);
}
function getFormvalue_jquery(){
    var  firstname =  $('#fname').val();
    var  lastname =   $('#lname').val();
    alert("Full name là: "+ firstname + " "+ lastname);
}

// Câu 3 cách 1:
function bgcolor()
{
  document.body.style.backgroundColor = "red";
   
}
// Caau3: cách 2
function bgcolor_jquery()
{
    $("body").css("background-color","blue");
}

// Câu 5: cách 1
function insert_Row()
{
      var table = document.getElementById("sampleTable");

      // Create an empty <tr> element and add it to the 1st position of the table:
      var row = table.insertRow(0);

    // Insert new cells (<td> elements) at the 1st and 2nd position of the "new" <tr> element:
      var cell1 = row.insertCell(0);
      var cell2 = row.insertCell(1);
     // Add some text to the new cells:
      cell1.innerHTML = "NEW CELL";
     cell2.innerHTML = "NEW CELL";
}
// Câu 5 cách 2
function insert_Row_jquery()
{
    $('#sampleTable').append('<tr><td>New Row</td><td>New Row</td></tr>');
}

// Câu 6 cách 1
function changeContent()
{
    document.getElementById('myTable').innerHTML = "Row in table";
   
}
// Câu 6: cách 2
function changeContent_jquery()
{
    var str = "<td></td><td></td><td></td>";
    var index = 1;
    $(str).eq(index).text("Some text"); 
   
}
// Câu 8 cách 1
function removecolor()
{
    var x = document.getElementById("colorSelect");
x.remove(x.selectedIndex);
}
// Câu 8 cách 2
function removecolor_jquery()
{
     $('#colorSelect :selected').remove();
}
// Câu 9 cách 1
function display_random_image() 
{
     var theImages = [{
        src: "http://farm4.staticflickr.com/3691/11268502654_f28f05966c_m.jpg",
        width: "240",
        height: "160"
    }, {
        src: "http://farm1.staticflickr.com/33/45336904_1aef569b30_n.jpg",
        width: "320",
        height: "195"
    }, {
        src: "http://farm6.staticflickr.com/5211/5384592886_80a512e2c9.jpg",
        width: "500",
        height: "343"
    }];
    
    var preBuffer = [];
    for (var i = 0, j = theImages.length; i < j; i++) {
        preBuffer[i] = new Image();
        preBuffer[i].src = theImages[i].src;
        preBuffer[i].width = theImages[i].width;
        preBuffer[i].height = theImages[i].height;
    }
   
// create random image number
  function getRandomInt(min,max) 
    {
      //  return Math.floor(Math.random() * (max - min + 1)) + min;
    
imn = Math.floor(Math.random() * (max - min + 1)) + min;
    return preBuffer[imn];
    }  

// 0 is first image,   preBuffer.length - 1) is  last image
  
var newImage = getRandomInt(0, preBuffer.length - 1);
 
// remove the previous images
var images = document.getElementsByTagName('img');
var l = images.length;
for (var p = 0; p < l; p++) {
    images[0].parentNode.removeChild(images[0]);
}
// display the image  
document.body.appendChild(newImage);
}

function showScreen(){
    document.getElementById("screen").innerHTML =
"Screen Width: " + screen.width;
}