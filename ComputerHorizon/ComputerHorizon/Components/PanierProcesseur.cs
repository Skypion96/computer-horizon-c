using System;
using System.Data.SqlClient;
using ComputerHorizon.ComponentsDAO;

namespace ComputerHorizon.Components
{
    public class PanierProcesseur
    {
        public int Id { get; set; }
        
        public string Nom { get; set; }
        
        public PanierProcesseur(){}
        
        public PanierProcesseur(int id, string nom){}
        
        public PanierProcesseur(SqlDataReader reader)
        {
            Id = Convert.ToInt32(reader[PanierProcesseurDAO.FIELD_ID].ToString());
            Nom = reader[PanierProcesseurDAO.FIELD_NOM].ToString();
        }
    }
}