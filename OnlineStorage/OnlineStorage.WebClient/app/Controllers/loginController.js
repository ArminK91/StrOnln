(function () {

    var app = angular.module("OnlineStorage");
'use strict';
app.controller('loginController', ['$scope', '$location', 'authService', 'localStorageService', function ($scope, $location, authService, localStorageService) {

    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.message = "";

    var authData = localStorageService.get('authorizationData');

    if (authData)
    {
        $scope.userId = authData.userId;
        $scope.userName = authData.userName;
        $scope.roles = authData.roles;

        if ($scope.roles == "[\"Administrator\"]")
        {
            $location.path('/productList');
        }
        else if ($scope.roles ==  "[\"Customer\"]")
        {
            $location.path('/productList');
        }
    }

    $scope.message = "";

    $scope.login = function () {

        authService.login($scope.loginData).then(function (response) {

            $location.path('/orders');

        },
         function (err) {
             $scope.message = err.error_description;
         });
    };
    }]);
}());