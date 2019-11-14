using System;
using System.Data.SqlClient;
using ComputerHorizon.ModelsProc;

namespace ComputerHorizon.ModelsDD
{
    public class DisqueDur
    {
        public string Nom { get; set; }
        public string Marque { get; set; }
        public string Capacite { get; set; }
        public bool Ssd { get; set; }
        public double Prix { get; set; }
        public bool Interne { get; set; }
        public int Qte { get; set; }
        public string Img { get; set; }
        
        public double PrixReduc { get; set; }


        public DisqueDur(string nom, string marque, string capacite, bool ssd, double prix, bool interne, int qte, string img,double prixReduc)
        {
            Nom= nom;
            Marque = marque;
            Capacite = capacite;
            Ssd = ssd;
            Prix = prix;
            Interne = interne;
            Qte = qte;
            Img = img;
            PrixReduc = prixReduc;
        }

        public DisqueDur()
        {
            
        }
        
        public DisqueDur(SqlDataReader reader)
        {
            Nom = reader[DisqueDurDao.FIELD_NOM].ToString();
            Marque = reader[DisqueDurDao.FIELD_MARQUE].ToString();
            Capacite = reader[DisqueDurDao.FIELD_CAPACITE].ToString();
            Ssd = Convert.ToBoolean(reader[DisqueDurDao.FIELD_SSD].ToString());
            Prix = Convert.ToDouble(reader[DisqueDurDao.FIELD_PRIX].ToString());
            Interne = Convert.ToBoolean(reader[DisqueDurDao.FIELD_INTERNE].ToString());
            Qte = Convert.ToInt32(reader[DisqueDurDao.FIELD_QUANTITE].ToString());
            Img = reader[DisqueDurDao.FIELD_IMG].ToString();
            PrixReduc = Convert.ToDouble(reader[DisqueDurDao.FIELD_PRIXREDUC].ToString());
        }
    }
}