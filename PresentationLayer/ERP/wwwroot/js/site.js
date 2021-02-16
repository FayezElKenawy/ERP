
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
$('.item:first input:first').on("click", function () {
    if ($('#invoicetable tr').length <3) {
        alert($('#invoicetable tr').length);
        $(this).removeClass('activeproduct');
        getrow();
    }

    
});

function getrow() {
    $.ajax({
       
        url: "_invoicetable",//assume action name is 'addItem' with paramater 'dataparam' of type string in same controller
        dataType: "html",
        success: function (result) {
            $('#invoicetable tbody').append(result);
       }
    });
}
$('.activeproduct').on('click', function () {
    if ($(this).hasClass('activeproduct')) {
        $(this).removeClass('activeproduct');
        getrow();
    }
});
function addRow() {
    $newRow = $('#invoicetable');
          $newRow.find('.activeproduct').on('click', function () {
                if ($(this).hasClass('activeproduct')) {
                    $(this).removeClass('activeproduct');
                    getrow();
                }
            });
}


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