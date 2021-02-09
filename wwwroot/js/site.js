// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

function onDragStart(event) {
    event
        .dataTransfer
        .setData('text/plain', event.target.id);
    event
        .currentTarget
        .style
}

function onDragOver(event) {
    event.preventDefault();
}

function onDrop(event) {
    //Placeholder js
    //Placeholder js
    const id = event
        .dataTransfer
        .getData('text');
    var draggableElement = document.getElementById(id);
    const dropzone = event.target;
    let dropzoneParent = dropzone.parentElement;
    if (draggableElement.className === dropzone.className) {
        dropzone.appendChild(draggableElement);
        event
            .dataTransfer
            .clearData()
    } else {
        dropzone.appendChild(sourceIdEl);
    }
}