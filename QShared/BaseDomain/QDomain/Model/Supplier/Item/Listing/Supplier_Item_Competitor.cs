using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDomain.Model.Supplier.Item.Listing
{
    public class Supplier_Item_Competitor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompetitorId { get; set; }
        public int ItemId { get; set; }
        public string CompetitorName { get; set; }
        public string CompetitorSalePrice { get; set; }
        public string Remarks { get; set; }
        public string RemarksAr { get; set; }
    }
}
