using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AG.Infra.Model.Tables
{
    [Table("Account", Schema = "AGAPI")]
    public class Account
    {
        [Key]
        public int Id { get; set; }

        public int BranchId { get; set; }

        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }

        [Required]
        [MaxLength(1024)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Password { get; set; }

        [Required]
        [MaxLength(2048)]
        public string SecretKey { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public bool Deleted { get; set; }

    }
}
