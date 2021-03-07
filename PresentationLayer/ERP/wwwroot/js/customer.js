$(document).ready(function () {
    $('#Productstableview').dataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "searching": true,
        "ajax": {
            "url": "/api/CustomersApi",
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