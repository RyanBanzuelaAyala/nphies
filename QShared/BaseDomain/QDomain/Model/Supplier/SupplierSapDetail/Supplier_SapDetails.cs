using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDomain.Model.Supplier.SupplierSapDetail
{
    public class Supplier_SapDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SapSupDetSystemId { get; set; }

        // 
        [ForeignKey("Supplier")]
        public int SapSupSystemId { get; set; }
        public Supplier Supplier { get; set; }
        public string BUKRS { get; set; } // CHECK
        public string NAME1 { get; set; } //"AL RAJHI CHEMICAL INDUSTRIES"
        public string NAME2 { get; set; }
        public string NAME3 { get; set; }
        public string NAME4 { get; set; }
        public string SORTL { get; set; } //"AL RAJ"
        public string PSTLZ { get; set; } //"11472"
        public string ADRNR { get; set; } //"11472"
        public string REGIO { get; set; } //"C"
        public string LZONE { get; set; } //"C"
        public string PFACH { get; set; } //"C"
        public string TELF1 { get; set; } //"C"
        public string TELFX { get; set; } //"01-498-1063"
        public string STENR { get; set; } //"01-498-1063"
        public string GBDAT { get; set; } //"01-498-1063"
        public string STCEG { get; set; } //"01-498-1063"
        public string AKONT { get; set; } //"01-498-1063"
        public string FDGRV { get; set; } //"01-498-1063"
        public string ZTERM { get; set; } //"01-498-1063"
        public string REPRF { get; set; } //"01-498-1063"
        public string HBKID { get; set; } //"01-498-1063"
        public string ZWELS { get; set; } //"01-498-1063"
        public string XAUSZ { get; set; } //"01-498-1063"
        public string WAERS { get; set; } //"01-498-1063"
        public string TOGRU { get; set; } //"01-498-1063"
        public string KALSK { get; set; } //"01-498-1063"

               
    }
}
