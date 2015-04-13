
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
                return $.ajax({
                    type: "GET",
                    url: "/Materials/MaterialsData",
                    data: filter,
                    dataType: "json"
                });
            },

            insertItem: function (item) {
                var materialsData = JSON.stringify({ customer: JSON.stringify(item) })
                return $.ajax({
                    type: "POST",
                    url: "/Materials/MaterialsData",
                    data: item,
                    dataType: "json"
                });
            },

            updateItem: function (item) { },

            deleteItem: function (item) { },
        },

        fields: [
            { name: "Expense", type: "text", width: 50, itemTemplate: function (value) {return "$" + value.toFixed(2);} },
            { title: "Job #", name: "JobID", type: "text", width: 50 },
            { title: "Item Number", name: "ItemNumber", type: "text", width: 50 },
            { title: "Description", name: "ExpenseDescription", type: "text", width: 75 },
            { title: "PO Number", name: "PONumber", type: "text", width: 50 },
            { title: "Invoice Number", name: "InvoiceNumber", type: "text", width: 60 },
            { title: "Tax Included", name: "TaxIncluded", type: "checkbox", width: 50 },
            { title: "Tax %", name: "TaxPercentage", type: "text", width: 60, itemTemplate: function (value) { return  value.toFixed(2) + "%"; } },
            { title: "Markup %", name: "MarkupPercentage", type: "text", width: 75, itemTemplate: function (value) { return value.toFixed(2) + "%"; } },
            { type: "control" }
        ]
    });
});