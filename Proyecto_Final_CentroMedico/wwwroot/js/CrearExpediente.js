
/*
document.getElementById('crearExpediente').addEventListener('submit',
    function (e) {
        e.preventDefault();
        Swal.fire({
            title: 'Confirmación',
            text: '¿Desea enviar los datos ingresados al formulario?',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Sí',
            cancelButtonText: 'No'
        }).then((result) => {
            if (result.isConfirmed) {
                // Envía el formulario con AJAX
                $.ajax({
                    url: $(this).attr('action'),
                    type: $(this).attr('method'),
                    data: $(this).serialize()
                });
            }
        });
    }
);
*/

/*
    $(document).ready(function () {
        $('#crearExpediente').submit(function (e) {
            e.preventDefault();

            var cedula = $('#cedula').val();
            var fechaNacimiento = $('#fechaNacimiento').val();
            var nombre = $('#nombre').val();
            var primerApellido = $('#primerApellido').val();
            var segundoApellido = $('#segundoApellido').val();
            var sexo = $('#sexo').val();
            var ocupacion = $('#ocupacion').val();
            var edad = parseInt($('#edad').val());
            var canton = $('#canton').val();
            var provincia = $('#provincia').val();
            var direccion = $('#direccion').val();
            var AGO = $('#AGO').val();
            var APnoP = $('#APnoP').val();
            var APP = $('#APP').val();
            var AHF = $('#AHF').val();
            var AQTx = $('#AQTx').val();

            // Validar campos vacíos
            if (cedula === '' || fechaNacimiento === '' || nombre === '' || primerApellido === '' || segundoApellido === '' ||
                sexo === '' || ocupacion === '' || isNaN(edad) || canton === '' || provincia === '' || direccion === '' ||
                AGO === '' || APnoP === '' || APP === '' || AHF === '' || AQTx === '') {
                Swal.fire({
                    title: 'Error',
                    text: 'Por favor, complete todos los campos.',
                    icon: 'error'
                });
                return;
            }

            // Validar cédula
            if (!/^\d{9}$/.test(cedula)) {
                Swal.fire({
                    title: 'Error',
                    text: 'Por favor, ingrese una cédula válida de 9 dígitos numéricos.',
                    icon: 'error'
                });
                return;
            }

            // Validar edad
            if (edad < 0 || edad > 150) {
                Swal.fire({
                    title: 'Error',
                    text: 'Por favor, ingrese una edad válida entre 0 y 150 años.',
                    icon: 'error'
                });
                return;
            }

            // Si todos los campos están llenos y válidos, muestra el cuadro de diálogo de confirmación
            Swal.fire({
                title: 'Confirmación',
                text: '¿Desea enviar los datos ingresados al formulario?',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Sí',
                cancelButtonText: 'No'
            }).then((result) => {
                if (result.isConfirmed) {
                    // Envía el formulario con AJAX o cualquier acción necesaria aquí
                    $('#crearExpediente').unbind('submit').submit();
                    window.location.href = '/Expediente/Index';
                }
            });
        });
    });
    */

   
    $(document).ready(function () {
        $('#crearExpediente').submit(function (e) {
            e.preventDefault();

            var cedula = $('#cedula').val();
            var fechaNacimiento = $('#fechaNacimiento').val();
            var nombre = $('#nombre').val();
            var primerApellido = $('#primerApellido').val();
            var segundoApellido = $('#segundoApellido').val();
            var sexo = $('#sexo').val();
            var ocupacion = $('#ocupacion').val();
            var edad = parseInt($('#edad').val());
            var canton = $('#canton').val();
            var provincia = $('#provincia').val();
            var direccion = $('#direccion').val();
            var AGO = $('#AGO').val();
            var APnoP = $('#APnoP').val();
            var APP = $('#APP').val();
            var AHF = $('#AHF').val();
            var AQTx = $('#AQTx').val();

            // Validar campos vacíos
            if (cedula === '' || fechaNacimiento === '' || nombre === '' || primerApellido === '' || segundoApellido === '' ||
                sexo === '' || ocupacion === '' || isNaN(edad) || canton === '' || provincia === '' || direccion === '' ||
                AGO === '' || APnoP === '' || APP === '' || AHF === '' || AQTx === '') {
                Swal.fire({
                    title: 'Error',
                    text: 'Por favor, complete todos los campos.',
                    icon: 'error'
                });
                return;
            }



            // Validar cédula
            if (!/^\d{9}$/.test(cedula)) {
                Swal.fire({
                    title: 'Error',
                    text: 'Por favor, ingrese una cédula válida de 9 dígitos numéricos.',
                    icon: 'error'
                });
                return;
            }

            // Validar edad
            if (edad < 0 || edad > 150) {
                Swal.fire({
                    title: 'Error',
                    text: 'Por favor, ingrese una edad válida entre 0 y 150 años.',
                    icon: 'error'
                });
                return;
            }

            // Validar longitud de campos de texto
            if (nombre.length > 100 || primerApellido.length > 100 || segundoApellido.length > 100 ||
                direccion.length > 200 || AGO.length > 2000 || APnoP.length > 2000 || APP.length > 2000 ||
                AHF.length > 2000 || AQTx.length > 2000) {
                Swal.fire({
                    title: 'Error',
                    text: 'Por favor, asegúrese de que los campos de texto no excedan la longitud máxima permitida.',
                    icon: 'error'
                });
                return;
            }

            // Validar fecha de nacimiento no futura
            var fechaActual = new Date();
            var fechaNacimientoDate = new Date(fechaNacimiento);
            if (fechaNacimientoDate > fechaActual) {
                Swal.fire({
                    title: 'Error',
                    text: 'La fecha de nacimiento no puede ser en el futuro.',
                    icon: 'error'
                });
                return;
            }



            // Si todos los campos están llenos y válidos, muestra el cuadro de diálogo de confirmación
            Swal.fire({
                title: 'Confirmación',
                text: '¿Desea enviar los datos ingresados al formulario?',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Sí',
                cancelButtonText: 'No'
            }).then((result) => {
                if (result.isConfirmed) {
                    // Envía el formulario con AJAX o cualquier acción necesaria aquí
                    $('#crearExpediente').unbind('submit').submit();

                    var cedulaOK = $('#crearExpediente').attr('cedula-ok');

                    // Validar si cedula-ok es true
                    if (cedulaOK === 'NO') {
                        // Si es true, mostrar SweetAlert y retornar
                        Swal.fire({
                            title: 'Error',
                            text: 'El número de cédula ya existe.',
                            icon: 'error',
                            timer: 5000 // Duración de 5 segundos
                        });
                        return;
                    }


                }
            });
        });
    });
    

  /*  

$(document).ready(function () {
    $('#crearExpediente').submit(function (e) {
        e.preventDefault();

        var cedulaOK = $('#crearExpediente').attr('cedula-ok');

        // Validar si cedula-ok es true
        if (cedulaOK === 'NO') {
            // Si es true, mostrar SweetAlert y retornar
            Swal.fire({
                title: 'Error',
                text: 'El número de cédula ya existe.',
                icon: 'error'
            });
            return;
        }

        // Resto de tu código...
    });
});*/





