//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class kategorija
    {
        public kategorija()
        {
            this.vozilo_vrsta = new HashSet<vozilo_vrsta>();
        }
    
        public int kat_id { get; set; }
        public string naziv { get; set; }
        public string opis { get; set; }
    
        public virtual ICollection<vozilo_vrsta> vozilo_vrsta { get; set; }
    }
}
