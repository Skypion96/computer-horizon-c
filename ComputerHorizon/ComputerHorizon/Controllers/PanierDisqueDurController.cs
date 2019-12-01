using System.Collections.Generic;
using ComputerHorizon.ComponentsDAO;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PanierDisqueDurController : ControllerBase
    {
        [HttpPost]
        public ComputerHorizon.Components.PanierDisqueDur Post([FromBody]ComputerHorizon.Components.PanierDisqueDur panierDD)
        {
            return PanierDisqueDurDAO.Post(panierDD);
        }
        
        [HttpGet]
        public IEnumerable<ComputerHorizon.Components.PanierDisqueDur> Get()
        {
            return PanierDisqueDurDAO.QueryBase();
        }
    }
}