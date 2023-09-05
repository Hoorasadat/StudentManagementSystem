function confirmDelete(id, isDeleteConfirmed) {
    let deleteSpan = "deleteSpan_" + id;
    let deleteButtonSpan = "deleteButtonSpan_" + id;

    if (isDeleteConfirmed) {
        $("#" + deleteSpan).show();
        $("#" + deleteButtonSpan).hide();
    } else {
        $("#" + deleteSpan).hide();
        $("#" + deleteButtonSpan).show();
    }
}