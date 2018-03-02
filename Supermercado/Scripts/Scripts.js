$(function () {
    $("#btnCrearProductos").click(function () {
        var url = "/api/crearProductos";
        var info = {
            Prod_NombreProducto: $("#IdNombreProducto").val(),
            Prod_Precio: $("#IdPrecio").val(),
            Prod_Existencias: $("#Existencias").val()
        };

        var fila;
        $.post(url, info).done(function (data) {
            $("#cuerpoTabla").empty();
            $.each(data, function (index, item) {
                fila += '<tr><td>' + item.Prod_NombreProducto + '</td><td>' + item.Prod_Precio + '</td><td>' + item.Prod_Existencias + '</td><td><a href="/Productos/Modificar?Prod_IdProducto='+ item.Prod_IdProducto +'">Modificar</a><a href="/Productos/Eliminar?Prod_IdProducto='+item.Prod_IdProducto+'">Eliminar</a></td></tr>';
            });
            $("#cuerpoTabla").append(fila);
        });

    });

});

