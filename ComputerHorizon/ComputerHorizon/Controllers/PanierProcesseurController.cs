using ComputerHorizon.ComponentsDAO;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    public class PanierProcesseurController : ControllerBase
    {
        [HttpPost]
        public ComputerHorizon.Components.PanierProcesseur Post([FromBody]ComputerHorizon.Components.PanierProcesseur panierP)
        {
            return PanierProcesseurDAO.Post(panierP);
        }
    }
}