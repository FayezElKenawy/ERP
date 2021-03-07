$(document).ready(function () {
    $('#CustomerList').dataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "searching": true,
        "ajax": {
            "url": "/api/CustomerApi",
            "type": "Post",
            "datatype": "json",
            "dataFilter": "",
            "dataSrc": ""
        },

        "columns": [
            { "data": "custArName", "name": "CustArName", "autowidth": true },
            { "data": "custEnName", "name": "CustEnName", "autowidth": true },
            { "data": "custMobileNo", "name": "CustMobileNo", "autowidth": true },
            { "data": "custAdress", "name": "CustAdress", "autowidth": true }
        ]
    });
});