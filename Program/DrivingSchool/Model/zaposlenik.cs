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
    
    public partial class zaposlenik : osoba
    {
        public int vrsta { get; set; }
    
        public virtual zaposlenik_vrsta zaposlenik_vrsta { get; set; }
    }
}
