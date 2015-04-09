//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SignetSSRProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MaterialsExpense
    {
        public int MaterialsExpenseID { get; set; }
        public decimal Expense { get; set; }
        public int JobID { get; set; }
        public Nullable<int> ItemNumberID { get; set; }
        public string ExpenseDescription { get; set; }
        public string PONumber { get; set; }
        public string InvoiceNumber { get; set; }
        public Nullable<bool> TaxIncluded { get; set; }
        public Nullable<decimal> TaxPercentage { get; set; }
        public Nullable<decimal> MarkupPercentage { get; set; }
    
        public virtual ItemNumber ItemNumber { get; set; }
        public virtual Job Job { get; set; }
    }
}
