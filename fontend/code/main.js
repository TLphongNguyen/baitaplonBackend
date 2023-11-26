
const menuLefts = document.querySelectorAll(".category-item");
menuLefts.forEach((menuLeft,index)=> {
    menuLeft.onclick= () => {
        menuLeft.classList.add("category-item--active")
    }
})





const modal = document.querySelector(".modal-1")
const userbtn = document.querySelector(".link-info__user")
const iconclose = document.querySelector(".icon")


userbtn.onclick = () => {
    modal.style.display = "flex"
}
iconclose.onclick = () => {
    modal.style.display = "none"
    

}

//required
const inputName = document.querySelector(".name-user")
const inputEmail = document.querySelector(".email-user")
const inputPhone = document.querySelector(".phone-user")
const inputAddress = document.querySelector(".address-user")

function containsSpecialCharacter(inputStr) {
    const specialCharacters = /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]+/;
    return specialCharacters.test(inputStr);
}
inputName.onblur = () => {
    if(inputName.value.length  < 2) {
        document.querySelector(".required.name").textContent = "vui lòng nhập đầy đủ tên"
        document.querySelector(".required.name").style.display = "block";
    }
    else if (containsSpecialCharacter(inputName.value)) {
        document.querySelector(".required.name").textContent = "Không được sử dụng kí tự đặc biệt trong tên"
        document.querySelector(".required.name").style.display = "block";
    }
    else {
        document.querySelector(".required.name").style.display = "none";
    }
}
function containsSpecialCharacter(inputStr) {
    const specialCharacters = /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]+/;
    return specialCharacters.test(inputStr);
}
inputAddress.onblur = () => {
    if(inputAddress.value.length  < 2) {
        document.querySelector(".required.address").textContent = "vui lòng nhập đầy đủ địa chỉ"
        document.querySelector(".required.address").style.display = "block";
    }
    else if (containsSpecialCharacter(inputAddress.value)) {
        document.querySelector(".required.address").textContent = "Không được sử dụng kí tự đặc biệt trong địa chỉ"
        document.querySelector(".required.address").style.display = "block";
    }
    else {
        document.querySelector(".required.address").style.display = "none";
    }
}
function isValidEmail(email) {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}
inputEmail.onblur = () => {
    if (!isValidEmail(inputEmail.value)) {
        
        document.querySelector(".required.email").style.display = "block";
    }
   
    else {
        document.querySelector(".required.email").style.display = "none";
    }
}
function isNumeric(value) {
    // Hàm isNaN trả về true nếu giá trị không phải là số
    return !isNaN(value);
}
inputPhone.onblur = () => {
    const inputValue = inputPhone.value.trim();

    if (isNumeric(inputValue) === false || inputValue.length !=10) {
        document.querySelector(".required.phone").style.display = "block";
    } else {
        document.querySelector(".required.phone").style.display = "none";
    }
}


const navigations = document.querySelectorAll(".pagination-item")

navigations.forEach((navigation) => {
    navigation.onclick = () => {
        const navigationActive = document.querySelector(".pagination-item.pagination__active")
        navigationActive.classList.remove("pagination__active")
        navigation.classList.add("pagination__active")
    }
})



