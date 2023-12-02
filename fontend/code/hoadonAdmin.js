var app = angular.module('AppBanHang', []);
app.controller("hoadonAdminCtrl", function($scope, $http) {
    $scope.chitiethoadon= [];
    $scope.listSearch = [];
    $scope.page =1;
    $scope.pageSize =5;
    $scope.nameSearch = '';
    $scope.infoproduct = [];
    $scope.pageChange = ((valueinput)=>{
        // Thực hiện các hành động khác dựa trên giá trị valueinput
        $scope.page = valueinput;
        console.log($scope.page);
        $scope.searchHoaDon()
    })
    $scope.searchHoaDon = function() {
        $http({
            method:'POST',
            data: { page: $scope.page, pageSize:$scope.pageSize,ten_khach : $scope.nameSearch},
            url:current_url1 + '/api/HoaDon/search',
            
            
        })
        .then((res)=>{
            $scope.listSearch = res.data.data;
            
        })
    }
    $scope.searchHoaDon()
    const chitiet =  document.querySelector(".chitietHoaDon")
    $scope.chitietHoaDon = (hoadon) => {
        chitiet.style.display = "flex";
        hoadon.list_json_chitiethoadon.forEach(function(chitiet) {
        $scope.chitiethoadon = chitiet;
        var idproduct = chitiet.iDproduct;
        

        
        $http({
            method: 'GET',
            url: current_url1 + '/api/Product/get-by-id-product/' + idproduct,
        })
        .then(function(product) {
            // Gán thông tin sản phẩm vào đối tượng hoadon
            $scope.infoproduct = product.data;
            console.log(hoadon.product);
        })
        
    });
    

    }
    $scope.close = () => {
        chitiet.style.display = "none";
    }
    
})