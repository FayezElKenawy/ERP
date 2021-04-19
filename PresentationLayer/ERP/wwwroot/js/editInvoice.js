var editor;
$(document).ready(function () {
   var table= $('#salestable').DataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "searching": true,
        "ajax": {
            "url": "/api/Invoice",
            "type": "post",
            "datatype": "json",
            "dataFilter": "",
            "dataSrc": "data"
        },

        "columns": [
            { "data": "invoiceNo", "name": "InvoiceNo", "autowidth": true },
            { "data": "custID", "name": "CustID", "autowidth": true },
            {
                "render": function (data, type, row) { return '<span>' + row.invoiceDate.split('T')[0] + '</span>' },
                "name": "InvoiceData"
            },
            { "data": "invoiceTotal", "name": "   InvoiceTotal", "autowidth": true },
            { "data": "invoiceDiscount", "name": "InvoiceDiscount", "autowidth": true },
            { "data": "invoiceNetTotal", "name": "InvoiceNetTotal", "autowidth": true },
            {
                "render": function (data, type, row) {
                    if (row.invoiceType == 0) {
                        return '<span class="text-primary">Cash</span>'
                    } else {
                        return '<span class="text-danger">Credit</span>'
                    }
                }
            },
            { "data": "invoicePaid", "name": "    InvoicePaid", "autowidth": true },
            { "data": "invoiceChange", "name": "  InvoiceChange", "autowidth": true },
            {
                "render": function (data, type, row) {
                    return '<a href="/sales/edit/' + row.invoiceNo + '"><span><i class="fa fa-edit"></i></span></a>  ' +
                        '<a href="" url="' + row.invoiceNo + '" class="url" data-toggle="modal" data-target="#deleteInvoice"><span class=" text-danger"><i class="fa fa-trash-o"></i></span></a>'
                }
            }
        ]
   });
});
$('#salestable ').on('click', 'tr td a.url', function () {
    var invoiceId = $(this).attr('url');
    var a = $(this);
    $('#btnDeleteInvoice').on('click', function () {
        var operation = [{ "path": "/isdeleted", "op": "replace", "value": "true" }];

            $.ajax({
                type: "patch",
                url: "api/invoice/" + invoiceId,
                contentType: "application/json",
                data: JSON.stringify(operation)

            });
        $(a).parent().parent().css({ "display": "none" });
    });
    
});
