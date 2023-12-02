var app = angular.module('AppBanHang', []);
app.controller("hoadonCtrl", function($scope,$http){
    $scope.sdtkh = '';
    $scope.tenKH = '';
    $scope.diachi = '';
    $scope.diaChiGiaoHang = '';
    $scope.listHoaDon =[];
    $scope.productInfo = [];
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
        pricePay = ( (priceProduct * parseInt(quantity)) + parseInt(priceShip))
        $scope.soluong = parseInt(quantity)
        $scope.dongia = pricePay    
        console.log(pricePay);
        return pricePay
    })
    // Gán thông tin sản phẩm cho $scope để hiển thị trong HTML
    $scope.selectedProduct = selectedProduct;
    $scope.iDhoadon = '';
    $scope.iDchitiethd = '';
    $scope.iDproduct =  selectedProduct.iDproduct;
    $scope.soluong= '';
    $scope.dongia = '';
    $scope.user = ''
    $scope.datehoadon = formattedDate;
    
    $scope.loadUser();
    
    $scope.createHoaDon = (() => {
        var data = {
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
            if(response.data != undefined) {
                alert("Đặt hàng thành công")
            }
        })
    })
    
    $scope.getDataHoaDon =(()=> {
        $http({
            method : 'GET',
            url : current_url1 +'/api/HoaDon/get-by-id-customer/' + idLogin,
            
        })
        .then((res) => {
            $scope.listHoaDon = res.data
            if ($scope.listHoaDon && $scope.listHoaDon.length > 0) {
                // Lặp qua từng hóa đơn
                angular.forEach($scope.listHoaDon, (hoaDon) => {
                    // Kiểm tra xem có danh sách chi tiết hóa đơn không
                    if (hoaDon.list_json_chitiethoadon && hoaDon.list_json_chitiethoadon.length > 0) {
                        // Lấy ID sản phẩm từ chi tiết hóa đơn đầu tiên
                        let productId = hoaDon.list_json_chitiethoadon[0].iDproduct;
                        $scope.iDhoadon = hoaDon.iDhoadon
                        // Gọi API hoặc xử lý dữ liệu sản phẩm dựa trên productId
                        // Ví dụ:
                        $http({
                            method: 'GET',
                            url: current_url1 + '/api/Product/get-by-id-product/' + productId,
                        })
                        .then((productRes) => {
                            // Gán thông tin sản phẩm vào hóa đơn tương ứng
                            hoaDon.productInfo = productRes.data;
                        });
                    }
                });
            }
        })
    })
    
    $scope.getDataHoaDon();
    $scope.showConfirmation = false;
    $scope.deleteHoaDon = (() => {
        $http({
        method: 'DELETE',
        url: current_url + '/api/HoaDon/delete-hoadon/'+ $scope.iDhoadon,
    })
    .then((response) => {
        $scope.hoaDonInfo = response.data.hoaDonInfo;
        $scope.showConfirmation = true;
    })
    })
    $scope.confirmDelete = () => {
    // Hiển thị thông báo xác nhận
    var confirmDelete = confirm("Bạn có chắc chắn muốn hủy không? Nếu đồng ý, hóa đơn sẽ bị hủy.");

    if (confirmDelete) {
        // Gọi API DELETE để xóa hóa đơn khi người dùng đồng ý
        $http({
            method: 'DELETE',
            url: current_url + '/api/HoaDon/delete-hoadon/'+ $scope.iDhoadon,
        })
        
        .then((response) => {
            console.log(response.data);
            alert("hủy hóa đơn thành công");
            // Thực hiện các xử lý khác nếu cần
            $scope.showConfirmation = false;
            $scope.getDataHoaDon();
        })
        .catch((error) => {
            console.error("Error:", error);
            alert("hủy hóa đơn thất bại");
            // Xử lý lỗi nếu cần
            $scope.showConfirmation = false;
        });
    } else {
        // Hủy xác nhận nếu người dùng không đồng ý
        $scope.showConfirmation = false;
    }
};
$scope.cancelDelete = () => {
    // Hủy xác nhận và ẩn xác nhận
    $scope.showConfirmation = false;
};


        

    
}) 