using System.Collections.Generic;
using ComputerHorizon.ComponentsDAO;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PanierController : ControllerBase
    {
        //AJOUT D'UN NOUVEAU PROCESSEURS
        [HttpPost]
        public ComputerHorizon.Components.Panier Post([FromBody]ComputerHorizon.Components.Panier panier)
        {
            return PanierDAO.Post(panier);
        }
        
    }
}