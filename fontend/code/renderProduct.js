var categoryApi = ' https://localhost:44355/api/Category/get-all'
var productApi = 'https://localhost:44355/api/Product/getAll-product'

const searchHeaders = document.querySelectorAll(".home-filter__btn");
let productMore = "https://localhost:44355/api/Product/get-by-ChucNang/1"
searchHeaders.forEach((searchHeader,index) => {
    searchHeader.onclick = () => {
        productMore = `https://localhost:44355/api/Product/get-by-ChucNang/${index + 1}`
        
        document.querySelector(".home-filter__btn.btn.btn--primary").classList.remove("btn--primary")
        searchHeader.classList.add("btn--primary")
        
        GetProduct(renderCodeProduct);
           
    }
    
        
    
    
})   

function start() {
    GetCategory(rendercodeCategory)    
}

start();



function GetProduct(callback) {
    fetch(productMore)
        .then(function (response) {
            return response.json();
        })
        .then(callback);
}
function GetCategory(callback) {
    fetch(categoryApi)
        .then(function (response) {
            return response.json();
        })
        .then(callback);
}

function rendercodeCategory(category) {
    const listCategory = document.querySelector(".category-list")
    const htmlsCategory = category.map((item)=> {
        
        return `
        <li class="category-item">
             <a href="#" class="category-item__link">${item.namecategory}</a>
        </li>
        
        `
    })
    listCategory.innerHTML = htmlsCategory.join(" ")
}
let apiChiTiet

function renderCodeProduct(product) {
    const listproduct = document.querySelector(".list-product")
    const htmls = product.map((item)=> {
        
        return `
        <div  class="col l-2-4 m-4 c-6">
        <a href = "#" class="home-product-item">
            <div class="home-product-item__img" style="background-image: url(${item.imgproduct})" >
            </div>
            <h4 class="home-product-item__name">${item.nameproduct}</h4>
            <div class="home-product-item__price">
                <span class="home-product-item__price-old">
                ${item.priceproduct}đ
                </span>
                <span class="home-product-item__price-current">
                    ${item.priceproduct} đ
                </span>
            </div>
            <div class="home-product-item__action">
                <span class="home-product-item__like home-product-item__like-liked">
                    <i class="home-product-item__icon-empy fa-regular fa-heart"></i>
                    <i class="home-product-item__icon-fill fa-solid fa-heart"></i>
                </span>

                <div class="home-product-item__rating">
                    <i class="home-product-item__gold fa-solid fa-star"></i>
                    <i class="home-product-item__gold fa-solid fa-star"></i>
                    <i class="home-product-item__gold fa-solid fa-star"></i>
                    <i class="home-product-item__gold fa-solid fa-star"></i>
                    <i class="fa-solid fa-star"></i>
                </div>
                <span class="home-product-item__sold">${item.soLuong} đã bán</span>
            </div>
            <div class="home-product-item__orign">
                <span class="home-product-item__brand">
                    ${item.namecategory}
                </span>
                <span class="home-product-item__origin-name">
                    Konoha
                </span>
            </div>
            <div class="home-product-item__favourite">
                <i class="fa-solid fa-check"></i>
                <span>yêu thích</span> 
            </div>
            <div class="home-product-item__sale-off">
                <span class="home-product-item__sale-off-precent">${item.sale}%</span>
                <div class="home-product-item__sale-off-label">GIẢM</div>
            </div>
        </a>
        
    </div>
        `
    })
   
   
    listproduct.innerHTML = htmls.join(' ')
    const itemProduct  = document.querySelectorAll(".home-product-item")
    itemProduct.forEach((itempr, i) => {
        
        itempr.onclick = () => {
           let targetid= product[i].iDproduct;
           
           
          apiChiTiet = `https://localhost:44355/api/Product/get-by-id-product/${targetid}`;
          
          GetProduct(renderCodeProduct)
        }
        
    })
}

console.log(apiChiTiet);
const chiTietProduct = document.querySelector("gwap-js");



`

<ul class="link-info">
<li class="link-info__item">
    Shoppe
    <i class="fa-solid fa-chevron-right link-info__icon"></i>
</li>
<li class="link-info__item">
    Máy Tính & Laptop
    <i class="fa-solid fa-chevron-right link-info__icon"></i>
</li>
<li class="link-info__item">
    Phụ Kiện Máy Tính
    <i class="fa-solid fa-chevron-right link-info__icon"></i>
</li>
<li class="link-info__item">
    Bàn Laptop
    <i class="fa-solid fa-chevron-right link-info__icon"></i>
</li>
<span class="name-link">
    Giá đỡ LAPTOP, MACBOOK, IPAD bằng nhôm có thể điều chỉnh được độ cao, đế tản nhiệt kê laptop nhôm
</span>
</ul>
<div class="product-gwap">
<div class="product-gwap__left">
    <div class="img-main">
        <img src="/img/giado1.png" alt="">
    </div>
    <div class="list-img">
        <div class="img-item">
            <img src="/img/giado.png" alt="">
        </div>
        <div class="img-item">
            <img src="/img/giado.png" alt="">
        </div>
        <div class="img-item">
            <img src="/img/giado.png" alt="">
        </div>
        <div class="img-item">
            <img src="/img/giado.png" alt="">
        </div>
    </div>
</div>
<div class="product-gwap__right">
    <div class="name-product">
        Giá đỡ LAPTOP, MACBOOK, IPAD bằng nhôm có thể điều chỉnh được độ cao, đế tản nhiệt kê laptop nhôm
    </div>
    <div class="evaluate">
        <div class="rate">
            <span>
                4.9

            </span>
            <i class="fa-solid fa-star"></i>
            <i class="fa-solid fa-star"></i>
            <i class="fa-solid fa-star"></i>
            <i class="fa-solid fa-star"></i>
            <i class="fa-solid fa-star"></i>
        </div>
        <div class="quantity-evaluate">
            <span>30,1k</span>
            Đánh Giá
        </div>
        <div class="quantity-evaluate">
            <span>
                96,5k
            </span>
            Đã Bán
        </div>
    </div>
    <div class="price-product">
        <div class="price-old">
            ₫129.000 - ₫539.000

        </div>
        <div class="price-new">
            ₫79.000 - ₫379.000
        </div>
    </div>
    <div class="product-body">
        <div class="deal">
            <div class="body-title">
                Deal Sốc
            </div>
            <div class="deal-price">
                Mua Kèm Deal Sốc
            </div>
        </div>
        <div class="ship">
            <div class="body-title">
                Vận Chuyển
            </div>
            <div class="ship-to">
                <i class="fa-solid fa-truck"></i>
                vận chuyển tới
            </div>
            <div class="address-ship">
                dia chi
                <i class="fa-solid fa-chevron-down"></i>
            </div>
        </div>
        <div class="product-buy__quantity">
            <div class="product-number">
                Số lượng
            </div>
            <div class="quantity">
                <button class="btn-giam">
                    <i class="fa-solid fa-minus"></i>

                </button>
                <span class="quantity-number">
                    1
                </span>
                <button class="btn-tang">
                    <i class="fa-solid fa-plus"></i>
                </button>
            </div>
            <div class="product-quantity">
                123 sản phẩm có sẵn
            </div>
        </div>

        <div class="gwap-btn">
            <button class="add-cart">
                <i class="fa-solid fa-cart-plus"></i>
                thêm vào giỏ hàng
            </button>
            <button class="buy-now">
                Mua ngay
            </button>
        </div>

    </div>
</div>
</div>
`




