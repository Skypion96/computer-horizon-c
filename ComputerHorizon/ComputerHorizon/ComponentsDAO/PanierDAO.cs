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
        
        //REQUETES :
        
        //AJOUTER UN NOUVEAU PROCESSEUR
        private static readonly string REQ_POST =
            $"INSERT INTO {TABLE_NAME} ({FIELD_ID})" +
            $" values(@{FIELD_ID})";
        
        //AFFICHER UNIQUEMENT IMAGE + NOM + MARQUE                                     
        private static readonly string REQ_QUERY_BASE = $"SELECT * FROM {TABLE_NAME} inner join panier_processeur on {TABLE_NAME}.@{FIELD_ID} = panier_processeur.id";


        
        public static Panier Post(Panier pan)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_POST;
                command.Parameters.AddWithValue($"@{FIELD_ID}", pan.Id);
                pan.Id = (int)command.ExecuteScalar(); 
            }
            return pan;
        }
        
        
                
        public static Panier QueryBase(int id)
        {
            Panier panier = new Panier();
            PanierProcesseur panierProcesseur = new PanierProcesseur();
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_QUERY_BASE;
                command.Parameters.AddWithValue($"@{FIELD_ID}",id);
                if (command.ExecuteNonQuery() == 1)
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        panier = new Panier(reader);
                        
                    }
                }
                
            }
            return panier;
        }
        
    }
}