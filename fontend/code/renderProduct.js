// var categoryApi = ' https://localhost:7162/api/Category/get-all'
// var productApi = 'https://localhost:44355/api/Product/getAll-product'

// const searchHeaders = document.querySelectorAll(".home-filter__btn");
// // let productMore = "https://localhost:44355/api/Product/get-by-ChucNang/1"
// // searchHeaders.forEach((searchHeader,index) => {
// //     searchHeader.onclick = () => {
// //         productMore = `https://localhost:44355/api/Product/get-by-ChucNang/${index + 1}`
        
// //         document.querySelector(".home-filter__btn.btn.btn--primary").classList.remove("btn--primary")
// //         searchHeader.classList.add("btn--primary")
        
// //         GetProduct(renderCodeProduct);
           
// //     }
    
        
    
    
// // })   

// function start() {
//     GetCategory(rendercodeCategory)    
// }

// start();



// // function GetProduct(callback) {
// //     fetch(productMore)
// //         .then(function (response) {
// //             return response.json();
// //         })
// //         .then(callback);
// // }
// function GetCategory(callback) {
//     fetch(categoryApi)
//         .then(function (response) {
//             return response.json();
//         })
//         .then(callback);
// }

// function rendercodeCategory(category) {
//     const listCategory = document.querySelector(".category-list")
//     const htmlsCategory = category.map((item)=> {
        
//         return `
//         <li class="category-item">
//              <a href="#" class="category-item__link">${item.namecategory}</a>
//         </li>
        
//         `
//     })
//     listCategory.innerHTML = htmlsCategory.join(" ")
// }
// let apiChiTiet

// // function renderCodeProduct(product) {
// //     const listproduct = document.querySelector(".list-product")
// //     const htmls = product.map((item)=> {
        
// //         return `
// //         <div  class="col l-2-4 m-4 c-6">
// //         <a href = "#" class="home-product-item">
// //             <div class="home-product-item__img" style="background-image: url(${item.imgproduct})" >
// //             </div>
// //             <h4 class="home-product-item__name">${item.nameproduct}</h4>
// //             <div class="home-product-item__price">
// //                 <span class="home-product-item__price-old">
// //                 ${item.priceproduct}đ
// //                 </span>
// //                 <span class="home-product-item__price-current">
// //                     ${item.priceproduct} đ
// //                 </span>
// //             </div>
// //             <div class="home-product-item__action">
// //                 <span class="home-product-item__like home-product-item__like-liked">
// //                     <i class="home-product-item__icon-empy fa-regular fa-heart"></i>
// //                     <i class="home-product-item__icon-fill fa-solid fa-heart"></i>
// //                 </span>

// //                 <div class="home-product-item__rating">
// //                     <i class="home-product-item__gold fa-solid fa-star"></i>
// //                     <i class="home-product-item__gold fa-solid fa-star"></i>
// //                     <i class="home-product-item__gold fa-solid fa-star"></i>
// //                     <i class="home-product-item__gold fa-solid fa-star"></i>
// //                     <i class="fa-solid fa-star"></i>
// //                 </div>
// //                 <span class="home-product-item__sold">${item.soLuong} đã bán</span>
// //             </div>
// //             <div class="home-product-item__orign">
// //                 <span class="home-product-item__brand">
// //                     ${item.namecategory}
// //                 </span>
// //                 <span class="home-product-item__origin-name">
// //                     Konoha
// //                 </span>
// //             </div>
// //             <div class="home-product-item__favourite">
// //                 <i class="fa-solid fa-check"></i>
// //                 <span>yêu thích</span> 
// //             </div>
// //             <div class="home-product-item__sale-off">
// //                 <span class="home-product-item__sale-off-precent">${item.sale}%</span>
// //                 <div class="home-product-item__sale-off-label">GIẢM</div>
// //             </div>
// //         </a>
        
// //     </div>
// //         `
// //     })
   
   
// //     listproduct.innerHTML = htmls.join(' ')
    
// // }









