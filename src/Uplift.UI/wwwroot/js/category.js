var DataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    DataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/admin/category/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name.name", "width": "50%" },
            { "data": "displayOrder", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/Category/Upsert/${data}" class='btn btn-success text-white btnDtSuccess'>
                                    <i class="fas fa-edit"></i> Editar
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Admin/Category/Delete/${data}") class='btn btn-danger text-white btnDtSuccess'>
                                    <i class="fas fa-trash"></i> Deletar
                                </a>
                            </div>`;
                },
                "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "Nenhum registro encontrado"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Tem certeza que deseja deletar?",
        text: "Você não vai ser capaz de recuperar o conteúdo!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Sim, apague!",
        cancelButtonText: "Não",
        closeOnConfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    DataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}