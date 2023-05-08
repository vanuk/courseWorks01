using System.Collections.Generic;

namespace CourseWork.DTO
{ 
    public class TeacherDTO : UserDTO
    {
        public TeacherDTO()
        {
            Subjects = new List<SubjectDTO>();
        }

        public ICollection<SubjectDTO> Subjects { get; set; }
    }
}
