$(window).on('qlik.mashup.error', function (event, error) {

    var modal = $('#error-modal');
    var modalBody = modal.find('.modal-body');

    modalBody.append(error.message + "<br/>");
    modal.modal({
        backdrop: 'static'
    });
});