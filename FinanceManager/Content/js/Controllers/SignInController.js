var moduleApp = angular.module('CommonModule');

// Контроллер авторизации
moduleApp.controller("SignInController", function ($scope, $http, $location) {
    // Видимость блока информации
    $scope.InfoView = false;

    // Видимость окна регистрации
    $scope.WindowRegView = false;

    // Видимость окна авторизации
    $scope.WindowSignInView = false;

    // Попытка авторизации
    $scope.TrySignIn = function (signIn, signInForm) {
        $scope.InfoView = false;
        ValidateInputPaint(".signInBlock");
        if (signInForm.$valid) {
            $http.post('/Authorization/SignIn', {
                login: signIn.userLogin,
                password: signIn.userPassword,
            }).success(function (response) {
                if (response.IsAuthenticated) {
                    SuccessSignIn("Авторизация успешно пройдена!");

                    // Redirect to personal page
                    document.location.href = '/Home/PersonalPage'                  
                }
                else {
                    ErrorInfo("Ошибка! Неверный логин и/или пароль!");
                }
            }).error(function (response) {
                //alert("Error: " + response);
                ErrorInfo("Ошибка сервера!");
            });
        }
        else {
            ErrorInfo("Заполните все поля!");
        }
    }

    // Окраска валидных и невалидных полей соответствующим цветом
    function ValidateInputPaint(formClass) {
        $(formClass + " input:invalid").css("background-color", "#FCD4E2");
        $(formClass + " input:valid").css("background-color", "#fff");
        // $(formClass + " input:valid").css("background-color", "#D4FCE2");
    }

    // Вывод ошибки при авторизации
    function ErrorInfo(text) {
        $scope.InfoStyle = { "background-color": "#FCD4E2", "border-left": "#D52C2C solid 6px" };
        $scope.infoText = text;
        $scope.InfoView = true;
    }

    // Вывод сообщения об усешной авторизации
    function SuccessSignIn(text) {
        $scope.InfoStyle = { "background-color": "#D4FCE2", "border-left": "#63B67A solid 6px" };
        $scope.infoText = text;
        $scope.InfoView = true;
        // setTimeout(function () { $scope.InfoView = false }, 5000);  
    }

    // Открытие формы авторизации
    $scope.OpenSignInForm = function () {
        $scope.InfoView = false;
        $scope.WindowSignInView = true;
    }

    // Обработка щелчка по свободному месту (закрытие окна авторизации)
    $scope.ClickNotSignInForm = function (event) {
        if ($(event.target).closest(".signInBlock").length || $(event.target).closest(".hiddenSignIn").length) {
            return;
        }
        $scope.CloseSignInForm();
        event.stopPropagation();
    }

    // Закрытие окна авторизации
    $scope.CloseSignInForm = function () {
        $scope.WindowSignInView = false;
    }

    // Открытие окна регистрации
    $scope.OpenRegisterForm = function () {
        $scope.WindowRegView = true;
        //$scope.WindowSignInView = false;
    }

    // Скрытие окна регистрации
    $scope.CloseRegisterForm = function () {
        $scope.WindowRegView = false;
    }

    // Попытка регистрации
    $scope.TryRegister = function (registerData, RegisterForm) {
        ValidateInputPaint(".registerForm");
        if (RegisterForm.$valid) {
            if (registerData.newUserPassword == registerData.newUserPasswordReplay) {
                $http.post('/Authorization/Register', {
                    name: registerData.newUserName,
                    surname: registerData.newUserSurname,
                    email: registerData.newUserEmail,
                    country: registerData.newUserCountry,
                    town: registerData.newUserTown,
                    login: registerData.newUserLogin,
                    password: registerData.newUserPassword,
                    currency: registerData.newUserCurrency
                }).success(function (response) {
                    if (response) {
                        alert("Пользователь добавлен");
                    }
                    else {
                        alert("Пользователь не добавлен");
                    }
                }).error(function (response) {
                    alert("Error: " + response);
                });
            }
            else {
                alert("Пароли не совпадают!");
            }
        }
    }
});