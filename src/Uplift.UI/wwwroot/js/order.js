var DataTable;

$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("approved")) {
        loadDataTable("GetAllApprovedOrders");
    } else {
        if (url.includes("all")) {
            loadDataTable("GetAllOrders");
        } else {
            loadDataTable("GetAllPendingOrders");
        }
    }
});

function loadDataTable(url) {
    DataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/admin/order/" + url,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name.name", "width": "20%" },
            { "data": "phone", "width": "20%" },
            { "data": "email", "width": "15%" },
            { "data": "serviceCount", "width": "15%" },
            { "data": "status", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/Orders/Details/${data}" class='btn btn-success text-white btnDtSuccess'>
                                    <i class="fas fa-edit"></i> Detalhes
                                </a>`
                },
                "width": "15%"
            }
        ],
        "language": {
            "emptyTable": "Nenhum registro encontrado"
        },
        "width": "100%"
    });
}