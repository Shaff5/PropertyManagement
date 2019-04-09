$((function () {
    var url;
    var redirectUrl;
    var target;

    //Delete Action
    $(".delete").on('click', function(e) {
        e.preventDefault();
        
        target = e.target;
        var Id = $(target).data('id');
        var controller = $(target).data('controller');
        var action = $(target).data('action');
        var bodyMessage = $(target).data('body-message');
        redirectUrl = $(target).data('redirect-url');

        url = "/" + controller + "/" + action + "?Id=" + Id;
        $(".delete-modal-body").text(bodyMessage);
        $("#deleteModal").modal('show');
    });

    $("#confirm-delete").on('click', function() {
        //$.get(url)
        //    .done((result) => {
        //        if (!redirectUrl) {
        //            return $(target).parent().parent().hide("slow");
        //        }
        //        window.location.href = redirectUrl;
        //    })
        //    .fail((error) => {
        //        if (redirectUrl)
        //            window.location.href = redirectUrl;
        //    }).always(() => {
        //        $("#deleteModal").modal('hide');
        //    });
        window.location.href = url;
    });

}()));