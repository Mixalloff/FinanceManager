var moduleApp = angular.module('SignIn', []);
moduleApp.controller("SignInController", function ($scope, $http) {
    // Видимость блока информации
    $scope.InfoView = false;

    // Видимость окна регистрации
    $scope.WindowRegView = false;

    // Попытка авторизации
    $scope.TrySignIn = function () {
        $http.post('/Authorization/SignIn', {
            login: $scope.userLogin,
            password: $scope.userPassword,        
        }).success(function (response) {
            if (response.IsAuthenticated) {
                SuccessSignIn();
            }
            else {
                ErrorLoginOrPassword();
            }
        }).error(function (response) {
            alert("Error: " + response);
        });
    }

    // Вывод ошибки при авторизации
    function ErrorLoginOrPassword() {
        $(".info").css("background-color", "#FCD4E2");
        $(".info").css("border-left", "#D52C2C solid 6px");
        $scope.infoText = "Ошибка! Неверный логин и/или пароль!";
        $scope.InfoView = true;
    }
    
    // Вывод сообщения об усешной авторизации
    function SuccessSignIn() {
        $(".info").css("background-color", "#D4FCE2");
        $(".info").css("border-left", "#63B67A solid 6px");
        $scope.infoText = "Авторизация успешно пройдена!";
        $scope.InfoView = true;
       // setTimeout(function () { $scope.InfoView = false }, 5000);  
    }

    // Открытие окна регистрации
    $scope.OpenRegisterForm = function () {
        $scope.WindowRegView = true;
    }

    // Скрытие окна регистрации
    $scope.CloseRegisterForm = function () {
        $scope.WindowRegView = false;
    }

    // Попытка регистрации
    $scope.TryRegister = function () {
            $http.post('/Authorization/Register', {
                name: $scope.newUserName,
                surname: $scope.newUserSurname,
                email: $scope.newUserEmail,
                country: $scope.newUserCountry,
                town: $scope.newUserTown,
                login: $scope.newUserLogin,
                password: $scope.newUserPassword,
                currency: $scope.newUserCurrency
            }).success(function (response) {
                if(response)
                {
                    alert("Пользователь добавлен");
                }
                else {
                    alert("Пользователь не добавлен");
                }
            }).error(function (response) {
                alert("Error: " + response);
            });
        }
});