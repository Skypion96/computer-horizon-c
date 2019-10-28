using System.Collections.Generic;
using System.Data.SqlClient;
using ComputerHorizon.Models;
using ComputerHorizon.ModelsProc;

namespace ComputerHorizon.ModelsOrdinateur
{
    public class OrdinateurDao
    {
        private static readonly string TABLE_NAME = "ordinateur";
        
        public static readonly string FIELD_NOM = "nom";
        public static readonly string FIELD_MARQUE = "marque";
        public static readonly string FIELD_PRIX = "prix";
        public static readonly string FIELD_NOMPROC = "nomProc";
        public static readonly string FIELD_NOMCG = "nomCg";
        public static readonly string FIELD_CAPACITE = "capacite";
        public static readonly string FIELD_MEMOIREV = "memoireV";
        public static readonly string FIELD_SSD = "ssd";
        public static readonly string FIELD_DESCRIPTION = "description";
        public static readonly string FIELD_QUANTITE = "quantite";
        public static readonly string FIELD_CAPACITE_SSD = "capaciteSsd";
        public static readonly string FIELD_IMG = "img";

        private static readonly string REQ_QUERY = $"SELECT * FROM {TABLE_NAME}";

        private static readonly string REQ_POST = 
            $"INSERT INTO {TABLE_NAME} ({FIELD_MARQUE},{FIELD_PRIX},{FIELD_NOMPROC},{FIELD_NOMCG},{FIELD_CAPACITE},{FIELD_MEMOIREV},{FIELD_SSD},{FIELD_DESCRIPTION},{FIELD_QUANTITE},{FIELD_CAPACITE_SSD},{FIELD_IMG})" +
            $" OUTPUT Inserted.{FIELD_NOM}" +
            $" VALUES (@{FIELD_MARQUE},@{FIELD_PRIX},@{FIELD_NOMPROC},@{FIELD_NOMCG},@{FIELD_CAPACITE},@{FIELD_MEMOIREV},@{FIELD_SSD},@{FIELD_DESCRIPTION},@{FIELD_QUANTITE},@{FIELD_CAPACITE_SSD},@{FIELD_IMG})";

        public static List<Ordinateur> Query()
        {
            List<Ordinateur> ordis = new List<Ordinateur>();

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_QUERY;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ordis.Add(new Ordinateur(reader));
                }
            }

            return ordis;
        }
    }
}