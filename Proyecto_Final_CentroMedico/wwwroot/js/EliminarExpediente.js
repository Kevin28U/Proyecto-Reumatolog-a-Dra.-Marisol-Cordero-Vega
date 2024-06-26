document.getElementById('eliminar-expediente').addEventListener('click', function (e) {
    e.preventDefault();

    var cedula = this.getAttribute('data-cedula'); // Obtener la cédula del atributo data-cedula

    Swal.fire({
        title: 'Confirmación',
        text: '¿Desea eliminar el expediente?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sí',
        cancelButtonText: 'No'
    }).then((result) => {
        if (result.isConfirmed) {
            // Obtener la URL de la acción del controlador
            var url = '/Expediente/Eliminar'; // Reemplaza '/ruta-a-tu-controlador/eliminar' con la ruta correcta a tu acción de eliminación
            // Datos a enviar en la solicitud AJAX
            var data = {
                id: cedula // Agregar la cédula del paciente
            };

            // Envía la solicitud AJAX
            $.ajax({
                url: url,
                type: 'POST', // Puedes ajustar el método según tu configuración
                data: data,
                success: function (response) {
                    // Maneja la respuesta si es necesario
                    location.reload();
                },
                error: function (xhr, status, error) {
                    // Maneja los errores si es necesario
                }
            });
        }
    });
});

