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

    public partial class stock
    {
        public int Stock_Id { get; set; }
        [DisplayName("Book Name")]

        public Nullable<int> Book_Name { get; set; }

        [DisplayName("Quantity")]

        public Nullable<int> Qty { get; set; }

        [DisplayName("Available")]

        public byte[] Available { get; set; }
    
        public virtual Book Book { get; set; }
    }
}