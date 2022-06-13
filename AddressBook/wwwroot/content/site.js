
function confirmDelete(param) {

    $("#deleteModalName").html(param.Name);
    $("#deleteModalSurname").html(param.Surname);
    $("#deleteModalEmail").html(param.Email);
    $("#deleteModalContactNumber").html(param.ContactNumber);
    $("#deleteModalCompany").html(param.Company);
    $("#deleteModalConfirm").attr("href", param.DeleteRoute);

    (new bootstrap.Modal(document.getElementById('confirmDeleteModal'))).show();
    
}
