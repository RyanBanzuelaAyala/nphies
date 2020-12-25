using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AG.Infra.Model.Tables
{
    [Table("DepartmentMappingDetail", Schema = "AGAPI")]
    public class DepartmentMappingDetail
    {
        [Key]
        public int Id { get; set; }

        public int DepartmentMappingProfileId { get; set; }
        [ForeignKey("DepartmentMappingProfileId")]
        public virtual DepartmentMappingProfile DepartmentMappingProfile { get; set; }

        [Required]
        [MaxLength(256)]
        public string BranchDepartmentCode { get; set; }

        [MaxLength(1024)]
        public string BranchDepartmentDescription { get; set; }

        [Required]
        [MaxLength(256)]
        public string InsuranceDepartmentCode { get; set; }

        [Required]
        [MaxLength(1024)]
        public string InsuranceDepartmentDescription { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public bool Deleted { get; set; }
    }
}
