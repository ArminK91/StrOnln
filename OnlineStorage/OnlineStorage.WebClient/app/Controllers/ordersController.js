(function () {
    var app = angular.module("OnlineStorage");

    app.controller("ordersController", ["$scope", "$window", "$location", "ordersService",
        function ($scope, $window, $location, ordersService) {
            $scope.orders = [];

            ordersService.getOrders().then(function (respond) {
                $scope.orders = respond.data;
            });
        }]);
    
    app.controller("makeOrder", ["$scope", "$window","$routeParams", "$location", "ordersService",
           function ($scope, $window, $routeParams, $location, ordersService) {

               $scope.order = {};

               ordersService.createOrder().then(function (respond) {
                   $scope.order = respond.data;

                   $scope.submit = function () {

                   }
               });
           }
    ])
}());