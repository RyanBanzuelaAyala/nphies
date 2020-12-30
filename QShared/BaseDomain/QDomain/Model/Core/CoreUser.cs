using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using QDomain.Model.System.Activity;

namespace QDomain.Model.Core
{
    public class CoreUser : IdentityUser
    {
        [Column(TypeName = "VARCHAR(50)")]
        public string UserId { get; set; }
        public bool IsActive { get; set; }
        public string Region { get; set; }
        public string Mobile { get; set; }
        public string EmailAddStatement { get; set; }
        
        public List<System_Activity> System_Activity { get; set; }

        public CoreUser()
        {
            this.System_Activity = new List<System_Activity>();
        }
    }
}
