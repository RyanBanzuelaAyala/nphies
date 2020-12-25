using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDomain.Model.Supplier.Otp
{
    public class Supplier_Otp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SupplierId { get; set; }
        public string MobileNo { get; set; }
        public string Otp { get; set; }
        public DateTime? DateRequested { get; set; }
        public bool Status { get; set; }
        public string ResetCode { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierSystemId { get; set; }
    }
}
