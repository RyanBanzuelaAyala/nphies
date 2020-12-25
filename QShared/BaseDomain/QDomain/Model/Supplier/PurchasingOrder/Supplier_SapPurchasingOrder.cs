using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDomain.Model.Supplier.PurchasingOrder
{
    public class Supplier_SapPurchasingOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MANDT { get; set; } //  	"100"
        public string EBELN { get; set; } //"4507974062"
        public string BUKRS { get; set; } //"TF01"
        public string BSTYP { get; set; } //"F"
        public string BSART { get; set; } //	"NB"
        public string BSAKZ	{ get; set; } // 
        public string LOEKZ	{ get; set; } // 
        public string STATU { get; set; } //"9"
        public string AEDAT { get; set; } //"20200101"
        public string ERNAM { get; set; } //"S124RCV"
        public string PINCR { get; set; } //"00010"
        public string LPONR { get; set; } //"00140"
        public string LIFNR { get; set; } //	"0000003989"
        public string SPRAS { get; set; } //"E"
        public string ZTERM { get; set; } //"Z021"
        public string ZBD1T { get; set; } //60
        public string ZBD2T { get; set; } //0
        public string ZBD3T { get; set; } //0
        public string ZBD1P { get; set; } //0
        public string ZBD2P { get; set; } //0
        public string EKORG { get; set; } //"TF01"
        public string EKGRP { get; set; } //"008"
        public string WAERS { get; set; } //"SAR"
        public string WKURS { get; set; } //1
        public string KUFIX	{ get; set; } // 
        public string BEDAT { get; set; } //"20200101"  
        public string KDATB { get; set; } //	"00000000"
        public string KDATE { get; set; } //"00000000"
        public string BWBDT { get; set; } //"00000000"
        public string ANGDT { get; set; } //"00000000"
        public string BNDDT { get; set; } //"00000000"
        public string GWLDT { get; set; } //	"00000000"
        public string AUSNR	{ get; set; } // 
        public string ANGNR	{ get; set; } // 
        public string IHRAN { get; set; } //"20200101"
        public string IHREZ { get; set; } //"000400514000"
        public string VERKF	{ get; set; } // 
        public string TELF1	{ get; set; } // 
        public string LLIEF	{ get; set; } // 
        public string KUNNR	{ get; set; } // 
        public string KONNR	{ get; set; } // 
        public string ABGRU	{ get; set; } // 
        public string AUTLF	{ get; set; } // 
        public string WEAKT	{ get; set; } // 
        public string RESWK	{ get; set; } // 
        public string LBLIF	{ get; set; } // 
        public string INCO1	{ get; set; } // 
        public string INCO2	{ get; set; } // 
        public string KTWRT { get; set; } //0
        public string SUBMI { get; set; } //"0000000512"
        public string KNUMV { get; set; } //"1097364162"
        public string KALSM { get; set; } //"ZTL000"
        public string STAFO { get; set; } //"SAP"
        public string LIFRE { get; set; } //"0000003989"
        public string EXNUM	{ get; set; } // 
        public string UNSEZ	{ get; set; } // 
        public string LOGSY	{ get; set; } // 
        public string UPINC { get; set; } //"00001"
        public string STAKO	{ get; set; } // 
        public string FRGGR	{ get; set; } // 
        public string FRGSX	{ get; set; } // 
        public string FRGKE	{ get; set; } // 
        public string FRGZU	{ get; set; } // 
        public string FRGRL	{ get; set; } // 
        public string LANDS { get; set; } //"SA"
        public string LPHIS	{ get; set; } // 
        public string ADRNR	{ get; set; } // 
        public string STCEG_L { get; set; } //"SA"
        public string STCEG { get; set; } //"300508296700003"
        public string ABSGR { get; set; } //"00"
        public string ADDNR	{ get; set; } // 
        public string KORNR	{ get; set; } // 
        public string MEMORY	{ get; set; } // 
        public string PROCSTAT { get; set; } //"02"
        public string RLWRT { get; set; } //0
        public string REVNO	{ get; set; } // 
        public string SCMPROC	{ get; set; } // 
        public string REASON_CODE	{ get; set; } // 
        public string FORCE_ID	{ get; set; } // 
        public string FORCE_CNT { get; set; } //"000000"
        public string RELOC_ID	{ get; set; } // 
        public string RELOC_SEQ_ID	{ get; set; } // 
        public string POHF_TYPE	{ get; set; } // 
        public string EQ_EINDT { get; set; } //"00000000"
        public string EQ_WERKS	{ get; set; } // 
        public string FIXPO	{ get; set; } // 
        public string EKGRP_ALLOW	{ get; set; } // 
        public string WERKS_ALLOW	{ get; set; } // 
        public string CONTRACT_ALLOW	{ get; set; } // 
        public string PSTYP_ALLOW	{ get; set; } // 
        public string FIXPO_ALLOW	{ get; set; } // 
        public string KEY_ID_ALLOW	{ get; set; } // 
        public string AUREL_ALLOW	{ get; set; } // 
        public string DELPER_ALLOW { get; set; } //""
        public string EINDT_ALLOW { get; set; } //""
        public string OTB_LEVEL { get; set; } //""
        public string OTB_COND_TYPE { get; set; } //""
        public string KEY_ID { get; set; } //"0000000000000000"
        public string OTB_VALUE { get; set; } //0
        public string OTB_CURR { get; set; } //""
        public string OTB_RES_VALUE { get; set; } //0
        public string OTB_SPEC_VALUE { get; set; } //0
        public string SPR_RSN_PROFILE { get; set; } //""
        public string BUDG_TYPE { get; set; } //""
        public string OTB_STATUS { get; set; } //	""
        public string OTB_REASON { get; set; } //	""
        public string CHECK_TYPE { get; set; } //	""
        public string CON_OTB_REQ { get; set; } //	""
        public string CON_PREBOOK_LEV { get; set; } //	""
        public string CON_DISTR_LEV { get; set; } //""

    }
}
