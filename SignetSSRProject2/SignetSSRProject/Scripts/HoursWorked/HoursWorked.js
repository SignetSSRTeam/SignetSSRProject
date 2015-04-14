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
                var HoursWorkedsData = JSON.stringify({ customer: JSON.stringify(item) })
                return $.ajax({
                    type: "POST",
                    url: "/HoursWorkeds/HoursWorkedsData",
                    data: item,
                    dataType: "json"
                });
            },

            updateItem: function (item) { },

            deleteItem: function (item) { },
        },

        fields: [
            { name: "FirstName", type: "text", width: 50},
            { name: "LastName", type: "text", width: 50 }, 
            { title: "Job ID", name: "JobID", type: "text", width: 50 },
            { title: "Date", name: "Date", type: "text", width: 75 },
            { title: "HoursWorkedRT", name: "HoursWorkedRT", type: "text", width: 50, itemTemplate: function (value) { return value.toFixed(2); } },
            { title: "HoursWorkedOT", name: "HoursWorkedOT", type: "text", width: 60, itemTemplate: function (value) { return value.toFixed(2); }  },
            { type: "control" }
        ]
    });
});

