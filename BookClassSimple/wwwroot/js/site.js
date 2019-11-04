$(document).ready(function () {
    $.ajaxSetup({
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            if (errorThrown == "Unauthorized") {
                messageBox("Please Login")
            } else { 
                location.href = "/Home/Error";
            }
        }
    });

    rebindAjaxFormSubmit();
    rebindAjaxGetPartial();

    $(".cat-item").click(function () {
        $(".cat-item").removeClass("active");
        $(this).addClass("active");
    });
});

function rebindAjaxGetPartial() {
    $('.get-partial').on('click', function (e) {
        e.preventDefault();
        var action = $(this).attr('href');
        var fillTarget = $(this).attr('target');
        var modal = $(this).attr('modal');

        $.get(action, function (result) {
            $('#' + fillTarget).html(result);
            if (modal != undefined) {
                $('#' + modal).modal('show');
            }
            rebindAjaxFormSubmit();
        });
    });
}

function rebindAjaxFormSubmit() {
    $('.ajax-form').submit(function (e) {
        e.preventDefault();
        var action = $(this).attr('action');
        var fillTarget = $(this).attr('target');

        $.post(action, $(this).serialize(), function (result) {
            if (result.href != undefined) {
                location.href = result.href;
            } else {
                $('#' + fillTarget).html(result);
                rebindAjaxFormSubmit();
            }
        });
    });
}

function messageBox(message) {
    $("#message-modal-content").html(message);
    $("#message-modal").modal('show');
}