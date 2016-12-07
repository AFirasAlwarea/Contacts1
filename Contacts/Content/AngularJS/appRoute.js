(function () {
    'use strict';

    var appRoute = angular.module('appRoute', [
        // Angular modules
        //'ngAnimate',
        'ngRoute' // <-- This is needed to use AngularJS Routing!
        // Custom modules

        // 3rd Party Modules

    ]);

    appRoute.controller('PeopleController', function ($scope, $http) {

        $http.get("/Home/AjaxThatReturnsJsonList")
            .then(function (response) {
                $scope.myJsonList = response.data;
            });

    });

    appRoute.controller('DetailsController', function ($scope, $http, $routeParams) { // <-- This is needed to handle extract/read parameters out of url
        $scope.params = $routeParams;

        $http.get("/Home/AjaxThatReturnsJsonPerson/" + $scope.params.Id)
            .then(function (response) {
                $scope.myJson = response.data;
            });

    });

    appRoute.config(['$routeProvider', // <-- This is needed to use AngularJS Routing!
      function ($routeProvider) {
          $routeProvider.
            when('/People', {
                templateUrl: '/Content/AngularJS/People.html',
                controller: 'PeopleController'
            }).
            when('/Person/:Id', {
                templateUrl: '/Content/AngularJS/Details.html',
                controller: 'DetailsController'
            }).
            otherwise({
                redirectTo: '/People'
            });
      }]);

})();

// Files that are modefied in this project to make this work:
// App_Start/BundleConfig.cs
// Views/Shared/_Layout.cshtml