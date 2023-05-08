using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using CourseWork.DTO;
using CourseWork.DATA_ACCESS;
using CourseWork.DATA_ACCESS.Entities;
using CourseWork.DATA_ACCESS.Constants;
using CourseWork.DTO.Result;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using CourseWork.DOMAIN.Validator;
using CourseWork.DOMAIN.JWT;
using System.IO;
using System.Text;

namespace CourseWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EFContext context;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IJWTTokenServices jwtTokenService;

        public UserController(
            EFContext _context,
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            IJWTTokenServices _jwtTokenService
            )
        {
            this.context = _context;
            this.userManager = _userManager;
            this.signInManager = _signInManager;
            this.jwtTokenService = _jwtTokenService;
        }

        [HttpPost("login")]
        public async Task<ResultDTO> Login([FromBody] LoginDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new ResultErrorDTO
                    {
                        Message = "ERROR",
                        Status = 401,
                        Errors = CustomValidator.getErrorsByModel(ModelState)
                    };
                }

                var result = signInManager.PasswordSignInAsync(model.Email, model.Password, false, false).Result;

                if (!result.Succeeded)
                {
                    return new ResultErrorDTO
                    {
                        Status = 403,
                        Message = "ERROR",
                        Errors = new List<string> { "Incorrect email or password" }
                    };
                }
                else
                {
                    var user = await userManager.FindByEmailAsync(model.Email);
                    await signInManager.SignInAsync(user, false);


                    return new ResultLoginDTO
                    {
                        Status = 200,
                        Message = "OK",
                        Token = jwtTokenService.CreateToken(user)
                    };
                }
            }
            catch (Exception e)
            {
                return new ResultErrorDTO
                {
                    Status = 500,
                    Message = "ERROR",
                    Errors = new List<string> { e.Message }
                };
            }
        }

        [HttpGet("get-assessments-by-email")]
        public List<StudentAssessmentDTO> GetAssessmentsByStudentEmail([FromQuery] string email)
        {
            var user = context.Students.FirstOrDefault(x => context.Users.FirstOrDefault(u => u.Id == x.UserId).CooperativeEmail == email);
            return context.StudentAssessments.Where(x => x.StudentId == user.Id)
                .Select(a => new StudentAssessmentDTO()
                {
                    Id = a.Id,
                    StudentName = user.OwnEmail,
                    SubjectName = context.Subjects.FirstOrDefault(x => x.Id == a.SubjectId).Name,
                    Value = a.Value
                }).ToList();
        }

        [HttpGet("get-classmates-by-email")]
        public List<StudentDTO> GetClassmatesByStudentId([FromQuery] string email)
        {
            var user = context.Students.FirstOrDefault(x => context.Users.FirstOrDefault(u => u.Id == x.UserId).CooperativeEmail == email);
            return context.Students.Where(x => x.GroupId == user.GroupId)
                .Select(st => GetCurrentStudent(context.Users.FirstOrDefault(u => u.Id == st.UserId).CooperativeEmail)).ToList();
        }

        [HttpGet("get-group-by-email")]
        public GroupDTO GetGroupByStudentId([FromQuery] string email)
        {
            var group = context.Groups.FirstOrDefault(g => g.Id == context.Students.FirstOrDefault(st => context.Users.FirstOrDefault(u => u.CooperativeEmail == email).CooperativeEmail == email).GroupId);
            var curriculum = context.Сurriculums.FirstOrDefault(c => c.Id == group.СurriculumId);
            return new GroupDTO()
            {
                Id = group.Id,
                FormOfStudying = group.FormOfStudying,
                Name = group.Name,
                Speciality = context.Specialities.FirstOrDefault(s => s.Id == group.SpecialityId).Name,
                Сurriculum = $"{curriculum.Name} {curriculum.Year}",
                Students = GetClassmatesByStudentId(email)
            };
        }

        [HttpGet("get-current-student")]
        public StudentDTO GetCurrentStudent([FromQuery] string email)
        {
            var user = context.Students.FirstOrDefault(st => context.Users.FirstOrDefault(u => u.Id == st.UserId).CooperativeEmail == email);
            var st = context.Users.FirstOrDefault(u => u.Id == user.Id);
            if (email == null)
            {
                return new StudentDTO();
            }
            else
            {
                return new StudentDTO()
                {
                    Id = user.Id,
                    CooperativeEmail = st.CooperativeEmail,
                    FirstName = st.FirstName,
                    LastName = st.LastName,
                    MiddleName = st.MiddleName,
                    GroupName = context.Groups.FirstOrDefault(g => g.Id == user.GroupId).Name,
                    OwnEmail = user.OwnEmail,
                    Assessments = GetAssessmentsByStudentEmail(email)
                };
            }
        }

        [HttpGet("get-data-teacher")]
        public TeacherDTO GetDataTeacher([FromQuery] string email)
        {
            var user = context.Users.FirstOrDefault(u => u.CooperativeEmail == email);
            var teacher = context.Teachers.FirstOrDefault(t => t.Id == user.Id);
            return new TeacherDTO()
            {
                Id = teacher.Id,
                CooperativeEmail = user.CooperativeEmail,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Subjects = context.SubjectTeachers.Where(s => s.TeacherId == teacher.Id).Select(n => new SubjectDTO()
                {
                    Id = context.Subjects.FirstOrDefault(x => x.Id == n.SubjectId).Id,
                    Description = context.Subjects.FirstOrDefault(x => x.Id == n.SubjectId).Description,
                    Credits = context.Subjects.FirstOrDefault(x => x.Id == n.SubjectId).Credits,
                    FormOfControl = ((FormOfControl)context.Subjects.FirstOrDefault(x => x.Id == n.SubjectId).FormOfControl).ToString(),
                    Labworks = context.Subjects.FirstOrDefault(x => x.Id == n.SubjectId).Labworks,
                    Lectures = context.Subjects.FirstOrDefault(x => x.Id == n.SubjectId).Lectures,
                    Name = context.Subjects.FirstOrDefault(x => x.Id == n.SubjectId).Name,
                    Practical = context.Subjects.FirstOrDefault(x => x.Id == n.SubjectId).Practical,
                    Teachers = null

                }).ToList()
            };
        }
    }
}