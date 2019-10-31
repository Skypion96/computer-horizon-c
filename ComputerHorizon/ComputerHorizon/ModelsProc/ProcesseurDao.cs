using System.Collections.Generic;
using System.Data.SqlClient;
using ComputerHorizon.Models;

namespace ComputerHorizon.ModelsProc
{
    public static class ProcesseurDao
    {
        //LE NOM DE LA TABLE
        private static readonly string TABLE_NAME = "processeur";
        
        //LES DIFFERENTS CHAMPS
        public static readonly string FIELD_NOM = "nom";
        public static readonly string FIELD_MARQUE = "marque";
        public static readonly string FIELD_NBCOEURS = "nbCoeurs";
        public static readonly string FIELD_FREQUENCE = "frequence";
        public static readonly string FIELD_PRIX = "prix";
        public static readonly string FIELD_QUANTITE = "quantite";
        public static readonly string FIELD_IMG = "img";
        
        //REQUETES :
        
            //AFFICHER EN FONCTION DU NOM
        private static readonly string REQ_QUERY = $"SELECT * FROM {TABLE_NAME}" +
            $" WHERE {FIELD_NOM} = @{FIELD_NOM}";
        
            //AFFICHER UNIQUEMENT IMAGE + NOM + MARQUE                                     
        private static readonly string REQ_QUERY_BASE = $"SELECT {FIELD_IMG},{FIELD_NOM},{FIELD_MARQUE} FROM {TABLE_NAME}";
        
            //AJOUTER UN NOUVEAU PROCESSEUR
        private static readonly string REQ_POST = 
            $"INSERT INTO {TABLE_NAME} ({FIELD_MARQUE},{FIELD_NBCOEURS},{FIELD_FREQUENCE},{FIELD_PRIX},{FIELD_QUANTITE},{FIELD_IMG})" +
            $" OUTPUT Inserted.{FIELD_NOM}" +
            $" VALUES (@{FIELD_MARQUE},@{FIELD_NBCOEURS},@{FIELD_FREQUENCE},@{FIELD_PRIX},@{FIELD_QUANTITE},@{FIELD_IMG})";
        
            //SUPPRIMER EN FONCTION DU NOM
        private static readonly string REQ_DELETE =
            $"DELETE from {TABLE_NAME} WHERE {FIELD_NOM} = @{FIELD_NOM}";
        
        //METHODES :
        
            //VALEUR DE UN PROCESSEUR PARTICULIER
        public static Processeur Query(Processeur procs)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_QUERY;
                command.Parameters.AddWithValue($"@{FIELD_NOM}", procs.Nom);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    procs = new Processeur(reader);
                }
            }
            return procs;
        }
        
        
            //AFFICHAGE DE L'IMAGE/ NOM / MARQUE'
        public static List<Processeur> QueryBase()
        {
            List<Processeur> procs = new List<Processeur>();
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_QUERY_BASE;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    procs.Add(new Processeur(reader));
                }
            }
            return procs;
        }
        
            //METHODE POUR AJOUTER UN PROCESSEUR
        public static Processeur Post(Processeur proc)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_POST;
                command.Parameters.AddWithValue($"@{FIELD_MARQUE}", proc.Marque);
                command.Parameters.AddWithValue($"@{FIELD_NBCOEURS}", proc.NbCoeurs);
                command.Parameters.AddWithValue($"@{FIELD_FREQUENCE}", proc.Frequence);
                command.Parameters.AddWithValue($"@{FIELD_PRIX}", proc.Prix);
                command.Parameters.AddWithValue($"@{FIELD_QUANTITE}", proc.Quantite);
                command.Parameters.AddWithValue($"@{FIELD_IMG}", proc.Img);
                proc.Nom = (string)command.ExecuteScalar();
            }
            return proc;
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