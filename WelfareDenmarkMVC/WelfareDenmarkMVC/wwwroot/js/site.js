var counter = 0;
function addNew() {
    // Get the main Div in which all the other divs will be added
    var mainContainer = document.getElementById('mainContainer');
    // Create a new div for holding text and button input elements
    var newDiv = document.createElement('div');
    newDiv.style.marginTop = "10px";
    newDiv.style.width = "300px";
    newDiv.style.height = "55px";
    newDiv.style.display = "block";


    // Create a new text input
    var newText = document.createElement('input');
    newText.type = "input";
    newText.value = counter;
    newText.style.backgroundColor = "White";
    newText.style.color = "#111";
    newText.style.padding = "0px";
    newText.style.fontSize = "16px";
    newText.style.borderColor = "#222";
    newText.style.borderWidth = "1px";
    newText.style.height = "55px";
    // Create a new button input
    var newDelButton = document.createElement('input');
    newDelButton.type = "button";
    newDelButton.value = "Delete";
    newDelButton.style.backgroundColor = "White";
    newDelButton.style.color = "Black";
    newDelButton.style.padding = "0px";
    newDelButton.style.Fontsize = "16px";
    newDelButton.style.borderColor = "#222";
    newDelButton.style.borderWidth = "1px";
    newDelButton.style.height = "55px";

    var newSaveButton = document.createElement('input');
    newSaveButton.type = "button";
    newSaveButton.value = "Save";
    newSaveButton.style.backgroundColor = "White";
    newSaveButton.style.color = "Black";
    newSaveButton.style.Fontsize = "16px";
    newSaveButton.style.borderColor = "#222";
    newSaveButton.style.borderWidth = "1px";
    newSaveButton.style.height = "55px";

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