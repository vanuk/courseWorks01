using CourseWork.DATA_ACCESS;
using CourseWork.DATA_ACCESS.Constants;
using CourseWork.DATA_ACCESS.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CourseWork.DOMAIN.Seeder
{
    public class SeederDatabase
    {
        public static void SeedDb(IServiceProvider services, IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var manager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var context = scope.ServiceProvider.GetRequiredService<EFContext>();
                SeedData(manager, managerRole, context);
            }
        }

        public static void SeedData(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager, EFContext context)
        {
            var roleName = "user";
            if (roleManager.FindByNameAsync(roleName).Result == null)
            {
                var resUserRole = roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                }).Result;

                var users = new List<User>()
                {
                    new User() {
                        LastName = "Мерцалова",
                        FirstName = "Ірина",
                        MiddleName = "Сергіївна",
                        CooperativeEmail = "mertsalova_ak21@nuwm.edu.ua",
                        Email = "mertsalova_ak21@nuwm.edu.ua",
                        UserName = "mertsalova_ak21@nuwm.edu.ua"
                    },
                    new User() {
                        LastName = "Мельник",
                        FirstName = "Яна",
                        MiddleName = "Василівна",
                        CooperativeEmail = "melnuk_ak20@nuwm.edu.ua",
                        Email = "melnuk_ak20@nuwm.edu.ua",
                        UserName = "melnuk_ak20@nuwm.edu.ua"
                    },
                    new User() {
                        LastName = "Білоус",
                        FirstName = "Діана",
                        MiddleName = "Вікторівна",
                        CooperativeEmail = "bilous_ak21@nuwm.edu.ua",
                        Email = "bilous_ak21@nuwm.edu.ua",
                        UserName = "bilous_ak21@nuwm.edu.ua"
                    },
                    new User() {
                        LastName = "Жуковський",
                        FirstName = "Віктор",
                        MiddleName = "Володимирович",
                        CooperativeEmail = "v.v.zhukovskyy@nuwm.edu.ua",
                        Email = "v.v.zhukovskyy@nuwm.edu.ua",
                        UserName = "v.v.zhukovskyy@nuwm.edu.ua"
                    },
                    new User() {
                        LastName = "Мічута",
                        FirstName = "Ольга",
                        MiddleName = "Романівна",
                        CooperativeEmail = "o.r.michuta@nuwm.edu.ua",
                        Email = "o.r.michuta@nuwm.edu.ua",
                        UserName = "o.r.michuta@nuwm.edu.ua"
                    }
                };

                foreach (var item in users)
                {
                    var resultUser = userManager.CreateAsync(item, $"{item.LastName}Uu12!").Result;
                    resultUser = userManager.AddToRoleAsync(item, roleName).Result;
                }
                context.SaveChanges();
            }


            var speciallities = new List<Speciality>()
                {
                    new Speciality() {
                        Name = "Інженерія програмного забезпечення",
                        Code = "121",
                        Description = "Інженерія прогамного забезпечення – це наука про принципи та методи, які застосовуються при розробці та супроводженні програмних систем. " +
                    "Вона вивчає застосування процеси розробки, експлуатації та супроводження програмного забезпечення (ПЗ), застосування принципів інженерії щодо процесу розробки ПЗ." },
                    new Speciality() {
                        Name = "Інформаційні системи і технології",
                        Code = "126",
                        Description = "Основним напрямком спеціалізації “Інформаційні системи та технології” є розробка та " +
                        "практичне використання інформаційних технологій з акцентом на системах Internet of things, Cloud сервісах, Big Data (сховищ)." },
                    new Speciality() {
                        Name = "Комп'ютерні науки",
                        Code = "122",
                        Description = "Комп'ютерні науки – загальна назва для групи дисциплін, які займаються різними аспектами розробки та застосування комп'ютерів, такими, " +
                        "як програмування, методи комп'ютерного та математичного моделювання, мови програмування, операційні системи, штучний інтелект, архітектура обчислювальних систем."
                    }
                };
            context.Specialities.AddRange(speciallities);

            context.SaveChanges();

            var groups = new List<Group>()
                {
                    new Group() { Name = "ІПЗ-21", FormOfStudying = "денна", SpecialityId = 1 },
                    new Group() { Name = "ІСТ-31", FormOfStudying = "денна", SpecialityId = 2 },
                    new Group() { Name = "КН-21", FormOfStudying = "денна", SpecialityId = 3 }
                };
            context.Groups.AddRange(groups);
            context.SaveChanges();
            var user = context.Users.ToList()[0].Id;
            var students = new List<Student>()
                {
                    new Student() { Id = context.Users.ToList()[0].Id, UserId = context.Users.ToList()[0].Id, OwnEmail = "irynamertsalova@gmail.com", GroupId = 1 },
                    new Student() { Id = context.Users.ToList()[1].Id, UserId = context.Users.ToList()[1].Id, OwnEmail = "yanamelnuk@gmail.com", GroupId = 2 },
                    new Student() { Id = context.Users.ToList()[2].Id, UserId = context.Users.ToList()[2].Id, OwnEmail = "dianabilous@gmail.com", GroupId = 3 }
                };
            context.Students.AddRange(students);

            var teachers = new List<Teacher>()
                {
                    new Teacher() { Id = context.Users.ToList()[3].Id, UserId = context.Users.ToList()[3].Id },
                    new Teacher() { Id = context.Users.ToList()[4].Id, UserId = context.Users.ToList()[4].Id }
                };
            context.Teachers.AddRange(teachers);

            context.SaveChanges();

            var subjects = new List<Subject>()
                {
                    new Subject() {
                        Name = "Об'єктно-орієнтоване програмування",
                        FormOfControl = FormOfControl.екзамен,
                        Credits = 6,
                        Lectures = 28,
                        Labworks = 56,
                        Practical = 0,
                        Description = "Об'єктно - орієнтоване програмування (ООП) – це модель програмування " +
                    "яка базується на стверджені того, що програма це сукупність об’єктів які взаємодіють між собою."
                    },
                    new Subject() {
                        Name = "Комп'ютерна дискретна математика",
                        FormOfControl = FormOfControl.екзамен,
                        Credits = 4,
                        Lectures = 28,
                        Labworks = 24,
                        Practical = 0,
                        Description = "Дискретна математика — галузь математики, що вивчає властивості будь-яких дискретних структур."
                    },
                    new Subject() {
                        Name = "Комп’ютерна графіка",
                        FormOfControl = FormOfControl.залік,
                        Credits = 4,
                        Lectures = 26,
                        Labworks = 22,
                        Practical = 0,
                        Description = "Мета дисципліни — формування в студентів фундаментальних теоретичних знань і практичних " +
                    "навичок застосування комп'ютерних засобів при виконанні завдань, що включають створення графічних об'єктів різних типів. "
                    },
                    new Subject() {
                        Name = "Оптимізація обчислень",
                        FormOfControl = FormOfControl.вибіркова,
                        Credits = 3,
                        Lectures = 16,
                        Labworks = 14,
                        Practical = 0,
                        Description = "Оптимізація обчислень в математиці, інформатиці та дослідженні операцій називають відбір найкращого елементу (за певним критерієм) з множини доступних альтернатив."
                    }
                };
            context.Subjects.AddRange(subjects);
            context.SaveChanges();

            var subjectTeacher = new List<SubjectTeacher>()
                {
                    new SubjectTeacher(){ SubjectId = 1, TeacherId = context.Teachers.ToList()[0].Id  },
                    new SubjectTeacher(){ SubjectId = 2, TeacherId = context.Teachers.ToList()[1].Id },
                    new SubjectTeacher(){ SubjectId = 3, TeacherId = context.Teachers.ToList()[1].Id },
                    new SubjectTeacher(){ SubjectId = 4, TeacherId = context.Teachers.ToList()[0].Id },
                };
            context.SubjectTeachers.AddRange(subjectTeacher);

            var curriculums = new List<Сurriculum>()
            {
                new Сurriculum() {
                    Name = "Програмне забезпечення",
                    Year = 2021,
                    Subjects = new List<Subject>() {
                        context.Subjects.ToList()[0],
                        context.Subjects.ToList()[1],
                        context.Subjects.ToList()[2] },
                    Groups = new List<Group>(){
                        context.Groups.ToList()[0],
                        context.Groups.ToList()[1] }
                },
                new Сurriculum() {
                    Name = "Оптимізація обчислень в математиці",
                    Year = 2020,
                    Subjects = new List<Subject>() {
                        context.Subjects.ToList()[1],
                        context.Subjects.ToList()[2],
                        context.Subjects.ToList()[3] },
                    Groups = new List<Group>() {
                        context.Groups.ToList()[2]
                    }
                }
            };
            context.Сurriculums.AddRange(curriculums);

            var studentAssesments = new List<StudentAssessment>()
            {
                new StudentAssessment() {
                 StudentId = context.Users.ToList()[0].Id,
                 SubjectId = 1,
                 Value = 80
                },
                new StudentAssessment() {
                 StudentId = context.Users.ToList()[0].Id,
                 SubjectId = 2,
                 Value = 85
                },
                new StudentAssessment() {
                 StudentId = context.Users.ToList()[0].Id,
                 SubjectId = 3,
                 Value = 89
                },
                new StudentAssessment() {
                 StudentId = context.Users.ToList()[1].Id,
                 SubjectId = 1,
                 Value = 90
                },
                new StudentAssessment() {
                 StudentId = context.Users.ToList()[1].Id,
                 SubjectId = 2,
                 Value = 99
                },
                new StudentAssessment() {
                 StudentId = context.Users.ToList()[1].Id,
                 SubjectId = 3,
                 Value = 81
                },
                new StudentAssessment() {
                 StudentId = context.Users.ToList()[2].Id,
                 SubjectId = 2,
                 Value = 82
                },
                new StudentAssessment() {
                 StudentId = context.Users.ToList()[2].Id,
                 SubjectId = 3,
                 Value = 88
                },
                new StudentAssessment() {
                 StudentId = context.Users.ToList()[2].Id,
                 SubjectId = 4,
                 Value = 91
                }
            };
            context.StudentAssessments.AddRange(studentAssesments);

            context.SaveChanges();
        }
    }
}
