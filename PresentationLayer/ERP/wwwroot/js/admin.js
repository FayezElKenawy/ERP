/*remove user by ajax*/

    $('#delete').on('click', function (e) {
            var operation = [{"path": "/isdeleted", "op": "replace", "value": "false" }];
            var userId = $('#userid').attr("user");
        $.ajax({
            type: "patch",
            url: "api/users/" + userId,
            contentType: "application/json",
            data: JSON.stringify(operation),
            success: console.log(operation)
        });

        });

