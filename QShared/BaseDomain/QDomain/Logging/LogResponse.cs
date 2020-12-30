namespace QDomain.Logging
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LogResponse")]
    public class LogResponse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("LogRequest")]
        public int LogRequestId { get; set; }

        public string JsonResponseBundle { get; set; }

        public DateTime? ResponseStampDateAndTime { get; set; }

        public string StatusCode { get; set; }
    }
}
