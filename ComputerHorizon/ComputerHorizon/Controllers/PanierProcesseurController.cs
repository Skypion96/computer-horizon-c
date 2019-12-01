using System.Collections.Generic;
using ComputerHorizon.ComponentsDAO;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PanierProcesseurController : ControllerBase
    {
        [HttpPost]
        public ComputerHorizon.Components.PanierProcesseur Post([FromBody]ComputerHorizon.Components.PanierProcesseur panierP)
        {
            return PanierProcesseurDAO.Post(panierP);
        }
        
        [HttpGet]
        public IEnumerable<ComputerHorizon.Components.PanierProcesseur> Get()
        {
            return PanierProcesseurDAO.QueryBase();
        }
    }
}