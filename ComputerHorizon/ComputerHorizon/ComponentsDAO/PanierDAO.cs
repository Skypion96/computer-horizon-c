using System.Collections.Generic;
using System.Data.SqlClient;
using ComputerHorizon.Components;
using ComputerHorizon.Models;

namespace ComputerHorizon.ComponentsDAO
{
    public class PanierDAO
    {
        //LE NOM DE LA TABLE
        private static readonly string TABLE_NAME = "panier";
        
        //LES DIFFERENTS CHAMPS
        public static readonly string FIELD_ID = "id";
        public static readonly string FIELD_MAIL = "mail";
        
        //REQUETES :
        
        //AJOUTER UN NOUVEAU PROCESSEUR
        private static readonly string REQ_POST =
            $"INSERT INTO {TABLE_NAME} ({FIELD_MAIL})" +
            $" OUTPUT Inserted.{FIELD_ID}"+
            $" values(@{FIELD_MAIL})";
        
        //AFFICHER UNIQUEMENT IMAGE + NOM + MARQUE                                     
        private static readonly string REQ_QUERY_BASE = $"SELECT * FROM {TABLE_NAME}";


        
        public static Panier Post(Panier pan)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_POST;
                command.Parameters.AddWithValue($"@{FIELD_MAIL}", pan.Mail);
                pan.Id = (int)command.ExecuteScalar(); 
            }
            return pan;
        }
        
        
                
        public static List<Panier> QueryBase( )
        {
            List<Panier> panier = new List<Panier>();
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_QUERY_BASE;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    panier.Add(new Panier(reader));

                }

            }
            return panier;
        }
        
    }
}