function hide() {

    let buttons = Array.from(document.querySelectorAll('i#hide'));

    buttons.forEach(button => button.addEventListener('click', clickEvent));

    function clickEvent(e) {
        let button = e.target;
        let table = button.parentNode.parentNode.parentNode.parentNode;
        let tableHeadings = table.children[0].children[1];
        let tableBody = table.children[1];

        if (button.className === 'fa fa-minus-circle') {
            button.className = 'fa fa-plus-circle';
            tableHeadings.hidden = true;
            tableBody.hidden = true;
        } else {
            button.className = 'fa fa-minus-circle';
            tableHeadings.hidden = false;
            tableBody.hidden = false;
        }
    }
}