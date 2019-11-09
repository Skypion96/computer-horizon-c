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
        public int Qte { get; set; }
        
        public string Img { get; set; }
        public int Reduction { get; set; }
        public int Cote { get; set; }
        public string  DateCote { get; set; }

        public Processeur(string nom, string marque, int nbCoeurs, string frequence, double prix, int qte, string img,int reduction,int cote,string dateCote)
        {
            Nom = nom;
            Marque = marque;
            NbCoeurs = nbCoeurs;
            Frequence = frequence;
            Prix = prix;
            Qte = qte;
            Img = img;
            Reduction = reduction;
            Cote = cote;
            DateCote = dateCote;
        }

        public Processeur()
        {
        }
        
        

        public Processeur(SqlDataReader reader)
        {
            Nom = reader[ProcesseurDao.FIELD_NOM].ToString();
            Marque = reader[ProcesseurDao.FIELD_MARQUE].ToString();
            NbCoeurs = Convert.ToInt32(reader[ProcesseurDao.FIELD_NBCOEURS].ToString());
            Frequence = reader[ProcesseurDao.FIELD_FREQUENCE].ToString();
            Prix = Convert.ToDouble(reader[ProcesseurDao.FIELD_PRIX].ToString());
            Qte = Convert.ToInt32(reader[ProcesseurDao.FIELD_QUANTITE].ToString());
            Img = reader[ProcesseurDao.FIELD_IMG].ToString();
            Reduction = Convert.ToInt32(reader[ProcesseurDao.FIELD_REDUCTION].ToString());
            Cote = Convert.ToInt32(reader[ProcesseurDao.FIELD_COTE].ToString());
            DateCote = reader[ProcesseurDao.FIELD_DATE_COTE].ToString();
        }
        
        
    }
}