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
    
    public partial class Rate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rate()
        {
            this.Jobs = new HashSet<Job>();
        }
    
        public int RateID { get; set; }
        public string JobType { get; set; }
        public Nullable<bool> Supervisor { get; set; }
        public decimal RateRT { get; set; }
        public decimal RateOT { get; set; }
        public Nullable<decimal> LaborHourlyCost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
