var app = angular.module('AppBanHang', []);
app.controller("ChitietCtrl", function ($scope, $http) {
    $scope.sanpham = '';  
    $scope.LoadSanPhambyID = function () { 
		var key = 'id';
		var value = window.location.search.substring(window.location.search.indexOf(key)+key.length+1);		 
        $http({
            method: 'GET', 
            url: current_url1 + '/api/Product/get-by-id-product/'+value,
        }).then(function (response) { 
            $scope.sanpham = response.data;
			// makeScript('js/main.js')
        });
    };  
    $scope.LoadSanPhambyID()
});
