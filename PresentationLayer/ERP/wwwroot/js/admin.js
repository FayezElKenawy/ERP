/*remove user by ajax*/

    $('#delete').on('click', function (e) {
            var operation = [{"path": "/isdeleted", "op": "replace", "value": "true" }];
            var userId = $('#userid').attr("user");
        $.ajax({
            type: "patch",
            url: "api/users/" + userId,
            contentType: "application/json",
            data: JSON.stringify(operation),
            success: console.log(operation)
        });

        
    });



$('#reActive').on('click', function () {
    var operation = [{ "path": "/isdeleted", "op": "replace", "value": "false" }];
    var userId = $(this).attr("user");
    $.ajax({
        type: "patch",
        url: "api/users/" + userId,
        contentType: "application/json",
        data: JSON.stringify(operation),
        success: console.log(operation)
    });
});

