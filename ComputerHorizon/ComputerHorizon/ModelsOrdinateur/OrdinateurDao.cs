using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ComputerHorizon.Models;
using ComputerHorizon.ModelsProc;

namespace ComputerHorizon.ModelsOrdinateur
{
    public class OrdinateurDao
    {
        //LE NOM DE LA TABLEs
        private static readonly string TABLE_NAME = "ordinateur";
        
        //LES DIFFERENTS CHAMPS
        public static readonly string FIELD_NOM = "nom";
        public static readonly string FIELD_MARQUE = "marque";
        public static readonly string FIELD_PRIX = "prix";
        public static readonly string FIELD_NOMPROC = "nomProc";
        public static readonly string FIELD_NOMCG = "nomCg";
        public static readonly string FIELD_CAPACITE = "capacite";
        public static readonly string FIELD_MEMOIREV = "memoireV";
        public static readonly string FIELD_SSD = "ssd";
        public static readonly string FIELD_DESCRIPTION = "description";
        public static readonly string FIELD_QUANTITE = "qte";
        public static readonly string FIELD_CAPACITE_SSD = "capaciteSsd";
        public static readonly string FIELD_IMG = "img";
        public static readonly string FIELD_PRIXREDUC = "prixReduc";

        //REQUETES :
        
            //AFFICHER EN FONCTION DU NOM
        private static readonly string REQ_QUERY = $"SELECT * FROM {TABLE_NAME}" +
                                                   $" WHERE {FIELD_NOM} = @{FIELD_NOM}";
        
            //AFFICHER UNIQUEMENT IMAGE + NOM + MARQUE   
        private static readonly string REQ_QUERY_BASE = $"SELECT * FROM {TABLE_NAME}";
        
            //AJOUTER UN NOUVEAU PROCESSEUR
        private static readonly string REQ_POST = 
            $"INSERT INTO {TABLE_NAME} ({FIELD_NOM},{FIELD_MARQUE},{FIELD_PRIX},{FIELD_NOMPROC},{FIELD_NOMCG},{FIELD_CAPACITE},{FIELD_MEMOIREV},{FIELD_SSD},{FIELD_DESCRIPTION},{FIELD_QUANTITE},{FIELD_CAPACITE_SSD},{FIELD_IMG},{FIELD_PRIXREDUC})" +
            $" VALUES (@{FIELD_NOM},@{FIELD_MARQUE},@{FIELD_PRIX},@{FIELD_NOMPROC},@{FIELD_NOMCG},@{FIELD_CAPACITE},@{FIELD_MEMOIREV},@{FIELD_SSD},@{FIELD_DESCRIPTION},@{FIELD_QUANTITE},@{FIELD_CAPACITE_SSD},@{FIELD_IMG},@{FIELD_PRIXREDUC})";
            
            //SUPPRIMER EN FONCTION DU NOM
        private static readonly string REQ_DELETE =
            $"DELETE from {TABLE_NAME} WHERE {FIELD_NOM} = @{FIELD_NOM}";
        
            //METTRE A JOUR LES INFOS D'UN ORDINATEUR
        private static readonly string REQ_UPDATE =
            $"UPDATE {TABLE_NAME} SET {FIELD_MARQUE} = @{FIELD_MARQUE},{FIELD_PRIX} = @{FIELD_PRIX} " +
            $", {FIELD_NOMPROC} = @{FIELD_NOMPROC},{FIELD_NOMCG} = @{FIELD_NOMCG} " +
            $", {FIELD_CAPACITE} = @{FIELD_CAPACITE},{FIELD_MEMOIREV} = @{FIELD_MEMOIREV} " +
            $", {FIELD_SSD} = @{FIELD_SSD},{FIELD_DESCRIPTION} = @{FIELD_DESCRIPTION} " +
            $", {FIELD_QUANTITE} = @{FIELD_QUANTITE},{FIELD_CAPACITE_SSD} = @{FIELD_CAPACITE_SSD},{FIELD_IMG} = @{FIELD_IMG},{FIELD_PRIXREDUC} = @{FIELD_PRIXREDUC} " +
            $" WHERE {FIELD_NOM} = @{FIELD_NOM}";
        
        //METHODES :
        
            //VALEUR D'UN ORDINATEUR PARTICULIER
        public static Ordinateur Query(Ordinateur ordis)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_QUERY;
                command.Parameters.AddWithValue($"@{FIELD_NOM}", ordis.Nom);
                if (command.ExecuteNonQuery() == 1)
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ordis = new Ordinateur(reader);
                    }
                }
            }
            return ordis;
        }
        
            //AFFICHAGE DE L'IMAGE/ NOM / MARQUE
        public static List<Ordinateur> QueryBase()
        {
            List<Ordinateur> ordis = new List<Ordinateur>();
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_QUERY_BASE;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ordis.Add(new Ordinateur(reader));
                }
            }
            return ordis;
        }
        
            //METHODE POUR AJOUTER UN ORDINATEUR
        public static Ordinateur Post(Ordinateur ordi)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_POST;
                command.Parameters.AddWithValue($"@{FIELD_NOM}", ordi.Nom);
                command.Parameters.AddWithValue($"@{FIELD_MARQUE}", ordi.Marque);
                command.Parameters.AddWithValue($"@{FIELD_PRIX}", ordi.Prix);
                command.Parameters.AddWithValue($"@{FIELD_NOMPROC}", ordi.NomProc);
                command.Parameters.AddWithValue($"@{FIELD_NOMCG}", ordi.NomCg);
                command.Parameters.AddWithValue($"@{FIELD_CAPACITE}", ordi.Capacite);
                command.Parameters.AddWithValue($"@{FIELD_MEMOIREV}", ordi.MemoireV);
                command.Parameters.AddWithValue($"@{FIELD_SSD}", ordi.Ssd);
                command.Parameters.AddWithValue($"@{FIELD_DESCRIPTION}", ordi.Description);
                command.Parameters.AddWithValue($"@{FIELD_QUANTITE}", ordi.Qte);
                command.Parameters.AddWithValue($"@{FIELD_CAPACITE_SSD}", ordi.CapaciteSsd);
                command.Parameters.AddWithValue($"@{FIELD_IMG}", ordi.Img);
                command.Parameters.AddWithValue($"@{FIELD_PRIXREDUC}", ordi.PrixReduc);
                ordi.Nom = (string)command.ExecuteScalar(); //-> utilisation possible NE PAS SUPPRIMER
            }
            return ordi;
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
            
            //MISE A JOUR DE LA TABLE POUR UNE CARTE GRAPHIQUE SOUHAITE
        public static bool Update(Ordinateur ordi)
        {
            bool hasBeenUpdate = false;
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_UPDATE;
                command.Parameters.AddWithValue($"@{FIELD_MARQUE}", ordi.Marque);
                command.Parameters.AddWithValue($"@{FIELD_PRIX}", ordi.Prix);
                command.Parameters.AddWithValue($"@{FIELD_NOMPROC}", ordi.NomProc);
                command.Parameters.AddWithValue($"@{FIELD_NOMCG}", ordi.NomCg);
                command.Parameters.AddWithValue($"@{FIELD_CAPACITE}", ordi.Capacite);
                command.Parameters.AddWithValue($"@{FIELD_MEMOIREV}", ordi.MemoireV);
                command.Parameters.AddWithValue($"@{FIELD_SSD}", ordi.Ssd);
                command.Parameters.AddWithValue($"@{FIELD_DESCRIPTION}", ordi.Description);
                command.Parameters.AddWithValue($"@{FIELD_QUANTITE}", ordi.Qte);
                command.Parameters.AddWithValue($"@{FIELD_CAPACITE_SSD}", ordi.CapaciteSsd);
                command.Parameters.AddWithValue($"@{FIELD_IMG}", ordi.Img);
                command.Parameters.AddWithValue($"@{FIELD_PRIXREDUC}", ordi.PrixReduc);
                command.Parameters.AddWithValue($"@{FIELD_NOM}", ordi.Nom);
                hasBeenUpdate = command.ExecuteNonQuery() ==1;
            }
            return hasBeenUpdate;
        }
    }
}