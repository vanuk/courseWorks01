using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CourseWork.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Поле «Електронна адреса» є обов'язковим")]
        [EmailAddress(ErrorMessage = "Некоректна електронна адреса")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле «Пароль» є обов'язковим")]
        public string Password { get; set; }
    }
}
