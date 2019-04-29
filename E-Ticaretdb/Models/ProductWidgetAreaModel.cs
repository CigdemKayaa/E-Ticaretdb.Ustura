using E_Ticaretdb.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Ticaretdb.Models
{
    public class ProductWidgetAreaModel
    {
        public List<Urunler> TopNew { get; set; }
        public List<EnÇokZiyaretEdilenUrun> TopVisitProduct { get; set; }
        public List<EnÇokSatanUrunler> TopProducts { get; set; }
    }
}