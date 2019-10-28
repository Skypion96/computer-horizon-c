using System;
using System.Data.SqlClient;
using ComputerHorizon.ModelsDD;

namespace ComputerHorizon.ModelsCG
{
    public class CarteGraphique
    {
        public string Nom { get; set; }
        public string Marque { get; set; }
        public double Prix { get; set; }
        public string Frequence { get; set; }
        public string MemoireVideo { get; set; }
        public int Quantite { get; set; }
        
        public string Img { get; set; }

        public CarteGraphique(string nom, string marque, double prix, string frequence, string memoireVideo, int quantite,string img)
        {
            Nom = nom;
            Marque = marque;
            Prix = prix;
            Frequence = frequence;
            MemoireVideo = memoireVideo;
            Quantite = quantite;
            Img = img;
        }
        
        public CarteGraphique(SqlDataReader reader)
        {
            Nom = reader[CarteGraphiqueDao.FIELD_NOM].ToString();
            Marque = reader[CarteGraphiqueDao.FIELD_MARQUE].ToString();
            Prix = Convert.ToDouble(reader[CarteGraphiqueDao.FIELD_PRIX].ToString());
            Frequence =  reader[CarteGraphiqueDao.FIELD_FREQUENCE].ToString();
            MemoireVideo =  reader[CarteGraphiqueDao.FIELD_MEMOIRE_VIDEO].ToString();
            Quantite = Convert.ToInt32(reader[CarteGraphiqueDao.FIELD_QUANTITE].ToString());
            Img = reader[CarteGraphiqueDao.FIELD_IMG].ToString();
        }
    }
}