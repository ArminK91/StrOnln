(function () {
    var app = angular.module("OnlineStorage");

    app.controller("viewProduct", ["$scope", "$routeParams", "$location", "productService", 
        function ($scope, $routeParams, $location, productService) {

            $scope.product = {};

            //var authDataNew = localStorageService.get('authorizationData');

            //if (authDataNew.roles != "[\"Customer\"]") {
            //    $location.path("/login");
            //}

            productService.getProduct($routeParams.id)
            .then(function (response) {
                $scope.product = response.data;
            });
        }]);


    app.controller("productsController", ["$scope", "$window", "$location", "productsService",
        function ($scope, $window, $location, productsService) {

            $scope.products = [];

            //var authDataNew = localStorageService.get('authorizationData');

            //if (authDataNew.roles != "[\"Customer\"]") {
            //    $location.path("/login");
            //}

            productsService.getProducts().then(function (response) {
                $scope.products = response.data;
            });

      

            $scope.delete = function (id, index) {
                var confirmationForDelete = $window.confirm("Are you sure you want delete product?");

                if (confirmationForDelete) {
                    productsService.deleteProduct(id)
                    .then(function (response) {
                        alert("Product deleted");
                        $scope.products.splice(index, 1);
                        $location.path("/");
                    },
                    function () {
                        alert("Question is not deleted");
                    })
                    .then(function () {
                    });
                }
            }
        }]);
  
    app.controller("saveProduct", ["$scope", "$routeParams", "$location", "$window", "productsService", "localStorageService",
        function ($scope, $routeParams, $location, $window, productsService, localStorageService) {

            $scope.productModel = {};

            //var authDataNew = localStorageService.get('authorizationData');

            //if (authDataNew.roles != "[\"Administrator\"]")
            //{
            //    location.path("/login");
            //}


            productsService.createProductModel = {};

            productsService.getProductModel($routeParams.id)
            .then(function (response) {
                angular.copy(response.data, $scope.productModel);
            },
            function () {
                alert("Error");
                $location.path("/");
            })
            .then(function () {

            });

            $scope.submit = function () {

                if ($scope.name == null) {
                    $scope.alertMessage = "You have to enter name of product!";
                    return;
                }
                else if ($scope.price == 0) {
                    $scope.alertMessage = "You have to put price!";
                    return;
                }
                else if ($scope.activ == undefined) {
                    $scope.alertMessage("Must provide does this product is active!");
                    return;
                }
                else if ($scope.details == null) {
                    $scope.alertMessage("Please enter some short description!");
                    return;
                }

                $scope.productModel.product.name = $scope.name;
                $scope.productModel.product.price = $scope.price;
                $scope.productModel.product.activ = $scope.activ;
                $scope.productModel.product.details = $scope.details;
              
                //$scope.productModel.product.image = $scope.image;

                productsService.saveProduct($scope.productModel).then(function () {
                    alert("Product is added!!");
                },
                function () {
                    alert("Some error ocured!!");
                });

            };
            
        }]);
    
}());