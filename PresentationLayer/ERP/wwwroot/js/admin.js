/*remove user by ajax*/

    $('#delete').on('click', function (e) {
            var operation = [{"path": "/isdeleted", "op": "replace", "value": "true" }];
            var userId = $('#userid').attr("user");
        $.ajax({
            type: "patch",
            url: "/api/users/" + userId,
            contentType: "application/json",
            data: JSON.stringify(operation),
            success: console.log(operation)
        });
        $('.active').attr('hidden', 'hidden');
        $('#' + userId).append('<td class="deleted">Deleted</td><td class="deleted"><a href="#" id="reActive" user="' + userId
            + '"><spn><i class="fa fa-refresh" aria-hidden="true"></i></spn></a></td>');
        $('.deleted').removeAttr('hidden');
        
    });



$('#reActive').on('click', function () {
    var operation = [{ "path": "/isdeleted", "op": "replace", "value": "false" }];
    var userId = $(this).attr("user");
    $.ajax({
        type: "patch",
        url: "/api/users/" + userId,
        contentType: "application/json",
        data: JSON.stringify(operation),
        success: console.log(operation)
    });
});

