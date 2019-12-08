using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using ComputerHorizon.Components;
using ComputerHorizon.ComponentsDAO;
using ComputerHorizon.Token;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ComputerHorizon.Controllers
{
    public interface IAdminService
    {
        AdminConnected Authenticate(string mail, string mdp);
        IEnumerable<Admin> GetAll();
    }

    public class AdminService : IAdminService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<Admin> _users = new List<Admin>
        {
            new Admin {Mail = "test", Mdp = "test"}
        };

        private readonly AppSettings _appSettings;

        public AdminService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public AdminConnected Authenticate(string mail, string mdp)
        {
            var user = AdminDAO.QueryBase()
                .SingleOrDefault(x => x.Mail == mail && BCrypt.Net.BCrypt.Verify(mdp,x.Mdp).Equals(true));

            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Mail)
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AdminConnected(tokenHandler.WriteToken(token));
        }

        public IEnumerable<Admin> GetAll()
        {
            List<Admin> admins = AdminDAO.QueryBase();
            return admins;
        }
    }
}