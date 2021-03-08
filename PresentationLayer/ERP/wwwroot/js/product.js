$(document).ready(function () {
    $('#Productstableview').DataTable({
        "processing": true,
        "serverSide": true,

        "ajax": {
            "url": "/api/Product",
            "type": "Post",
            "datatype": "json",
            "dataFilter": "",
            "dataSrc": ""
        },
       
        "columns": [
            { "data": "productId", "name": "ProductId", "autowidth": true },
            { "data": "arabicName", "name": "ArabicName", "autowidth": true },
            { "data": "englishName", "name": "EnglishName", "autowidth": true },
            { "data": "model", "name": "Model", "autowidth": true },
            { "data": "desc", "name": "Desc", "autowidth": true },
            { "data": "cost", "name": "Cost", "autowidth": true },
            { "data": "salesPrice", "name": "SalePrice", "autowidth": true },
            { "data": "balance", "name": "Balance", "autowidth": true }
        ]
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