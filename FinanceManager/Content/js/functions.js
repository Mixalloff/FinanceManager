// Спиннер при загрузке страницы
$(window).load(function () {
    setTimeout(10000);
    $(".loaderInner").fadeOut();
    $(".loader").delay(400).fadeOut("slow");

    // Квадратные блоки
    //  $(".catalogs").css("height", $(".catalogs").css("width"));

   // imageAlign(".profileImg", ".profileImgContainer");

    // Выравнивание изображения профиля по центру
    //if ($(".profileImg").width() < $(".profileImg").height()) {
    //    $(".profileImg").width($(".profileImgContainer").width());
    //    $(".profileImg").css("margin-top", -($(".profileImg").height() - $(".profileImgContainer").height()) / 2);
    //}
    //else {
    //    $(".profileImg").height($(".profileImgContainer").height());
    //    $(".profileImg").css("margin-left", -($(".profileImg").width() - $(".profileImgContainer").width()) / 2);
    //}

});

//function imageAlign(image, container) {
//    if ($(image).width() < $(image).height()) {
//        $(image).width($(container).width());
//        $(image).css("margin-top", -($(image).height() - $(container).height()) / 2);
//    }
//    else {
//        $(image).height($(container).height());
//        $(image).css("margin-left", -($(image).width() - $(container).width()) / 2);
//    }
//}

$(document).ready(function () {
    // Определение высоты секций
    heightDetect(".headSection");

    // Определение высоты секций при изменении размера окна
    $(window).resize(function () {
        heightDetect(".headSection");
    });

    //else {
    //    $(".profileImg").css("width", $(".profileImg").height() / $(".profileImgContainer").height());
    //    $(".profileImg").css("height", $(".profileImgContainer").height());
    //}

    // Анимация кнопки меню при нажатии
    $(".toogleMenu").click(function () {
        $(".sandwich").toggleClass("active");
    });

    // Анимация появления/скрытия меню после нажатия ссылки
    $(".topMenu a").click(function () {
        $(".topMenu").addClass("fadeOutUp animated");
        $(".sandwich").toggleClass("active");
        $(".topMenu").fadeOut(400);
        $(".topMenu").removeClass("fadeOutUp animated");
    });

    // Анимация при скролле до элемента
    $(".projectName").animated("fadeInDown", "fadeOutUp");
    $(".slogan, .sectionHeadBlock").animated("fadeInUp", "fadeOutDown");
    $(".animationLeft").animated("fadeInLeft", "fadeOutRight");
    $(".animationRight").animated("fadeInRight", "fadeOutLeft");
    $(".animationImg").animated("zoomIn", "zoomOut");

});

// Определение высоты элемента по высоте экрана
function heightDetect(elementClass) {
    $(elementClass).css("height", $(window).height());
}

// Появление/скрытие меню 
function menuToogle(animatedElement, animatedEffect) {
    $(animatedElement).toggleClass(animatedEffect + " animated");
    $(animatedElement).fadeToggle(600);
}