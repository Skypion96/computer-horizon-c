using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ComputerHorizon.Components;
using ComputerHorizon.Models;

namespace ComputerHorizon.ComponentsDAO
{
    public class UtilisateurDAO
    {
        //LE NOM DE LA TABLE
        private static readonly string TABLE_NAME = "utilisateur";
        
        //LES DIFFERENTS CHAMPS
        public static readonly string FIELD_NOM_UTILISATEUR = "nomUtilisateur";
        public static readonly string FIELD_PRENOM_UTILISATEUR = "prenomUtilisateur";
        public static readonly string FIELD_MAIL = "mail";
        public static readonly string FIELD_MDP = "mdp";
        public static readonly string FIELD_TEL = "tel";
        public static readonly string FIELD_RUE = "rue";
        public static readonly string FIELD_NUMRUE = "numRue";
        public static readonly string FIELD_CP = "cp";
        public static readonly string FIELD_VILLE = "ville";
        //public static readonly string FIELD_IDPANIER = "idPanier";

        //REQUETES :
        
            //AFFICHER EN FONCTION DU NOM
        private static readonly string REQ_QUERY = $"SELECT * FROM {TABLE_NAME} " +
            $" WHERE {FIELD_MAIL} = @{FIELD_MAIL} AND {FIELD_MDP} = @{FIELD_MDP}";
        
            //AFFICHER UNIQUEMENT IMAGE + NOM + MARQUE                                     
        private static readonly string REQ_QUERY_BASE = $"SELECT * FROM {TABLE_NAME}";
        
            //AJOUTER UN NOUVEAU Utilisateur
        private static readonly string REQ_POST = 
            $"INSERT INTO {TABLE_NAME} ({FIELD_NOM_UTILISATEUR},{FIELD_PRENOM_UTILISATEUR},{FIELD_MAIL},{FIELD_MDP},{FIELD_TEL},{FIELD_RUE},{FIELD_NUMRUE},{FIELD_CP},{FIELD_VILLE})" +
            //$" OUTPUT Inserted.{FIELD_IDPANIER}" +
            $" VALUES (@{FIELD_NOM_UTILISATEUR},@{FIELD_PRENOM_UTILISATEUR},@{FIELD_MAIL},@{FIELD_MDP},@{FIELD_TEL},@{FIELD_RUE},@{FIELD_NUMRUE},@{FIELD_CP},@{FIELD_VILLE})";
        
            //SUPPRIMER EN FONCTION DU NOM
        private static readonly string REQ_DELETE =
            $"DELETE from {TABLE_NAME} WHERE {FIELD_MAIL} = @{FIELD_MAIL}";
        
            //METTRE A JOUR LES INFOS D'UN Utilisateur
        private static readonly string REQ_UPDATE =
            $"UPDATE {TABLE_NAME} SET {FIELD_NOM_UTILISATEUR} = @{FIELD_NOM_UTILISATEUR},{FIELD_PRENOM_UTILISATEUR} = @{FIELD_PRENOM_UTILISATEUR} " +
            $", {FIELD_MDP} = @{FIELD_MDP},{FIELD_TEL} = @{FIELD_TEL},{FIELD_RUE} = @{FIELD_RUE},{FIELD_NUMRUE} = @{FIELD_NUMRUE} "+
            $",{FIELD_CP} = @{FIELD_CP},{FIELD_VILLE} = @{FIELD_VILLE}" + /*,{FIELD_IDPANIER} = @{FIELD_IDPANIER}*/
            $" WHERE {FIELD_MAIL} = @{FIELD_MAIL}";
        
        //METHODES :
        
            //VALEUR DE UN Utilisateur PARTICULIER
        public static Utilisateur Query(string mail, string mdp)
        {
            Utilisateur user = null;
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_QUERY;
                command.Parameters.AddWithValue($"@{FIELD_MAIL}", mail);
                command.Parameters.AddWithValue($"@{FIELD_MDP}", mdp);
                SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new Utilisateur(reader);
                    }
            }
            return user;
        }
        
        
            //AFFICHAGE
        public static List<Utilisateur> QueryBase()
        {
            List<Utilisateur> users = new List<Utilisateur>();
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_QUERY_BASE;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new Utilisateur(reader));
                }
            }
            return users;
        }
        
            //METHODE POUR AJOUTER UN Utilisateur
        public static Utilisateur Post(Utilisateur user)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_POST;
                command.Parameters.AddWithValue($"@{FIELD_NOM_UTILISATEUR}",user.NomUtilisateur);
                command.Parameters.AddWithValue($"@{FIELD_PRENOM_UTILISATEUR}", user.PrenomUtilisateur);
                command.Parameters.AddWithValue($"@{FIELD_MAIL}", user.Mail);
                command.Parameters.AddWithValue($"@{FIELD_MDP}", user.Mdp);
                command.Parameters.AddWithValue($"@{FIELD_TEL}", user.Tel);
                command.Parameters.AddWithValue($"@{FIELD_RUE}", user.Rue);
                command.Parameters.AddWithValue($"@{FIELD_NUMRUE}", user.NumRue);
                command.Parameters.AddWithValue($"@{FIELD_CP}", user.Cp);
                command.Parameters.AddWithValue($"@{FIELD_VILLE}", user.Ville);
                //user.Mail = (string)command.ExecuteScalar(); 
                command.ExecuteNonQuery();
            }
            return user;
        }
        
            //SUPPRESSION EN FONCTION DU NOM
        public static bool Delete(string mail)
        {
            bool hasBeenDeleted = false;
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_DELETE;
                command.Parameters.AddWithValue($"@{FIELD_MAIL}",mail);
                hasBeenDeleted = command.ExecuteNonQuery() == 1;
            }
            return hasBeenDeleted;
        }
        
            //MISE A JOUR DE LA TABLE POUR UNE Utilisateur SOUHAITE
        public static bool Update(Utilisateur user)
        {
            bool hasBeenUpdate = false;
            using (SqlConnection connection = DataBase.GetConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = REQ_UPDATE;
                command.Parameters.AddWithValue($"@{FIELD_NOM_UTILISATEUR}", user.NomUtilisateur);
                command.Parameters.AddWithValue($"@{FIELD_PRENOM_UTILISATEUR}", user.PrenomUtilisateur);
                command.Parameters.AddWithValue($"@{FIELD_MDP}", user.Mdp);
                command.Parameters.AddWithValue($"@{FIELD_TEL}", user.Tel);
                command.Parameters.AddWithValue($"@{FIELD_RUE}", user.Rue);
                command.Parameters.AddWithValue($"@{FIELD_NUMRUE}", user.NumRue);
                command.Parameters.AddWithValue($"@{FIELD_CP}", user.Cp);
                command.Parameters.AddWithValue($"@{FIELD_VILLE}", user.Ville);
                //command.Parameters.AddWithValue($"@{FIELD_IDPANIER}", user.IdPanier);

                command.Parameters.AddWithValue($"@{FIELD_MAIL}", user.Mail);
                hasBeenUpdate = command.ExecuteNonQuery() ==1;
            }
            return hasBeenUpdate;
        }
    }
}