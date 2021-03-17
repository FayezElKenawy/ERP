$(document).ready(function () {
    $('#CustomerList').dataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "searching": true,
        "ajax": {
            "url": "/api/Customer",
            "type": "Post",
            "datatype": "json",
            "dataSrc": "data"
        },

        "columns": [
            { "data": "custArName", "name": "CustArName", "autowidth": true },
            { "data": "custEnName", "name": "CustEnName", "autowidth": true },
            { "data": "custMobileNo", "name": "CustMobileNo", "autowidth": true },
            { "data": "custAdress", "name": "CustAdress", "autowidth": true }
        ]
    });
});