// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code
function incrementOne(elementToIncrement, maxValue, callback) {

    maxValue = parseInt(maxValue);

    var element = document.getElementById(elementToIncrement);

    element.value = parseInt(element.value) + 1;

    if (element.value > maxValue) element.value = maxValue;

    if (callback != undefined) callback();

}

function decrementOne(elementToIncrement, minValue, callback) {

    if (minValue == undefined) minValue = 0;

    var element = document.getElementById(elementToIncrement);

    element.value = parseInt(element.value) - 1;
    if (element.value < 0) element.value = 0;

    if (callback != undefined) callback();

}

function setValue(elementToSet, value, callback) {

    var element = document.getElementById(elementToSet);
    element.value = value;

    if (callback != undefined) callback();

}

function copyValue(elementToCopyFrom, elementToCopyTo, callback) {

    var elementDonor = document.getElementById(elementToCopyFrom);
    var elementRecipient = document.getElementById(elementToCopyTo);

    elementRecipient.value = elementDonor.value;

    if (callback != undefined) callback();

}

function submitForm(formToSubmit) {

    setTimeout(() => {
        var form = document.getElementById(formToSubmit);
        form.submit();
    }, 25)

}