﻿using System.Collections.Generic;
using System.Data.SqlClient;
using ComputerHorizon.Models;
using ComputerHorizon.ModelsProc;

namespace ComputerHorizon.ModelsCG
{
    public class CarteGraphiqueDao
    {
        //LE NOM DE LA TABLE
        private static readonly string TABLE_NAME = "carte_graphique";
        
        //LES DIFFERENTS CHAMPS
        public static readonly string FIELD_NOM = "nom";
        public static readonly string FIELD_MARQUE = "marque";
        public static readonly string FIELD_PRIX = "prix";
        public static readonly string FIELD_FREQUENCE = "frequence";
        public static readonly string FIELD_MEMOIRE_VIDEO = "memoireVideo";
        public static readonly string FIELD_QUANTITE = "quantite";
        public static readonly string FIELD_IMG = "img";
        
        //REQUETES :
        
            //AFFICHER EN FONCTION DU NOM
        private static readonly string REQ_QUERY = $"SELECT * FROM {TABLE_NAME}";
        
            //AFFICHER UNIQUEMENT IMAGE + NOM + MARQUE 
        private static readonly string REQ_QUERY_BASE = $"SELECT {FIELD_IMG},{FIELD_NOM},{FIELD_MARQUE} FROM {TABLE_NAME}";
        
            //AJOUTER UN NOUVEAU PROCESSEUR
        private static readonly string REQ_POST = 
            $"INSERT INTO {TABLE_NAME} ({FIELD_MARQUE},{FIELD_PRIX},{FIELD_FREQUENCE},{FIELD_MEMOIRE_VIDEO},{FIELD_QUANTITE},{FIELD_IMG})" +
            $" OUTPUT Inserted.{FIELD_NOM}" +
            $" VALUES (@{FIELD_MARQUE},@{FIELD_PRIX},@{FIELD_FREQUENCE},@{FIELD_MEMOIRE_VIDEO},@{FIELD_QUANTITE},@{FIELD_IMG})";
        
            //SUPPRIMER EN FONCTION DU NOM
        private static readonly string REQ_DELETE =
            $"DELETE from {TABLE_NAME} WHERE {FIELD_NOM} = @{FIELD_NOM}";
        
        //METHODES :
        
            //VALEUR D'UNE CARTE GRAPHIQUE PARTICULIERE
        public static CarteGraphique Query(CarteGraphique carteG)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_QUERY;
                command.Parameters.AddWithValue($"@{FIELD_NOM}", carteG.Nom);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    carteG = new CarteGraphique(reader);
                }
            }
            return carteG;
        }
        
        
            //AFFICHAGE DE L'IMAGE/ NOM / MARQUE'
        public static List<CarteGraphique> QueryBase()
        {
            List<CarteGraphique> carteGs = new List<CarteGraphique>();
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_QUERY_BASE;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    carteGs.Add(new CarteGraphique(reader));
                }
            }
            return carteGs;
        }
            //METHODE POUR AJOUTER UNE CARTE GRAPHIQUE
        public static CarteGraphique Post(CarteGraphique carteG)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_POST;
                command.Parameters.AddWithValue($"@{FIELD_MARQUE}", carteG.Marque);
                command.Parameters.AddWithValue($"@{FIELD_PRIX}", carteG.Prix);
                command.Parameters.AddWithValue($"@{FIELD_FREQUENCE}", carteG.Frequence);
                command.Parameters.AddWithValue($"@{FIELD_MEMOIRE_VIDEO}", carteG.MemoireVideo);
                command.Parameters.AddWithValue($"@{FIELD_QUANTITE}", carteG.Quantite);
                command.Parameters.AddWithValue($"@{FIELD_IMG}", carteG.Img);
                carteG.Nom = (string)command.ExecuteScalar();
            }
            return carteG;
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