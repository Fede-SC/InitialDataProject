using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techpork.Core.Entities;

namespace Techpork.Infrastructure.Services
{
    public interface IIdentityService
    {
        User AddEmail(string email);
        bool Authenticate(string username, string password = null);
        void SendEmail(string email, string body, bool isForgotPassword = false);
        string GetToken(string email, User user = null, bool isActivation = false);
    }
}
