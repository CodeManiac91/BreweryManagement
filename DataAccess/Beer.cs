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
    
    public partial class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AlcoholContent { get; set; }
        public int BreweryId { get; set; }
        public bool Removed { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
    
        public virtual Brewer Brewer { get; set; }
        public virtual Brewer Brewer1 { get; set; }
        public virtual Brewery Brewery { get; set; }
    }
}
