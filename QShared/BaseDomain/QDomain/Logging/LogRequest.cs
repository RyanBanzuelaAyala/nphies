namespace QDomain.Logging
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="LogRequest" />.
    /// </summary>
    [Table("LogRequest")]
    public class LogRequest
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the RequestParam.
        /// </summary>
        public string RequestParam { get; set; }

        /// <summary>
        /// Gets or sets the JsonRequestBundle.
        /// </summary>
        public string JsonRequestBundle { get; set; }

        /// <summary>
        /// Gets or sets the RequestType.
        /// </summary>
        public string RequestType { get; set; }

        /// <summary>
        /// Gets or sets the RequestStampDateAndTime.
        /// </summary>
        public DateTime? RequestStampDateAndTime { get; set; }

        /// <summary>
        /// Gets or sets the StatusCode.
        /// </summary>
        public string StatusCode { get; set; }
    }
}
