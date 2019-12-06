using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using ComputerHorizon.Components;
using ComputerHorizon.ComponentsDAO;
using ComputerHorizon.Controllers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using static ComputerHorizon.Token.ExtensionMethods;

namespace ComputerHorizon.Token
{
    public interface IUserService
    {
        UserConnected Authenticate(string mail, string mdp);
        IEnumerable<Utilisateur> GetAll();
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<Utilisateur> _users = new List<Utilisateur>
        { 
            new Utilisateur {NomUtilisateur = "Test", PrenomUtilisateur = "User", Mail = "test", Mdp = "test", Tel = "02020202", Rue = "test", NumRue = "20", Cp = 2000, Ville = "test"} 
        };

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public UserConnected Authenticate(string mail, string mdp)
        {
            var user = UtilisateurDAO.QueryBase()
                .SingleOrDefault(x => x.Mail == mail && x.Mdp == mdp);
            
            if(user == null) return null;
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Mail) 
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new UserConnected(tokenHandler.WriteToken(token));
        }

        public IEnumerable<Utilisateur> GetAll()
        {
            List<Utilisateur> users = UtilisateurDAO.QueryBase();
            return users;
        }
    }
}