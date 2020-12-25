using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDomain.Model.Supplier.Item.Listing
{
    public class Supplier_Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        public string BrandName { get; set; }
        public string BrandNameAr { get; set; }
        public string ProductName { get; set; }
        public string ProductNameAr { get; set; }
        public string Variant { get; set; }
        public string UnitOfMeasure { get; set; }
        public string ItemCode { get; set; }
        public string PriceSize { get; set; }
        public string PieceBarcode { get; set; }
        public string PackSizeOuter { get; set; }
        public string OuterBarcode { get; set; }
        public string PackSizeCarton { get; set; }
        public string CartonBarcode { get; set; }
        public string ItemType { get; set; }
        public string Company { get; set; }
        public string Buyer { get; set; }
        public string PieceCostPrice { get; set; }
        public string PirceSuggestedSalePrice { get; set; }

        [ForeignKey("Supplier")]
        public int SystemId { get; set; }

        public List<Supplier_Item_Competitor> Supplier_Item_Competitor { get; set; }

        public Supplier_Item()
        {
            this.Supplier_Item_Competitor = new List<Supplier_Item_Competitor>();
        }
    }
}
