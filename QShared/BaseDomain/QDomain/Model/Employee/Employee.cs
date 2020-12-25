using QDomain.Model.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QDomain.Model.Employee
{
    public class Employee
    {        
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        [ForeignKey("IdentityUser")]
        public string CoreUserId { get; set; }
        public CoreUser CoreUser { get; set; }

    }
}
