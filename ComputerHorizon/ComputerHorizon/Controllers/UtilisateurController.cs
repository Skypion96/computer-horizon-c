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
        private IUserService _userService;
        
        public UtilisateurController(IUserService userService)
        {
            _userService = userService;
        }

        //AFFICHAGE DE TOUT LES UTILISATEURS
        [HttpGet("all")]
        public IEnumerable<ComputerHorizon.Components.Utilisateur> GetAll()
        {
            return UtilisateurDAO.QueryBase();
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

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult<UserConnected> Authenticate([FromBody] AuthenticateModel model)
        {
            UserConnected token = _userService.Authenticate(model.Mail, model.Mdp);

            if (token == null)
                return BadRequest(new { message = "Mail or password is incorrect" });
            return Ok(token);
        }
        
        [HttpGet]
        public Utilisateur Get([FromBody] AuthenticateModel model)
        {
            return UtilisateurDAO.Query(model.Mail, model.Mdp);
        }
    }
}