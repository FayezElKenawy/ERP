$(document).ready(function () {
    $('#CustomerList').dataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "searching": true,
        "ajax": {
            "url": "/api/Customer/List",
            "type": "Post",
            "datatype": "json",
            "dataFilter": "",
            "dataSrc": "data"
        },

        "columns": [
            { "data": "custID", "name": "CustId", "autowidth": true },
            { "data": "custEnName", "name": "CustEnName", "autowidth": true },
            { "data": "custMobileNo", "name": "CustMobileNo", "autowidth": true },
            { "data": "custAdress", "name": "CustAdress", "autowidth": true }
        ]
    });
});