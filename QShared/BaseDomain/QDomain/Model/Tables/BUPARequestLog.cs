using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AG.Infra.Model.Tables
{
    [Table("BUPARequestLog", Schema = "AGAPI")]
    public class BUPARequestLog
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int OPRequestId { get; set; }

        [Required]
        public int ReSubmit { get; set; }

        [Required]
        public int PreAuthId { get; set; }
        
        [Required]
        [MaxLength(1024)]
        public string PatientFileNo { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string MemberId { get; set; }

        [Required]
        [MaxLength(250)]
        public string MemberName { get; set; }

        [Required]
        [MaxLength(250)]
        public string MembershipNo { get; set; }

        [Required]
        [MaxLength(5)]
        public string TreatmentType { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string RequestBody { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        [MaxLength(100)]
        public string RequestType { get; set; }


    }
}
