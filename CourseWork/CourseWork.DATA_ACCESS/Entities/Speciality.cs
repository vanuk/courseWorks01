using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.DATA_ACCESS.Entities
{
    public class Speciality
    {
        public Speciality()
        {
            Groups = new List<Group>();
        }

        [Key]
        public int Id { get; set; }

        [Required] 
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        public string Description { get; set; } 
        public ICollection<Group> Groups { get; set; }
    }
}
