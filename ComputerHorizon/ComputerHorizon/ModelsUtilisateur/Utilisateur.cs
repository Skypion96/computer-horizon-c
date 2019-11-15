using System;
using System.Data.SqlClient;
using System.Globalization;

namespace ComputerHorizon.ModelsUtilisateur
{
    public class Utilisateur
    {
        public string NomUtilisateur { get; set; }
        public string PrenomUtilisateur { get; set; }
        public string Mail { get; set; }
        public string Mdp { get; set; }
        public string Tel { get; set; }
        public string Rue { get; set; }
        public string NumRue { get; set; }
        public int Cp { get; set; }
        public string Ville { get; set; }
        public string Token { get; set; }


        public Utilisateur(string nomUtilisateur, string prenomUtilisateur, string mail, string mdp, string tel, string rue, string numRue, int cp, string ville,string token)
        {
            NomUtilisateur = nomUtilisateur;
            PrenomUtilisateur = prenomUtilisateur;
            Mail = mail;
            Mdp = mdp;
            Tel = tel;
            Rue = rue;
            NumRue = numRue;
            Cp = cp;
            Ville = ville;
            Token = token;
        }

        public Utilisateur()
        {
        }

        public Utilisateur(SqlDataReader reader)
        {
            NomUtilisateur = reader[UtilisateurDAO.FIELD_NOM_UTILISATEUR].ToString();
            PrenomUtilisateur = reader[UtilisateurDAO.FIELD_PRENOM_UTILISATEUR].ToString();
            Mail = reader[UtilisateurDAO.FIELD_MAIL].ToString();
            Mdp = reader[UtilisateurDAO.FIELD_MDP].ToString();
            Tel = reader[UtilisateurDAO.FIELD_TEL].ToString();
            Rue = reader[UtilisateurDAO.FIELD_RUE].ToString();
            NumRue = reader[UtilisateurDAO.FIELD_NUMRUE].ToString();
            Cp = Convert.ToInt32(reader[UtilisateurDAO.FIELD_CP].ToString());
            Ville = reader[UtilisateurDAO.FIELD_VILLE].ToString();
            Token = reader[UtilisateurDAO.FIELD_TOKEN].ToString();
        }
    }
}