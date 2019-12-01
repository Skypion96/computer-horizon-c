using System.Collections.Generic;
using ComputerHorizon.Components;
using ComputerHorizon.ComponentsDAO;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")] //ATENTION A LA ROUTE UTILISER
    public class CarteGraphiqueController : ControllerBase
    {
        //AFFICHAGE DE TOUTES LES CARTES GRAPHIQUES / IMAGE + NOM +MARQUE
        [HttpGet]
        public IEnumerable<ComputerHorizon.Components.CarteGraphique> Get()
        {
            return CarteGraphiqueDao.QueryBase();
        }
          
        
        //AFFICHAGE D'UNE CARTE GRAPHIQUE PARTICULIERE
        [Route("[controller]")]
        [HttpGet]
        public ComputerHorizon.Components.CarteGraphique GetOneElement(CarteGraphique carteG)
        {
            return CarteGraphiqueDao.Query(carteG);
        }

        //AJOUT D'UNE NOUVELLE CARTE GRAPHIQUE
        [HttpPost]
        public ComputerHorizon.Components.CarteGraphique Post([FromBody]ComputerHorizon.Components.CarteGraphique carteG)
        {
            return CarteGraphiqueDao.Post(carteG);
        }
      
        //SUPPRESSION D'UNE CARTE GRAPHIQUE PARTICULIERE
        [HttpDelete("{id}")]
        public ActionResult Delete(string nom)
        {
            return CarteGraphiqueDao.Delete(nom) ? (ActionResult) Ok() : BadRequest();
        }
        
        //MISE A JOUR DES INFORMATIONS D'UNE CARTE GRAPHIQUE
        [HttpPut]
        public ActionResult Update([FromBody]ComputerHorizon.Components.CarteGraphique carteG)
        {
            return CarteGraphiqueDao.Update(carteG) ? (ActionResult) Ok():BadRequest();
        }
    }
}