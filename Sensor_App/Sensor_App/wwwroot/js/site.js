// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//$(document).ready(function () {
//    $("#btnSubmit").click(function (e) {
//        //Serialize the form datas.   
//        var valdata = $("#loginForm").serialize();
//        //to get alert popup   
//        alert(valdata);
//        $.ajax({
//            url: "/User/Login",
//            type: "POST",
//            dataType: 'json',
//            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
//            data: valdata
//        });
//    });
//});
//let btnSubmit = document.getElementById("btnSubmit");
//btn.addEventListener
//window.addEventListener('load', iniciarBotones);
//async function iniciarBotones() {
//    const btnLogIn = document.getElementById('btnSubmit');
//    btnLogIn.addEventListener('click', function () {

//        var logIn = $("#loginForm").serialize();


//        //console.log(logIn);
//        logInPost(logIn);

//    });
//}

//async function logInPost(userLogin) {
//    //ARCHIVO CONFIG QUE VA EN FETCH
//    console.log(userLogin);
//    const config = {
//        method: "POST",
//        headers: {
//            "Content-type": "application/x-www-form-urlencoded; charset=UTF-8"
//        },
//        data: JSON.stringify(userLogin) //PASAMOS COMO JSON STRING EL OBJETO
//    }
//    try {
//        let res = await axios('https://localhost:44372/user/login', config);
//        console.log("Login POST");
//    }
//    catch (error) {
//        console.error(err.response.status, err.response.statusText);
//    }
//}
$('#msg').hide();
var Login = function () {
    var data = $('#loginForm').serialize();
    $.ajax({
        type: "post",
        url: "/User/Login",
        data: data,
        success: function (result) {
            if (result == "Fail") {
                $('#loginForm')[0].reset;
                $('#msg').show();
            }
            else {
                window.location.href = "/User/Inicio";
                $('#msg').show();
            }
        }
    })
}