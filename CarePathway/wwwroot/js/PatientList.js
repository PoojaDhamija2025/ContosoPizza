﻿var dataTable;
$(document).ready(
    function () {
        
        loadDataTable();
    }
);
function loadDataTable() {
    dataTable = $('#patient_load').DataTable({
        "ajax": { "url": "/api/Patient", "type": "GET", "datatype": "json" },
        "columns": [
            { "data": "name", "width": "16%" },
            { "data": "address", "width": "16%" },
            { "data": "dob", "width": "16%" },
            { "data": "attendentName", "width": "16%" },
            { "data": "attendentPhoneNumber", "width": "16%" },
            { "data": "attendentRelationship", "width": "16%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center"><a href="/PatientList/Upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer;width:100px">
                            Edit </a> &nbsp;
                            <a onclick=Delete('/api/patient?id='+${data}) class="btn btn-danger text-white" style="cursor:pointer;width:100px">
                            Delete </a> </div>`;
                },
                "width":"16%"

            }

        ],
        "language": { "emptyTable": "no data found" },
        "width": "100%"
    }); 
}
function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once Deleted, you will not be able to recover.",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}
