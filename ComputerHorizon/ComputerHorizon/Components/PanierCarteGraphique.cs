using System;
using System.Data.SqlClient;
using ComputerHorizon.ComponentsDAO;

namespace ComputerHorizon.Components
{
    public class PanierCarteGraphique
    {
        public int Id { get; set; }
        
        public string Nom { get; set; }
        
        public PanierCarteGraphique(){}

        public PanierCarteGraphique(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }
        
        public PanierCarteGraphique(SqlDataReader reader)
        {
            Id = Convert.ToInt32(reader[PanierCarteGraphiqueDAO.FIELD_ID].ToString());
            Nom = reader[PanierCarteGraphiqueDAO.FIELD_NOM].ToString();
        }
    }
}