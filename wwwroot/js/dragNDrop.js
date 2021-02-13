const cards = document.querySelectorAll('.card.mb-2.dragAbleElement');
const empties = document.querySelectorAll('.card.mb-2.empty');

// Listerners
for (const card of cards) {
    card.addEventListener('dragstart', dragStart);
    card.addEventListener('dragend', dragEnd);
}

for (const empty of empties) {
    empty.addEventListener('dragover', dragOver);
    empty.addEventListener('dragenter', dragEnter);
    empty.addEventListener('dragleave', dragLeave);
    empty.addEventListener('drop', dragDrop);
}

//for (var i = 0; i < cards.length; i++) {
//    cards[i].addEventListener('dragstart', dragStart);
//    cards[i].addEventListener('dragend', dragEnd);
//}

function dragStart(event) {
    setTimeout(() => (this.className = 'invisible'), 0);
    event
        .dataTransfer
        .setData('text/plain', event.target.id);
}

function dragEnd() {
    this.className = '.card.mb-2.dragAbleElement';
}

function dragOver(event) {
    event.preventDefault();
}

function dragEnter(event) {
    event.preventDefault();
}

function dragLeave() {
    this.className = '.card.mb-2.dragAbleElement.empty';
}

function dragDrop(event) {

    
    columnName = JSON.stringify(this.id); // This turns the id from the html object into a json string.
    const id = event // Get the id of whatever object we're trying to drag to.
        .dataTransfer
        .getData('text');

    //id: card.id, 
    for (const card of cards) { // Loop over all cards, this is too ensure we cant place cards within eachother.
        if (card.id === id) {
            this.append(card); // This appends the card by the end.
            $.ajax({
                url: "/UserStories?handler=UpdateObject", // This is an ajax request to the OnGetUpdateObject function in userstories, ensures that the object's colunm property is updated correctly.
                type: 'GET',
                dataType: 'json',
                data: { id: card.id, column: columnName },
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    var strResponse = "";
                    $.each(data, function (index, value) {
                        $.each(this, function (index, value) {
                            strResponse += index + " :: " + value + "<br/>";
                        });
                    });
                    $("#response").html(strResponse);
                },
                error: function (xhr, status, error) {
                    console.log("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText)
                }
            });
        }
    }
}
