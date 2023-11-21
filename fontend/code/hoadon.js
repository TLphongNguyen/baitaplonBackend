var app = angular.module('AppBanHang', []);
app.controller("hoadonCtrl", function($scope,$http){
    $scope.sdtkh = '';
    $scope.tenKH = '';
    $scope.diachi = '';
    $scope.diaChiGiaoHang = '';
    var idLogin = localStorage.getItem('idLogin');
    $scope.loadUser = (()=> {
        
        $http({
            method : 'GET',
            url: current_url1 + '/api/Customer/get-by-id/' +idLogin,

        })
        .then((response) => {
            $scope.user = response.data;
            $scope.sdtkh = $scope.user.soDienThoai;
            $scope.tenKH = $scope.user.hoTen;
            $scope.diachi = $scope.user.diaChi;
            $scope.diaChiGiaoHang = $scope.user.diaChi
        })
    })
    var selectedProduct = JSON.parse(window.localStorage.getItem('selectedProduct')) || {};
    var currentDate = new Date();

// Lấy ngày, tháng và năm
    var day = currentDate.getDate();
    var month = currentDate.getMonth() + 1; // Tháng trong JavaScript bắt đầu từ 0
    var year = currentDate.getFullYear();

    // Định dạng ngày tháng năm
    var formattedDate = year + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;

    //tinh tien hang hoa
    $scope.priceAll = (()=> {
        var pricePay = 0;
        const priceProduct =  selectedProduct.priceproduct
        const priceShip = document.querySelector(".price-2").textContent
        var quantity = document.querySelector(".quantity-products").textContent
        console.log(typeof  parseInt(priceShip));
        pricePay = ( (priceProduct * parseInt(quantity)) + parseInt(priceShip))
        $scope.soluong = parseInt(quantity)
        $scope.dongia = pricePay    
        return pricePay
    })
    // Gán thông tin sản phẩm cho $scope để hiển thị trong HTML
    $scope.selectedProduct = selectedProduct;
    $scope.iDhoadon = 1;
    $scope.iDchitiethd = '';
    $scope.iDproduct =  selectedProduct.iDproduct;
    $scope.soluong= '';
    $scope.dongia = '';
    $scope.user = ''
    $scope.datehoadon = formattedDate;
    
    $scope.loadUser();
    
    $scope.createHoaDon = (() => {
        data = {
            datehoadon: $scope.datehoadon,
            tenKH: $scope.tenKH,
            diachi: $scope.diachi,
            sdtkh: $scope.sdtkh,
            diaChiGiaoHang: $scope.diaChiGiaoHang,
            list_json_chitiethoadon: [
              {
                iDproduct: $scope.iDproduct,
                soluong: $scope.soluong,
                dongia: $scope.dongia,
                status: 1
              }
            ]
        }
        $http({
            method : 'POST',
            url : current_url + '/api/HoaDon/create-hoadon',
            data : JSON.stringify(data)
        })
        .then((response)=> {
            console.log(response.data);
        })
    })
    
        

    
}) 