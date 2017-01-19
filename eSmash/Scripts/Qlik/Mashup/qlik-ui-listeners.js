/**
 * Listeners para QlikUi.
 */
var QlikUiListeners = (function () {

    return {
        register: register,
        setOnDataSelectionsListener: setOnDataSelectionsListener,
        registerOnClearFieldListener: registerOnClearFieldListener,
        setOnShowListener: setOnShowListener,
        setToggleOnClikListener: setToggleOnClikListener,
        triggerShowEvent: triggerShowEvent
    };

    function register() {

        registerOnClearAllListener();
        registerOnClearFieldListener();
        registerOnDataTotalSelectionsListener();
        registerThirdPartiesEventWrappers();
        registerOnDataExportListener();
    }

    function registerOnClearAllListener() {

        $('[data-qlik-action="clearall"]').click(function (event) {
            event.preventDefault();
            $(this).trigger('qlik.ui.filter.clearall');
        });
    }

    function registerOnClearFieldListener() {

        $('[data-qlik-content="current-selections"] [data-qlik-action="dismiss"]').click(function () {

            $(this).trigger('qlik.ui.filter.clearfield', $(this).data('qlik-arg'));
        });
    }

    function registerOnDataTotalSelectionsListener() {

        $(window).on('qlik.mashup.selections.ondata', function (event, selectionState) {

            var totalSelections = selectionState.selections.length;

            $('[data-qlik-content="total-selections"]').text(totalSelections);
        });
    }

    function registerOnDataExportListener() {

        $('[data-qlik-export]').click(function () {

            var that = $(this);
            var exportFormat = that.data('qlik-export');
            var exportFilename = that.data('qlik-file');
            var target = $(that.data('qlik-target'));
            var qlikObjectId = target.data('qlik-object');

            var values = {
                format: exportFormat,
                objectId: qlikObjectId,
                filename: exportFilename
            };

            that.trigger('qlik.data.export', values);
        });
    }

    function registerThirdPartiesEventWrappers() {

        // Bootstrap modal
        $(window).on('shown.bs.modal', function (event) {

            //$(event.target).trigger('qlik.ui.show');
            triggerShowEvent(event.target);
        });

        // Jasny Bootstrap Offcanvas menu
        $(window).on('shown.bs.offcanvas', function (event) {

            //$(event.target).trigger('qlik.ui.show');
            triggerShowEvent(event.target);
        });
    }

    function setOnDataSelectionsListener(callback) {

        $(window).on('qlik.mashup.selections.ondata', function (event, selectionState) {

            $('[data-qlik-content="current-selections"]').each(function () {

                callback.call(this, selectionState);
            });
        });
    }

    function setOnShowListener(callback) {

        $(window).on('qlik.ui.show', callback);
    }

    function setToggleOnClikListener(callback) {

        $('[data-qlik-action="toggle"]').click(function (event) {

            event.preventDefault();
            callback.call(this, event);
        });
    }

    function triggerShowEvent(element) {

        $(element).trigger('qlik.ui.show');
    }

})();
