using System;
using System.Data.SqlClient;
using ComputerHorizon.ComponentsDAO;
using ComputerHorizon.Controllers;

namespace ComputerHorizon.Components
{
    public class Panier
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        
        public Panier(){}

        public Panier(int id,string mail)
        {
            Id = id;
            Mail = mail;
        }
        
        public Panier(SqlDataReader reader)
        {
            Id = Convert.ToInt32(reader[PanierDAO.FIELD_ID].ToString());
            Mail = reader[PanierDAO.FIELD_MAIL].ToString();
        }
    }
}