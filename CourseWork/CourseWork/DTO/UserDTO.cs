using System.ComponentModel.DataAnnotations;

namespace CourseWork.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Поле Прізвище є обов'язковим")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле Ім'я є обов'язковим")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле По-батькові є обов'язковим")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Поле Кооперативна пошта є обов'язковим")]
        public string CooperativeEmail { get; set; }
    }
}
