var QlikSession = (function () {

    var elementWithTicket = null;
    var url = null;

    function htmlElementWithTicket(value) {

        elementWithTicket = value;
    }

    function redirectionUrl(value) {

        url = value;
    }

    function run() {

        var element = $(elementWithTicket).load(function () {
            window.location.href = url;
        });
    }

    return {
        setHtmlElementWithTicket: htmlElementWithTicket,
        setRedirectionUrl: redirectionUrl,
        run: run
    }
})();