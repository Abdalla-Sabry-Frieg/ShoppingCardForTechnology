
Reset = () => {
    document.getElementById("title").innerHTML = "Save new  SubCategory";
    document.getElementById("btnSave").value = "Save";
    document.getElementById("subCategoryId").value = "";
    document.getElementById("ImageSubCategory").src = "";
    document.getElementById("SubcategoryTitle").value = "";
    document.getElementById("Description").value = "";
    document.getElementById("CategoryId").value = "";

}

$(document).ready(function () {
    $('.delete-item').on('click' , function (){

        var btn = $(this).data('id');
        var id = btn.data('id');
        $.ajax({ 

            url: '/subCategory/Delete?Id=' + id,
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                if (data.success) {
                    // Item deleted successfully, update UI (e.g., remove row from table)
                    console.log("Item deleted!');
                    alert('Success deleting item!');
                } else {
                    alert('Error deleting item!');
                }
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.error('Error deleting item:', textStatus, errorThrown);
                alert("An error occurred. Please try again later.");
            }
        });
    });
});
