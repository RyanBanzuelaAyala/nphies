using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDomain.Model.Supplier.PurchasingOrder
{
    public class Supplier_PurchasingOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SupplierId { get; set; }
        public string PurchasingId { get; set; }
        public string Branch { get; set; }
        public string Region { get; set; }
        public DateTime? DateReleased { get; set; }
        public DateTime? DateDownloaded { get; set; }
        public string FileName { get; set; }
        public DateTime? FileExpiration { get; set; }
        public bool Status { get; set; }
    }
}
