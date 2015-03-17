//var moduleApp = angular.module('SignIn', []);
//moduleApp.controller("SignInController", function ($scope, $http) {
//    // Видимость блока информации
//    $scope.InfoView = false;

//    // Видимость окна регистрации
//    $scope.WindowRegView = false;

//    // Попытка авторизации
//    $scope.TrySignIn = function (signIn, signInForm) {
//        if (signInForm.$valid) {
//            $http.post('/Authorization/SignIn', {
//                login: signIn.userLogin,
//                password: signIn.userPassword,
//            }).success(function (response) {
//                if (response.IsAuthenticated) {
//                    SuccessSignIn("Авторизация успешно пройдена!");
//                }
//                else {
//                    ErrorLoginOrPassword("Ошибка! Неверный логин и/или пароль!");
//                }
//            }).error(function (response) {
//                alert("Error: " + response);
//            });
//        }
//        else {
//            ErrorLoginOrPassword("Заполните все поля!");
//        }
//    } 

//    // Вывод ошибки при авторизации
//    function ErrorLoginOrPassword(text) {
//        $scope.InfoStyle = { "background-color": "#FCD4E2", "border-left": "#D52C2C solid 6px" };
//        $scope.infoText = text;
//        $scope.InfoView = true;
//    }
    
//    // Вывод сообщения об усешной авторизации
//    function SuccessSignIn(text) {
//        $scope.InfoStyle = { "background-color": "#D4FCE2", "border-left": "#63B67A solid 6px" };
//        $scope.infoText = text;
//        $scope.InfoView = true;       
//       // setTimeout(function () { $scope.InfoView = false }, 5000);  
//    }

//    // Открытие окна регистрации
//    $scope.OpenRegisterForm = function () {
//        $scope.WindowRegView = true;
//    }

//    // Скрытие окна регистрации
//    $scope.CloseRegisterForm = function () {
//        $scope.WindowRegView = false;
//    }

//    // Попытка регистрации
//    $scope.TryRegister = function (registerData, RegisterForm) {
//        if (RegisterForm.$valid) {
//            if (registerData.newUserPassword == registerData.newUserPasswordReplay) {
//                $http.post('/Authorization/Register', {
//                    name: registerData.newUserName,
//                    surname: registerData.newUserSurname,
//                    email: registerData.newUserEmail,
//                    country: registerData.newUserCountry,
//                    town: registerData.newUserTown,
//                    login: registerData.newUserLogin,
//                    password: registerData.newUserPassword,
//                    currency: registerData.newUserCurrency
//                }).success(function (response) {
//                    if (response) {
//                        alert("Пользователь добавлен");
//                    }
//                    else {
//                        alert("Пользователь не добавлен");
//                    }
//                }).error(function (response) {
//                    alert("Error: " + response);
//                });
//            }
//            else {
//                alert("Пароли не совпадают!");
//            }
//        }
//    }
//});