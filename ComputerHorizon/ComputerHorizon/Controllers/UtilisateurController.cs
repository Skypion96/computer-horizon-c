using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ComputerHorizon.Components;
using ComputerHorizon.ComponentsDAO;
using ComputerHorizon.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")] //ATENTION A LA ROUTE UTILISER
    public class UtilisateurController : ControllerBase
    {
        //private IUserService _userService;

        //AFFICHAGE DE TOUT LES UTILISATEURS
        [HttpGet]
        public IEnumerable<ComputerHorizon.Components.Utilisateur> Get()
        {
            return UtilisateurDAO.QueryBase();
        }
        
        //AFFICHAGE D'UN UTILISATEUR PARTICULIER
        [Route("[controller]")]
        [HttpGet]
        public ComputerHorizon.Components.Utilisateur GetOneElement(Utilisateur user)
        {
            return UtilisateurDAO.Query(user);
        }

        //AJOUT D'UN NOUVEAU UTILISATEUR
        [HttpPost]
        public ComputerHorizon.Components.Utilisateur Post([FromBody]ComputerHorizon.Components.Utilisateur user)
        {
            return UtilisateurDAO.Post(user);
        }
        
        //SUPPRESSION D'UN UTILISATEUR PARTICULIER
        [HttpDelete("{mail}")]
        public ActionResult Delete(string mail)
        {
            return UtilisateurDAO.Delete(mail) ? (ActionResult) Ok() : BadRequest();
        }
        
        //MISE A JOUR DES INFORMATIONS D'UN UTILISATEUR
        [HttpPut]
        public ActionResult Update([FromBody]ComputerHorizon.Components.Utilisateur user)
        {
            return UtilisateurDAO.Update(user) ? (ActionResult) Ok():BadRequest();
        }

       /*public UtilisateurController(IUserService userService)
        {
            _userService = userService;
        }*/
        
        private readonly Startup.AppSettings _appSettings;
        public UtilisateurController(IOptions<Startup.AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        /*public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = UtilisateurController.Authenticate(model.Mail, model.Mdp);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(user);
        }*/

        [HttpGet]
        public IEnumerable<Utilisateur> GetAll()
        {
            List<Utilisateur> users = UtilisateurDAO.QueryBase();
            return users;
        }
    }
}