(function() {

  var app = angular.module('myApp', []);

  var appController = function($scope, $http) {

    $http.get("/Location/LocationJsonResult").then(function(response) {
      $scope.myData = response.data.records;

    });

    $scope.message = "Locations";
  };

  app.controller("appController", ["$scope", "$http", appController]);

}

());