/**
 * QlikMashup.
 * ===========
 * 
 * Realiza la inicialización necesaria para obtener un objeto qlik
 * (js/qlik.js).
 * 
 */
var QlikMashup = (function () {

    return {
        run: run,
        getAppId: function () { return appId; },
        getQlikApp: function () { return qlikApp; },
        getQlikObject: function () { return qlikObject; },
        loadQlikObjectsOrResize: loadQlikObjectsOrResize,
        onAppLoad: onAppLoad
    };

    var config = null;
    var appId = null;
    var userCallback = null;
    var qlikObject = null;
    var qlikApp = null;
    var onAppLoadCallback = null;
    var triggerQlikAppErrors = null;
    var qlikBaseUrl = null;

    function run(mashupConfig, qlikAppId, callback) {

        config = mashupConfig;
        appId = qlikAppId;
        userCallback = callback;

        var protocol = config.isSecure ? "https://" : "http://";
        var port = config.port ? ":" + config.port : "";

        qlikBaseUrl = protocol
            + config.host
            + port
            + config.prefix;

        // ojo: el puerto tiene que estar indicado siempre, aunque sea un
        // puerto estándar, sino no funciona con la versión servidor de Qlik.
        require.config({

            baseUrl: qlikBaseUrl + "resources"
        });

        require(["js/qlik"], callbackWrapper);
    };

    function callbackWrapper(qlik) {

        qlikObject = qlik;
        setOnErrorCallback(qlikObject);

        if (!openApp()) {
            return;
        }

        if (typeof userCallback == 'function') {
            userCallback(qlikObject, qlikApp);
        }
    }

    function setOnErrorCallback(qlikObject) {

        triggerQlikAppErrors = true;

        qlikObject.setOnError(function (error) {

            if (!triggerQlikAppErrors) {
                return;
            }

            console.error(JSON.stringify(error))
            QlikMashupListeners.triggerOnErrorEvent(error);
        });
    }

    function openApp() {

        qlikApp = qlikObject.openApp(appId, config);

        if (!qlikApp) {
            return;
        }

        loadQlikObjects($('[data-qlik-action="load"]'));
        registerEventsAndListeners(qlikApp);
        callOnAppLoadCallback();

        return qlikApp;
    }

    function loadQlikObjects(objects) {

        $(objects).each(loadQlikObjectInContainer);
    }

    function loadQlikObjectInContainer() {

        var container = $(this);
        var qlikObjectId = container.data('qlik-object');
        var containerId = getElementIdOrAddOne(container, qlikObjectId);

        qlikApp.getObject(containerId, qlikObjectId);
        QlikMashupUtils.setAsLoaded(container);
    }

    function getElementIdOrAddOne(element, idSuffix) {

        var id = $(element).attr('id');

        if (!id) {

            id = 'qlik-object-' + idSuffix;
            element.attr('id', id);
        }

        return id;
    }

    function loadQlikObjectsOrResize(objects) {

        $(objects).each(function () {

            var target = $(this);

            if (QlikMashupUtils.isLoaded(target)) {

                resizeObject(getObjectIdFromElement(target));
            }
            else {

                loadQlikObjectInContainer.call(target);
            }
        });
    }

    function getObjectIdFromElement(element) {

        return $(element).data('qlik-object');
    }

    function resizeObject(objectId) {

        qlikObject.resize(objectId);
    }

    function registerEventsAndListeners(qlikApp) {

        QlikMashupListeners.setOnClearAllSelectionsListener(function () {

            qlikApp.clearAll();
        });

        QlikMashupListeners.setOnClearFieldSelectionsListener(function (event, fieldName) {

            qlikApp.field(fieldName).clear();
        });

        QlikMashupListeners.setOnPageUnloadListener(onPageUnload);

        QlikMashupListeners.setOnDataExportListener(onDataExport);

        registerOnDataSelectionsListener(qlikApp);
    }


    // Evita errores de desconexión de la aplicación de Qlik.
    function onPageUnload() {

        triggerQlikAppErrors = false;
        qlikApp.close();
    }

    function onDataExport(event, values) {

        qlikApp.getObject(values.objectId).then(function (model) {

            exportData(event.target, model, values);
        });
    }

    function exportData(target, model, values) {

        var qTable = qlikObject.table(model);

        var options = {
            format: values.format ? values.format : 'OOXML'
        };

        if (values.filename) {

            options.filename = values.filename
        }

        qTable.exportData(options, function (url) {

            var downloadUrl = parseDownloadUrl(url);

            $(target).trigger('qlik.data.exported', downloadUrl);
        });
    }

    function parseDownloadUrl(url) {

        var regex = new RegExp(/^http/);

        if (regex.test(url)) {
            return url;
        }

        // Qlik Desktop
        return qlikBaseUrl + url.replace(/\.\.\//g, '');
    }

    function registerOnDataSelectionsListener(qlikApp) {

        var selectionState = qlikApp.selectionState();

        selectionState.OnData.bind(function () {

            $(window).trigger('qlik.mashup.selections.ondata', selectionState);
        });
    }

    function onAppLoad(callback) {

        onAppLoadCallback = callback;

        callOnAppLoadCallback();
    }

    function callOnAppLoadCallback() {

        if (!qlikApp || !onAppLoadCallback) {
            return;
        }

        onAppLoadCallback(qlikObject, qlikApp);
        onAppLoadCallback = null;
    }

})();

$(function () {

    var appId = $('[data-qlik-app]').first().data('qlik-app');
    QlikMashup.run(qlikServerConfig, appId);
});