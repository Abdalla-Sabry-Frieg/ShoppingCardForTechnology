$(document).ready(function () {
    $('#myTable').DataTable({
        "autoWidth": false,
        "responsive": true
    });
});



function Delete(id) {

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
            window.location.href = `/Admin/Roles/DeleteRole?Id=${id}`
            Swal.fire({
                title: "Deleted!",
                text: "Your file has been deleted.",
                icon: "success"
            });
        }
    });

}

Edit = (id, name) => {
    document.getElementById("title").innerHTML = "Edit roles";
    document.getElementById("btnSave").value = "Edit";
    document.getElementById("roleId").value = id;
    document.getElementById("roleName").value = name;
}

Rest = () => {
    document.getElementById("title").innerHTML = "Save new role";
    document.getElementById("btnSave").value = "Save";
    document.getElementById("roleId").value = "";
    document.getElementById("roleName").value = "";
}