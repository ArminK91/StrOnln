(function () {
    'use strict'
    var app = angular.module("OnlineStorage");

    app.factory('productsService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

        var serviceBase = ngAuthSettings.apiServiceBaseUri;

        var productsServiceFactory = {};

        var _getProducts = function () {
            return $http.get(serviceBase + 'api/products/getProducts').then(function (results) {
                return results;
            });
        };

       

        var _getProduct = function (id) {
            return $http.get(serviceBase + 'api/products/getProduct?id=' + id).then(function (results) {
                return results;
            });
        };

        var _deleteProduct = function (id) {
            return $http.get(serviceBase + 'api/products/delete?id=' + id).then(function (results) {
                return results;
            });
        };


        var _saveProduct = function (product) {

            if (product.id === undefined || product.id == null || product.id === 0) {
                return $http.post(serviceBase + 'api/products/create', product).then(function (results) {
                    return results;
                });
            }
        };

        var _getProductModel = function (id) {

            if (id === undefined || id === 0) {
                return $http.get(serviceBase + 'api/products/getProductModel').then(function (results) {
                    return results;
                });
            }
            else {
                return $http.get(serviceBase + 'api/products/getProductModel?id=' + id).then(function (results) {
                    return results;
                });
            }
        };
            
    
    

        productsServiceFactory.getProductModel = _getProductModel;
        productsServiceFactory.saveProduct = _saveProduct;
        productsServiceFactory.deleteProduct = _deleteProduct;
        productsServiceFactory.getProduct = _getProduct;
        productsServiceFactory.getProducts = _getProducts;



        return productsServiceFactory;
    }]);
}());