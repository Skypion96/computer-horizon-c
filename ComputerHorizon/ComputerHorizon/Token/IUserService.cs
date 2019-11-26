﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using ComputerHorizon.ModelsUtilisateur;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ComputerHorizon.Token
{
    public interface IUserService
    {
        Utilisateur Authenticate(string mail, string mdp);
        IEnumerable<Utilisateur> GetAll();
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<Utilisateur> _users = new List<Utilisateur>
        { 
            new Utilisateur {NomUtilisateur = "Test", PrenomUtilisateur = "User", Mail = "test", Mdp = "test", Tel = "02020202", Rue = "test", NumRue = "20", Cp = 2000, Ville = "test"} 
        };

        private readonly Startup.AppSettings _appSettings;

        public UserService(IOptions<Startup.AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public Utilisateur Authenticate(string mail, string mdp)
        {
            var user = _users.SingleOrDefault(x => x.Mail == mail && x.Mdp == mdp);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.Token.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            //return user.WithoutPassword();
            return null;
        }

        public IEnumerable<Utilisateur> GetAll()
        {
            //return _users.WithoutPasswords();
            return null;
        }
    }
}