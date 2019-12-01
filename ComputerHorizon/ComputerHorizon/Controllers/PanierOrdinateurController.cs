using System.Collections.Generic;
using ComputerHorizon.ComponentsDAO;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PanierOrdinateurController : ControllerBase
    {
        [HttpPost]
        public ComputerHorizon.Components.PanierOrdinateur Post([FromBody]ComputerHorizon.Components.PanierOrdinateur panierO)
        {
            return PanierOrdinateurDAO.Post(panierO);
        }
        
        [HttpGet]
        public IEnumerable<ComputerHorizon.Components.PanierOrdinateur> Get()
        {
            return PanierOrdinateurDAO.QueryBase();
        }
    }
}