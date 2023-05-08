using CourseWork.DATA_ACCESS.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.DATA_ACCESS.Entities
{
    public class Subject
    {
        public Subject()
        {
            Teachers = new List<Teacher>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public FormOfControl FormOfControl { get; set; }
        public float Credits { get; set; }
        public float Lectures { get; set; }
        public float Labworks { get; set; }
        public float Practical { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
