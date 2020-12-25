using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDomain.Model.Supplier.PurchasingOrder
{
    public class Supplier_SapPurchasing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DT { get; set; } //	"100"
        public string BUKRS { get; set; } //	"TF01"
        public string MJAHR { get; set; } //	"2020"
        public string NRNUM { get; set; } //	"0000000573"
        public string MATNR { get; set; } //	"000000000000110053"
        public string BSTME { get; set; } //	"EA"
        public string BSTMG { get; set; } //	24
        public string JOTQTY { get; set; } //	0
        public string NETPR { get; set; } //	4.5
        public string LB { get; set; } //
    }
}
