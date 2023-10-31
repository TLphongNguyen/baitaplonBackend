var app = angular.module('AppBanHang', []);
app.controller("HomeCtrl", function ($scope, $http) {
    $scope.listProduct= [];
    $scope.listCategory = [];
    $scope.renderCategory = function () {
        $http({
            method : 'GET',
            url : current_url1 + "/api/Category/get-all",

        }).then(function (response) {
            $scope.listCategory = response.data;
        })
    }
    $scope.renderCategory();
    $scope.RenderProduct= function () {
        $http({
            method: 'GET',
            url: current_url1 + '/api/Product/getAll-product',
        }).then(function (response) {  
            
            $scope.listProduct = response.data;  
        });
    };   
	$scope.RenderProduct();
});