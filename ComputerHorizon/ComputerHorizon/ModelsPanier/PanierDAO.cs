using System.Collections.Generic;
using System.Data.SqlClient;
using ComputerHorizon.Models;
using ComputerHorizon.ModelsUtilisateur;

namespace ComputerHorizon.ModelsPanier
{
    public class PanierDAO
    {
        //LE NOM DE LA TABLE
        private static readonly string TABLE_NAME = "panier";
        
        //LES DIFFERENTS CHAMPS
        public static readonly string FIELD_ID = "id";
        public static readonly string FIELD_COUCOU = "testCOL";
        
        //REQUETES :
        
        //AJOUTER UN NOUVEAU PROCESSEUR
        private static readonly string REQ_POST =
            $"INSERT INTO {TABLE_NAME} ({FIELD_COUCOU})" +
            $" OUTPUT Inserted.{FIELD_ID}" +
            $" values(@{FIELD_COUCOU})";

        
        public static Panier Post(Panier pan)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_POST;
                command.Parameters.AddWithValue($"@{FIELD_COUCOU}", pan.TestCOL);

                pan.Id = (int)command.ExecuteScalar(); 
            }
            return pan;
        }
        
    }
}