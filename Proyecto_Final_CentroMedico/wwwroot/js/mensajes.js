document.addEventListener("DOMContentLoaded", function () {
    setTimeout(function () {
        var parrafo = document.getElementById("mensaje-confirmacion");
        if (parrafo) {
            parrafo.remove();
        }
    }, 7000); // 5000 milisegundos = 5 segundos
});
