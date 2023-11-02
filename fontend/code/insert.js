var app = angular.module('AppBanHang', []);
app.controller("insertCategoryCtrl", ($scope, $http)=> {
    $scope.nameCategory ="";
    $scope.idCategory ="";
    $scope.inrertCategory =() => {
        var data = {
            namecategory : $scope.nameCategory,
            iDcategory  : $scope.idCategory

        };
        $http({
            method : 'POST',
            url : current_url + '/api/Category/create-category',
            data: JSON.stringify(data)
        })
        .then((response)=> {
            console.log(response)
        })
        
    }
    $scope.updateCategory = ()=> {
        var data = {
            namecategory : $scope.nameCategory,
            iDcategory  : $scope.idCategory

        };
        $http({
            method: 'POST',
            url: current_url + '/api/Category/update-category',
            data : JSON.stringify(data)
        })
        .then((res) => {
            console.log(res);
        })
    }
})
