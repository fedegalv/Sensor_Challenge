jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    //$("#view-all").html(res);
                    //$('#form-modal .modal-body').html('');
                    //$('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide')
                    window.location.href = "/User/ListaUsuarios";
                    alert("Accion realizada correctamente");
                }
                else {
                    alert("No se pudo realizar la accion, faltan datos o son incorrectos");
                    $('#form-modal')[0].reset;
                }
            },
            error: function (err) {
                console.log(err);
            }

        });

    } catch (e) {

    }


    return false;
}