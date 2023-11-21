var app = angular.module('AppBanHang', []);
app.controller("ChitietCtrl", function ($scope, $http) {
    $scope.sanpham = '';  
    $scope.user = '';
    
    var idLogin = localStorage.getItem('idLogin');
    console.log(idLogin);
    var accountName = 'user_' + idLogin;	 
    $scope.LoadSanPhambyID = function () { 
        var key = 'id';
        var value = window.location.search.substring(window.location.search.indexOf(key)+key.length+1);	
        $http({
            method: 'GET', 
            url: current_url1 + '/api/Product/get-by-id-product/'+value,
        }).then(function (response) { 
            $scope.sanpham = response.data;
			// makeScript('js/main.js')
        });
    };
    function getCartData() {
        var gioHangCuaTaiKhoan = localStorage.getItem('giohang_' + accountName);
    
        if (!gioHangCuaTaiKhoan) {
            return [];
        }
    
        // Parse dữ liệu từ Local Storage
        var gioHang = JSON.parse(gioHangCuaTaiKhoan);
    
        // Sắp xếp mảng theo cơ chế FILO (First In, Last Out)
        gioHang.reverse();
    
        return gioHang;
    }
    
    // Hàm để load toàn bộ giỏ hàng từ Local Storage
    $scope.LoadGioHang = function () {
        $scope.giohang = getCartData();
    };
    // Hàm để thêm sản phẩm vào giỏ hàng và cập nhật giỏ hàng
    $scope.ThemVaoGioHang = function () {
        var gioHangCuaTaiKhoan = getCartData();

        var index = gioHangCuaTaiKhoan.findIndex(item => item.iDproduct === $scope.sanpham.iDproduct);

        if (index === -1) {
            gioHangCuaTaiKhoan.push({
                iDproduct: $scope.sanpham.iDproduct,
                nameproduct: $scope.sanpham.nameproduct,
                priceproduct: $scope.sanpham.priceproduct,
                imgproduct : $scope.sanpham.imgproduct,
                namecategory : $scope.sanpham.namecategory,
                soLuong: 1
            });
        } else {
            gioHangCuaTaiKhoan[index].soLuong++;
        }

        localStorage.setItem('giohang_' + accountName, JSON.stringify(gioHangCuaTaiKhoan));

        // Sau khi thêm vào giỏ hàng, cập nhật danh sách giỏ hàng và render lại trang
        $scope.LoadGioHang();
    }; 
    $scope.DemSoLuongSanPhamKhongTrunglapTrongGioHang = function () {
        var gioHangCuaTaiKhoan = getCartData();
        
        var idSanPhamDaThem = new Set();
        var soLuongSanPhamKhongTrungLap = 0;
    
        for (var i = 0; i < gioHangCuaTaiKhoan.length; i++) {
            var idSanPham = gioHangCuaTaiKhoan[i].iDproduct;
    
            // Kiểm tra xem sản phẩm đã được thêm vào giỏ hàng chưa
            if (!idSanPhamDaThem.has(idSanPham)) {
                soLuongSanPhamKhongTrungLap++;
                idSanPhamDaThem.add(idSanPham);
            }
        }
    
        return soLuongSanPhamKhongTrungLap;
    };
    $scope.XoaKhoiGioHang = function (productId) {
        var gioHangCuaTaiKhoan = getCartData();

        // Tìm vị trí của sản phẩm trong giỏ hàng
        var index = gioHangCuaTaiKhoan.findIndex(item => item.iDproduct === productId);

        // Nếu tìm thấy sản phẩm, xóa nó khỏi giỏ hàng
        if (index !== -1) {
            gioHangCuaTaiKhoan.splice(index, 1);
            localStorage.setItem('giohang_' + accountName, JSON.stringify(gioHangCuaTaiKhoan));

            // Sau khi xóa sản phẩm, cập nhật danh sách giỏ hàng và render lại trang
            $scope.LoadGioHang();
        }
    };

    // Gọi hàm để load giỏ hàng khi controller được khởi tạo
    $scope.LoadGioHang();

    // Load thông tin sản phẩm khi controller được khởi tạo
    $scope.LoadSanPhambyID();
    
    $scope.loadUser = (()=> {
        
        $http({
            method : 'GET',
            url: current_url1 + '/api/Customer/get-by-id/' +idLogin,

        })
        .then((response) => {
            $scope.user = response.data;
            
        })
    })
    
    $scope.loadUser();
    $scope.buyNow = function (product) {
        // Lấy thông tin sản phẩm được chọn
        var selectedProduct = {
            iDproduct: product.iDproduct,
            nameproduct: product.nameproduct,
            priceproduct: product.priceproduct,
            imgproduct : product.imgproduct,
            namecategory : product.namecategory,
            soLuong : product.soLuong
        };
        

        // Lưu thông tin sản phẩm vào Local Storage
        window.localStorage.setItem('selectedProduct', JSON.stringify(selectedProduct));
        
        // Hiển thị thông báo hoặc chuyển hướng đến trang thanh toán, tùy thuộc vào yêu cầu của bạn
        console.log ('Mua ngay sản phẩm:', product);
    };
    
});

