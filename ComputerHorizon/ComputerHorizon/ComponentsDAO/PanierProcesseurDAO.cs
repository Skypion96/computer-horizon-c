using System.Collections.Generic;
using System.Data.SqlClient;
using ComputerHorizon.Components;
using ComputerHorizon.Controllers;
using ComputerHorizon.Models;

namespace ComputerHorizon.ComponentsDAO
{
    public class PanierProcesseurDAO
    {
        //LE NOM DE LA TABLE
        private static readonly string TABLE_NAME = "panier_processeur";
        
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

        
        public static PanierProcesseur Post(PanierProcesseur pan)
        {
            Processeur proc = new Processeur();
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
        
        public static List<PanierProcesseur> QueryBase()
        {
            List<PanierProcesseur> procs = new List<PanierProcesseur>();
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_QUERY_BASE;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    procs.Add(new PanierProcesseur(reader));
                }
            }
            return procs;
        }
    }
}