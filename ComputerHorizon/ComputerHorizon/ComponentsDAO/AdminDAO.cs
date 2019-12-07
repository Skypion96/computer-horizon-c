using System.Collections.Generic;
using System.Data.SqlClient;
using ComputerHorizon.Components;
using ComputerHorizon.Models;

namespace ComputerHorizon.ComponentsDAO
{
    public class AdminDAO
    {
        private static readonly string TABLE_NAME = "admin";
        
        public static readonly string FIELD_MAIL = "mail";
        public static readonly string FIELD_MDP = "mdp";
        
        private static readonly string REQ_QUERY = $"SELECT * FROM {TABLE_NAME} " +
                                                   $" WHERE {FIELD_MAIL} = @{FIELD_MAIL} AND {FIELD_MDP} = @{FIELD_MDP}";
        
        private static readonly string REQ_QUERY_BASE = $"SELECT * FROM {TABLE_NAME}";
        
        public static Admin Query(string mail, string mdp)
        {
            Admin admin = null;
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_QUERY;
                command.Parameters.AddWithValue($"@{FIELD_MAIL}", mail);
                command.Parameters.AddWithValue($"@{FIELD_MDP}", mdp);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    admin = new Admin(reader);
                }
            }
            return admin;
        }
        
        
        //AFFICHAGE
        public static List<Admin> QueryBase()
        {
            List<Admin> admins = new List<Admin>();
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_QUERY_BASE;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    admins.Add(new Admin(reader));
                }
            }
            return admins;
        }
    }
}