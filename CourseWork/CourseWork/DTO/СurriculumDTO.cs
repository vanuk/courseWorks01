using CourseWork.DATA_ACCESS.Entities;
using System.Collections.Generic;

namespace CourseWork.DTO
{
    public class СurriculumDTO
    {
        public СurriculumDTO()
        {
            Subjects = new List<SubjectDTO>();
            Groups = new List<GroupDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public ICollection<SubjectDTO> Subjects { get; set; }
        public ICollection<GroupDTO> Groups { get; set; }
    }
}
