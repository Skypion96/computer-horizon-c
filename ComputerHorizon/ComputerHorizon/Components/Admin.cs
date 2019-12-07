using System.Data.SqlClient;
using ComputerHorizon.ComponentsDAO;

namespace ComputerHorizon.Components
{
    public class Admin
    {
        public string Mail { get; set; }
        public string Mdp { get; set; }

        public Admin(string mail, string mdp)
        {
            Mail = mail;
            Mdp = mdp;
        }

        public Admin()
        {
        }
        
        public Admin(SqlDataReader reader)
        {
            Mail = reader[AdminDAO.FIELD_MAIL].ToString();
            Mdp = reader[AdminDAO.FIELD_MDP].ToString();
        }
    }
}