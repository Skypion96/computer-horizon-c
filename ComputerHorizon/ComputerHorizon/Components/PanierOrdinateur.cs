using System;
using System.Data.SqlClient;
using ComputerHorizon.ComponentsDAO;

namespace ComputerHorizon.Components
{
    public class PanierOrdinateur
    {
        public int Id { get; set; }
        
        public string Nom { get; set; }
        
        public PanierOrdinateur(){}

        public PanierOrdinateur(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }
        
        public PanierOrdinateur(SqlDataReader reader)
        {
            Id = Convert.ToInt32(reader[PanierOrdinateurDAO.FIELD_ID].ToString());
            Nom = reader[PanierOrdinateurDAO.FIELD_NOM].ToString();
        }
    }
}