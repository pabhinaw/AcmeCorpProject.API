using AcmeCorpProject.Application.Tocken;
using SampleProject.Application.Results;
using SampleProject.Application.Tocken;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Application.Customers.LoginCustomer
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IHashService _hashService;
        private readonly ITokenService _tokenService;

        public LoginService(ILoginRepository loginRepository,
            IHashService hashService,
            ITokenService tokenService)
        {
            _loginRepository = loginRepository;
            _hashService = hashService;
            _tokenService = tokenService;
        }

        public async Task<TokenResult> GetRefreshToken(int loginId)
        {
            var login = await _loginRepository.GetById(loginId);

            try
            {
                if (login == null)
                    return new TokenResult(false, "This email does not exists");

                string token = _tokenService.GenerateToken(login.Id, login.Email);
                return new TokenResult(true, "Token generated", token);
            }
            catch (Exception exception)
            {
                return new TokenResult(false, exception.Message);
            }
        }

        public async Task<TokenResult> Authenticate(LoginDto loginDto)
        {
            var login = await _loginRepository.GetByEmail(loginDto.Email);

            try
            {
                if (login == null)
                    return new TokenResult(false, "This email does not exists");

                if (login.Password != _hashService.Hash(loginDto.Password))
                    return new TokenResult(false, "Invalid password");

                string token = _tokenService.GenerateToken(login.Id, login.Email);
                return new TokenResult(true, "Authenticated", token);
            }
            catch (Exception exception)
            {
                return new TokenResult(false, exception.Message);
            }
        }
    }
}
