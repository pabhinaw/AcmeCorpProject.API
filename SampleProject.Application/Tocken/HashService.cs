using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Application.Tocken
{
    public class HashService : IHashService
    {
        private readonly IConfiguration _configuration;

        public HashService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetSalt() => _configuration.GetConnectionString("Salt");

        public string Hash(string text)
        {
            byte[] salt = System.Text.UnicodeEncoding.Unicode.GetBytes(GetSalt());

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: text,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
