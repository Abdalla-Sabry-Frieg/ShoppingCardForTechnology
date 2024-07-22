Edit = (id, image, title, description, categoryId,price) => {
    document.getElementById("title").innerHTML = "Category Edit";
    document.getElementById("btnSave").value = "Edit";
    document.getElementById("ItemId").value = id;
    document.getElementById("Select").value = categoryId;
    document.getElementById("ImageItem").src = "/Images/Items/" + image;
    document.getElementById("ItemTitle").value = title;
    document.getElementById("Price").value = price;
    document.getElementById("Description").value = description;

}

Reset = () => {
    document.getElementById("title").innerHTML = "Save new Category";
    document.getElementById("btnSave").value = "Save";
    document.getElementById("ItemId").value = "";
    document.getElementById("Select").value = "";
    document.getElementById("ImageItem").src = "";
    document.getElementById("ItemTitle").value = "";
    document.getElementById("price").value = ""; 
    document.getElementById("Description").value = "";
    

}
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
           
            $.post("/Items/Delete/?Id=" + id, { Id: id }, function () {
               
            });
            Swal.fire({
                title: "Deleted!",
                text: "Your file has been deleted.",
                icon: "success"
            });
        }
    });

}