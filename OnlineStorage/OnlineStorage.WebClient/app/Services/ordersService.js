(function () {
    'use strict'

    var app = angular.module("OnlineStorage");


    app.factory('ordersService', ["$http", "ngAuthSettings", function ($http, ngAuthSettings) {

        var serviceBase = ngAuthSettings.apiServiceBaseUri;

        var ordersServiceFactory = {};



        var _getOrders = function () {
            return http.get(serviceBase + "api/orders/Get").then(function (results) {
                return results;
            });
        };



        var _createOrder = function (order) {
            return $http.post(serviceBase + "api/Orders/Create", order).then(function (results) {
                return results;
            });
        };

        ordersServiceFactory.createOrder = _createOrder;
        ordersServiceFactory.getOrders = _getOrders;



        return ordersServiceFactory;

    }]);
}());