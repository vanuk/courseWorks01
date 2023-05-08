using CourseWork.DATA_ACCESS.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System;
using CourseWork.DATA_ACCESS;
using CourseWork.DTO;

namespace CourseWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbiturientController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly EFContext context;

        public AbiturientController(UserManager<User> _userManager, EFContext _context)
        {
            this.userManager = _userManager;
            this.context = _context;
        }

        [HttpGet("generate")]
        public AbiturientDTO GetAbiturient([FromQuery] string lastName, string firstName, string fatherName, string institute, string phone)
        {
            var map = new Dictionary<char, string>
            {
                { 'а', "a" }, { 'б', "b" }, { 'в', "v" }, { 'г', "h" },
                { 'ґ', "g" }, { 'д', "d" }, { 'е', "e" }, { 'є', "ie" },
                { 'ж', "zh" }, { 'з', "z" }, { 'и', "y" }, { 'і', "i" },
                { 'ї', "yi" }, { 'й', "y" }, { 'к', "k" }, { 'л', "l" },
                { 'м', "m" }, { 'н', "n" }, { 'о', "o" }, { 'п', "p" },
                { 'р', "r" }, { 'с', "s" }, { 'т', "t" }, { 'у', "u" },
                { 'ф', "f" }, { 'х', "kh" }, { 'ц', "ts" }, { 'ч', "ch" },
                { 'ш', "sh" }, { 'щ', "shch" }, { 'ю', "yi" }, { 'я', "ya" }, { 'ь', "" }, {' ', ""}
            };
            DateTime dateNow = DateTime.Now;
            string year = dateNow.ToString("yy");
            string email = "";
            foreach (var item in context.Abiturients)
            {
                email = $"{string.Concat(lastName.ToLower().Select(x => map[x]))}";
                if (lastName == item.LastName && item.Institute == institute && item.Email.Contains(year))
                {
                    email += $".{string.Concat(firstName.ToLower().Select(x => map[x]).ElementAt(0))}";

                    if (firstName == item.FirstName)
                    {
                        email += $".{string.Concat(fatherName.ToLower().Select(x => map[x]).ElementAt(0))}";
                    }
                }
                email += $"_{institute.ToLower()}{year}@nuwm.edu.ua";
            }
            var abiturient = new AbiturientDTO()
            {
                FirstName = firstName,
                LastName = lastName,
                FatherName = fatherName,
                Institute = institute,
                Phone = phone,
                Email = email,
                Password = GeneratePassword()
            };
            context.Abiturients.Add(new Abiturient()
            {
                FirstName = abiturient.FirstName,
                LastName = abiturient.LastName,
                FatherName = abiturient.FatherName,
                Institute = abiturient.Institute,
                Phone = abiturient.Phone,
                Email = abiturient.Email,
                Password = abiturient.Password
            });
            context.SaveChanges();

            string textOfFile = "";
            using (StreamReader reader = new StreamReader(@"D:\нувгп\ІПЗ-21\курсова робота\CourseWork\CourseWork\abiturients.txt"))
            {
                textOfFile = reader.ReadToEnd();
            }
            using (StreamWriter writer = new StreamWriter(@"D:\нувгп\ІПЗ-21\курсова робота\CourseWork\CourseWork\abiturients.txt"))
            {
                writer.WriteLine($"{textOfFile}" +
                    $"{abiturient.LastName}\t\t" +
                    $"{abiturient.FirstName}\t\t" +
                    $"{abiturient.FatherName} \t\t" +
                    $"{abiturient.Institute}\t\t" +
                    $"{abiturient.Phone}\t" +
                    $"{abiturient.Email}\t" +
                    $"{abiturient.Password}");
            }

            return abiturient;
        }
        [HttpGet]
        public string GeneratePassword()
        {
            var options = userManager.Options.Password;

            int length = options.RequiredLength;

            bool nonAlphanumeric = options.RequireNonAlphanumeric;
            bool digit = options.RequireDigit;
            bool lowercase = options.RequireLowercase;
            bool uppercase = options.RequireUppercase;

            StringBuilder password = new StringBuilder();
            Random random = new Random();

            while (password.Length < length)
            {
                char c = (char)random.Next(32, 126);

                password.Append(c);

                if (char.IsDigit(c))
                    digit = false;
                else if (char.IsLower(c))
                    lowercase = false;
                else if (char.IsUpper(c))
                    uppercase = false;
                else if (!char.IsLetterOrDigit(c))
                    nonAlphanumeric = false;
            }

            if (nonAlphanumeric)
                password.Append((char)random.Next(33, 48));
            if (digit)
                password.Append((char)random.Next(48, 58));
            if (lowercase)
                password.Append((char)random.Next(97, 123));
            if (uppercase)
                password.Append((char)random.Next(65, 91));

            return password.ToString();
        }
    }
}
