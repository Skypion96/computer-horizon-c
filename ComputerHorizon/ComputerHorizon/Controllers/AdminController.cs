using System.Collections.Generic;
using ComputerHorizon.Components;
using ComputerHorizon.ComponentsDAO;
using ComputerHorizon.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private IAdminService _adminService;
        
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        //AFFICHAGE DE TOUT LES UTILISATEURS
        [HttpGet("all")]
        public IEnumerable<ComputerHorizon.Components.Admin> GetAll()
        {
            return AdminDAO.QueryBase();
        }
        
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult<AdminConnected> Authenticate([FromBody] AuthenticateModel model)
        {
            AdminConnected token = _adminService.Authenticate(model.Mail, model.Mdp);

            if (token == null)
                return BadRequest(new { message = "Mail or password is incorrect" });
            return Ok(token);
        }
        
        [HttpGet]
        public Admin Get([FromBody] AuthenticateModel model)
        {
            return AdminDAO.Query(model.Mail, model.Mdp);
        }
    }
}