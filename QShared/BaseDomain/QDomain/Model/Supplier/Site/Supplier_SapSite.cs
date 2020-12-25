using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QDomain.Model.Supplier.Site
{
    public class Supplier_SapSite
    {
        [Key]
        public int Id { get; set; }

        public string NAME01 { get; set; }

        public string ORT01 { get; set; }

        public string LANDX { get; set; }

        public string WERKS { get; set; }
    }
}
