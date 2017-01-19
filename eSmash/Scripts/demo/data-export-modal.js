$(function () {

    var modalContainer = $('#data-export-modal');

    $(window).on('qlik.data.export', function () {

        toggle();
        modalContainer.modal('show');
    });

    $(window).on('qlik.data.exported', function (event, downloadUrl) {

        modalContainer.find('a').first().attr('href', downloadUrl);
        toggle();
    });

    function toggle() {

        var cssClass = 'hidden';

        modalContainer.find('.export-result').toggleClass(cssClass);
        modalContainer.find('.spinner').toggleClass(cssClass);
    }
});