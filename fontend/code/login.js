var app = angular.module('AppBanHang', []);
app.controller('LoginCtrl', function ($scope, $http) {
    $scope.userName = '';
    $scope.password = '';
    $scope.dataUser;
    $scope.login = function () {
        var data = {
            userName: $scope.userName,
            password: $scope.password,
        };
        $http({
            method: 'POST',
            url: 'https://localhost:44355/api/Users/login',
            data: JSON.stringify(data),
        })
            .then(function (response) {
                console.log(response);
                $scope.dataUser = response.data;

                switch ($scope.dataUser.maloai) {
                    case 1:
                        if ($scope.dataUser.idLogin) {
                            window.location.href = `/admin/SanPham.html?id=${$scope.dataUser.idLogin}`;
                        } else {
                            console.log('Không có ID để chuyển hướng.');
                        }
                        
                        break;
                    case 2:
                        if($scope.dataUser.idLogin){
                            window.location.href = `/index.html?id=${$scope.dataUser.idLogin}`;
                        }
                        else {
                            console.log("khong co id");
                        }
                        break;
                    default:
                        console.log($scope.dataUser.maloai);
                }
            })
        
    };
});
