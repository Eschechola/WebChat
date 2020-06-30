
function ShowRegister() {
    var content = document.getElementsByClassName('content')[0];
    content.display = "block";

    //midbox 1 = imagem
    //midbox 2 = form

    var midbox = document.getElementsByClassName('mid-box');

    for (var i = 0; i < midbox.length; i++) {
        midbox[i].style.float = "left";
        midbox[i].style.width = "50%";
    }

    var formLogin = document.getElementsByClassName('form-login')[0];
    formLogin.style.display = "none";

    var formRegister = document.getElementsByClassName('form-register')[0];
    formRegister.style.display = "block";
    formRegister.style.animation = "Opacity 2.5s";

    //reduz a animação quando for mobile
    var width = window.innerWidth;

    if (width >= 1024) {
        midbox[0].style.marginLeft = "50%";
        midbox[1].style.marginLeft = "-260%";
    }
}


function ShowLogin(){
    var content = document.getElementsByClassName('content')[0];
    content.display = "block";

    //midbox 1 = imagem
    //midbox 2 = form

    var midbox = document.getElementsByClassName('mid-box');

    for (var i = 0; i < midbox.length; i++) {
        midbox[i].style.float = "left";
        midbox[i].style.width = "50%";
    }

    var formRegister = document.getElementsByClassName('form-register')[0];
    formRegister.style.display = "none";

    var formLogin = document.getElementsByClassName('form-login')[0];
    formLogin.style.display = "block";
    formLogin.style.animation = "Opacity 2.5s";


    //reduz a animação quando for mobile
    var width = window.innerWidth;

    if (width >= 1024) {
        midbox[0].style.marginLeft = "0%";
        midbox[1].style.marginLeft = "0%";
    }
}

function OpenErrorModal() {
    document.getElementsByClassName('modal-error')[0].style.marginLeft = "0";

    setTimeout(CloseErrorModal, 5000);
}


function CloseErrorModal() {
    document.getElementsByClassName('modal-error')[0].style.marginLeft = "-380px";
}