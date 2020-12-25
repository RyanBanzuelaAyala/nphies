using QDomain.Model.Core;
using QDomain.Model.Supplier.Otp;
using QDomain.Model.Supplier.PurchasingOrder;
using QDomain.Model.Supplier.SupplierSapDetail;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QDomain.Model.Supplier
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SystemId { get; set; }
        public string Vendor_no { get; set; }
        public string Region { get; set; }
        public string Name { get; set; }
        
        public Supplier_SapDetail Supplier_SapDetail { get; set; }
        public Supplier_SapDetail_Full Supplier_SapDetail_Full { get; set; }

        // Setup 1 = 1 to CoreUser
        [ForeignKey("IdentityUser")]
        public string CoreUserId { get; set; }
        public CoreUser CoreUser { get; set; }

        // Setup 1 = Many 
        public List<Supplier_Otp> Supplier_Otp { get; set; }
        
        //public List<Supplier_Item> Supplier_Item { get; set; }
        //public List<Supplier_Meeting> Supplier_Meeting { get; set; }
        public List<Supplier_PurchasingOrder> Supplier_PurchasingOrder { get; set; }
        
        public Supplier()
        {
            this.Supplier_Otp = new List<Supplier_Otp>();
            
            this.Supplier_PurchasingOrder = new List<Supplier_PurchasingOrder>();

            //this.Supplier_Item = new List<Supplier_Item>();
            //this.Supplier_Meeting = new List<Supplier_Meeting>();
        }
    }    
}
