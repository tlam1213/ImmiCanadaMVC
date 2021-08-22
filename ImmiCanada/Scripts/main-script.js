$(document).ready(function () {
    AOS.init({
        duration: 1100
    });
    $(".main-menu .menu-item a").click(function () {
        var currentItem = $(this);
        //$(".main-menu .menu-item div[aria-expanded='false']").removeClass("show");
        $(".main-menu .menu-item div[aria-expanded='false']").each(function () {
            if ($(this).attr("id") != currentItem.find("+ div").attr("id"))
                $(this).removeClass("show");
        });
       //$(this).find("+ div").addClass("show");
    });

    //Load the banner based on URL
    $('#NewsSlide').on('slide.bs.carousel', function (e) {
        /*
            CC 2.0 License Iatek LLC 2018 - Attribution required
        */

        var $e = $(e.relatedTarget);
        var idx = $e.index();
        var itemsPerSlide = 5;
        var totalItems = $('#NewsSlide .carousel-item').length;

        if (idx >= totalItems - (itemsPerSlide - 1)) {
            var it = itemsPerSlide - (totalItems - idx);
            for (var i = 0; i < it; i++) {
                // append slides to end
                if (e.direction == "left") {
                    $('#NewsSlide .carousel-item').eq(i).appendTo('#NewsSlide .carousel-inner');
                }
                else {
                    $('#NewsSlide .carousel-item').eq(0).appendTo('#NewsSlide .carousel-inner');
                }
            }
        }
    });
});