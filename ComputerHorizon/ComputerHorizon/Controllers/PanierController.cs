using System.Collections.Generic;
using ComputerHorizon.ModelsDD;
using ComputerHorizon.ModelsPanier;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PanierController : ControllerBase
    {
        //AJOUT D'UN NOUVEAU PROCESSEURS
        [HttpPost]
        public ComputerHorizon.ModelsPanier.Panier Post([FromBody]ComputerHorizon.ModelsPanier.Panier panier)
        {
            return PanierDAO.Post(panier);
        }
        
    }
}