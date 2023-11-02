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
                $scope.dataUser = response.data;
                console.log($scope.dataUser);
                localStorage.setItem('MaChitietLogin', $scope.dataUser.maChitietLogin);
                localStorage.setItem('HoTen', $scope.dataUser.HoTen);
                localStorage.setItem('DiaChi', $scope.dataUser.DiaChi);
                localStorage.setItem(
                    'SoDienThoai',
                    $scope.dataUser.SoDienThoai
                );
                localStorage.setItem('Avatar', $scope.dataUser.Avatar);
                
                localStorage.setItem(
                    'token',
                    JSON.stringify($scope.dataUser.token)
                );
                switch ($scope.dataUser.Maloai) {
                    case '1':
                        window.location.href = '/index.html';
                        
                        break;
                    case '2':
                        window.location.href = '';
                        break;
                    default:
                        window.location.href = '';
                }
            })
            .catch(function (error) {
                // Xử lý khi có lỗi
                if (error.status === 400) {
                    console.log('Yêu cầu không hợp lệ (BadRequest).');
                    alert(error.data.message);
                } else {
                    console.log('Lỗi không xác định: ' + error.status);
                }
            });
    };
});
