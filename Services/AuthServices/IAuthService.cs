using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AuthServices
{
    public interface IAuthService
    {
        bool VerifyPassword(string hashedPasswordWithSalt, string passwordToCheck);
        string HashPassword(string password, byte[] salt = null, bool needsOnlyHash = false);
    }
}
