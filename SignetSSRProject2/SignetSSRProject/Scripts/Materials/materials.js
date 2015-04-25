
$(function () {

    $("#jsGrid").jsGrid({
        width: "100%",
        height: "400px",

        filtering: true,
        editing: true,
        sorting: true,
        paging: true,
        autoload: true,
        pageSize: 25,
        pageButtonCount: 5,
        deleteConfirm: "Do you really want to delete the materials detail?",


        controller: {
            loadData: function (filter) {
                var materials = $.ajax({
                    type: "GET",
                    url: "/Materials/MaterialsData",
                    data: filter,
                    dataType: "json"
                });
                /*return $.grep(materials, function (mat) {
                    return (!filter.Description || client.Name.indexOf(filter.Description) > -1);
                });*/
                return materials;
            },

            insertItem: function (item) {
                delete item.MaterialsExpenseID;
                return $.ajax({
                    type: "POST",
                    url: "/Materials/InsertMaterialsData",
                    data: item,
                    dataType: "json"
                });
            },

            updateItem: function (item) {
                return $.ajax({
                    type: "POST",
                    url: "/Materials/UpdateMaterialsData",
                    data: item,
                    dataType: "json"
                });
            },

            deleteItem: function (item) {
                return $.ajax({
                    type: "POST",
                    url: "/Materials/DeleteMaterialsData",
                    data: item,
                    dataType: "json"
                });
            }
        },

        fields: [
            { title: "ID", name: "MaterialsExpenseID", width: 25, align: "center"},
            { name: "Expense", type: "text", width: 50, itemTemplate: function (value) { return "$" + value.toFixed(2); }, align: "center" },
            { title: "Job #", name: "JobID", type: "select", items: listJobNumber, valueField: "JobID", textField: "JobNumber", width: 50, align: "center" },
            { title: "Item Number", name: "ItemNumber", type: "number", width: 50, align: "center" },
            { title: "Description", name: "ExpenseDescription", type: "text", width: 75, align: "center" },
            { title: "PO Number", name: "PONumber", type: "text", width: 50, align: "center" },
            { title: "Invoice Number", name: "InvoiceNumber", type: "text", width: 60, align: "center" },
            { title: "Tax Included", name: "TaxIncluded", type: "checkbox", width: 50, align: "center" },
            { title: "Tax %", name: "TaxPercentage", type: "text", width: 50, itemTemplate: function (value) { return value.toFixed(2) + "%"; }, align: "center" },
            { title: "Markup %", name: "MarkupPercentage", type: "text", width: 50, itemTemplate: function (value) { return value.toFixed(2) + "%"; }, align: "center" },
            { type: "control" }
        ]
    });
});