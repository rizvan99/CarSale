using CarSale.Core.Entity.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSale.Core.Application_Service.Interface
{
    public interface IAuthenticationService
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
        string GenerateToken(User user);

    }
}
