using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDomain.Model.Supplier.SupplierSapDetail
{
    public class Supplier_SapDetail_Other
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
        public string BUKRS { get; set; } // "TF01"
        public string LIFNR { get; set; } //: "0000003989"
        public string LTSNR { get; set; } //: "-"
        public string EMAIL1 { get; set; } //: "Peethambaran.Appuchamy@almarai.com"
        public string EMAIL2 { get; set; } //: "Emmanuel.nulian@almarai.com"
        public string EMAIL3 { get; set; } //: "Josue.Vicente@almarai.com"
        public string MOBILE1 { get; set; } //: ""
        public string MOBILE2 { get; set; } //: ""
        public string MOBILE3 { get; set; } //: ""
    }
}
