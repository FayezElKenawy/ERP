


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

//invoice clac
    var quantity = $('#Quantity').val();
    var saleprice = $('#SalesPrice').val();
    var discount = $('#discount').val();
    var total = $('#total').val();
    var vat = $('#vat').val();
var totalvat = $('#totalvat').val();

function calctotl(q,s,d) {
    var t = (q * s) - d;
    return t;
}
$('#total').on("keyup", function () {
    total = calctotl(quantity, saleprice, discount);
        $('#total').val() = total;
    });


//adding new row to invoice table
$('.item:first input:first').on("click", function () {
    if ($('#invoicetable tr').length <3) {
        alert($('#invoicetable tr').length);
        $(this).removeClass('activeproduct');
        addRow();
    }

    
});
function addRow() {
    $newRow = $(' <tr class="item"> <td class="partcode"><input asp-for="ProductID" class="form-control text-center activeproduct"  type="text" id="ProductId" name="ProductId" value="" data-toggle="modal" data-target=".bd-example-modal-lg"  />' +
        '<td class="partName"><input class="form-control text-center"  value="" /> </td>' +
        '<td class="price inv"> <input asp-for="Quantity" type="number" step="0.001" class="form-control text-center" autocomplete="off" placeholder="0.0" value="" /></td>' +
        '<td class="price inv"> <input asp-for="Details.SalesPrice" type="number" step="0.001" class="form-control text-center" autocomplete="off" placeholder="0.0" value="" /></td>' +
        '<td class="discount inv"><input asp-for="discount" type="number" step="0.001" class="form-control text-center" autocomplete="off" placeholder="0.0"  value=""/></td>' +
        '<td class="total inv"><input asp-for="Total" type="number" disabled step="0.001" class="form-control text-center" autocomplete="off" placeholder="0.0" value="" /></td>' +
        '<td class="vatamount inv"><input asp-for="VatAmount" type="number" step="0.001" class="form-control text-center" autocomplete="off" placeholder="0.0" value="" /></td>' +
        '<td class="totalvat inv"><input asp-for="TotalWithVat" type="number" step="0.001" class="form-control text-center" autocomplete="off" placeholder="0.0" value=""/></td></tr>');
    $newRow.find('.activeproduct').on('click', function () {
        if ($(this).hasClass('activeproduct')) {
            $(this).removeClass('activeproduct');
            addRow();
        }

    });
    $('#invoicetable tbody').append($newRow);
}


//calculations for table
$('#invoicetable').on('mouseup keyup', 'input[type=number]', () => calculateTotals());


function calculateTotals() {
    const subtotals = $('.item').map((idx, val) => calculateSubtotal(val)).get();
    const total = subtotals.reduce((a, v) => a + Number(v), 0);
    $('#InvoiceTotal').val(formatAsCurrency(total));
    $('#InvoiceNetTotal').val(formatAsCurrency(total));
    $('#InvoiceChange').val(formatAsCurrency(total));
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

function fixUndefine(value) {
    if (value == "") {
        formatAsCurrency(0);
    }
    else {
        formatAsCurrency(value);
    }
}
function formatAsCurrency(amount) {
    return Number(amount).toFixed(2);
}