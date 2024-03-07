var dataTable;

function loadDataTable(status) {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Tasks/GetAll?status=" + status
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "TaskTitle", "width": "15%" },
            { "data": "Description", "width": "15%" },
            { "data": "Priority", "width": "5%" },
            { "data": "AssignBy", "width": "15%" },
            { "data": "AssignTo", "width": "15%" },
            { "data": "AssignDate", "width": "15%" },
            { "data": "DueDate", "width": "15%" },
            { "data": "Status", "width": "15%" },

            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a href="/Tasks/Details?tasksId=${data}"
                            class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i></a>
                            <a onClick=Delete('/Admin/Company/Delete/${data}')
                            class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
					    </div>
                    `
                        
                },
                "width": "15%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}