using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDomain.Model.Supplier.SupplierSapDetail
{
    public class Supplier_SapDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SapSupDetSystemId { get; set; }

        // 
        [ForeignKey("Supplier")]
        public int SapSupSystemId { get; set; }
        public Supplier Supplier { get; set; }
        //public string AKONT { get; set; } // CHECK
        //public string FDGRV { get; set; } // CHECK
        //public string ZTERM { get; set; } // CHECK
        //public string REPRF { get; set; } // CHECK
        //public string HBKID { get; set; } // CHECK
        //public string ZWELS { get; set; } // CHECK
        //public string XAUSZ { get; set; } // CHECK
        //public string WAERS { get; set; } // CHECK
        //public string TOGRU { get; set; } // CHECK
        //public string KALSK { get; set; } // CHECK
        public string MANDT { get; set; } //"100"
        public string LIFNR { get; set; } //"0000002089"
        public string LAND1 { get; set; } //"SA"
        public string NAME1 { get; set; } //"AL RAJHI CHEMICAL INDUSTRIES"
        public string NAME2 { get; set; }
        public string NAME3 { get; set; }
        public string NAME4 { get; set; }
        public string ORT01 { get; set; } //"RIYADH"
        public string ORT02 { get; set; }
        public string PFACH { get; set; } //"7799"
        public string PSTL2 { get; set; }
        public string PSTLZ { get; set; } //"11472"
        public string REGIO { get; set; } //"C"
        public string SORTL { get; set; } //"AL RAJ"
        public string STRAS { get; set; }
        public string ADRNR { get; set; } //"0000008287"
        public string MCOD1 { get; set; } //"AL RAJHI CHEMICAL INDUSTR"
        public string MCOD2 { get; set; }
        public string MCOD3 { get; set; } //"RIYADH"
        public string ANRED { get; set; }
        public string BAHNS { get; set; }
        public string BBBNR { get; set; } //"0000000"
        public string BBSNR { get; set; } //"00000"
        public string BEGRU { get; set; }
        public string BRSCH { get; set; }
        public string BUBKZ { get; set; } //"0"
        public string DATLT { get; set; }
        public string DTAMS { get; set; }
        public string DTAWS { get; set; }
        public string ERDAT { get; set; } //"2000-08-12"
        public string ERNAM { get; set; } //"CONVERSION"
        public string ESRNR { get; set; }
        public string KONZS { get; set; }
        public string KTOKK { get; set; } //"TG01"
        public string KUNNR { get; set; } //"0000002089"
        public string LNRZA { get; set; }
        public string LOEVM { get; set; }
        public string SPERR { get; set; } //"X"
        public string SPERM { get; set; } //"X"
        public string SPRAS { get; set; } //"E"
        public string STCD1 { get; set; }
        public string STCD2 { get; set; }
        public string STKZA { get; set; }
        public string STKZU { get; set; }
        public string TELBX { get; set; }
        public string TELF1 { get; set; } //"01-498-3443"
        public string TELF2 { get; set; }
        public string TELFX { get; set; } //"01-498-1063"
        public string TELTX { get; set; }
        public string TELX1 { get; set; }
        public string XCPDK { get; set; }
        public string XZEMP { get; set; }
        public string VBUND { get; set; }
        public string FISKN { get; set; }
        public string STCEG { get; set; }
        public string STKZN { get; set; }
        public string SPERQ { get; set; }
        public string GBORT { get; set; }
        public string GBDAT { get; set; } //"0000-00-00"
        public string SEXKZ { get; set; }
        public string KRAUS { get; set; }
        public string REVDB { get; set; } //"0000-00-00"
        public string QSSYS { get; set; }
        public string KTOCK { get; set; }
        public string PFORT { get; set; }
        public string WERKS { get; set; }
        public string LTSNA { get; set; } //"X"
        public string WERKR { get; set; } //"X"
        public string PLKAL { get; set; }
        public string DUEFL { get; set; } //"X"
        public string TXJCD { get; set; }
        public string SPERZ { get; set; }
        public string SCACD { get; set; }
        public string SFRGR { get; set; }
        public string LZONE { get; set; } //"A"
        public string XLFZA { get; set; }
        public string DLGRP { get; set; }
        public string FITYP { get; set; }
        public string STCDT { get; set; }
        public string REGSS { get; set; }
        public string ACTSS { get; set; }
        public string STCD3 { get; set; }
        public string STCD4 { get; set; }
        public string STCD5 { get; set; }
        public string IPISP { get; set; }
        public string TAXBS { get; set; } //"0"
        public string PROFS { get; set; }
        public string STGDL { get; set; }
        public string EMNFR { get; set; }
        public string LFURL { get; set; }
        public string J_1KFREPRE { get; set; }
        public string J_1KFTBUS { get; set; }
        public string J_1KFTIND { get; set; }
        public string CONFS { get; set; }
        public string UPDAT { get; set; } //"0000-00-00"
        public string UPTIM { get; set; } //"00:00:00"
        public string NODEL { get; set; }
        public string QSSYSDAT { get; set; } //"0000-00-00"
        public string PODKZB { get; set; }
        public string FISKU { get; set; }
        public string STENR { get; set; }
        public string CARRIER_CONF { get; set; }
        public string J_SC_CAPITAL { get; set; } //"0.00"
        public string J_SC_CURRENCY { get; set; }
        public string ALC { get; set; }
        public string PMT_OFFICE { get; set; }
        public string PSOFG { get; set; }
        public string PSOIS { get; set; }
        public string PSON1 { get; set; }
        public string PSON2 { get; set; }
        public string PSON3 { get; set; }
        public string PSOVN { get; set; }
        public string PSOTL { get; set; }
        public string PSOHS { get; set; }
        public string PSOST { get; set; }
        public string TRANSPORT_CHAIN { get; set; }
        public string STAGING_TIME { get; set; } //"0"
        public string SCHEDULING_TYPE { get; set; }
        public string SUBMI_RELEVANT { get; set; }


    }
}
