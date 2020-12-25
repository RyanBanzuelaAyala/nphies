using System;
using System.Collections.Generic;
using System.Text;

namespace QDomain.Model.Supplier.PurchasingOrder
{
    public class Supplier_PurchasingPoItems
    {
        public List<Supplier_Purchasing> PO { get; set; }

        public List<Supplier_SapPurchasingItem> POItems { get; set; }
    }

    public class Supplier_PurchasingPoItemsParent
    {
        public string response { get; set; }
        public string data { get; set; }
    }
}
