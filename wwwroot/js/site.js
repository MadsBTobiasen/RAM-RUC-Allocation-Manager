// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code
function incrementOneAndSubmitForm(elementToIncrement, formToSubmit, maxValue) {

    maxValue = parseInt(maxValue);

    var element = document.getElementById(elementToIncrement);

    element.value = parseInt(element.value) + 1;

    if (element.value > maxValue) element.value = maxValue;

    console.log(element);

    var form = document.getElementById(formToSubmit);
    form.submit();

}
function decrementOneAndSubmitForm(elementToIncrement, formToSubmit, minValue) {

    if (minValue == undefined) minValue = 0;

    var element = document.getElementById(elementToIncrement);

    element.value = parseInt(element.value) - 1;
    if (element.value < 0) element.value = 0;

    var form = document.getElementById(formToSubmit);
    form.submit();

}
function setValueAndSubmitForm(elementToSet, formToSubmit, value) {

    var element = document.getElementById(elementToSet);
    element.value = value;

    console.log(element);

    var form = document.getElementById(formToSubmit);
    form.submit();

}

function copyValueAndSubmitForm(elementToCopyFrom, elementToCopyTo, formToSubmit) {

    var elementDonor = document.getElementById(elementToCopyFrom);
    var elementRecipient = document.getElementById(elementToCopyTo);

    elementRecipient.value = elementDonor.value;

    var form = document.getElementById(formToSubmit);
    form.submit();

}