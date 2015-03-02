// Спиннер при загрузке страницы
$(window).load(function(){
	setTimeout(10000);
	$(".loaderInner").fadeOut(); 
	$(".loader").delay(400).fadeOut("slow"); 
});

$(document).ready(function(){
	// Определение высоты секций
	heightDetect("section");

	// Определение высоты секций при изменении размера окна
	$(window).resize(function(){
		heightDetect(".section");
	});

	// Анимация кнопки меню при нажатии
	$(".toogleMenu").click(function() {
  		$(".sandwich").toggleClass("active");
	});
	
	// Появление/скрытие меню при нажатии
	$(".toogleMenu").click(menuToogle);

	// Анимация появления/скрытия меню после нажатия ссылки
	$(".topMenu a").click(function(){
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
	$(".popup").magnificPopup({type:"image"});
	
});

// Определение высоты элемента по высоте экрана
function heightDetect(elementClass){
		$(elementClass).css("height", $(window).height());
	}

// Появление/скрытие меню 
function menuToogle(){
	if ($(".topMenu").is(":hidden"))
	{
		$(".topMenu").addClass("fadeInDown animated");
	}
	else{
		$(".topMenu").removeClass("fadeInDown animated");
	}
	$(".topMenu ").fadeToggle(600);
}
	