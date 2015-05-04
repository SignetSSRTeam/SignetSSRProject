
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
    
public partial class Job
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Job()
    {

        this.HoursWorkeds = new HashSet<HoursWorked>();

        this.MaterialsExpenses = new HashSet<MaterialsExpense>();

    }


    public int JobID { get; set; }

    public string JobNumber { get; set; }

    public int CustomerID { get; set; }

    public int RateID { get; set; }

    public string VesselName { get; set; }

    public string Priority { get; set; }

    public string Status { get; set; }

    public string Description { get; set; }

    public Nullable<System.DateTime> StartDate { get; set; }

    public Nullable<System.DateTime> EndDate { get; set; }

    public Nullable<int> ItemNumber { get; set; }



    public virtual Customer Customer { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<HoursWorked> HoursWorkeds { get; set; }

    public virtual Rate Rate { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<MaterialsExpense> MaterialsExpenses { get; set; }

}

}
