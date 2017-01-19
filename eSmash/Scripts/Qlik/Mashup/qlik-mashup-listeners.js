/**
 * Listeners para QlikMashup
 */
var QlikMashupListeners = (function () {

    return {

        setOnClearAllSelectionsListener: setOnClearAllSelectionsListener,
        setOnClearFieldSelectionsListener: setOnClearFieldSelectionsListener,
        triggerOnErrorEvent: triggerOnErrorEvent,
        setOnPageUnloadListener: setOnPageUnloadListener,
        setOnDataExportListener: setOnDataExportListener
    };

    function setOnClearAllSelectionsListener(callback) {

        $(window).on('qlik.ui.filter.clearall', callback);
    }

    function setOnClearFieldSelectionsListener(callback) {

        $(window).on('qlik.ui.filter.clearfield', callback);
    }

    function setOnPageUnloadListener(callback) {

        $(window).on('beforeunload unload', callback);
    }

    function setOnDataExportListener(callback) {

        $(window).on('qlik.data.export', callback);
    }

    function triggerOnErrorEvent(error) {

        $(window).trigger('qlik.mashup.error', error);
    }

})();
