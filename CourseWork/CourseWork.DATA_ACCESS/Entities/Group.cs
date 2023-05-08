using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.DATA_ACCESS.Entities
{
    public class Group
    {
        public Group()
        { 
            Students = new List<Student>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string FormOfStudying { get; set; }

        public int? SpecialityId { get; set; }
        [ForeignKey(nameof(SpecialityId))]
        public virtual Speciality Speciality { get; set; }

        public int? СurriculumId { get; set; }
        [ForeignKey(nameof(СurriculumId))]
        public virtual Сurriculum Сurriculum { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
