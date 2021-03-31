/*remove user by ajax*/

    $('#delete').on('click', function (e) {
            var operation = [{"path": "/isdeleted", "op": "replace", "value": "true" }];
            var userId = $('#userid').attr("user");
            var result = confirm("Are You Sure?");
            if (result) {
        $.ajax({
            type: "patch",
            url: "api/users/" + userId,
            contentType: "application/json",
            data: JSON.stringify(operation),
            success: console.log(operation)

        });
            }
        });

