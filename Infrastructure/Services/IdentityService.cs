using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Techpork.Core.Entities;
using Techpork.Core.Extensions;
using Techpork.Core.Helpers;
using Techpork.Core.Repositories.Base;

namespace Techpork.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IRepository<User> _userRepository;
        private readonly AppSettings _appSettings;

        public IdentityService(
            IRepository<User> userRepository,
            IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        public User AddEmail(string email)
        {
            User user = new User
            {
                Email = email,
                AvatarUri = "Resources/Images/no_picture.png",
                Visible = true
            };

            return _userRepository.InsertReturnObj(user);
        }

        public bool Authenticate(string email, string password = null)
        {
            bool retVal = false;
            User user = null;
            if (email.IsValidEmail())
                user = _userRepository.GetByProperty("Email", email, true);
            else
                user = _userRepository.GetByProperty("Username", email, true);

            if (user != null)
            {
                if (password != null)
                {
                    string encryptPwd = user.Password;
                    retVal = SecurityService.Check(encryptPwd, password).Verified && user.Visible;
                }
                else
                {
                    retVal = user.Visible;
                }
            }

            return retVal;
        }

        public void SendEmail(string email, string body, bool isForgotPassword = false)
        {
            if (!email.IsValidEmail())
                return;
            var client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("64fe03c2e0d3a5", "81156f24aa214e"),
                EnableSsl = true
            };

            MailMessage message = new MailMessage();
            message.From = new MailAddress("from@example.com");
            message.Subject = isForgotPassword ? "Password reset request" : "Account confirmation";
            message.IsBodyHtml = true;
            message.Body = isForgotPassword
            ? $"Please log on this link and change your password: <a href='{body + GetToken(email, null)}'>{body + GetToken(email, null)}</a>"
            : $"Please confirm your account at the following link: <a href='{body + GetToken(email, null, true)}'>{body + GetToken(email, null, true)}</a>";
            message.To.Add(email);

            client.Send(message);
        }

        public string GetToken(string email, User user = null, bool isActivation = false)
        {
            if (user == null) user = _userRepository.GetByProperty("Email", email, true);
            if (user == null) return null;

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            List<Claim> claimList = new List<Claim>();
            // claims.Add(new Claim(ClaimTypes.Name, user.Username))
            claimList.Add(new Claim(ClaimTypes.Name, user.Email));
            claimList.Add(new Claim("activation", isActivation.ToString().ToLower()));

            var token = new JwtSecurityToken(
                claims: claimList,
                expires: DateTime.UtcNow.AddHours(_appSettings.Expiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
