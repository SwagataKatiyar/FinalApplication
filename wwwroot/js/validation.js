const username = document.getElementById('username');
const email = document.getElementById('email');


const myBtn = document.getElementById('Register');


function emailValidation(input) {
    const emailVerify = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if (emailVerify.test(input.value.trim())) {
        
    }
    else {
        showError(input, 'Email is not Valid');
    }

}

