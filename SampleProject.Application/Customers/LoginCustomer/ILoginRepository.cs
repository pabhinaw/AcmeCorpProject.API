using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Application.Customers.LoginCustomer
{
    public interface ILoginRepository
    {         
        Task<Login> GetById(int id);
        Task<Login> GetByEmail(string email);
        Task<Login> Add(Login entity);
    }
}
