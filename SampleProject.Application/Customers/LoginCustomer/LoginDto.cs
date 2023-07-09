using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Application.Customers.LoginCustomer
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginDto(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
