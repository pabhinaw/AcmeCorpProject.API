using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Application.Tocken
{
    public interface ITokenService
    {
        string GenerateToken(int loginId, string email);
    }
}
