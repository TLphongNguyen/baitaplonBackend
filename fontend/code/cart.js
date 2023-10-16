const quantyProduct = document.querySelector(".quantity-number");
const btnTang = document.querySelector(".btn-tang");
const btnGiam = document.querySelector(".btn-giam");
const price = document.querySelector(".price-now")
let quantitydefaut = 1;
let pricenow = price.textContent
const updatePrice = function(quantitydefaut) {
    console.log(quantyProduct.textContent,quantitydefaut)
    return price.innerHTML = quantyProduct.textContent *pricenow;

}
btnTang.onclick = () => {
    quantitydefaut += 1
    quantyProduct.innerHTML = quantitydefaut.toString();
    updatePrice()
}
btnGiam.onclick = () => {
    if(quantyProduct.textContent > 1){
        
        quantitydefaut -= 1
        quantyProduct.innerHTML = quantitydefaut.toString();
        updatePrice()
        
    }
}

