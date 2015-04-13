(function () {

    var employeeInfo = {
        loadData:
            function (filter) {
                return this.data;
            },

        insertItem:
            function (insertingClient) { },

        updateItem:
            function (updatingClient) { },

        deleteItem:
            function (deletingClient) { }
    }

    window.employeeInfo = employeeInfo;

    employeeInfo.data = [
                        {
                            "Date": "3/4/2015",
                            "FirstName": "Donnie",
                            "LastName": "Smith",
                            "HoursWorkedRT": 8.00,
                            "HoursWorkedOT": 0.00,
                            "Description": "ItemA",
                            "JobNumber": 1
                        },
                        {
                            "Date": "3/4/2015",
                            "FirstName": "Liza",
                            "LastName": "Johnson",
                            "HoursWorkedRT": 8.00,
                            "HoursWorkedOT": 0.00,
                            "Description": "ItemB",
                            "JobNumber": 2
                        },
                        {
                            "Date": "3/4/2015",
                            "FirstName": "Phil",
                            "LastName": "Wheeler",
                            "HoursWorkedRT": 8.00,
                            "HoursWorkedOT": 0.00,
                            "Description": "ItemC",
                            "JobNumber": 3
                        }
    ]
}());

