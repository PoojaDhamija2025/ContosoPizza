var dataTable;
$(document).ready(
    function () {
       
        loadDataTable();
    }
);


function loadDataTable() {
    dataTable = $('#observation4Patients_load').DataTable({
        "ajax": { "url": "/api/ObservationForPatient", "type": "GET", "datatype": "json" },
        "columns": [
            { "data": "mrn", "width": "16%" },
            { "data": "patientName", "width": "16%" },
            { "data": "observation", "width": "16%" },
            { "data": "index", "width": "16%" },
            { "data": "value", "width": "16%" },
            
        ],
        "language": { "emptyTable": "no data found" },
        "width": "100%"
    });
}