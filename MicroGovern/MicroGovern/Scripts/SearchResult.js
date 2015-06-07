$(document).ready(function () {
    $("#SearchFilterCollapse").slideUp();

    //Enable all popovers on page
    $('[data-toggle="popover"]').popover();

    //Enable all tooltips on page
    $('[data-toggle="tooltip"]').tooltip();

    $("#SearchFilterBtn").click(function () {
        $("#SearchFilterCollapse").toggle();
    });

    // Search Result display table. Toggle description on row click
    $("#SearchResultTable tbody .hiderow").hide();
    $("#SearchResultTable tbody .clickableRow").click(function () {
        $(this).toggleClass("SelectedRow");
        $(this).next().toggle();
        $(this).next().toggleClass("SelectedRow");
    });

    $('.dropdown-toggle').dropdown('toggle');


// Search Options Change Location Dropdowns
    $(function () {
        $("#listofLocations li a").click(function () {
            $("#locationInput").val($(this).text());
        });
    });
    $(function () {
        $("#listofMohallas li a").click(function () {
            $("#mohallaInput").val($(this).text());
        });
    });


    //function collision($div1, $div2) {
    //    var x1 = $div1.offset().left;
    //    var w1 = 40;
    //    var r1 = x1 + w1;
    //    var x2 = $div2.offset().left;
    //    var w2 = 40;
    //    var r2 = x2 + w2;

    //    if (r1 < x2 || x1 > r2) return false;
    //    return true;

    //}

    //// // slider call

    //$('#slider').slider({
    //    range: true,
    //    min: 0,
    //    max: 500,
    //    values: [75, 300],
    //    slide: function (event, ui) {

    //        $('.ui-slider-handle:eq(0) .price-range-min').html('$' + ui.values[0]);
    //        $('.ui-slider-handle:eq(1) .price-range-max').html('$' + ui.values[1]);
    //        $('.price-range-both').html('<i>$' + ui.values[0] + ' - </i>$' + ui.values[1]);

    //        //

    //        if (ui.values[0] == ui.values[1]) {
    //            $('.price-range-both i').css('display', 'none');
    //        } else {
    //            $('.price-range-both i').css('display', 'inline');
    //        }

    //        //

    //        if (collision($('.price-range-min'), $('.price-range-max')) == true) {
    //            $('.price-range-min, .price-range-max').css('opacity', '0');
    //            $('.price-range-both').css('display', 'block');
    //        } else {
    //            $('.price-range-min, .price-range-max').css('opacity', '1');
    //            $('.price-range-both').css('display', 'none');
    //        }

    //    }
    //});

    //$('.ui-slider-range').append('<span class="price-range-both value"><i>$' + $('#slider').slider('values', 0) + ' - </i>' + $('#slider').slider('values', 1) + '</span>');

    //$('.ui-slider-handle:eq(0)').append('<span class="price-range-min value">$' + $('#slider').slider('values', 0) + '</span>');

    //$('.ui-slider-handle:eq(1)').append('<span class="price-range-max value">$' + $('#slider').slider('values', 1) + '</span>');

});



