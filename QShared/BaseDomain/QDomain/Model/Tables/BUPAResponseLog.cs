using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AG.Infra.Model.Tables
{
    [Table("BUPAResponseLog", Schema = "AGAPI")]
    public class BUPAResponseLog
    {
        [Key]
        public int Id { get; set; }

        public int RequestLogId { get; set; }

        [ForeignKey("RequestLogId")]
        public virtual BUPARequestLog BUPARequestLog { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string ResponseBody { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        [MaxLength(100)]
        public string RequestType { get; set; }


    }
}
