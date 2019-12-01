using System;
using System.Data.SqlClient;
using ComputerHorizon.ComponentsDAO;

namespace ComputerHorizon.Components
{
    public class PanierDisqueDur
    {
        public int Id { get; set; }
        
        public string Nom { get; set; }
        
        public PanierDisqueDur(){}

        public PanierDisqueDur(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }
        
        public PanierDisqueDur(SqlDataReader reader)
        {
            Id = Convert.ToInt32(reader[PanierDisqueDurDAO.FIELD_ID].ToString());
            Nom = reader[PanierDisqueDurDAO.FIELD_NOM].ToString();
        }
    }
}