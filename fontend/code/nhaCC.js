var app = angular.module("appbanhang", []);
app.controller("nhaccController",(($scope, $http)=> {
     $scope.listNhacc = [];
     $scope.manhacc = '';
     $scope.tennhacc = '';
     $scope.diachinhacc = '';
     $scope.sdtnhacc = '';
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
     $scope.createNhacc = function() {
        data = {
            maNhaCC : $scope.manhacc,
            tenNhaCC : $scope.tennhacc,
            diachiNhaCC : $scope.diachinhacc,
            sdtNhaCC : $scope.sdtnhacc
        }
        $http({
            method : 'POST',
            url : current_url + '/api/NhaCungCap/create-NhaCC',
            data : JSON.stringify(data)
        })
        .then((res)=> {
            if(res!= undefined) {
                alert("thêm thành công")
                $scope.getNhacc();
            }
            else {
                alert("lỗi vui lòng kiểm tra lại")
            }
        })
     }
     $scope.updateNhacc = (()=> {
        data = {
            maNhaCC : $scope.manhacc,
            tenNhaCC : $scope.tennhacc,
            diachiNhaCC : $scope.diachinhacc,
            sdtNhaCC : $scope.sdtnhacc
        }
        $http({
            method : 'POST',
            url : current_url + '/api/NhaCungCap/update-NhaCC',
            data : JSON.stringify(data)
        })
        .then((res)=> {
            if(res!= undefined) {
                alert("sửa thành công")
                $scope.getNhacc();
            }
            else {
                alert("lỗi vui lòng kiểm tra lại")
            }
        })
     })
}))