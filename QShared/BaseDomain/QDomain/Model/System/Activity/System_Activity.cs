using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDomain.Model.System.Activity
{
    public class System_Activity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Action { get; set; }
        public DateTime? DateTimeLog { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }

        [ForeignKey("IdentityUser")]
        public string CoreUserId { get; set; }
    }
}
