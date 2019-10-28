using System.Collections.Generic;
using System.Data.SqlClient;
using ComputerHorizon.Models;

namespace ComputerHorizon.ModelsProc
{
    public static class ProcesseurDao
    {
        private static readonly string TABLE_NAME = "processeur";
        
        public static readonly string FIELD_NOM = "nom";
        public static readonly string FIELD_MARQUE = "marque";
        public static readonly string FIELD_NBCOEURS = "nbCoeurs";
        public static readonly string FIELD_FREQUENCE = "frequence";
        public static readonly string FIELD_PRIX = "prix";
        public static readonly string FIELD_QUANTITE = "quantite";
        public static readonly string FIELD_IMG = "img";
        
        private static readonly string REQ_QUERY = $"SELECT * FROM {TABLE_NAME}";

        private static readonly string REQ_POST = 
            $"INSERT INTO {TABLE_NAME} ({FIELD_MARQUE},{FIELD_NBCOEURS},{FIELD_FREQUENCE},{FIELD_PRIX},{FIELD_QUANTITE},{FIELD_IMG})" +
            $" OUTPUT Inserted.{FIELD_NOM}" +
            $" VALUES (@{FIELD_MARQUE},@{FIELD_NBCOEURS},@{FIELD_FREQUENCE},@{FIELD_PRIX},@{FIELD_QUANTITE},@{FIELD_IMG})";

        public static List<Processeur> Query()
        {
            List<Processeur> procs = new List<Processeur>();

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_QUERY;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    procs.Add(new Processeur(reader));
                }
            }

            return procs;
        }
        
        
        
        
    }
    



}