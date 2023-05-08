using CourseWork.DATA_ACCESS.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CourseWork.DTO
{
    public class StudentDTO : UserDTO
    {
        public StudentDTO()
        {
            Assessments = new List<StudentAssessmentDTO>();
        }

        [Required(ErrorMessage = "Поле Власна пошта є обов'язковим")]
        public string OwnEmail { get; set; }

        public string GroupName { get; set; }

        public ICollection<StudentAssessmentDTO> Assessments { get; set; }

    }
}
