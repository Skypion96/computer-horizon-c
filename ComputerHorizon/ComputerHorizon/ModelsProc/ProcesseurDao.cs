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
        public static readonly string FIELD_QUANTITE = "qte";
        public static readonly string FIELD_IMG = "img";
        public static readonly string FIELD_REDUCTION = "reduction";
        public static readonly string FIELD_COTE = "cote";

        //REQUETES :
        
            //AFFICHER EN FONCTION DU NOM
        private static readonly string REQ_QUERY = $"SELECT * FROM {TABLE_NAME} " +
            $" WHERE {FIELD_NOM} = @{FIELD_NOM}";
        
            //AFFICHER UNIQUEMENT IMAGE + NOM + MARQUE                                     
        private static readonly string REQ_QUERY_BASE = $"SELECT * FROM {TABLE_NAME}"; //{FIELD_NOM},{FIELD_IMG},{FIELD_MARQUE} 
        
            //AJOUTER UN NOUVEAU PROCESSEUR
        private static readonly string REQ_POST = 
            $"INSERT INTO {TABLE_NAME} ({FIELD_NOM},{FIELD_MARQUE},{FIELD_NBCOEURS},{FIELD_FREQUENCE},{FIELD_PRIX},{FIELD_QUANTITE},{FIELD_IMG},{FIELD_REDUCTION},{FIELD_COTE})" +
            //$" OUTPUT Inserted.{FIELD_NOM}" +
            $" VALUES (@{FIELD_NOM},@{FIELD_MARQUE},@{FIELD_NBCOEURS},@{FIELD_FREQUENCE},@{FIELD_PRIX},@{FIELD_QUANTITE},@{FIELD_IMG},@{FIELD_REDUCTION},@{FIELD_COTE})";
        
            //SUPPRIMER EN FONCTION DU NOM
        private static readonly string REQ_DELETE =
            $"DELETE from {TABLE_NAME} WHERE {FIELD_NOM} = @{FIELD_NOM}";
        
            //METTRE A JOUR LES INFOS D'UN PROCESSEUR
        private static readonly string REQ_UPDATE =
            $"UPDATE {TABLE_NAME} SET {FIELD_MARQUE} = @{FIELD_MARQUE},{FIELD_NBCOEURS} = @{FIELD_NBCOEURS} " +
            $", {FIELD_FREQUENCE} = @{FIELD_FREQUENCE},{FIELD_PRIX} = @{FIELD_PRIX},{FIELD_QUANTITE} = @{FIELD_QUANTITE},{FIELD_IMG} = @{FIELD_IMG} "+
            $",{FIELD_REDUCTION} = @{FIELD_REDUCTION},{FIELD_COTE} = @{FIELD_COTE}" +
            $" WHERE {FIELD_NOM} = @{FIELD_NOM}";
        
        //METHODES :
        
            //VALEUR DE UN PROCESSEUR PARTICULIER
        public static Processeur Query(Processeur proc)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                bool hasBeenOK;
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_QUERY;
                command.Parameters.AddWithValue($"@{FIELD_NOM}", proc.Nom);
                if (command.ExecuteNonQuery() == 1)
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        proc = new Processeur(reader);
                    }
                }
            }
            return proc;
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
                command.Parameters.AddWithValue($"@{FIELD_NOM}", proc.Nom);
                command.Parameters.AddWithValue($"@{FIELD_MARQUE}", proc.Marque);
                command.Parameters.AddWithValue($"@{FIELD_NBCOEURS}", proc.NbCoeurs);
                command.Parameters.AddWithValue($"@{FIELD_FREQUENCE}", proc.Frequence);
                command.Parameters.AddWithValue($"@{FIELD_PRIX}", proc.Prix);
                command.Parameters.AddWithValue($"@{FIELD_QUANTITE}", proc.Qte);
                command.Parameters.AddWithValue($"@{FIELD_IMG}", proc.Img);
                command.Parameters.AddWithValue($"@{FIELD_REDUCTION}", proc.Reduction);
                command.Parameters.AddWithValue($"@{FIELD_COTE}", proc.Cote);
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
                command.Parameters.AddWithValue($"@{FIELD_NOM}",nom);
                hasBeenDeleted = command.ExecuteNonQuery() == 1;
            }
            return hasBeenDeleted;
        }
        
            //MISE A JOUR DE LA TABLE POUR UNE CARTE GRAPHIQUE SOUHAITE
        public static bool Update(Processeur proc)
        {
            bool hasBeenUpdate = false;
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_UPDATE;
                command.Parameters.AddWithValue($"@{FIELD_MARQUE}", proc.Marque);
                command.Parameters.AddWithValue($"@{FIELD_NBCOEURS}", proc.NbCoeurs);
                command.Parameters.AddWithValue($"@{FIELD_FREQUENCE}", proc.Frequence);
                command.Parameters.AddWithValue($"@{FIELD_PRIX}", proc.Prix);
                command.Parameters.AddWithValue($"@{FIELD_QUANTITE}", proc.Qte);
                command.Parameters.AddWithValue($"@{FIELD_IMG}", proc.Img);
                command.Parameters.AddWithValue($"@{FIELD_REDUCTION}", proc.Reduction);
                command.Parameters.AddWithValue($"@{FIELD_COTE}", proc.Cote);
                command.Parameters.AddWithValue($"@{FIELD_NOM}", proc.Nom);
                hasBeenUpdate = command.ExecuteNonQuery() ==1;
            }
            return hasBeenUpdate;
        }
    }
}