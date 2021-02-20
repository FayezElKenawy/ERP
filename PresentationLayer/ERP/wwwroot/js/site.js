
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
//adding new row to invoice table
function getrow() {//get row from partial view
     $.ajax({
        url: "_invoicetable",//get row from partialview
        dataType: "html",
        success: function (result) {
            $('#invoicetable tbody').append(result);//add row to invoice table
        }
    });
}
$('#invoicetable').on('click','.activeproduct', function () {
        $(this).removeClass('activeproduct');
        getrow();

});

//calculations for table
$('#invoicetable').on('mouseup keyup','input[type=number]', () => calculateTotals());


function calculateTotals() {
    const subtotals = $('.item').map((idx, val) => calculateSubtotal(val)).get();
    const total = subtotals.reduce((a, v) => a + Number(v), 0);
    $('#InvoiceTotal').val(formatAsCurrency(total));
    $('#InvoiceNetTotal').val(formatAsCurrency(total));
    $('#InvoiceChange').val(formatAsCurrency(total));
    calculateMainTotals()
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
    row.find(inputs[4]).val(formatAsCurrency(remain));

}
function formatAsCurrency(amount) {
    return Number(amount).toFixed(2);
}
//post data to controller

function getInvoiceProduct() {
    var rows = $('#invoicetable').find('.item');
    const listdetails = new Array();
    for (var i = 0; i < rows.length; i++) {
        const inputs = $(rows[i]).find('input');
        const Product = {};
        if (inputs[0].value != null) {
            Product.ProductID = inputs[0].value;
            Product.SalesPrice = inputs[2].value;
            Product.Quantity = inputs[3].value;
            Product.discount = inputs[4].value;
            Product.Total = inputs[5].value;
            Product.VatAmount = inputs[6].value;
            Product.TotalWithVat = inputs[7].value;
            listdetails.push(Product);
        }

    }
    var allitem = $('.allitems').find('input');
    var jsonitem = JSON.stringify(listdetails);
    $(allitem).val(jsonitem);

}
//adding hover color
$('#pro tr').hover(function () {
    if (!$(this).hasClass('selectforinvoice')) {
        $(this).toggleClass('hovero');
    }
    
});
//select items for adding to invoice table
$('#pro #TableProducts tr').on('click', function () {
    $(this).toggleClass('selectforinvoice').toggleClass('hovero');
});
function GetEmptyRow(partcode,partname,price,html) {
    var rows = $('#invoicetable').find('.item');

    for (var i = 0; i < rows.length; i++) {
        const inputs = $(rows[i]).find('input');
        if (inputs[0].value == "") {
            if ($(rows[i]).hasClass('activeproduct')) {
                $(this).removeClass('activeproduct');
            }
            $(inputs[0]).val(partcode);
            $(inputs[1]).val(partname);
            $(inputs[3]).val(price);

            break;
        }
    }
}
function GetItems() {
    const tr = $('#TableProducts').find('.selectforinvoice');
    var h = '<tr class="item"><td class="partcode" > <input  class="form-control text-center " type="text"  data-toggle="modal" data-target=".bd-example-modal-lg" /></td>' +

        '<td class="partName"><input class="form-control text-center" value="" /> </td>' +

        '<td class="price inv"> <input  type="number" step="0.001" class="form-control text-center" autocomplete="off" placeholder="0.0" value="" /></td>' +

        '<td class="price inv"> <input  type="number" step="0.001" class="form-control text-center" autocomplete="off" placeholder="0.0" value="" /></td>' +

        '<td class="discount inv"><input  type="number" step="0.001" class="form-control text-center" autocomplete="off" placeholder="0.0" value="" /></td>' +

        '<td class="total inv"><input  type="number" disabled step="0.001" class="form-control text-center" autocomplete="off" placeholder="0.0" value="" /></td>' +

        ' <td class="vatamount inv"><input  type="number" step="0.001" class="form-control text-center" autocomplete="off" placeholder="0.0" value="" /></td>' +

        '<td class="totalvat inv"><input  type="number" step="0.001" class="form-control text-center" autocomplete="off" placeholder="0.0" value="" /></td></tr >'
    for (var i = 0; i < tr.length; i++) {
        const partcode = $(tr[i]).find('.productid').text();
        const partname = $(tr[i]).find('.pertname').text();
        const salesprice = $(tr[i]).find('.price').text();
        GetEmptyRow(partcode, partname, salesprice,h);

    }
  
}
$('html').keypress(function (e) {
    var key = e.which;
    if (key == 13)  // the enter key code
    {
        GetItems();
    }
});  