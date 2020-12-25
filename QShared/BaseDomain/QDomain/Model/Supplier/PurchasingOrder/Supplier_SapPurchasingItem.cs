using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDomain.Model.Supplier.PurchasingOrder
{
    public class Supplier_SapPurchasingItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MANDT { get; set; } //  	"100"
        public string BUKRS { get; set; } //"4507974062"
        public string MJAHR { get; set; } //"TF01"
        public string NRNUM { get; set; } //"F"
        public string MATNR { get; set; } //	"NB"
        public string BSTME { get; set; } // 
        public string BSTMG { get; set; } // 
        public string JOTQTY { get; set; } //"9"
        public string NETPR { get; set; } //"20200101"
        public string LBKUM { get; set; } //"S124RCV"
        public string MAKTG { get; set; }
    }
}
