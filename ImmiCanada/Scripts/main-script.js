﻿$(document).ready(function () {
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
    
});