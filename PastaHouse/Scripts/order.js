$(document).ready(function () {
    $(function () {
        $("body").on('DOMSubtreeModified', "#chosen-dishes", function () {
            if ($(".font-weight-bold").text() == "Cena końcowa: 0,00 zł") {
                window.location.href = '/Menu';
            }
        });
    });
});

jQuery(document).ready(function ($) {
    if (performance.navigation.type == 2) {
        location.reload(true);
    }
});
