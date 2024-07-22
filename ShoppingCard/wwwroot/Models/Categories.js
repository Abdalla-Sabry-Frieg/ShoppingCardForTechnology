function Delete(id) {

    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to remove this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            /*    window.location.href = `/Category/Delete?Id=${id}`*/
            $.post("/Category/Delete/?Id=" + id, { Id: id }, function () {
                // Handle success (e.g., refresh the page or update UI)
            });
            Swal.fire({
                title: "Deleted!",
                text: "Your file has been deleted.",
                icon: "success"
            });
        }
    });

}

Edit = (id, image, title, description, parantid) => {
    document.getElementById("title").innerHTML = "Category Edit";
    document.getElementById("btnSave").value = "Save";
    document.getElementById("categoryId").value = id;
    document.getElementById("ImageCategory").src = "~/Images/Categories/"+image;
    document.getElementById("categoryTitle").value = title;
    document.getElementById("Description").value = description;
    document.getElementById("parant").value = parantid;


}
Reset = () => {
    document.getElementById("title").innerHTML = "Save new Category";
    document.getElementById("btnSave").value = "Save";
    document.getElementById("categoryId").value = "";
    document.getElementById("ImageCategory").src = "";
    document.getElementById("categoryTitle").value = "";
    document.getElementById("Description").value = "";
    document.getElementById("parant").value = "";
}

// using Jquery

//$(document).ready(function () {
//    $(".Deletebutton").click(function () {
//        var recordToDelete = $(this).data("id"); // Get the data-id attribute value

//        // Show a confirmation dialog using jQuery UI dialog component
//        $("#dialog-confirm").dialog({
//            resizable: false,
//            height: 200,
//            modal: true,
//            buttons: {
//                "Delete": function () {
//                    $(this).dialog("close");
//                    // Send a POST request to the DeleteItem action
//                    $.post("/Category/Delete", { Id: id }, function () {
//                        // Handle success (e.g., refresh the page or update UI)
//                    });
//                },
//                "Cancel": function () {
//                    $(this).dialog("close");
//                }
//            }
//        });
//        return false;
//    });
//});
