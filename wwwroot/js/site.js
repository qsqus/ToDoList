// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function toggleTaskState(url) {
    $.ajax({
        type: 'POST',
        url: url,
        success: function (res) {
            $('#taskListContainer').html(res);
        },
        error: function (err) {
            console.error(err);
        }
    });
}

function showPopUp(url, title) {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $('#modalForm .modal-body').html(res);
            $('#modalForm .modal-title').html(title);
            $('#modalForm').modal('show');
        },
        error: function (err) {
            console.log(err);
        }
    });
};

function postForm(form) {
    $.ajax({
        type: "POST",
        url: form.action,
        data: new FormData(form),
        contentType: false,
        processData: false,
        success: function (res) {
            $('#taskListContainer').html(res);
            $('#modalForm').modal('hide');
        },
        error: function (err) {
            console.log(err);
        }
    });

    // Prevents default form submit event
    return false;
}

function deleteTask(url, isInline) {
    $.ajax({
        type: "POST",
        url: url,
        success: function (res) {
            $('#taskListContainer').html(res);

            if (!isInline) {
                $('#modalForm').modal('hide');
            }
        },
        error: function (err) {
            console.log(err);
        }
    });
};