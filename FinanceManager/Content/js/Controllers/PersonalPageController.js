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
    .when('/PersonalPage/operations', { 
        templateUrl: '/Content/Templates/personalOperations.html',
        controller: 'personalOperationsController'
    })
    .when('/PersonalPage/chats', { 
        templateUrl: '/Content/Templates/personalChats.html',
        controller: 'personalChatsController'
    })
    .when('/PersonalPage/accounts', {
        templateUrl: '/Content/Templates/personalAccounts.html',
        controller: 'personalAccountsController'
    })
    .otherwise({
        redirectTo: '/Home'
    });

})
.controller("PersonalPageController",
function ($route, $routeParams, $location, $scope, $http) {
    $scope.goToStart = function () {
        $location.path('/PersonalPage')
    }

    $scope.goToOperations = function () {
        $location.path('/PersonalPage/operations')
    }

    $scope.goToChats = function () {
        $location.path('/PersonalPage/chats')
    }

    $scope.goToAccounts = function () {
        $location.path('/PersonalPage/accounts')
    }

    //$scope.name = getCookie("VisitorName");
    // $scope.surname = getCookie("VisitorSurname");

    // Тестовые данные-заглушки (будут подтягиваться из БД)
    // $scope.balance = 6800;
    //$scope.profileImgSrc = "/Resources/UsersFiles/mixalloff/images/1.jpg";


    $scope.squareElemByWidth = function (element) {
        $(element).css("height", $(element).css("width"));
    }

    $scope.squareElemByHeight = function (element) {
        $(element).css("width", $(element).css("height"));
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

    $scope.userdata = function () {
        $http.get("/PersonalPage/GetUserData")
        .success(function (data) {
            $scope.balance = data.Balance;
               
            $scope.name = data.Name;
            $scope.surname = data.Surname;

            // Предварительная загрузка изображения
            var image = new Image();
            image.onload = function () {
                $scope.$apply(function () {
                    $scope.profileImgSrc = image.src;
                });
            };
            image.src = data.Image;
                
        })
        .error(function (data) {
            alert(data);
        });
    }
})
.controller("personalStartController",
function ($route, $routeParams, $location, $scope) {
})

.controller("personalChatsController",
    function ($route, $routeParams, $location, $scope) {
    })

.controller("personalAccountsController",
    function ($route, $routeParams, $location, $scope) {
        $scope.accounts = [
            { name: "Наличные", amount: "15 000", img: "/Resources/UsersFiles/mixalloff/images/1.jpg" },
            { name: "Мобильный", amount: "200", img: "/Resources/UsersFiles/Mixalloff/avatar.jpeg" },
            { name: "Наличные", amount: "15 000", img: "/Resources/UsersFiles/mixalloff/images/1.jpg" },
            { name: "Наличные", amount: "15 000", img: "/Resources/UsersFiles/mixalloff/images/1.jpg" },
            { name: "Наличные", amount: "15 000", img: "/Resources/UsersFiles/mixalloff/images/1.jpg" },
            { name: "Наличные", amount: "15 000", img: "/Resources/UsersFiles/mixalloff/images/1.jpg" },
            { name: "Наличные", amount: "15 000", img: "/Resources/UsersFiles/mixalloff/images/1.jpg" },
            { name: "Наличные", amount: "15 000", img: "/Resources/UsersFiles/mixalloff/images/1.jpg" }
        ];
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

    $scope.operationGroups = [
        { name: 'Доходы' },
        { name: 'Расходы' }
    ];

    $scope.userAccounts = [
        { name: 'Наличные' },
        { name: 'Карта сбербанк' }
    ];

    $scope.operationType = [
        { name: 'Доход' },
        { name: 'Расход' }
    ];

    $scope.newOperationDate = new Date();

    $scope.openAddOperationFormVisible = false;

    $scope.OpenAddOperationForm = function () {
        $scope.openAddOperationFormVisible = true;
    }

    $scope.CloseAddOperationForm = function () {
        $scope.openAddOperationFormVisible = false;
    }

                //$http.post('/Authorization/SignIn', {
                //    login: signIn.userLogin,
                //    password: hex_md5(signIn.userPassword),
                //}).success(function (response) {
                //    if (response.IsAuthenticated) {
                //        SuccessSignIn("Авторизация успешно пройдена!");

                //        // Redirect to personal page
                //        setTimeout(
                //            function () {
                //                document.location.href = '/PersonalPage';
                //            }, 1000
                //        );
                //    }
                //    else {
                //        ErrorInfo("Ошибка! Неверный логин и/или пароль!");
                //    }
                //}).error(function (response) {
                //    //alert("Error: " + response);
                //    ErrorInfo("Ошибка сервера!");
                //});

})

.directive("imageAlign", [function () {
    return {
        link: function (scope, element, attr) {
            attr.$observe("src", function (srcAttribute) {
                if (element.width() < element.height()) {
                    element.width(element.parent().width());
                    element.css("margin-top", -(element.height() - element.parent().height()) / 2);
                }
                else {
                    element.height(element.parent().height());
                    element.css("margin-left", -(element.width() - element.parent().width()) / 2);
                }
            });
        }
    }
}]);
