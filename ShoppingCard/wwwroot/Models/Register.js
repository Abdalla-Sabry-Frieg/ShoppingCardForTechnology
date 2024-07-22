$(document).ready(function () {
    $('#myTable').DataTable({
        "autoWidth": false,
        "responsive": true
    });
});
// replace the table id to new name (id="TableRole") to set the jquery function

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
           window.location.href = `/Admin/Register/DeleteUser?userId=${id}`
            Swal.fire({
                title: "Deleted!",
                text: "Your file has been deleted.",
                icon: "success"
            });
        }
    });

}

// Arrow function Method

Edit = (id, name,email, image,roleName, activeUser) => {
    document.getElementById("title").innerHTML = "Edit users";
    document.getElementById("btnSave").value = "Edit";
    document.getElementById("UserId").value = id;
    document.getElementById("UserName").value = name;
    document.getElementById("UserEmail").value = email;
    document.getElementById("UserRole").value = roleName;
    document.getElementById("Image").hidden = true;
    document.getElementById("Image").src = "~/Images/Users/" +image;


    var Active = document.getElementById("ActiveUser");
    if (activeUser == "True")
        Active.Checked = true;
    else
        Active.Checked = false;

    //to hide password in edit view because the password will change in seperated view 

    $('#grPassword').hide();
    $('#grComparPassword').hide();
    // becuse i have a validation side to password
    document.getElementById("userPassword").value = "$$$$$$";
    document.getElementById("userComparePassword").value = "$$$$$$";
 

  document.getElementById("imageHide").value = image;




}

Rest = () => {
    document.getElementById("title").innerHTML = "Save new user";
    document.getElementById("btnSave").value = "Save";
    document.getElementById("UserId").value = "";
    document.getElementById("UserName").value = "";
    document.getElementById("UserRole").value = "";
    document.getElementById("UserEmail").value = "";
    document.getElementById("ImageUser").value = "";
    document.getElementById("ActiveUser").Checked = false;

    // to show the password in create step
    $('#grPassword').show();
    $('#grComparPassword').show();
    document.getElementById("userPassword").value = "";
    document.getElementById("userComparePassword").value = "";

   // document.getElementById("Image").hidden = true;
}

function ChangePassword(id) {

    document.getElementById('userPasswordId').value = id;
   

}
