var app = angular.module('AppBanHang', []);
app.directive("customOnChange", function () {
    return {
      restrict: "A",
      link: function (scope, element, attrs) {
        var onChangeHandler = scope.$eval(attrs.customOnChange);
        element.on("change", onChangeHandler);
        element.on("$destroy", function () {
          element.off();
        });
      },
    };
  });
app.controller("HomeCtrl", function ($scope, $http) {
    $scope.listProduct= [];
    $scope.listCategory = [];
    $scope.clothes = [];
    $scope.Footwear = [];
    $scope.Houseware = [];
    $scope.clothes = [];
    $scope.clothes = [];
    $scope.user = '';
    $scope.idCT = '';
    $scope.idlogin = $scope.user.iDLogin;
    $scope.hoten = '';
    $scope.diachi = '';
    $scope.sdt = '';
    $scope.avt = '';
    $scope.email = ''
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
    $scope.loadClothes = function() {
        $http({
            method : 'GET',
            url :current_url1 + '/api/Product/get-by-Category/1'

        })
        .then((res)=> {
            $scope.clothes = res.data;
        })
    }
    $scope.loadClothes();
    $scope.loadFootwear = function() {
        $http({
            method : 'GET',
            url :current_url1 + '/api/Product/get-by-Category/2'

        })
        .then((res)=> {
            $scope.Footwear = res.data;
        })
    }
    $scope.loadFootwear();
    $scope.loadHouseware = function() {
        $http({
            method : 'GET',
            url :current_url1 + '/api/Product/get-by-Category/3'

        })
        .then((res)=> {
            $scope.Houseware = res.data;
        })
    }
    $scope.loadHouseware();
    $scope.loadUser = (()=> {
        var key = 'id';
        var value = window.location.search.substring(window.location.search.indexOf(key)+key.length+1)
        $http({
            method : 'GET',
            url: current_url1 + '/api/Customer/get-by-id/' +value,

        })
        .then((response) => {
            $scope.user = response.data;
            $scope.idlogin = response.data.iDlogin
            $scope.idCT = response.data.maChitietLogin
        })
    })
    
    $scope.loadUser();

    $scope.previewImage = function(input) {
        var file = input.files[0];
        
       
        if (file) {
            // Lưu tên file
            var fileName = file.name;
        
            var reader = new FileReader();
            reader.onload = function(e) {
                $scope.$apply(function() {
                    // Tạo URL cho file và lưu theo đường dẫn img/tên_file
                    var imgPath = "/img/" + fileName; // Đường dẫn đến file trong thư mục 'img'
                    $scope.imgProduct = imgPath;

                    // Cập nhật đường dẫn ảnh trong user.avatar nếu bạn muốn
                    // Chắc chắn rằng $scope.user tồn tại và có thuộc tính avatar
                    if ($scope.user && $scope.user.avatar) {
                        $scope.user.avatar = imgPath;
                    }
                });
            };
            reader.readAsDataURL(file);
        }
    };
    $scope.loadFile = function (e) {
        const imageEl = document.querySelector(".avt");
        if (e.target.files && e.target.files[0]) {
            var fileName = e.target.files[0].name;
            var imgPath = "/img/" + fileName; // Đường dẫn đến file trong thư mục 'img'
            
            imageEl.src = window.URL.createObjectURL(e.target.files[0]);
            $scope.avt = e.target.files[0];
            $scope.avt = imgPath;
            // Sử dụng imgPath theo nhu cầu của bạn, có thể lưu vào $scope hoặc sử dụng nó theo cách khác
            console.log("Đường dẫn ảnh:", $scope.avt);
        }
      };
    $scope.updateUser = (()=> {
        var data = {
            maChitietLogin : $scope.idCT,
            iDLogin : $scope.idlogin,
            HoTen : $scope.hoten,
            DiaChi : $scope.diachi,
            SoDienThoai : $scope.sdt,
            Email : $scope.email,
            Avatar : $scope.avt
        };
        $http({
            method : 'POST',
            url : current_url1 + '/api/Customer/update-Customer',
            data :JSON.stringify(data)
        })
        .then((response)=> {
            console.log(response);
            if(response !== undefined) {
                alert("thay đổi thành công")
            }
            $scope.loadUser();

            
        })
    })
    
});