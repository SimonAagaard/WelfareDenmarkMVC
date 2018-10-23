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
function newContact() {
    document.getElementById("contact-phone-text").innerHTML = "Hello World";
}

document.addEventListener('DOMContentLoaded', function () {
    document.getElementById("result").innerHTML = "Vi har nu fjernet demens " + localStorage.clickcount + " gange.";
}, false);

function clickCounter() {
    if (typeof (Storage) !== "undefined") {
        if (localStorage.clickcount) {
            localStorage.clickcount = Number(localStorage.clickcount) + 1;
        } else {
            localStorage.clickcount = 1;
        }
        document.getElementById("result").innerHTML = "Vi har nu fjernet demens " + localStorage.clickcount + " gange.";
    } else {
        document.getElementById("result").innerHTML = "Sorry, your browser does not support web storage...";
    }
}

//Script for showing/hidding answers in FAQ
function ShowAnswer(id) {
    if (document.getElementById(id).style.display == "none") {
        document.getElementById(id).style.display = '';
    } else {
        document.getElementById(id).style.display = "none";
    }
}


//Script for greeting when visiting profile
window.onload = function () {
	var greetingMessage = document.getElementById("greeting");
	var greeting;
	var time = new Date().getHours();
	if (time < 9) {
		greeting = "Godmorgen og velkommen til din profil!";
	} else if (time < 12) {
		greeting = "God formiddag og velkommen til din profil!";
	} else if (time < 13) {
		greeting = "Goddag og velkommen til din profil!";
	} else if (time < 18) {
		greeting = "God eftermiddag og velkommen til din profil!";
	} else {
		greeting = "Godaften og velkommen til din profil!";
	}
	greetingMessage.innerHTML = greeting;
}, false;

function fileupload(filename) {
    var inputfile = document.getElementById(filename);
    var files = inputfile.files;
    var fdata = new FormData();
    for (var i = 0; i != files.length; i++) {
        fdata.append("files", files[i]);
    }

    $.ajax(
        {
            url:"/UploadImage",
            data: fdata,
            processData: false,
            contentType: false,
            type: "POST",
            success: function (data) {
                alert("Dine billeder er nu blevet tilføjet.");
            }
        }

    );
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
