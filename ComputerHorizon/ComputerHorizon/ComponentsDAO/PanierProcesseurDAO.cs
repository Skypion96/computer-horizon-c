using System.Data.SqlClient;
using ComputerHorizon.Components;
using ComputerHorizon.Models;

namespace ComputerHorizon.ComponentsDAO
{
    public class PanierProcesseurDAO
    {
        //LE NOM DE LA TABLE
        private static readonly string TABLE_NAME = "panierProcesseur";
        
        //LES DIFFERENTS CHAMPS
        public static readonly string FIELD_ID = "id";
        public static readonly string FIELD_NOM = "nom";
        
        //REQUETES :
        
        //AJOUTER UN NOUVEAU PANIERPROCESSEUR
        private static readonly string REQ_POST =
            $"INSERT INTO {TABLE_NAME} ({FIELD_ID}), ({FIELD_NOM})" +
            $" values(@{FIELD_ID}, @{FIELD_NOM})";

        
        public static PanierProcesseur Post(PanierProcesseur pan)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_POST;
                command.Parameters.AddWithValue($"@{FIELD_ID}", pan.Id);
                command.Parameters.AddWithValue($"@{FIELD_NOM}", pan.Nom);
                pan.Id = (int) command.ExecuteScalar();
            }
            return pan;
        }
    }
}