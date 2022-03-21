var dataTable;

var ptName;
var obType;
var obIndex;

$(document).ready(
    function () {

     
    }
);
function loadDataTable(apiUrl) {
    $.ajax({
        url: apiUrl, success: function (result) {
            if (result.obResults.length != 0) {
               // toastr.success("Observation value for Patient: " + ptName + ", Test: " + obType + " is " + result.obResults[0].value);
                alert("Observation value for Patient: " + ptName + ", Test: " + obType + " is " + result.obResults[0].value);
            } else {
                alert("Record not found.");
            }
        }
    });
}
function callSuccess(data) {
    //alert(data.data.vitals.observations.index);
}
function findValue() {
    
    ptName = $.trim($('#ptName').val());
    obType = $.trim($('#obType').val());
    obIndex = $.trim($('#obIndex').val());
    if (ptName != '') {
        ptName = $("#ptName").val();
    }
    if (obType != '') {
        obType = $("#obType").val();
    }
    if (obIndex != '') {
        obIndex = $("#obIndex").val();
    }



    var apiUrl = "https://localhost:7051/api/PatientObservation?ptName=" + ptName + "&obType=" + obType + "&obIndex=" + obIndex;
    loadDataTable(apiUrl);
    
  

}