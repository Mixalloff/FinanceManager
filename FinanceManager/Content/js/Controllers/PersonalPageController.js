//var personalModuleApp = angular.module('PersonalModule');

var personalModuleApp = angular.module('PersonalModule', ['ngRoute'])

.config(function ($routeProvider, $locationProvider) {
    'use strict';
    // $locationProvider.html5Mode(true);

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });

    $routeProvider.when('/PersonalPage', { //Шаблон авторизированного входа
        templateUrl: '/Content/Templates/mainPersonalPage.html',
        controller: 'personalStartController'
    })
    .when('/PersonalPage/operations', { //Шаблон авторизированного входа
        templateUrl: '/Content/Templates/personalOperations.html',
        controller: 'personalOperationsController'
    })
    .otherwise({
        redirectTo: '/Home'
    });

})
.controller("PersonalPageController", 
function ($route, $routeParams, $location, $scope) {
    $scope.goToStart = function () {
        $location.path('/PersonalPage')
    }

    $scope.goToOperations = function () {
        $location.path('/PersonalPage/operations')
    }

    $scope.name = getCookie("VisitorName");
    $scope.surname = getCookie("VisitorSurname");

    // Тестовые данные-заглушки (будут подтягиваться из БД)
    $scope.balance = 6800;
    $scope.profileImgSrc = "/Resources/UsersFiles/mixalloff/images/1.jpg";


    $scope.squareElemLoad = function (element) {
        $(element).css("height", $(element).css("width"));
    }

    $scope.logout = function () {
        deleteCookie(getCookie("CookieNameOfTicket"));
        deleteCookie("VisitorName");
        deleteCookie("VisitorSurname");
        deleteCookie("CookieNameOfTicket");
        document.location.href = '/';
    }

    function deleteCookie(name) {
        document.cookie = name += "=; expires=" + new Date(0).toGMTString();
    }

    function getCookie(name) {    
        var matches = document.cookie.match(new RegExp(
          "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)" 
        ));
        return matches ? decodeURIComponent(matches[1]) : undefined; 
    }


})
.controller("personalStartController",
function ($route, $routeParams, $location, $scope) {
})
.controller("personalOperationsController",
function ($route, $routeParams, $location, $scope) {
    $scope.operations = [
       { name: 'Получение зарплаты', type: 1, account: 'Банковская карта', group: 'Регулярные доходы', price: '55000 руб', date: '12.04.2014' },
       { name: 'Заправка бензина', type: -1, account: 'Наличные', group: 'Авто', price: '1000 руб', date: '13.04.2014' },
       { name: 'Оплата телефона', type: -1, account: 'Наличные', group: 'Коммуналка', price: '200 руб', date: '19.04.2014' },
       { name: 'Получение стипухи', type: 1, account: 'Банковская карта', group: 'Регулярные доходы', price: '2000 руб', date: '25.04.2014' },
       { name: 'Закупка в магазине продуктами', type: -1, account: 'Банковская карта', group: 'Продукты', price: '450 руб', date: '25.04.2014' },
       { name: 'Сделал лабу пацанам', type: 1, account: 'Наличные', group: 'Подработка', price: '500 руб', date: '30.04.2014' }
    ];
});