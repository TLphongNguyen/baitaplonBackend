const quantyProduct = document.querySelector(".quantity-number");
const btnTang = document.querySelector(".btn-tang");
const btnGiam = document.querySelector(".btn-giam");

let quantitydefaut = 1;


btnTang.onclick = () => {
    quantitydefaut += 1
    quantyProduct.innerHTML = quantitydefaut.toString();
   
}
btnGiam.onclick = () => {
    if(quantyProduct.textContent > 1){
        
        quantitydefaut -= 1
        quantyProduct.innerHTML = quantitydefaut.toString();
        
        
    }
}

