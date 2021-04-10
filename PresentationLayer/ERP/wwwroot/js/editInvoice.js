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
            { "data": "invoiceType", "name": "    InvoiceType", "autowidth": true },
            { "data": "invoicePaid", "name": "    InvoicePaid", "autowidth": true },
            { "data": "invoiceChange", "name": "  InvoiceChange", "autowidth": true },
            {
                "render": function (data, type, row) {
                    return '<a href="/sales/edit/' + row.invoiceNo + '"><span><i class="fa fa-edit"></i></span></a>  ' +
                           '<a href="/sales/delete/' + row.invoiceNo + '"><span class="text-danger"><i class="fa fa-trash-o"></i></span></a>'  }
            }
        ]
   });
});