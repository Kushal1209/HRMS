// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

addtaskmodel = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#addnewtaskmodel .modal-body").html(res);
            $("#addnewtaskmodel .modal-title").html(title);
            $("#addnewtaskmodel").modal('show');
        }
    })
}
