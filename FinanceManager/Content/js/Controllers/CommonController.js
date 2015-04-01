var moduleApp = angular.module('CommonModule',
     [
        'PersonalModule'
        ]);

moduleApp.directive('squareElem', function () {
    return function (scope, element, attrs) {
        $scope.load = function () {
            $(element).css("height", $(element).css("width"));
        }
    }
});

// Общий контроллер
moduleApp.controller("CommonController", function ($scope, $http) {

    $scope.mainMenuToogle = function (animatedElement, animatedEffect) {
        $(animatedElement).toggleClass(animatedEffect + " animated");
        $(animatedElement).fadeToggle(600);
    }

    $scope.squareElemLoad = function (element) {
        $(element).css("height", $(element).css("width"));
    }
});

//moduleApp.controller("PersonalPageController", function ($scope, $http) {
    //function SquareElem(elemSelector, knownMeasurement, unknownMeasurement) {
    //    var elem = angular.element(document.querySelector(elemSelector));
    //    elem.css(unknownMeasurement, elem.css(knownMeasurement));
    //}
//});
