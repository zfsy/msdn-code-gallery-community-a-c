//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCDemoAzureSQLServer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car
    {
        public Car()
        {
            this.Model = new HashSet<Model>();
        }
    
        public int Id { get; set; }
        public string Brand { get; set; }
    
        public virtual ICollection<Model> Model { get; set; }
    }
}
