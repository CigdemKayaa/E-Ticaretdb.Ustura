//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E_Ticaretdb.DatabaseModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Müşteri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Müşteri()
        {
            this.Müşteri1 = new HashSet<Müşteri>();
        }
    
        public int MüşteriID { get; set; }
        public string MüşteriAdı { get; set; }
        public string e_Mail { get; set; }
        public string Şifre { get; set; }
        public Nullable<int> Telefon { get; set; }
        public Nullable<int> MüşteriTipiID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Müşteri> Müşteri1 { get; set; }
        public virtual Müşteri Müşteri2 { get; set; }
        public virtual MüşteriTipi MüşteriTipi { get; set; }
    }
}
