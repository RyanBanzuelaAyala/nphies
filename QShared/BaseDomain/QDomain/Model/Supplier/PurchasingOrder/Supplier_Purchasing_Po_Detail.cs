using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDomain.Model.Supplier.PurchasingOrder
{
    public class Supplier_Purchasing_Po_Detail
    {
        public string PO_NUMBER { get; set; } //""
        public string COMP_CODE	{ get; set; } //
        public string DOC_TYPE	{ get; set; } //
        public string DELETE_IND	{ get; set; } //
        public string STATUS	{ get; set; } //
        public string CREAT_DATE { get; set; } //"0000-00-00"
        public string CREATED_BY	{ get; set; } //
        public string ITEM_INTVL { get; set; } //"00000"    
        public string VENDOR	{ get; set; } //
        public string LANGU	{ get; set; } //
        public string LANGU_ISO	{ get; set; } //
        public string PMNTTRMS	{ get; set; } //
        public string DSCNT1_TO { get; set; } //"0"
        public string DSCNT2_TO { get; set; } //"0"
        public string DSCNT3_TO { get; set; } //"0"
        public string DSCT_PCT1 { get; set; } //"0.000"
        public string DSCT_PCT2 { get; set; } //"0.000"
        public string PURCH_ORG	{ get; set; } //
        public string PUR_GROUP	{ get; set; } //
        public string CURRENCY	{ get; set; } //
        public string CURRENCY_ISO	{ get; set; } //
        public string EXCH_RATE { get; set; } //"0.00000"
        public string EX_RATE_FX	{ get; set; } //
        public string DOC_DATE { get; set; } //"0000-00-00"
        public string VPER_START { get; set; } //"0000-00-00"
        public string VPER_END { get; set; } //"0000-00-00"
        public string WARRANTY { get; set; } //"0000-00-00"
        public string QUOTATION	{ get; set; } //
        public string QUOT_DATE { get; set; } //"0000-00-00"
        public string REF_1	{ get; set; } //
        public string SALES_PERS	{ get; set; } //
        public string TELEPHONE	{ get; set; } //
        public string SUPPL_VEND	{ get; set; } //
        public string CUSTOMER	{ get; set; } //
        public string AGREEMENT	{ get; set; } //
        public string GR_MESSAGE	{ get; set; } //
        public string SUPPL_PLNT	{ get; set; } //
        public string INCOTERMS1	{ get; set; } //
        public string INCOTERMS2	{ get; set; } //
        public string COLLECT_NO	{ get; set; } //
        public string DIFF_INV	{ get; set; } //
        public string OUR_REF	{ get; set; } //
        public string LOGSYSTEM	{ get; set; } //
        public string SUBITEMINT { get; set; } //"00000"
        public string PO_REL_IND	{ get; set; } //
        public string REL_STATUS	{ get; set; } //
        public string VAT_CNTRY	{ get; set; } //
        public string VAT_CNTRY_ISO	{ get; set; } //
        public string REASON_CANCEL { get; set; } //"00"
        public string REASON_CODE { get; set; } //
    }
}
