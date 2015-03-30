var moduleApp = angular.module('CommonModule');

moduleApp.directive('squareElem', function () {
    //return{
    //    restrict: 'A',
    //    postlink: function (scope, element, attrs) {
    //        //element.css("height", element.css("width"));
    //        $(element).css("height", $(element).css("width"));
    //    }
    //}
    return function (scope, element, attrs) {
                //element.css("height", element.css("width"));
        //  $(element).css("height", $(element).css("width"));

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

moduleApp.controller("PersonalPageController", function ($scope, $http) {

    //function SquareElem(elemSelector, knownMeasurement, unknownMeasurement) {
    //    var elem = angular.element(document.querySelector(elemSelector));
    //    elem.css(unknownMeasurement, elem.css(knownMeasurement));
    //}
});

