(function () {

    var app = angular.module("OnlineStorage", ['ngRoute', 'LocalStorageModule']);

    var serviceBase = 'http://localhost:3000/';

    app.constant('ngAuthSettings', {
        apiServiceBaseUri: serviceBase
    });




    app.config(function ($routeProvider) {

        //$routeProvider.when("/home", {
        //    controller: "homeController",
        //    templateUrl: "/Views/home.html"
        //});

        $routeProvider.when("/", {
            controller: "productsController",
            templateUrl: "Views/Products/ProductList.html"
        });

        $routeProvider.when("/ordersList", {
            controller: "ordersController",
            templateUrl: "Views/Orders/OrdersList.html"
        });

      

        $routeProvider.when("/productDetails/:id", {
            controller: "viewProduct",
            templateUrl: "Views/Products/ProductDetails.html"
        });

        $routeProvider.when("/login", {
            controller: "loginController",
            templateUrl: "/Views/Login/Login.html"
        });

        $routeProvider.when("/addProduct/:id?", {
            controller: "saveProduct",
            templateUrl: "Views/Products/AddProduct.html"
        });

        $routeProvider.when("/productList", {
            controller: "productsController",
            templateUrl: "Views/Products/productList.html"
        });
        $routeProvider.when("/home", {
            controller: "homeController",
            templateUrl: "/Views/home.html"
        });


        $routeProvider.when("/signup", {
            controller: "signupController",
            templateUrl: "Views/Login/Signup.html"
        });

        //$routeProvider.when("/home", {
        //    controller: "homeController",
        //    templateUrl: "Views/Login/OrdersList.html"
        //});

        $routeProvider.otherwise({ redirectTo: "/" });

    });
    app.config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptorService');
    });
    app.run(['authService', function (authService) {
        authService.fillAuthData();
    }]);
}());