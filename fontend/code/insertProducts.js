var app = angular.module('AppBanHang', []);

app.controller("insertProductCtrl", ($scope,$http)=> {
    $scope.idProducts = "";
    $scope.nameProduct = "";
    $scope.idCategory = "";
    $scope.soLuong = "";
    $scope.imgProduct = '';
    $scope.priceProduct = "";
    $scope.sale = "";
    $scope.page = 1;
    $scope.pageSize = 10;
    $scope.nameSearch = "";
    $scope.listSearch = [];
    $scope.listCategory = [];
   
    $scope.searchProduct = (()=> {
        
        $http({
            method:'POST',
            data: { page: $scope.page, pageSize:$scope.pageSize,nameproduct : $scope.nameSearch},
            url:current_url1 + '/api/Product/search',
            
            
        })
        .then((res)=>{
            $scope.listSearch = res.data.data;
        })
    })
    $scope.pageChange = ((valueinput)=>{
        // Thực hiện các hành động khác dựa trên giá trị valueinput
        $scope.page = valueinput;
        console.log($scope.page);
        $scope.searchProduct()
    })
    $scope.performSearch = () => {
        console.log($scope.nameSearch);
        $scope.searchProduct();
    };
    $scope.searchProduct();
    $scope.categoryChanged = function() {
        const category = document.querySelector("#loaisp");
        let categoryItem = category.value;
        $scope.idCategory = categoryItem;
        
        console.log("Giá trị idCategory đã thay đổi: " + $scope.idCategory);
    
   
    };

$scope.previewImage = function(input) {
    var file = input.files[0];
        
       
        if (file) {
            // Lưu tên file
            var fileName = file.name;
        
            var reader = new FileReader();
            reader.onload = function(e) {
                $scope.$apply(function() {
                    // Tạo URL cho file và lưu theo đường dẫn img/tên_file
                    $scope.imgProduct = "/img/" + fileName; // Đường dẫn đến file trong thư mục 'img'
                });
            };
            reader.readAsDataURL(file);
        }
  
};

  
    
    
    $scope.insertProduct = () => {
        var data = {
            
            Nameproduct :$scope.nameProduct,
            IDcategory :$scope.idCategory,
            SoLuong :$scope.soLuong,
            Imgproduct : $scope.imgProduct,
            PriceProduct : $scope.priceProduct,
            sale : $scope.sale
        }
        $http({
            method : 'POST',
            url : current_url + '/api/Product/create-product',
            data: JSON.stringify(data)
        })
        .then((res)=> {
            console.log(res);
        })
        
    };
    $scope.renderCategory = function () {
        $http({
            method : 'GET',
            url : current_url1 + "/api/Category/get-all",

        }).then(function (response) {
            $scope.listCategory = response.data;
        })
    }
    $scope.renderCategory();
    $scope.updateProduct = function() {
        var data = {
            iDproduct :$scope.idProducts,
            Nameproduct :$scope.nameProduct,
            IDcategory :$scope.idCategory,
            SoLuong :$scope.soLuong,
            Imgproduct : $scope.imgProduct,
            PriceProduct : $scope.priceProduct,
            sale : $scope.sale
        }
        $http({
            method  : 'POST',
            url : current_url + "/api/Product/update-product",
            data : JSON.stringify(data),
        })
        .then ((res)=> {
            if(res != null) {
                alert("Cập nhật thông tin thành công!");
            }
            else {
                alert("vui long kiem tra lai thong tin")
            }
            
        })
        $scope.renderCategory();
    }

})

function NhapMoi() {
    document.getElementById('loaisp').value = 'choose';
    document.getElementById('nhacungcap').value = 'choose';
    document.getElementById('masanpham').value = '';
    document.getElementById('tensanpham').value = '';
    document.getElementById('imgproduct').value = '';
    document.getElementById('slsp').value = '';
    document.getElementById('giaban').value = '';
}
function LoadData() {
    // const select = document.querySelector("#loaisp")
    // var categoryApi = ' https://localhost:7162/api/Category/get-all'
    // // var productApi = 'https://localhost:7162/api/Product/getAll-product'

    // function GetCategory(callback) {
    //     fetch(categoryApi)
    //         .then(function (response) {
    //             return response.json();
    //         })
    //         .then(callback);
    // }

    
    // function rendercodeCategory(category) {
    //     const htmls = category.map((item) => {
    //         return `
    //             <option class = "category-item" value="${item.iDcategory}">${item.namecategory}</option>
    //         `
    //     })

    // select.innerHTML = htmls.join(" ")
    // }
    // GetCategory(rendercodeCategory)
    

}
LoadData();
setTimeout(() => {
    const listData = document.querySelectorAll(".gwap-item")
      listData.forEach((i) => {
            i.onclick = () => {
                    
                const tr = i.closest(".gwap-item")
                document.getElementById('masanpham').value = tr.querySelector("tr td:nth-child(2)").textContent;
                document.querySelector('.category-item').value = tr.querySelector("tr td:nth-child(7)").textContent;
                document.getElementById('tensanpham').value = tr.querySelector("tr td:nth-child(3)").textContent;
                document.getElementById('imgproduct').value = tr.querySelector("tr td:nth-child(4) img").textContent;
                document.getElementById('slsp').value = tr.querySelector("tr td:nth-child(5)").textContent;
                document.getElementById('giaban').value = tr.querySelector("tr td:nth-child(6)").textContent;
    
                
            }
        })

},1000)


function CheckAll(parent) {
    var ids = document.getElementsByTagName('input');
    for (var i = 0; i < ids.length; i++) {
        if (ids[i].name == "check_all") {
            ids[i].checked = parent.checked;
        }
    }
}






function CapNhat() {
    var masanpham = document.getElementById("masanpham").value;
    var tensanpham = document.getElementById("tensanpham").value;
    var anhsp = document.getElementById("imgproduct").value;
    var slsp = document.getElementById("slsp").value;
    var giaban = document.getElementById("giaban").value;
    var loaisp = document.getElementById("loaisp").value;
    var nhacungcap = document.getElementById("nhacungcap").value;
    var number = /^[0-9]+$/;
    var ok = true;

    if (loaisp == "choose") {
        alert("Vui lòng chọn loại sản phẩm!");
        return false;
    }
    else if (nhacungcap == "choose") {
        alert("Vui lòng chọn nhà cung cấp!");
        return false;
    }
    else if (tensanpham == null || tensanpham == "") {
        alert("Tên sản phẩm không được để trống! Vui lòng nhập lại!");
        return false;
    }
    else if (slsp == null || slsp == "") {
        alert("Số lượng sản phẩm không được để trống! Vui lòng nhập lại!");
        return false;
    } else if (slsp < 0) {
        alert("Số lượng sản phẩm phải lớn hơn hoặc bằng 0! Vui lòng nhập lại!");
        return false;
    }
    else if (giaban == null || giaban == "") {
        alert("Giá bán sản phẩm không được để trống! Vui lòng nhập lại!");
        return false;
    } else if (giaban <= 0) {
        alert("Giá bán sản phẩm phải lớn hơn 0! Vui lòng nhập lại!");
        return false;
    }


    if (ok == false) {
        localStorage.setItem("Product", JSON.stringify(list));
        location.reload();
    }
    else {
        alert("Cập nhật thông tin thất bại!");
    }
}