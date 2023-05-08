using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CourseWork.DATA_ACCESS.Entities
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; } 

        [Required]
        public string LastName { get; set; } 

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string CooperativeEmail { get; set; }
    }
}
