(function () {

    var customerInfo = {
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

    window.customerInfo = customerInfo;

    customerInfo.data = [
                        {
                            "Expense": 200.00,
                            "JobNumber": "15A54",
                            "ItemNumber": 700,
                            "ExpenseDescription": "Tiles",
                            "PONumber": "AA6879348",
                            "InvoiceNumber": "AA8923",
                            "TaxIncluded": false,
                            "TaxPercentage": 7,
                            "MarkupPercentage": 15
                        },
                        {
                            "Expense": 250.00,
                            "JobNumber": "15294",
                            "ItemNumber": 700,
                            "ExpenseDescription": "Pipes",
                            "PONumber": "AA6870048",
                            "InvoiceNumber": "ABH923",
                            "TaxIncluded": true,
                            "TaxPercentage": 7,
                            "MarkupPercentage": 15
                        },
                        {
                            "Expense": 1000.00,
                            "JobNumber": "19909",
                            "ItemNumber": 090,
                            "ExpenseDescription": "Welding materials",
                            "PONumber": "DD289374",
                            "InvoiceNumber": "DB23",
                            "TaxIncluded": false,
                            "TaxPercentage": 7,
                            "MarkupPercentage": 15
                        }
    ]
}());