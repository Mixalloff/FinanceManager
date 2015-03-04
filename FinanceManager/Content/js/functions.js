// Спиннер при загрузке страницы
$(window).load(function () {
    setTimeout(10000);
    $(".loaderInner").fadeOut();
    $(".loader").delay(400).fadeOut("slow");
});

$(document).ready(function () {
    // Определение высоты секций
    heightDetect("section");

    // Определение высоты секций при изменении размера окна
    $(window).resize(function () {
        heightDetect(".section");
    });

    // Анимация кнопки меню при нажатии
    $(".toogleMenu").click(function () {
        $(".sandwich").toggleClass("active");
    });

    // Появление/скрытие меню при нажатии
    $(".toogleMenu").click(function () {
        menuToogle(".topMenu", "fadeInDown");
    });

    // Появление меню авторизации при щелчке по кнопке
    $(".hiddenSignIn").click(function () {
        if ($(".signInBlock").is(":hidden")) {
            $(".signInBlock").addClass("fadeInRight animated");
        }

        $(".signInBlock").fadeToggle(600);
        $(".hiddenSignIn").fadeToggle(600);

    });

    // Закрытие окна авторизации при щелчке по свободной зоне
    $(document).click(function () {
        if ($(event.target).closest(".hiddenSignIn").length) return;
        if ($(".signInBlock").is(":visible")) {
            $(".signInBlock").removeClass("fadeInRight animated");
            $(".signInBlock").fadeToggle(600);
            $(".hiddenSignIn").fadeToggle(600);
        }
    });

    // Останавливает вызов события к родительским элементам при щелчке
    // по окну авторизации (чтобы оно не закрывалось)
    $(".signInBlock").click(function (e) {
        e.stopPropagation();
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


    // Попап при клике на элемент
    $(".popup").magnificPopup({ type: "image" });

});

// Определение высоты элемента по высоте экрана
function heightDetect(elementClass) {
    $(elementClass).css("height", $(window).height());
}

// Появление/скрытие меню 
function menuToogle(animatedElement, animatedEffect) {
    if ($(animatedElement).is(":hidden")) {
        $(animatedElement).addClass(animatedEffect + " animated");
    }
    else {
        $(animatedElement).removeClass(animatedEffect + " animated");
    }
    $(animatedElement).fadeToggle(600);
}
