var app = angular.module('app', []);
app.controller('AppController',($scope,$http) =>{
    $scope.user;
    $scope.loadUser = (()=> {
        
        var idLogin = localStorage.getItem('idLogin');
        $http({
            method : 'GET',
            url: current_url1 + '/api/Customer/get-by-id/' +idLogin,

        })
        .then((response) => {
            $scope.user = response.data;
        })
    })
    
    $scope.loadUser();
})