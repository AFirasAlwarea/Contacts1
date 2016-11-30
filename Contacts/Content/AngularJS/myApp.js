angular.module('myApp', []);
app.controller('myCtrl', function ($scope, $http) {
    $scope.FirstName = "Khaled";
    $scope.LastName = "Alwarea";

    $http.get("Home/AjaxThatReturnsJson")
        .then(function (response) {
            $scope.myJson = response.data;
        });

    $http.get("Home/AjaxThatReturnsJsonList")
        .then(function (response) {
            $scope.myJsonList = response.data;
        });
});
