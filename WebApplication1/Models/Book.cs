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

    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.Borrower_Details = new HashSet<Borrower_Details>();
            this.stocks = new HashSet<stock>();
        }


    
        public int Book_Id { get; set; }
        [DisplayName("Book Name")]

        public string Book_Name { get; set; }

        [DisplayName("Cateogory Name")]

        public Nullable<int> Category_Id { get; set; }

        [DisplayName("Author Name")]

        public Nullable<int> Author_Id { get; set; }

        [DisplayName("Publication Year")]

        public Nullable<System.DateTime> Publication_Year { get; set; }

        [DisplayName("Author Name")]


        public virtual Author Author { get; set; }

        [DisplayName("Cateogory")]

        public virtual category category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]


        [DisplayName("Borrowe Details")]

        public virtual ICollection<Borrower_Details> Borrower_Details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        [DisplayName("Stocks")]

        public virtual ICollection<stock> stocks { get; set; }
    }
}