var app = angular.module('app',[]);
app.controller('HDNController',($scope, $http) => {
    $scope.listCategory = [];
    $scope.iDnhap;
    $scope.iDlogin;
    $scope.ngaynhap;
    $scope.maNhaCC;
    $scope.iDctdn;
    $scope.iDproduct;
    $scope.soluong;
    $scope.gianhap;
    $scope.Idcategory = 1;
    $scope.productlist = [];
    $scope.listNhacc = [];
    var idLogin = localStorage.getItem('idLogin');
    $scope.iDlogin = idLogin;
    $scope.renderCategory = function () {
        $http({
            method : 'GET',
            url : current_url1 + "/api/Category/get-all",

        }).then(function (response) {
            $scope.listCategory = response.data;
        })
    }
    $scope.renderCategory();
    $scope.categoryChanged = function() {
        const category = document.querySelector("#MaLoaiHangnhap");
        let categoryItem = category.value;
        $scope.Idcategory = categoryItem;
        
        console.log("Giá trị nhacc đã thay đổi: " + $scope.Idcategory);
        $scope.loadProduct();
    
   
    };
    $scope.nhaCCChanged = function() {
        const nhaCC = document.querySelector("#nhacungcap");
        let nhaCCvalue = nhaCC.value;
        $scope.maNhaCC = nhaCCvalue;
        
        console.log("Giá trị idCategory đã thay đổi: " + $scope.maNhaCC);
        $scope.loadProduct();
    
   
    };
    var currentDate = new Date();

// Lấy ngày, tháng và năm
    var day = currentDate.getDate();
    var month = currentDate.getMonth() + 1; // Tháng trong JavaScript bắt đầu từ 0
    var year = currentDate.getFullYear();

    // Định dạng ngày tháng năm
    var formattedDate = year + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;

    $scope.loadProduct = (()=> {
        $http({
            methob : "GET",
            url : current_url1 + "/api/Product/get-by-Category/" + $scope.Idcategory
        })
        .then((response) =>{
            $scope.productlist = response.data;
        })
    })
    
    $scope.loadProduct();
    $scope.editProduct = function(product) {
        
        console.log('Thông tin sản phẩm cần sửa:', product);
        var valueproduct = document.querySelector("#ghichu")
        valueproduct.value = product.nameproduct
        $scope.iDproduct = product.iDproduct
        console.log($scope.iDproduct);
    };
    $scope.getNhacc = function() {
        $http({
            method : 'GET',
            url : current_url1 +'/api/NhaCungCap/getAll_nhaCC'
        })
        .then((res) => {
            $scope.listNhacc = res.data
        })
     }
     $scope.getNhacc();
     $scope.ngaynhap = formattedDate

     $scope.createHoaDonNhap = (()=> {
        var data = {
            iDlogin : $scope.iDlogin,
            ngaynhap: $scope.ngaynhap,
            maNhaCC: $scope.maNhaCC,
            list_json_chitiethoadonNhap: [
              {
                iDproduct: $scope.iDproduct,
                soluong: $scope.soluong,
                gianhap: $scope.gianhap
              }
            ]
        }
        $http({
            method : 'POST',
            url : current_url + '/api/HoaDonNhap/create-hoadon_nhap',
            data : JSON.stringify(data)
        })
        .then((response)=>{
            console.log(response);
        })
     })
})