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
        deleteConfirm: "Do you really want to delete the hours worked record?",


        controller: {
            loadData: function (filter) {
                return $.ajax({
                    type: "GET",
                    url: "/HoursWorkeds/HoursWorkedsData",
                    data: filter,
                    dataType: "json"
                });
            },

            insertItem: function (item) {
                return $.ajax({
                    type: "POST",
                    url: "/HoursWorkeds/InsertHoursWorkedsData",
                    data: item,
                    dataType: "json"
                });
            },

            updateItem: function (item) {
                return $.ajax({
                    type: "POST",
                    url: "/HoursWorkeds/UpdateHoursWorkedsData",
                    data: item,
                    dataType: "json"
                });
            },

            deleteItem: function (item) {
                return $.ajax({
                    type: "POST",
                    url: "/HoursWorkeds/DeleteHoursWorkedData",
                    data: item,
                    dataType: "json"
                });
            },
        },

        fields: [
            { title: "ID", name: "HoursWorkedID", width: 25, align: "center" },
            { title: "Employee Name", name: "EmployeeID", type: "select", items: listEmployeeName, valueField: "EmployeeID", textField: "EmployeeName", width: 60, align: "center" },
            { title: "Job Number", name: "JobID", type: "select", items: listJobNumber, valueField: "JobID", textField: "JobNumber", width: 50, align: "center" },
            { title: "Item Number", name: "ItemNumberID", type: "text", width: 50, align: "center" },
            { title: "Date", name: "Date", type: "text", width: 50, align: "center" },
            { title: "HoursWorkedRT", name: "HoursWorkedRT", type: "text", width: 50, align: "center", itemTemplate: function (value) { return value.toFixed(2); } },
            { title: "HoursWorkedOT", name: "HoursWorkedOT", type: "text", width: 60, align: "center", itemTemplate: function (value) { return value.toFixed(2); }  },
            { type: "control" }
        ]
    });
});

