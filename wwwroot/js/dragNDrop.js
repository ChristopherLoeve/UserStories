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
    this.className = '.card.mb-2.dragAbleElement.empty';
    const id = event
        .dataTransfer
        .getData('text');

    for (const card of cards) {
        if (card.id === id) {
            this.append(card);
        }
    }
}
