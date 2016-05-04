(function() {

  var app = angular.module('myApp', []);

  var appController = function($scope, $http) {

    $http.get("/Search/SearchJsonResult").then(function(response) {
      $scope.myData = response.data;

    });

    $scope.message = "Locations";
  };

  app.controller("appController", ["$scope", "$http", appController]);

}

());