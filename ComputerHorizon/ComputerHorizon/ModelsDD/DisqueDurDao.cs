using System.Collections.Generic;
using System.Data.SqlClient;
using ComputerHorizon.Models;

namespace ComputerHorizon.ModelsDD
{
    public class DisqueDurDao
    {
        private static readonly string TABLE_NAME = "disque_dur";
        
        public static readonly string FIELD_NOM = "nom";
        public static readonly string FIELD_MARQUE = "marque";
        public static readonly string FIELD_CAPACITE = "capacite";
        public static readonly string FIELD_SSD = "ssd";
        public static readonly string FIELD_PRIX = "prix";
        public static readonly string FIELD_INTERNE = "interne";
        public static readonly string FIELD_QUANTITE = "quantite";
        public static readonly string FIELD_IMG = "img";

        private static readonly string REQ_QUERY = $"SELECT * FROM {TABLE_NAME}";

        private static readonly string REQ_POST = 
            $"INSERT INTO {TABLE_NAME} ({FIELD_MARQUE},{FIELD_CAPACITE},{FIELD_SSD},{FIELD_PRIX},{FIELD_INTERNE},{FIELD_QUANTITE},{FIELD_IMG})" +
            $" OUTPUT Inserted.{FIELD_NOM}" +
            $" VALUES (@{FIELD_MARQUE},@{FIELD_CAPACITE},@{FIELD_SSD},@{FIELD_PRIX},@{FIELD_INTERNE},@{FIELD_QUANTITE},@{FIELD_IMG})";
        
        public static List<DisqueDur> Query()
        {
            List<DisqueDur> dds = new List<DisqueDur>();

            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_QUERY;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dds.Add(new DisqueDur(reader));
                }
            }

            return dds;
        }
        
        public static DisqueDur Post(DisqueDur disqueD)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_POST;

                command.Parameters.AddWithValue($"@{FIELD_MARQUE}", disqueD.Marque);
                command.Parameters.AddWithValue($"@{FIELD_CAPACITE}", disqueD.Capacite);
                command.Parameters.AddWithValue($"@{FIELD_SSD}", disqueD.Ssd);
                command.Parameters.AddWithValue($"@{FIELD_PRIX}", disqueD.Prix);
                command.Parameters.AddWithValue($"@{FIELD_INTERNE}", disqueD.Interne);
                command.Parameters.AddWithValue($"@{FIELD_QUANTITE}", disqueD.Quantite);
                command.Parameters.AddWithValue($"@{FIELD_IMG}", disqueD.Img);

                disqueD.Nom = (string)command.ExecuteScalar();
            }

            return disqueD;
        }

    }
}