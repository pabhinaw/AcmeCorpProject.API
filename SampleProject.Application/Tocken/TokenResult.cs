using SampleProject.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeCorpProject.Application.Tocken
{
    public class TokenResult : Result
    {
        public string Token { get; set; }
        public TokenResult(bool success, string message, string token = null) : base(success, message)
        {
            Token = token;
        }
    }
}
