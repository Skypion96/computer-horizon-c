using System.Collections.Generic;
using ComputerHorizon.ModelsCG;
using Microsoft.AspNetCore.Mvc;

namespace ComputerHorizon.Controllers
{
    [ApiController]
    [Route("[controller]")] //ATENTION A LA ROUTE UTILISER
    public class CarteGraphiqueController : ControllerBase
    {
        //AFFICHAGE DE TOUTES LES CARTES GRAPHIQUES / IMAGE + NOM +MARQUE
        [HttpGet]
        public IEnumerable<ComputerHorizon.ModelsCG.CarteGraphique> Get()
        {
            return CarteGraphiqueDao.QueryBase();
        }
          
        
        //AFFICHAGE D'UNE CARTE GRAPHIQUE PARTICULIERE
        [Route("[controller]")]
        [HttpGet]
        public ComputerHorizon.ModelsCG.CarteGraphique GetOneElement(CarteGraphique carteG)
        {
            return CarteGraphiqueDao.Query(carteG);
        }

        //AJOUT D'UNE NOUVELLE CARTE GRAPHIQUE
        [HttpPost]
        public ComputerHorizon.ModelsCG.CarteGraphique Post([FromBody]ComputerHorizon.ModelsCG.CarteGraphique carteG)
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
        public ActionResult Update([FromBody]ComputerHorizon.ModelsCG.CarteGraphique carteG)
        {
            return CarteGraphiqueDao.Update(carteG) ? (ActionResult) Ok():BadRequest();
        }
    }
}