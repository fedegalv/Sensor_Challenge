
jQueryAjaxPostUser = form => {
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
                alert("No se pudo ejecutar la accion, revise si tiene los permisos necesarios.");
                console.log(err);
            }

        });

    } catch (e) {

    }


    return false;
}

jQueryAjaxPostCliente = form => {
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
                    window.location.href = "/Cliente/ListaClientes";
                    alert("Accion realizada correctamente");
                }
                else {
                    alert("No se pudo realizar la accion, faltan datos o son incorrectos");
                    $('#form-modal')[0].reset;
                }
            },
            error: function (err) {
                alert("No se pudo ejecutar la accion, revise si tiene los permisos necesarios.");
                console.log(err);
            }

        });

    } catch (e) {

    }


    return false;
}
jQueryAjaxDelete = form => {
    if (confirm("Seguro que desea eliminar este elemento?")) {
        try {
            $.ajax({

                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    if (res.isValid) {
                        window.location.href = "/User/ListaUsuarios";
                        alert("Accion realizada correctamente");
                    }
                    else {
                        alert("No se pudo eliminar el elemento");
                        $('#form-modal').modal('hide')
                    }
                },
                error: function (err) {

                    console.log(err);
                    alert("No se pudo ejecutar la accion, revise si tiene los permisos necesarios.");
                }

            });
        }
        catch (e) {
            console.log(e);
        }
    }
    return false;
}
jQueryAjaxDeleteCliente = form => {
    if (confirm("Seguro que desea eliminar este elemento?")) {
        try {
            $.ajax({

                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    if (res.isValid) {
                        window.location.href = "/Cliente/ListaClientes";
                        alert("Accion realizada correctamente");
                    }
                    else {
                        alert("No se pudo eliminar el elemento");
                        $('#form-modal').modal('hide')
                    }
                },
                error: function (err) {

                    console.log(err);
                    alert("No se pudo ejecutar la accion, revise si tiene los permisos necesarios.");
                }

            });
        }
        catch (e) {
            console.log(e);
        }
    }
    return false;
}