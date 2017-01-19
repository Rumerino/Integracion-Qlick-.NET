$(function () {

    var options = {
        valueNames: ['glossary-term', 'glossary-content' ]
    };

    var list = new List('glossary-search', options);

    // set focus over the search input
    $('#glossary-modal').on('shown.bs.modal', function () {
        $('.search').focus();
    });

    // clean input text
    $('.clear-input').click(function () {

        $(".search").val("");
        list.search();
    });

    // no-result message
    list.on('updated', function (list) {
        if (list.matchingItems.length > 0) {
            $('.no-result').hide()
        } else {
            $('.no-result').show()
        }
    })
});
