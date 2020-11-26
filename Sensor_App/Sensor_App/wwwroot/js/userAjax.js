var crearUsuario = function () {
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
                alert("Sesion iniciada correctamente");
                //$('#loginMessage').show();
            }
        }
    })
}