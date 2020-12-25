using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDomain.Model.Supplier.SupplierSapDetail
{
    public class Supplier_SapDetail_Full
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SapSupDetSystemId { get; set; }
        // 
        [ForeignKey("Supplier")]
        public int SapSupSystemId { get; set; }
        public Supplier Supplier { get; set; }
        public string BUKRS { get; set; } // CHECK
        public string NAME1 { get; set; } // CHECK
        public string NAME2 { get; set; } // CHECK
        public string NAME3 { get; set; } // CHECK
        public string NAME4 { get; set; } // CHECK
        public string SORTL { get; set; } // CHECK
        public string PSTLZ { get; set; } // CHECK
        public string ADRNR { get; set; } // CHECK
        public string REGIO { get; set; } // CHECK
        public string LZONE { get; set; } // CHECK
        public string PFACH { get; set; } // CHECK
        public string TELF1 { get; set; } // CHECK
        public string TELFX { get; set; } // CHECK
        public string STENR { get; set; } // CHECK
        public string GBDAT { get; set; } // CHECK
        public string STCEG { get; set; } // CHECK
        public string AKONT { get; set; } // CHECK
        public string FDGRV { get; set; } // CHECK
        public string ZTERM { get; set; } // CHECK
        public string REPRF { get; set; } // CHECK
        public string HBKID { get; set; } // CHECK
        public string ZWELS { get; set; } // CHECK
        public string XAUSZ { get; set; } // CHECK
        public string WAERS { get; set; } // CHECK
        public string TOGRU { get; set; } // CHECK
        public string KALSK { get; set; } // CHECK
        
    }
}
