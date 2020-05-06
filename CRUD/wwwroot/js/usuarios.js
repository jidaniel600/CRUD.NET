$(function () {

    const url = 'https://localhost:44342/api/CrudWebApi';
    const urlTipoId = "https://localhost:44342/api/Utilidades";
    
    cargarTiposIdentificacion();
    
    function cargarTiposIdentificacion() {

        fetch(urlTipoId, {
            method: 'GET'

        }).then(respuesta => respuesta.json())
            .then(res => {
                _.each(res.listaUsuarios, function (item) {

                    $('#tipoId').append("<option value='" + item.codTipoId + "'>" + item.abreviTipoId + "</option>");
                });
            })
            .catch(error => console.log('error', error));

    }

    var constraints = {
        password: {
            presence: {
                message: "no puede ser vacio  "
            },
            length: {
                minimum: 6,
                message: "debe tener minimo 6 caracteres, la longitud no es valida"
            }
        },
        email: {
            email: true
        },
        cedula: {
            numericality: {
                onlyInteger: true,
                greaterThan: 0,
                message : ' debe ser un numero entero'
            },
            presence: {
                message: "no puede ser vacio  "
            }
        }
    }


    var form = document.querySelector('form#registro');

    form.addEventListener('submit', function (ev) {
        ev.preventDefault();
        manejarFormulario(form);
    })

    var inputs = document.querySelectorAll("input, select")
    for (var i = 0; i < inputs.length; ++i) {
        inputs.item(i).addEventListener("change", function (ev) {
            var errors = validate(form, constraints) || {};

        });
    }
    function manejarFormulario(form, input) {

        var errors = validate(form, constraints);

        showErrors(form, errors || {});
        if (!errors) {

            completado();

        }
    }
    function showErrors(form, errors) {


        _.each(form.querySelectorAll("input[name], select[name]"), function (input) {

            if (input.name != '__RequestVerificationToken') {
                MostrarErroresInput(input, errors && errors[input.name]);
            }

        });
    }


    function MostrarErroresInput(input, errors) {

        var formGroup = closestParent(input.parentNode, "form-group")

            , messages = formGroup.querySelector(".mensaje");

        resetFormGroup(formGroup);

        if (errors) {

            formGroup.classList.add("has-error");

            _.each(errors, function (error) {
                addError(messages, error);
            });
        } else {

            formGroup.classList.add("has-success");
        }
    }


    function closestParent(child, className) {
        if (!child || child == document) {
            return null;
        }
        if (child.classList.contains(className)) {
            return child;
        } else {
            return closestParent(child.parentNode, className);
        }
    }

    function resetFormGroup(formGroup) {

        formGroup.classList.remove("has-error");
        formGroup.classList.remove("has-success");

        _.each(formGroup.querySelectorAll(".help-block.error"), function (el) {
            el.parentNode.removeChild(el);
        });
    }

    function addError(messages, error) {
        var block = document.createElement("p");
        block.classList.add("help-block");
        block.classList.add("error");
        block.innerText = error;
        messages.appendChild(block);
    }

    function completado() {

        var nombre = document.getElementById('nombre').value;
        var apellido = document.getElementById('apellido').value;
        var cedula = Number.parseInt(document.getElementById('cedula').value);
        var tipoId = Number.parseInt(document.getElementById('tipoId').value);
        var email = document.getElementById('email').value;
        var password = document.getElementById('password').value;
        crearUsuario(cedula, nombre, apellido, tipoId, password, email);
    }

    var btnlimpiar = document.getElementById('limpiarForm');
    btnlimpiar.addEventListener('click', limpiarFormulario);



    function limpiarFormulario() {

        _.each(form.querySelectorAll("input[name]"), function (input) {
            input.value = "";
        });
    }

    function crearUsuario(id, nombre, apellido, tipoId, password, email) {

        const data = {
            "Id": id,
            "Nombre": nombre,
            "Apellido": apellido,
            "TipoId": tipoId,
            "Contraseña": password,
            "Email": email
        };

        fetch(url, {
            method: 'POST',
            body: JSON.stringify(data),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }

        }).then(response => response.json())
            .then(res => {
                console.log(res);
                if (res.codigoRespuesta == 1) {
                    window.alert('usuario creado');
                    limpiarFormulario();
                }
                    

                if (res.codigoRespuesta == 3)
                    window.alert(res.mensajeRespuesta);
            })
            .catch(error => console.error('Error ', error));
    }


 



});