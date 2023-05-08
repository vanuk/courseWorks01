using CourseWork.DATA_ACCESS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork.DOMAIN.JWT
{
    public interface IJWTTokenServices
    {
        string CreateToken(User user);
    }
}
