'use strict'
function Getitems(e) {
    var tr = e;
    var td = $(tr).find('td');
    alert(td[0].innerHTML.toString());
}