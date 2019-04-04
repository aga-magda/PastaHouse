jQuery(document).ready(function ($) {
    if (performance.navigation.type == 2) {
        location.reload(true);
    }
});

$(document).ready(function () {
    
    var numbers = {};   
    var numItems = $('.btn-plus').length;

    for (i = 1; i < numItems + 1; i++) {
        key = "plus" + String(i);
        btn_number = parseInt($("#" + key).text().replace("+ | ", ""));
        numbers[key] = btn_number;
    }

    // Plus buttons
    $(".btn-plus").off().click(function () {
        btn_plus_id = this.id;
        numbers[btn_plus_id] = numbers[btn_plus_id] + 1;
        $(this).text("+ | " + numbers[btn_plus_id]);
    });


    // Minus buttons
    $(".btn-minus").off().click(function () {
        btn_minus_id = this.id;
        btn_plus_id = this.id.replace("minus", "plus").toString();

        if (numbers[btn_plus_id] > 0) {
            numbers[btn_plus_id] = numbers[btn_plus_id] - 1;
            $("#" + btn_plus_id).text("+ | " + numbers[btn_plus_id]);
        }
    });

    // Clear cart
    $(function () {
        $("body").on('DOMSubtreeModified', "#menuCart", function () {
            if (parseInt($(".total-price-header").text()) == 0) {
                keys = Object.keys(numbers);
                for (i = 0; i < keys.length; i++) {
                    numbers[keys[i]] = 0;                    
                }
                $(".btn-plus").text("+ | " + 0);
            }
        });
    });

});