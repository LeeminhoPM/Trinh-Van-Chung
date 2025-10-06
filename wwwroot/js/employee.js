$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').dataTable({
        'ajax': { url: '/admin/employee/getall' },
        'columns': [
            { data: 'fullName', 'width': '15%' },
            { data: 'gender', 'width': '5%' },
            { data: 'phone', 'width': '10%' },
            { data: 'email', 'width': '15%' },
            { data: 'salary', 'width': '10%' },
            { data: 'status', 'width': '25%' },
            {
                data: 'id',
                'render': function (data) {
                    return `<div class="w-75 btn-group" role="group">
                                <a href="/admin/employee/upsert?id=${data}" class="btn btn-primary mx-2">Edit</a>
                                <a onClick=Delete("/admin/employee/delete/${data}") class="btn btn-danger mx-2">Delete</a>
                            </div>`
                },
                'width': '20%'
            },
        ]
    });
}
function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    $('#tblData').DataTable().ajax.reload()
                    toastr.success(data.message);
                }
            })
        }
    });
}
