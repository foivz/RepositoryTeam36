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
    
    public partial class vozilo
    {
        public vozilo()
        {
            this.vozilo_dodatna_oprema = new HashSet<vozilo_dodatna_oprema>();
        }
    
        public int vozilo_id { get; set; }
        public string marka { get; set; }
        public string naziv { get; set; }
        public int vrsta_id { get; set; }
        public int god_proiz { get; set; }
        public System.DateTime nad_prve_reg { get; set; }
        public System.DateTime nad_reg_do { get; set; }
    
        public virtual vozilo_vrsta vozilo_vrsta { get; set; }
        public virtual ICollection<vozilo_dodatna_oprema> vozilo_dodatna_oprema { get; set; }
    }
}
