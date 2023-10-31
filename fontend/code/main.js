
const menuLefts = document.querySelectorAll(".category-item");
menuLefts.forEach((menuLeft,index)=> {
    menuLeft.onclick= () => {
        menuLeft.classList.add("category-item--active")
    }
})





const modal = document.querySelector(".modal")
const formSub = document.querySelector(".auth-form.sub")
const formLogin = document.querySelector(".auth-form.login");
const spanSub = document.querySelector(".auth-form__switch-btn.sub")
const spanLogin = document.querySelector(".auth-form__switch-btn.login");
const btnHeaderSub = document.querySelector(".header__navbar-item.sub")
const btnHeaderlogin = document.querySelector(".header__navbar-item.login")
const btnBacks = document.querySelectorAll(".auth-form__controls-back")


//dang nhap 
// btnHeaderSub.onclick = () => {
//     modal.style.display = "flex";
//     formSub.style.display = "block";
//     formLogin.style.display = "none";

// }
// btnBacks.forEach((btnBack) => {
//     btnBack.onclick = () => {
//         modal.style.display = "none";
//         formSub.style.display = "none";
//     }

// })
// spanSub.onclick = () => {
//     formSub.style.display = "none";
//     formLogin.style.display = "block";
// }
// //login
// btnHeaderlogin.onclick = () => {
//     modal.style.display = "flex";
//     formSub.style.display = "none";
//     formLogin.style.display = "block";
// }
// spanLogin.onclick = () => {
//     formSub.style.display = "block";
//     formLogin.style.display = "none";
// }





//conerct database
