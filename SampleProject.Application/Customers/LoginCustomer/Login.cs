using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Application.Customers.LoginCustomer
{
    public class Login
    {
        public int Id { get; set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public Login(string email, string password)
        {
            Email = email;
            Password = password;
        }
       
    }
}
