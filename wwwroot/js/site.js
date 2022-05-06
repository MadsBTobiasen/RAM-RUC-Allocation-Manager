// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function incrementOne(idToIncrement, max) {

    var element = document.getElementById(idToIncrement);
    if (element.value < max) ++element.value;

}

function decrementOne(idToDecrement, min) {

    var element = document.getElementById(idToDecrement);
    if (element.value > 0) --element.value;

}