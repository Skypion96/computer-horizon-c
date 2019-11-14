using System.Collections.Generic;
using System.Data.SqlClient;
using ComputerHorizon.Models;

namespace ComputerHorizon.ModelsDD
{
    public class DisqueDurDao
    {
        //LE NOM DE LA TABLE
        private static readonly string TABLE_NAME = "disque_dur";
        
        //LES DIFFERENTS CHAMPS
        public static readonly string FIELD_NOM = "nom";
        public static readonly string FIELD_MARQUE = "marque";
        public static readonly string FIELD_CAPACITE = "capacite";
        public static readonly string FIELD_SSD = "ssd";
        public static readonly string FIELD_PRIX = "prix";
        public static readonly string FIELD_INTERNE = "interne";
        public static readonly string FIELD_QUANTITE = "qte";
        public static readonly string FIELD_IMG = "img";
        public static readonly string FIELD_PRIXREDUC = "prixReduc";

        //REQUETES :
        
            //AFFICHER EN FONCTION DU NOM
        private static readonly string REQ_QUERY = $"SELECT * FROM {TABLE_NAME}" +
                                                   $" WHERE {FIELD_NOM} = @{FIELD_NOM}";
        
            //AFFICHER UNIQUEMENT IMAGE + NOM + MARQUE 
        private static readonly string REQ_QUERY_BASE = $"SELECT * FROM {TABLE_NAME}";
        
            //AJOUTER UN NOUVEAU DisqueDur
        private static readonly string REQ_POST = 
            $"INSERT INTO {TABLE_NAME} ({FIELD_NOM},{FIELD_MARQUE},{FIELD_CAPACITE},{FIELD_SSD},{FIELD_PRIX},{FIELD_INTERNE},{FIELD_QUANTITE},{FIELD_IMG},{FIELD_PRIXREDUC})" +
            $" VALUES (@{FIELD_NOM},@{FIELD_MARQUE},@{FIELD_CAPACITE},@{FIELD_SSD},@{FIELD_PRIX},@{FIELD_INTERNE},@{FIELD_QUANTITE},@{FIELD_IMG},@{FIELD_PRIXREDUC})";
        
            //SUPPRIMER EN FONCTION DU NOM
        private static readonly string REQ_DELETE =
            $"DELETE from {TABLE_NAME} WHERE {FIELD_NOM} = @{FIELD_NOM}";
        
            //METTRE A JOUR LES INFOS D'UN ORDINATEUR
        private static readonly string REQ_UPDATE =
            $"UPDATE {TABLE_NAME} SET {FIELD_MARQUE} = @{FIELD_MARQUE},{FIELD_SSD} = @{FIELD_SSD} " +
            $", {FIELD_PRIX} = @{FIELD_PRIX},{FIELD_INTERNE} = @{FIELD_INTERNE} " +
            $", {FIELD_QUANTITE} = @{FIELD_QUANTITE},{FIELD_IMG} = @{FIELD_IMG},{FIELD_PRIXREDUC} = @{FIELD_PRIXREDUC} " +
            $" WHERE {FIELD_NOM} = @{FIELD_NOM}";
        
        //METHODES :
        
            //VALEUR D'UN DISQUE DUR PARTICULIER
        public static DisqueDur Query(DisqueDur dds)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_QUERY;
                command.Parameters.AddWithValue($"@{FIELD_NOM}", dds.Nom);
                if (command.ExecuteNonQuery() == 1)
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        dds = new DisqueDur(reader);
                    }
                }
            }
            return dds;
        }
        
        //AFFICHAGE DE L'IMAGE/ NOM / MARQUE
        public static List<DisqueDur> QueryBase()
        {
            List<DisqueDur> dds = new List<DisqueDur>();
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_QUERY_BASE;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dds.Add(new DisqueDur(reader));
                }
            }
            return dds;
        }
            //METHODE POUR AJOUTER UN DISQUE DUR
        public static DisqueDur Post(DisqueDur disqueD)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_POST;
                command.Parameters.AddWithValue($"@{FIELD_NOM}", disqueD.Nom);
                command.Parameters.AddWithValue($"@{FIELD_MARQUE}", disqueD.Marque);
                command.Parameters.AddWithValue($"@{FIELD_CAPACITE}", disqueD.Capacite);
                command.Parameters.AddWithValue($"@{FIELD_SSD}", disqueD.Ssd);
                command.Parameters.AddWithValue($"@{FIELD_PRIX}", disqueD.Prix);
                command.Parameters.AddWithValue($"@{FIELD_INTERNE}", disqueD.Interne);
                command.Parameters.AddWithValue($"@{FIELD_QUANTITE}", disqueD.Qte);
                command.Parameters.AddWithValue($"@{FIELD_IMG}", disqueD.Img);
                command.Parameters.AddWithValue($"@{FIELD_PRIXREDUC}", disqueD.PrixReduc);
                disqueD.Nom = (string)command.ExecuteScalar(); 
            }
            return disqueD;
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
        public static bool Update(DisqueDur disqueD)
        {
            bool hasBeenUpdate = false;
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_UPDATE;
                command.Parameters.AddWithValue($"@{FIELD_MARQUE}", disqueD.Marque);
                command.Parameters.AddWithValue($"@{FIELD_CAPACITE}", disqueD.Capacite);
                command.Parameters.AddWithValue($"@{FIELD_SSD}", disqueD.Ssd);
                command.Parameters.AddWithValue($"@{FIELD_PRIX}", disqueD.Prix);
                command.Parameters.AddWithValue($"@{FIELD_INTERNE}", disqueD.Interne);
                command.Parameters.AddWithValue($"@{FIELD_QUANTITE}", disqueD.Qte);
                command.Parameters.AddWithValue($"@{FIELD_IMG}", disqueD.Img);
                command.Parameters.AddWithValue($"@{FIELD_PRIXREDUC}", disqueD.PrixReduc);
                command.Parameters.AddWithValue($"@{FIELD_NOM}", disqueD.Nom);
                hasBeenUpdate = command.ExecuteNonQuery() ==1;
            }
            return hasBeenUpdate;
        }
    }
}