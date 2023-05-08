using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseWork.DTO
{
    public class GroupDTO
    {
        public GroupDTO()
        {
            Students = new List<StudentDTO>();
        }

        public int Id { get; set; }
        
        public string Name { get; set; }
        public string FormOfStudying { get; set; }
        public string Speciality { get; set; }
        public ICollection<StudentDTO> Students { get;set; }
        public string Сurriculum { get; set; }
    }
}
