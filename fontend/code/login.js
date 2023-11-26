var app = angular.module('AppBanHang', []);
app.controller('LoginCtrl', function ($scope, $http) {
    $scope.userName = '';
    $scope.password = '';
    $scope.dataUser;
    $scope.tk ='';
    $scope.mk = '';
    $scope.mkAgain = '';
    $scope.maloai = 2;
    $scope.token = 'random'
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
                            window.location.href = `/admin/TongQuan.html?id=${$scope.dataUser.idLogin}`;
                        } else {
                            console.log('Không có ID để chuyển hướng.');
                        }
                        break;
                    case 2:
                        if ($scope.dataUser.idLogin) {
                            // Đẩy thông tin vào local storage
                            window.location.href = `/index.html?id=${$scope.dataUser.idLogin}`;
                            localStorage.setItem('idLogin', $scope.dataUser.idLogin);
                        } else {
                            console.log("khong co id");
                        }
                        break;
                    default:
                        console.log($scope.dataUser.maloai);
                }
            })
        
    };
    $scope.createAccount = (()=> {
        if($scope.mk == $scope.mkAgain) {
            var data ={
                username :$scope.tk,
                password :$scope.mk,
                maloai :$scope.maloai,
                token : $scope.token
            }
            $http({
                method: 'POST',
                url: current_url + '/api/Users/create-user',
                data: JSON.stringify(data),
            }).then(function (response) {
                console.log(response);
            });
        }
    })
});

const btnLogin = document.querySelector(".auth-form__switch-btn.login")
const btnsub = document.querySelector(".auth-form__switch-btn.sub")
const formsub = document.querySelector(".auth-form.sub")
const formLogin = document.querySelector(".auth-form.login")
const messerror = document.querySelector(".messerro")
const btnDangKi = document.querySelector(".btn.sub")
let regiter = true;
btnLogin.onclick = () => {
    formsub.style.display = "block";
    formLogin.style.display = "none";
}
btnsub.onclick = () => {
    formLogin.style.display = "block";
    formsub.style.display = "none";
}


const password = document.querySelector(".password")
const passwordConfirm = document.querySelector(".password-again")

passwordConfirm.onblur = () => {
    if(password.value != passwordConfirm.value) {
        messerror.style.display = "block";
        regiter = false;
    }
    else {
        messerror.style.display = "none";
        regiter = true;
    }
}
btnDangKi.onclick = () => {
    if(regiter = true) {
        alert("đăng kí thành công")
    }
    else {
        alert("đăng kí thất bại, vui lòng kiểm tra lại thông tin")
    }
}