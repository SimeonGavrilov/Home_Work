var pass = document.getElementById("inputPassword3")
var r_pass = document.getElementById("r_inputPassword3")
var usna = document.getElementById("inputName")
var butt = document.getElementById("reg_send").disabled = true
var error = document.querySelector('.error');
var error_r_p = document.querySelector(".error_r_p")


var x = new Boolean(false)
var y = new Boolean(false)


r_pass.onchange = function () {
    var data = pass.value
    var r_data = r_pass.value
    if (data != r_data) {
        y = false;
        error_r_p.innerHTML = "wrong row"
        r_pass.style.border = "2px solid red"
        look()
    }
    else {
        y = true;
        error_r_p.innerHTML = ""
        r_pass.style.border = "2px solid black"
        look()
    }
}

usna.onchange = function () {
    var data = usna.value
    if (data.length > 3 & data.length < 50) {
        x = true;
        error.innerHTML = ""
        usna.style.border = "2px solid black"
        look()
    }
    else {
        x = false;
        error.innerHTML = "wrong row"
        usna.style.border = "2px solid red"
        look()
    }
}

function look() {
    if (x == true & y == true) {
        var butt = document.getElementById("reg_send").disabled = false
    }
    else {
        var butt = document.getElementById("reg_send").disabled = true
    }
}



$.ajax() //переслать на ссылку username get/post