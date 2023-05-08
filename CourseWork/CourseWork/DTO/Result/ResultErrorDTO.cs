using System.Collections.Generic;

namespace CourseWork.DTO.Result
{
    public class ResultErrorDTO : ResultDTO
    {
        public List<string> Errors { get; set; }
    }
}
