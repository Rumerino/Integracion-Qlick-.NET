/**
 * Añade el fondo que evita la interacción del usuario con la página mientras
 * el menú "offcanvas" está abierto.
 */
$(function () {

    var menu = null;
    var offcanvasWidth = null;

    function hideMenu() {

        if (menu) {
            menu.offcanvas('hide');
        }
    }

    function closeOnEscapeKeyPress(event) {

        var escapeKey = 27;

        if (event.which == escapeKey) {

            hideMenu();
        }
    }

    function createBackdrop() {

        var backdrop = $('<div>')
            .addClass('modal-backdrop fade')
            .css('right', offcanvasWidth);

        backdrop.appendTo('body').addClass('in');
        
        return backdrop;
    }

    function getOffcanvasWidth() {

        var defaultWidth = '300px';
        var width = $('.navbar-offcanvas').css('width');

        if (!width) {

            width = $('.navmenu').css('width');
        }

        return width;
    }

    var offcanvasWidth = getOffcanvasWidth();

    $(window).on('shown.bs.offcanvas', function (event) {

        menu = $(event.target);

        $(window).one('keydown', closeOnEscapeKeyPress);

        createBackdrop().click(hideMenu);
    });

    $(window).on('hide.bs.offcanvas', function () {

        // eliminación del fondo
        $('.modal-backdrop').remove();
    });
});
