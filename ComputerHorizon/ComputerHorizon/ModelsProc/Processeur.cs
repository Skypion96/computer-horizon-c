using System;
using System.Data.SqlClient;

namespace ComputerHorizon.ModelsProc
{
    public class Processeur
    {
        public string Nom { get; set; }
        public string Marque { get; set; }
        public int NbCoeurs { get; set; }
        public string Frequence { get; set; }
        public double Prix { get; set; }
        public int Quantite { get; set; }
        public string Img { get; set; }

        public Processeur(string nom, string marque, int nbCoeurs, string frequence, double prix, int quantite, string img)
        {
            Nom = nom;
            Marque = marque;
            NbCoeurs = nbCoeurs;
            Frequence = frequence;
            Prix = prix;
            Quantite = quantite;
            Img = img;
        }
        
        public Processeur(SqlDataReader reader)
        {
            Nom = reader[ProcesseurDao.FIELD_NOM].ToString();
            Marque = reader[ProcesseurDao.FIELD_MARQUE].ToString();
            NbCoeurs = Convert.ToInt32(reader[ProcesseurDao.FIELD_NBCOEURS].ToString());
            Frequence = reader[ProcesseurDao.FIELD_FREQUENCE].ToString();
            Prix = Convert.ToDouble(reader[ProcesseurDao.FIELD_PRIX].ToString());
            Quantite = Convert.ToInt32(reader[ProcesseurDao.FIELD_QUANTITE].ToString());
            Img = reader[ProcesseurDao.FIELD_IMG].ToString();
        }
    }
}