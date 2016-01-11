
    $(document).ready(function () {
        $('#dataTable').DataTable({
            searching: true,
            ordering: true,
            select: true,
            language: {
                processing: 'Procesando información...',
                search: "Buscar:",
                lengthMenu: "Mostrar elementos _MENU_ ",
                info: "Mostrando del elemento _START_ al _END_ de _TOTAL_ elementos",
                infoEmpty: "Mostrando del elemento 0 al 0 de 0 elementos",
                infoFiltered: "(_MAX_ elementos filtrados en total)",
                infoPostFix: "",
                loadingRecords: "Cargando...",
                zeroRecords: "No hay datos disposibles",
                emptyTable: "No hay datos disponibles en la tabla",
                paginate: {
                    first: "Primero",
                    previous: "Anterior",
                    next: "Siguiente",
                    last: "Último"
                },
                aria: {
                    sortAscending: ": habilitado para ordenar la columna en orden ascendente",
                    sortDescending: ": habilitado para ordenar la columna en orden descendente"
                }
            }
        });
    });