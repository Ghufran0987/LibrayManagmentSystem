//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Staff()
        {
            this.Borrower_Details = new HashSet<Borrower_Details>();
        }
    
        public int Staff_Id { get; set; }
        [DisplayName("First Name")]

        public string First_Name { get; set; }
        [DisplayName("Last Name")]

        public string Last_Name { get; set; }
        [DisplayName("Phone No")]

        public Nullable<int> Phone_No { get; set; }
        [DisplayName("Email")]

        public string Email { get; set; }
        [DisplayName("Username")]

        public string Username { get; set; }

        [DisplayName("Password")]

        public string Pass { get; set; }
        public Nullable<int> Role_Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Borrower_Details> Borrower_Details { get; set; }
        public virtual Role Role { get; set; }
    }
}