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
    
    public partial class Kategori
    {
        public int KategoriID { get; set; }
        public string KategoriAdı { get; set; }
        public Nullable<bool> Durum { get; set; }
        public string SeoLink { get; set; }
        public Nullable<int> SiparişNo { get; set; }
    }
}