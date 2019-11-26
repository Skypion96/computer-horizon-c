using System.Collections.Generic;
using ComputerHorizon.ModelsDD;
using ComputerHorizon.ModelsUtilisateur;
using ComputerHorizon.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")] //ATENTION A LA ROUTE UTILISER
    public class UtilisateurController : ControllerBase
    {
        private IUserService _userService;
        
        //AFFICHAGE DE TOUT LES UTILISATEURS
        [HttpGet]
        public IEnumerable<ComputerHorizon.ModelsUtilisateur.Utilisateur> Get()
        {
            return UtilisateurDAO.QueryBase();
        }
        
        //AFFICHAGE D'UN UTILISATEUR PARTICULIER
        [Route("[controller]")]
        [HttpGet]
        public ComputerHorizon.ModelsUtilisateur.Utilisateur GetOneElement(Utilisateur user)
        {
            return UtilisateurDAO.Query(user);
        }

        //AJOUT D'UN NOUVEAU UTILISATEUR
        [HttpPost]
        public ComputerHorizon.ModelsUtilisateur.Utilisateur Post([FromBody]ComputerHorizon.ModelsUtilisateur.Utilisateur user)
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
        public ActionResult Update([FromBody]ComputerHorizon.ModelsUtilisateur.Utilisateur user)
        {
            return UtilisateurDAO.Update(user) ? (ActionResult) Ok():BadRequest();
        }

        public UtilisateurController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Mail, model.Mdp);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}