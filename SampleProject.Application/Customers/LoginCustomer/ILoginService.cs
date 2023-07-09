using AcmeCorpProject.Application.Tocken;
using SampleProject.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Application.Customers.LoginCustomer
{
    public interface ILoginService
    {
        Task<TokenResult> Authenticate(LoginDto loginDto);
        Task<TokenResult> GetRefreshToken(int loginId);
    }
}
