var app = angular.module('AppBanHang', []);
app.controller("HomeCtrl", function ($scope, $http) {
    $scope.listProduct= [];
    $scope.listCategory = [];
    $scope.user = '';
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
    $scope.loadUser = (()=> {
        var key = 'id';
        var value = window.location.search.substring(window.location.search.indexOf(key)+key.length+1)
        $http({
            method : 'GET',
            url: current_url1 + '/api/Customer/get-by-id/' +value,

        })
        .then((response) => {
            $scope.user = response.data;
        })
    })
    $scope.loadUser();
});