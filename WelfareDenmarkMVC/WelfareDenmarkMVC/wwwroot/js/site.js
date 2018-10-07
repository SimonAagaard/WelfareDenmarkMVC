var counter = 0;
function addNew() {
    // Get the main Div in which all the other divs will be added
    var mainContainer = document.getElementById('mainContainer');
    // Create a new div for holding text and button input elements
    var newDiv = document.createElement('div');

    newDiv.className = "form-group";


    // Create a new text input
    var newText = document.createElement('input');
    newText.type = "input";
    newText.value = counter;
    newText.className = "form-control";

    // Create a new button input
    var newDelButton = document.createElement('input');
    newDelButton.type = "button";
    newDelButton.value = "Slet";
    newDelButton.className = "btn btn-default";


    var newSaveButton = document.createElement('input');
    newSaveButton.type = "button";
    newSaveButton.value = "Tilføj";
    newSaveButton.className = "btn btn-default";

    // Append new text input to the newDiv
    newDiv.appendChild(newText);
    // Append new button input to the newDiv
    newDiv.appendChild(newDelButton);
    newDiv.appendChild(newSaveButton);
    // Append newDiv input to the mainContainer div
    mainContainer.appendChild(newDiv);


    // Add a handler to button for deleting the newDiv from the mainContainer
    newDelButton.onclick = function () {
        mainContainer.removeChild(newDiv);
    }

}
// script for the FAQ
function ShowAnswer() {
    var x = document.getElementById("answer1");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}


//}
//newSaveButton.onClick = function saveItem() {
//    var inputElement = document.getElementById('newText');
//    var theirInput = '';
//    inputElement.addEventListener('change',
//        function (e) {
//            theirInput = e.target.value;
//        });
//}
