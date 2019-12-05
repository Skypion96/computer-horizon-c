using System.Collections.Generic;
using System.Data.SqlClient;
using ComputerHorizon.Components;
using ComputerHorizon.Models;

namespace ComputerHorizon.ComponentsDAO
{
    public class PanierCarteGraphiqueDAO
    {
        //LE NOM DE LA TABLE
        private static readonly string TABLE_NAME = "panier_carte_graphique";
        
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

        //SUPPRIMER EN FONCTION DU NOM
        private static readonly string REQ_DELETE =
            $"DELETE from {TABLE_NAME} WHERE {FIELD_NOM} = @{FIELD_NOM}";
        
        public static PanierCarteGraphique Post(PanierCarteGraphique pan)
        {
            CarteGraphique proc = new CarteGraphique();
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
        
        public static List<PanierCarteGraphique> QueryBase()
        {
            List<PanierCarteGraphique> procs = new List<PanierCarteGraphique>();
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_QUERY_BASE;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    procs.Add(new PanierCarteGraphique(reader));
                }
            }
            return procs;
        }
        
        //SUPPRESSION EN FONCTION DU NOM
        public static bool Delete(string nom)
        {
            bool hasBeenDeleted = false;
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_DELETE;
                command.Parameters.AddWithValue($"@{FIELD_NOM}", nom);
                hasBeenDeleted = command.ExecuteNonQuery() == 1;
            }
            return hasBeenDeleted;
        }
    }
}