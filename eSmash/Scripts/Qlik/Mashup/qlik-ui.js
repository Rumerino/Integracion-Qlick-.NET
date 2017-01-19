/**
 * Funciones para la interfaz de usuario.
 */
var QlikUi = (function () {

    return {
        run: run
    }

    var qlikMashup = null;
    var qlikUiListeners = null;

    function run(mashup, listeners) {

        qlikMashup = mashup;
        qlikUiListeners = listeners;

        qlikUiListeners.register();
        qlikUiListeners.setToggleOnClikListener(onToggleElement);
        qlikUiListeners.setOnDataSelectionsListener(onDataSelections);
        qlikUiListeners.setOnShowListener(onShowListener);

        initializeMultiPanel();
    }

    function onToggleElement() {

        var eventTarget = $(this);
        var actionTarget = $(eventTarget.data('qlik-target'));
        var toggleOptions = { effect: getEffect(eventTarget) };

        var isOpening = !actionTarget.is(":visible");

        if (isOpening) {

            toggleOptions.complete = function () {

                qlikUiListeners.triggerShowEvent(actionTarget);
            };
        }

        actionTarget.toggle(toggleOptions);
    }

    function getEffect(target) {

        var effect = $(target).data('qlik-effect');

        return effect ? effect : 'blind';
    }

    function onDataSelections(selectionState) {

        var templateSelector = $(this).data('qlik-template');
        var template = $(templateSelector).first();
        var htmlContent = "";

        var selections = selectionState.selections;

        $.each(selections, function (index, selection) {

            var fieldName = selection.fieldName;
            var selectedCount = selection.selectedCount;

            // selection.qSelected contiene todos los valores, pero no se
            // insertarán por ahorro de espacio
            var selected = (selectedCount > 1)
                ? selectedCount + " of " + selection.totalCount
                : selection.qSelected;

            var element = $('<div>' + template.html() + '</div>');

            element.find('.current-selection-title').html(fieldName);
            element.find('.current-selection-content').html(selected);
            element.find('[data-qlik-action="dismiss"]').attr('data-qlik-arg', fieldName);

            htmlContent += element.html();
        });

        $(this).html(htmlContent);

        qlikUiListeners.registerOnClearFieldListener();
    }

    function onShowListener(event) {

        var target = $(event.target);

        // si el elemento describe un objecto de qlik se carga ese objeto
        // sino se buscan los descendientes que describan objetos de qlik.
        var objects = QlikMashupUtils.isQlikObject(target)
            ? target
            : target.find('[data-qlik-object]');

        QlikMashup.loadQlikObjectsOrResize(objects);
    }

    function initializeMultiPanel() {

        $('[data-qlik-content="multi-panel"]').each(function () {

            var activeCssClass = 'active';
            var hiddenCssClass = 'hidden';

            var multiPanel = $(this);

            var activeTrigger = $(multiPanel).find('.' + activeCssClass + '[data-qlik-target]');
            var activePanel = $(activeTrigger.data('qlik-target'));

            multiPanel.data('trigger', activeTrigger);
            multiPanel.data('panel', activePanel);

            $(multiPanel).find("[data-qlik-target]").click(function (event) {

                event.preventDefault();

                var trigger = $(this);
                var panel = $(trigger.data('qlik-target'));
                var current = multiPanel.data('panel');

                if (current && current != panel) {

                    toggle(multiPanel.data('trigger'), current);
                }

                multiPanel.data('panel', panel);
                multiPanel.data('trigger', trigger);

                toggle(trigger, panel);

                $(panel).trigger('qlik.ui.show');
            });

            function toggle(trigger, panel) {

                trigger.toggleClass(activeCssClass);
                panel.toggleClass(hiddenCssClass);
            }
        });
    }

})();

$(function () {
    QlikUi.run(QlikMashup, QlikUiListeners);
});
