

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
$('.js-searchable-dropdown-list-item').on('click', function () {
    $('.js-searchable-dropdown-input').val($(this).find('.custname').text());
    $('.js-searchable-dropdown-input-id').val($(this).attr('data-id-value'));
    console.log($(this).attr('data-id-value'));
});

    var quantity = $('#Quantity').val();
    var saleprice = $('#SalesPrice').val();
    var discount = $('#discount').val();
    var total = $('#total').val();
    var vat = $('#vat').val();
    var totalvat = $('#totalvat').val();

    $('#total').keyup(function () {
        total = (quantity * saleprice) - discount;

        $('#total').val() = total;
    });
$('#invoicetable tr:last-child td.partcode input.activeproduct').on("click", function () {
    $(this).removeClass('activeproduct');
    addRow();
    
});
function addRow() {
    $sampleRow = $(' <tr> <td class="partcode"><input asp-for="ProductID" class="form-control text-center activeproduct"  type="text" data-toggle="modal" data-target=".bd-example-modal-lg" placeholder="Part Code" /></td> <td><input type="text"/></td></tr>');
    $sampleRow.find("td.partcode input.activeproduct").click(function () {
        addRow();
    });
    $('#invoicetable tbody').append($sampleRow);
}
//function removeatt() {
//    $('#ProductID').on('click', function () {
//        if ($(this).attr('onclick')) {
//            $(this).removeAttr('onclick');

//            generateTableRow();
//        }

//    });
//}

////invoice calculations

//function generateTableRow() {
//    //var element = document.getElementById('ProductID');
//    //element.removeAttribute('onclick');
//    $('table.invoicetable tbody').append('<tr><td class="partcode"><input onclick="generateTableRow()" id="ProductID" asp-for= "Details.ProductID" class= "form-control text-center " type = "text" data-toggle="modal" data-target=".bd-example-modal-lg" placeholder = "Part Code" /><span asp-validation-for="ProductId" class="text-danger "></span></td ></tr>');
//    //$('table.invoicetable tbody').append(
//    //    '<tr><td class="partcode"><input asp-for="ProductID" id="ProductID" class="form-control text-center newpart" type ="text" data-toggle="modal" data-target=".bd-example-modal-lg" placeholder = "Part Code" /><span asp-validation-for="ProductId" class="text-danger "></span></td >' +
//    //    '<td class="partName"><input class="form-control text-center" disabled placeholder="Part Name" /> </td>' +
//    //    '<td class="price inv"> <input asp-for="Quantity" class="form-control text-center" autocomplete="off" placeholder="Sale Price" /></td>' +
//    //    '<td class="price inv"> <input asp-for="Details.SalesPrice" class="form-control text-center" autocomplete="off" placeholder="Sale Price" /></td>' +
//    //    '<td class="discount inv"><input asp-for="discount" class="form-control text-center" autocomplete="off" placeholder="Sale Price" /></td>' +
//    //    '<td class="total inv"><input asp-for="Total" class="form-control text-center" autocomplete="off" placeholder="Total" /></td>' +
//    //    '<td class="vatamount inv"><input asp-for="VatAmount" class="form-control text-center" autocomplete="off" placeholder="Vat" /></td>' +
//    //    '<td class="totalvat inv"><input asp-for="TotalWithVat" class="form-control text-center" autocomplete="off" placeholder="Net Total" /></td></tr>');
//    removeatt();
//}
