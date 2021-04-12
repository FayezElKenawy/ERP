$(document).ready(function () {
    $('#Productstableview tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="' + title + '" />');
    });
   table= $('#Productstableview').DataTable({
        "processing": true,
       "serverSide": true,
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
       ],
       "initComplete": function () {
           // Apply the search
           this.api().columns().every(function () {
               var that = this;

               $('input', this.footer()).on('keyup change clear', function () {
                   if (that.search() !== this.value) {
                       that
                           .search(this.value)
                           .draw();
                   }
               });
           });
       }
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