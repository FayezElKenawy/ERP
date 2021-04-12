$(document).ready(function () {
    $('#Productstableview thead tr').clone(true).appendTo('#example thead');
    $('#Productstableview thead tr:eq(1) th').each(function (i) {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder='+ title +'/>');
        $('input', this).on('keyup change', function () {
            if (table.column(i).search() !== this.value) {
                table
                    .column(i)
                    .search(this.value)
                    .draw();
            }
        });
    });
   table= $('#Productstableview').DataTable({
        "processing": true,
       "serverSide": true,
      "orderCellsTop": true,
       "fixedHeader": true,
        "ajax": {
            "url": "/api/Product",
            "type": "Post",
            "datatype": "json",
            "dataFilter": "",
            "dataSrc": "data"
        },
       
        "columns": [
            { "data": "productId", "name": "ProductId", "autowidth": true },
            { "data": "arabicName", "name": "ArabicName", "autowidth": true },
            { "data": "model", "name": "Model", "autowidth": true },
            { "data": "cost", "name": "Cost", "autowidth": true },
            { "data": "salePrice", "name": "SalePrice", "autowidth": true },
            { "data": "balance", "name": "Balance", "autowidth": true }
       ]
    });
    
    $('#Productstableview tbody').attr('id', 'tablepro');
    $('#Productstableview #tablepro').on('click', 'tr', function () {
        $(this).toggleClass('selectforinvoice').toggleClass('hovero');
    });
});
//function GetProducts(){
//    $.ajax({
//        url: "_ProductsList",//get row from partialview
//        dataType: "html",
//        success: function (result) {
//            $('#Productstableview').append(result);//add row to invoice table
//        }
//    });
//}