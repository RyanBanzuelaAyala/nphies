using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AG.Infra.Model.Tables
{
    [Table("InsuranceAccount", Schema = "AGAPI")]
    public class InsuranceAccount
    {

        [Key]
        public int Id { get; set; }

        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }

        public int DepartmentMappingProfileId { get; set; }
        [ForeignKey("DepartmentMappingProfileId")]
        public virtual DepartmentMappingProfile DepartmentMappingProfile { get; set; }

        public int InsuranceServiceMasterId { get; set; }
        [ForeignKey("InsuranceServiceMasterId")]
        public virtual InsuranceServiceMaster InsuranceServiceMaster { get; set; }

        [Required]
        [MaxLength(256)]
        public string InsuranceCode { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public bool Deleted { get; set; }
    }
}
