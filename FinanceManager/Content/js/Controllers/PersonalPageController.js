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
    $scope.userId = "undefined";

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
       // deleteCookie("VisitorName");
      //  deleteCookie("VisitorSurname");
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

            $scope.userId = data.Id;//!

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
    function ($route, $http, $routeParams, $location, $scope) {

        //$scope.accounts = [
        //    { Name: "Наличные", Balance: "15 000", Logo: "/Resources/UsersFiles/mixalloff/images/1.jpg" },
        //    { Name: "Карта сбербанк", Balance: "200", Logo: "/Resources/UsersFiles/Mixalloff/avatar.jpeg" }
        //];

        $scope.accountTypes = [
            { Name: "Наличные", Id: "1" },
            { Name: "Банковский счет", Id: "19" },
            { Name: "Электронный кошелек", Id: "20" }
        ];

        $scope.currencies = [
            { Name: "Рубль", Abbreviation: "RUB", Id: 1 },
            { Name: "Доллар", Abbreviation: "USD", Id: 13 },
            { Name: "Евро", Abbreviation: "EUR", Id: 16 },
            { Name: "Франк", Abbreviation: "CHR", Id: 19 },
            { Name: "Фунт", Abbreviation: "GBR", Id: 20 },
            { Name: "Йена", Abbreviation: "JPY", Id: 18 }
        ];

        $http.post('/PersonalPage/GetAccounts', {
            userId: $scope.userId
        }).success(function (response) {
            if (response) {
                // Получены
                $scope.accounts = response;
            }
            else {
                // Нет  
                alert('не получено!');
            }
        }).error(function (response) {
            // Ошибка
            $scope.operations = response;
            // alert('ошибка!');
        });

        $scope.TryAddAccount = function (newAccountData, AccountAddForm) {
            $http.post('/PersonalPage/AddAccount', {
                userId: $scope.userId,
                name: newAccountData.newAccountName,
                balance: newAccountData.newAccountBalance,
                typeId: newAccountData.newAccountType.Id,
                currencyId: newAccountData.newAccountCurrency.Id,
                logo: newAccountData.newAccountPhoto
            }).success(function (response) {
                if (response) {
                    // Удачно добавлен
                    $scope.accounts.push({ Id: response, Name: newAccountData.newAccountName, Balance: newAccountData.newAccountBalance, Logo: newAccountData.newAccountPhoto, Currency: newAccountData.newAccountCurrency.Abbreviation });
                    $scope.CloseAddAccountForm();
                }
                else {
                    // Не добавлен   
                    alert('не добавлен!');
                }
            }).error(function (response) {
                // Ошибка
                alert('ошибка!');
            });
        }

        $scope.DeleteAccount = function (elem) {
            if (confirm("Удалить выбранный счет?")) {
                $scope.accounts.forEach(function (element, index, array) {
                    if (element.Id == elem.current.Id) {
                        array.splice(index, 1);
                    }
                });

                $http.post('/PersonalPage/DeleteAccount', {
                    accountId: elem.current.Id
                }).success(function (response) {
                    if (response) {
                        // Удалено
                        alert("Удалено!");
                    }
                    else {
                        // Нет  
                        alert("Не удалено!");
                    }
                }).error(function (response) {
                    // Ошибка
                    alert('ошибка!');
                });
            }
        }

        $scope.AddAccountFormVisible = false;

        $scope.OpenAddAccountForm = function () {
            $scope.AddAccountFormVisible = true;
        }

        $scope.previewImgSrc = "/Resources/UsersFiles/mixalloff/images/1.jpg";

        $scope.CloseAddAccountForm = function () {
            $scope.AddAccountFormVisible = false;
        }
})

.controller("personalOperationsController",
function ($route, $routeParams, $http, $location, $scope) {
    //$scope.operations =

    //$scope.operations = [
    //   { name: 'Получение зарплаты', type: 'Доход', account: 'Банковская карта', group: 'Регулярные доходы', price: '55000 руб', date: '12.04.2014' },
    //   { name: 'Заправка бензина', type: 'Расход', account: 'Наличные', group: 'Авто', price: '1000 руб', date: '13.04.2014' },
    //   { name: 'Оплата телефона', type: 'Расход', account: 'Наличные', group: 'Коммуналка', price: '200 руб', date: '19.04.2014' },
    //   { name: 'Получение стипухи', type: 'Доход', account: 'Банковская карта', group: 'Регулярные доходы', price: '2000 руб', date: '25.04.2014' },
    //   { name: 'Закупка в магазине продуктами', type: 'Расход', account: 'Банковская карта', group: 'Продукты', price: '450 руб', date: '25.04.2014' },
    //   { name: 'Сделал лабу пацанам', type: 'Доход', account: 'Наличные', group: 'Подработка', price: '500 руб', date: '30.04.2014' }
    //];

    $http.post('/PersonalPage/GetOperations', {
        userId: $scope.userId
    }).success(function (response) {
        if (response) {
            // Получены
            $scope.operations = response;
        }
        else {
            // Нет  
            alert('не получено!');
        }
    }).error(function (response) {
        // Ошибка
        $scope.operations = response;
       // alert('ошибка!');
    });

    $scope.select = function (elem) {
        elem.current.IsSelected = !elem.current.IsSelected;
    }

    $scope.selectAll = function (current) {
        var allSelected = true;
        current.forEach(function (element, index, array) {
            if (element.IsSelected == false) {
                allSelected = false;
            }
        });

        current.forEach(function (element, index, array) {
            element.IsSelected = !allSelected;
        });
     //   elem.current.IsSelected = !elem.current.IsSelected;
    }

    $scope.operationGroups = [
        { name: 'Доходы', id: 1 },
        { name: 'Расходы', id: 2 }
    ];

    //$scope.userAccounts = [
    //    { name: 'Наличные', id: 1 },
    //    { name: 'Карта сбербанк', id: 2 }
    //];

    $http.post('/PersonalPage/GetAccounts', {
        userId: $scope.userId
    }).success(function (response) {
        if (response) {
            // Получены
            $scope.accounts = response;
        }
        else {
            // Нет  
            alert('не получено!');
        }
    }).error(function (response) {
        // Ошибка
        $scope.operations = response;
        // alert('ошибка!');
    });

    $scope.operationType = [
        { name: 'Доход', id: 1 },
        { name: 'Расход', id: 2 }
    ];

    $scope.openAddOperationFormVisible = false;

    $scope.OpenAddOperationForm = function () {
        $scope.openAddOperationFormVisible = true;
    }

    $scope.CloseAddOperationForm = function () {
        $scope.openAddOperationFormVisible = false;
    }
   
    $scope.TryAddOperation = function (newOperationData, operationAddForm) {
        // Проверить валидность формы
        $http.post('/PersonalPage/AddOperation', {
            name: newOperationData.newOperationName,
            groupId: newOperationData.newOperationGroup.id,
            accountId: newOperationData.newOperationAccount.Id,
            typeId: newOperationData.newOperationType.id,
            dateStart: newOperationData.newOperationDate,
            amount: newOperationData.newOperationNominal,
            notes: newOperationData.newOperationNotes
        }).success(function (response) {
            if (response) {
                // Удачно добавлен
                $scope.operations.push({ Id: response, Name: newOperationData.newOperationName, Type: newOperationData.newOperationType.name, Account: newOperationData.newOperationAccount.Name, Group: newOperationData.newOperationGroup.name, Price: newOperationData.newOperationNominal, Date: newOperationData.newOperationDate, IsSelected: false });
                $scope.CloseAddOperationForm();
            }
            else {
                // Не добавлен   
              //  alert('не добавлен!');
                alert('не достаточно денег на счету!');
            }
        }).error(function (response) {
            // Ошибка
            alert('ошибка!');
        });
    }

    $scope.DeleteSelectedOperations = function () {
        if (confirm("Вы уверены, что хотите удалить выбранные элементы?")) {
            var arr = [];
            $scope.operations.forEach(function (element, index, array) {
                if (element.IsSelected) {
                    arr.push(element.Id);
                    array.splice(index, 1);
                    index--;
                }
            });
        
            $http.post('/PersonalPage/DeleteOperation', {
                operationId: arr
            }).success(function (response) {
                if (response) {   
                    alert('Записи удалены!');
                }
                else {
                    // Нет  
                    alert('Не удалось удалить запись!');
                }
            }).error(function (response) {
                // Ошибка
                alert('Ошибка сервера!');
            });
        }
    }
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
}])

.directive("fread", [function () {
    return {
        scope: {
            fread: "="
        },
        link: function (scope, element, attributes) {
            element.bind("change", function (changeEvent) {
                var reader = new FileReader();
                reader.onload = function (loadEvent) {
                    scope.$apply(function () {
                        scope.fread = loadEvent.target.result;

                        // Изменение превью картинки
                        scope.$parent.previewImgSrc = loadEvent.target.result;
                    });
                };
                reader.readAsDataURL(changeEvent.target.files[0]).result;
            });
        }
    }
}]);
