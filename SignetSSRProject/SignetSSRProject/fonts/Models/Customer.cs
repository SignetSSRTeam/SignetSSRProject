
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace SignetSSRProject.fonts.Models
{

using System;
    using System.Collections.Generic;
    
public partial class Customer
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Customer()
    {

        this.Jobs = new HashSet<Job>();

    }


    public int CustomerID { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Company { get; set; }

    public string Title { get; set; }

    public string BusinessPhone { get; set; }

    public string HomePhone { get; set; }

    public string CellPhone { get; set; }

    public string FaxNumber { get; set; }

    public string EmailAddress { get; set; }

    public string Notes { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Job> Jobs { get; set; }

}

}
