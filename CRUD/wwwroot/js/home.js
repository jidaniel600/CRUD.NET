$(function () {

    todosUsuarios = [];
    
    const url = 'https://localhost:44342/api/CrudWebApi';
    cargarTodosLosUsuario();
    $('#EditarForm').submit(actualizarRegistros);
    document.getElementById('linkclose').addEventListener('click', closeInput);
    function cargarTodosLosUsuario() {

        fetch(url, {
            method: 'GET'

        }).then(response => response.json())
            .then(res => {
                mostrarDatosUsuario(res.listaUsuarios);

            })
            .catch(error => console.error('Error ', error));
    }

    

    function mostrarDatosUsuario(data) {
        
        const bodyUsuarios = document.getElementById('usuariosBody');
        bodyUsuarios.innerHTML = '';

        const button = document.createElement('button');

        data.forEach(item => {

            let botoneliminar = button.cloneNode(false);
            botoneliminar.innerText = 'Eliminar';
          
            botoneliminar.addEventListener('click', eliminarItem.bind(null, `${item.id}`));

            let botonActualizar = button.cloneNode(false);
            botonActualizar.innerText = 'Actualizar';
            botonActualizar.addEventListener('click', mostrarDatosEdicion.bind(null, `${item.id}`));

            let tr = bodyUsuarios.insertRow();

            let td1 = tr.insertCell(0);
            let textoId = document.createTextNode(item.id);
            td1.appendChild(textoId);
            

            let td2 = tr.insertCell(1);
            let textoNombre = document.createTextNode(item.nombre);
            td2.appendChild(textoNombre);

            let td3 = tr.insertCell(2);
            let textoApellido = document.createTextNode(item.apellido);
            td3.appendChild(textoApellido);

            let td4 = tr.insertCell(3);
            let textoEmail = document.createTextNode(item.email);
            td4.appendChild(textoEmail);

            let td5 = tr.insertCell(4);
            td5.appendChild(botoneliminar);

            td5.appendChild(botonActualizar);


        });

        todosUsuarios = data;
    }



    function mostrarDatosEdicion(id) {
        const item = todosUsuarios.find(item => item.id == id);
        
        document.getElementById('edit-id').value = item.id;
        document.getElementById('edit-tipoId').value = item.tipoId;
        document.getElementById('edit-contraseña').value = item.contraseña;
        document.getElementById('edit-nombre').value = item.nombre;
        document.getElementById('edit-apellido').value = item.apellido;
        document.getElementById('edit-email').value = item.email;
        document.getElementById('editForm').style.display = 'block';
    }

    

    function eliminarItem(id) {

        fetch(`${url}/${id}`, {
            method: 'DELETE'

        }).then(response => response.json())
            .then(res => {
                
                cargarTodosLosUsuario();

            })
            .catch(error => console.error('Error ', error));
    }
    function actualizarRegistros() {
        const itemId = document.getElementById('edit-id').value;
        const item = {
            Id: parseInt(itemId, 10),
            Nombre : document.getElementById('edit-nombre').value.trim(),
            Apellido : document.getElementById('edit-apellido').value.trim(),
            Contraseña: document.getElementById('edit-contraseña').value.trim(),
            email : document.getElementById('edit-email').value.trim(),
            TipoId : document.getElementById('edit-tipoId').value.trim()
            
        };

        fetch(`${url}/${itemId}`, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(item)
        })
            .then(() => {
                cargarTodosLosUsuario();
            })
            .catch(error => console.error('error', error));

        closeInput();

        return false;
    }

    
    function closeInput() {
        document.getElementById('editForm').style.display = 'none';
    }

});