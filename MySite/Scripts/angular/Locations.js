var app = angular.module('myApp', []);
app.controller('locationsCtrl', function ($scope, $http) {
  $http.get("/Location/LocationJsonResult").then(function (response) {
    $scope.myData = response.data;
    $scope.message = "Infrgistics";
  });
});