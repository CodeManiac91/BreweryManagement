//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sale
    {
        public int Id { get; set; }
        public string SalesOrderNumber { get; set; }
        public int BeerId { get; set; }
        public int WholeSalerId { get; set; }
        public int Amount { get; set; }
        public decimal TotalPrice { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual Beer Beer { get; set; }
        public virtual WholeSaler WholeSaler { get; set; }
    }
}
