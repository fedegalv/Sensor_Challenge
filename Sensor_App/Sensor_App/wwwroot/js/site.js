// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Write your JavaScript code.

//LOADER
$(window).on("load", function () {
    $(".loader-wrapper").fadeOut("slow");
    


});
$('#msg').hide();
$('#loginMessage').hide();
$('#logoutMessage').hide();

//PROFILE PICTURE
//jQuery(function () {
//    $("#profilePicture").empty();
//    $("#profilePicture").append('<img src="/assets/img/user-13.jpg" />');
//});

//LOGIN
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
                
                //$.notify("Sesion iniciada correctamente", "sucess");
                window.location.href = "/User/Inicio";
                alert("Sesion iniciada correctamente");
                //$('#loginMessage').show();
            }
        }
    })
}
// MODAL
showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
        },
        error: function (err) {
            alert("No se pudo ejecutar la accion, revise si tiene los permisos necesarios.");
            console.log(err);
        }
       
    })
}

//LOGOUT
var LogOut = function () {
    $.ajax({
        type: "GET",
        url: "/User/LogOut",
        success: function (result) {
            if (result == "Fail") {
                alert("ERROR al cerrar sesion");
            }
            else {
                window.location.href = "/User/Inicio";
                //$('#logoutMessage').show();
                alert("Sesion cerrada correctamente");
            }
        }
    })
}

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

                //$.notify("Sesion iniciada correctamente", "sucess");
                window.location.href = "/User/Inicio";
                alert("Sesion iniciada correctamente");
                //$('#loginMessage').show();
            }
        }
    })
}

//DATATABLE
$(document).ready(function () {
    $('#table_id').DataTable();
});