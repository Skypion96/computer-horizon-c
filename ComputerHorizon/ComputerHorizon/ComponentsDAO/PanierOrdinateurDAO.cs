using System.Collections.Generic;
using System.Data.SqlClient;
using ComputerHorizon.Components;
using ComputerHorizon.Models;

namespace ComputerHorizon.ComponentsDAO
{
    public class PanierOrdinateurDAO
    {
        //LE NOM DE LA TABLE
        private static readonly string TABLE_NAME = "panier_ordinateur";
        
        //LES DIFFERENTS CHAMPS
        public static readonly string FIELD_ID = "id";
        public static readonly string FIELD_NOM = "nom";
        
        //REQUETES :
        
        //AJOUTER UN NOUVEAU PANIERPROCESSEUR
        private static readonly string REQ_POST =
            $"INSERT INTO {TABLE_NAME} ({FIELD_ID},{FIELD_NOM})" +
            $" values(@{FIELD_ID}, @{FIELD_NOM})";
        
        //AFFICHER UNIQUEMENT IMAGE + NOM + MARQUE                                     
        private static readonly string REQ_QUERY_BASE = $"SELECT * FROM {TABLE_NAME}";

        
        public static PanierOrdinateur Post(PanierOrdinateur pan)
        {
            Ordinateur proc = new Ordinateur();
            proc.Nom = pan.Nom;
            using (SqlConnection connection = DataBase.GetConnection())
            {
                
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_POST;
                command.Parameters.AddWithValue($"@{FIELD_ID}", pan.Id);
                command.Parameters.AddWithValue($"@{FIELD_NOM}", proc.Nom);
                pan.Nom = (string) command.ExecuteScalar();
            }
            return pan;
        }
        
        public static List<PanierOrdinateur> QueryBase()
        {
            List<PanierOrdinateur> procs = new List<PanierOrdinateur>();
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_QUERY_BASE;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    procs.Add(new PanierOrdinateur(reader));
                }
            }
            return procs;
        }
    }
}