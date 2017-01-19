var QlikMashupUtils = (function () {

    return {
        isLoaded: isLoaded,
        setAsLoaded: setAsLoaded,
        isQlikObject: isQlikObject
    };

    function isLoaded(element) {

        return $(element).data('qlik-status') == 'loaded';
    }

    function setAsLoaded(element) {

        $(element).data('qlik-status', 'loaded');
    }

    function isQlikObject(element) {

        return $(element).data('qlik-object') != undefined;
    }

})();