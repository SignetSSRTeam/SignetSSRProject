
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
    using System.ComponentModel.DataAnnotations;
    
public partial class Job
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Job()
    {

        this.HoursWorkeds = new HashSet<HoursWorked>();

        this.MaterialsExpenses = new HashSet<MaterialsExpense>();

    }


    public int JobID { get; set; }

    [Required]
    public string JobNumber { get; set; }

    [Required]
    public int CustomerID { get; set; }

    [Required]
    public int RateID { get; set; }

    [Required]
    public string VesselName { get; set; }

    [Required]
    public string Priority { get; set; }

    [Required]
    public string Status { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public Nullable<System.DateTime> StartDate { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
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
