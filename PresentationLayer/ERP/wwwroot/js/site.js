﻿
//sales invoice 
    $(function () {
        $("#datepicker").datepicker();//invoice date picker
        });
        //customer search
        $('.js-searchable-dropdown-input')
            .on('focus', function (e) {
        $('.js-searchable-dropdown').addClass('active');
                $('.js-list-empty').hide();
            })
            .on('blur', function (e) {
        setTimeout(function () {
            $('.js-searchable-dropdown').removeClass('active');
        }, 150);
            })
            .on('keyup', function (e) {
                var _v = $(this).val().toLowerCase();
                var _ul = $('.js-searchable-dropdown-list');
                var _empty = $('.js-list-empty');

                _ul.find('li').show();

                if (_v !== '') {
        _ul.find('li[data-search-value*="' + _v + '"]').show();
                    _ul.find('li:not([data-search-value*="' + _v + '"])').hide();
                }

                if (_ul.find('li:visible').length > 0) {
        _empty.hide();
                }
                else {
        _empty.show();
                }
            });
//adding select cuxtomer to input 
$('.js-searchable-dropdown-list-item').on('click', function () {
    $('.js-searchable-dropdown-input').val($(this).find('.custname').text());
    $('.js-searchable-dropdown-input-id').val($(this).attr('data-id-value'));
    console.log($(this).attr('data-id-value'));
});


//calculations for table
$('#invoicetable').on('mouseup keyup','input[type=number]', () => calculateTotals());


function calculateTotals() {
    const subtotals = $('.item').map((idx, val) => calculateSubtotal(val)).get();
    const total = subtotals.reduce((a, v) => a + Number(v), 0);
    const inputs = $('.downtotals').find('input');
    $(inputs[0]).val(formatAsCurrency(total));
    $(inputs[2]).val(formatAsCurrency(total));

    var select = $('.topheader').find('.select');
    cridtcash();
    calculateMainTotals();
}

function calculateSubtotal(row) {
    const $row = $(row);
    const inputs = $row.find('input');
    const subtotal = (inputs[2].value * inputs[3].value) - inputs[4].value;
    const vat = subtotal * 0.15;
    $(row).find(inputs[6]).val(vat.toFixed(2));
    $row.find('input:last').val(formatAsCurrency(subtotal + vat));
    $row.find(inputs[5]).val(subtotal.toFixed(2));
    return subtotal+vat;
}
//calculations main totals 
$('.downtotals').on('mouseup keyup', 'input[type=number]', () => calculateMainTotals());

function calculateMainTotals() {
    var row = $('.downtotals');
    const inputs = row.find('input');
    const net = inputs[0].value - inputs[1].value;
    row.find(inputs[2]).val(formatAsCurrency(net));
    const remain = inputs[2].value - inputs[3].value;
    cridtcash();

}
//change value from cash and cridt
function cridtcash() {
    var select = $('.topheader').find('.select');
    const inputs = $('.downtotals').find('input');
    if (select.val() == 0) {
        $(inputs[3]).val(formatAsCurrency(inputs[2].value));
        $(inputs[4]).val(formatAsCurrency(0.0));
        var x = $.find('.js-searchable-dropdown-input');
        $(x).removeAttr('required');
        
    }
    else {
        $(inputs[3]).val(formatAsCurrency(0.0));
        $(inputs[4]).val(formatAsCurrency(inputs[2].value));
        var x = $.find('.js-searchable-dropdown-input');
        $(x).attr('required', ''); 
    }
}
function formatAsCurrency(amount) {
    return Number(amount).toFixed(2);
}
$('.select').on('change', function () {
    cridtcash();
});
//post data to controller

function getInvoiceProduct() {
    var rows = $('#invoicetable').find('.item');
    const listdetails = new Array();
    for (var i = 0; i < rows.length; i++) {
        const inputs = $(rows[i]).find('input');
        const Product = {};
        if (inputs[0].value != "") {
            Product.ProductID = inputs[0].value;
            Product.SalesPrice = removenull(inputs[3].value);
            Product.Quantity = removenull(inputs[2].value);
            Product.discount = removenull(inputs[4].value);
            Product.Total = removenull(inputs[5].value);
            Product.VatAmount = removenull(inputs[6].value);
            Product.TotalWithVat = removenull(inputs[7].value);
            listdetails.push(Product);
        }
    }
    const inputsdown = $('.downtotals').find('input');
    const top = {};
    const downt = new Array();
    top.InvoiceTotal = removenull(inputsdown[0].value);
    top.InvoiceDiscount = removenull(inputsdown[1].value)
    top.InvoiceNetTotal = removenull(inputsdown[2].value)
    top.InvoicePaid = removenull(inputsdown[3].value)
    top.InvoiceChange = removenull(inputsdown[4].value)
        downt.push(top);
    var downtjson = JSON.stringify(downt);
    var hiddeninput = $('.downtotals').find('input[type=hidden]');
    $(hiddeninput).val(downtjson);
    var allitem = $('.allitems').find('input');
    var jsonitem = JSON.stringify(listdetails);
    $(allitem).val(jsonitem);

}
//remove null
function removenull(o) {
    if (o != ""&&o!=null) {
        return o
    }
    else {
        return 0;
    }
}
//adding hover color
$('#Productstableview tr').hover(function () {
    if (!$(this).hasClass('selectforinvoice')) {
        $(this).toggleClass('hovero');
    }
    
});
//adding new row to invoice table
function getrow() {//get row from partial view
   
    $.ajax({
        url: "_invoicetable",//get row from partialview
        dataType: "html",
         success: function (result) {
             $('#invoicetable tbody').append(result);
             console.log('good');//add row to invoice table
         },
         error: function (result) {
             console.log('error' + result);
         }
    });
}
function addRow(e, u) {
    const item = $('#invoicetable tbody').find('.item');
    if (e != "" && item.length<=1) {
        $(this).removeClass('activeproduct');
        getrow();
    }
}
$('#invoicetable').on('keyup', '.activeproduct', function () {
    var h = $(this).find('activepart');
    if (h != null) {
        $(this).removeClass('activeproduct');
        getrow();
    }
});
//select items for adding to invoice table
$('#Productstableview #TableProducts tr').on('click', function () {
    $(this).toggleClass('selectforinvoice').toggleClass('hovero');
});
function GetEmptyRow(partcode, partname, price) {
    var rows = $('#invoicetable tbody').find('.item td .activeproduct').parent().parent();
        const inputs = $(rows).find('input');
        if (inputs[0].value == "") {
            $(inputs[0]).removeClass('activeproduct');
            $(inputs[0]).val(partcode);
            $(inputs[1]).val(partname);
            $(inputs[3]).val(formatAsCurrency(price));
            getrow();
    }
}
function GetItems() {
    const tr = $('#TableProducts').find('.selectforinvoice');
    for (var i = 0; i < tr.length; i++) {
        const td = $(tr[i]).find('td');
        const partcode = $(td[0]).text();
        const partname = $(td[1]).text();
        const salesprice = $(td[3]).text();
        GetEmptyRow(partcode, partname, salesprice);
        $(tr[i]).removeClass('selectforinvoice');
    }
}
function GetItems1(trh) {
    const tr = trh;
        const partcode = $(tr[0]).text();
        const partname = $(tr[1]).text();
        const salesprice = $(tr[3]).text();
        GetEmptyRow(partcode, partname, salesprice);
}
$('#Productstableview #TableProducts').on('dblclick','tr', function () { GetItems1($(this).find("td")); });
$('html').keypress(function (e) {
    var key = e.which;
    if (key == 13)  // the enter key code
    {
        GetItems();
    }
});



