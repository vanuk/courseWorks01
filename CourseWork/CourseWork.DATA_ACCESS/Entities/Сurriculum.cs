using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CourseWork.DATA_ACCESS.Entities
{
    public class Сurriculum
    {
        public Сurriculum()
        {
            Subjects = new List<Subject>();
            Groups = new List<Group>();
        }

        [Key] 
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }    
        public int Year { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
