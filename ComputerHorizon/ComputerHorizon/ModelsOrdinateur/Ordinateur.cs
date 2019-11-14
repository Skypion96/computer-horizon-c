using System;
using System.Data.SqlClient;
using ComputerHorizon.ModelsProc;

namespace ComputerHorizon.ModelsOrdinateur
{
    public class Ordinateur
    {
        public string Nom { get; set; }
        public string Marque { get; set; }
        public double Prix { get; set; }
        public string NomProc { get; set; }
        public string NomCg { get; set; }
        public string Capacite { get; set; }
        public int MemoireV { get; set; }
        public bool Ssd { get; set; }
        public string Description { get; set; }
        public int Qte { get; set; }
        public string CapaciteSsd { get; set; }
        public string Img { get; set; }
        
        public double PrixReduc { get; set; }


        public Ordinateur(string nom, string marque, double prix, string nomProc, string nomCg, string capacite, int memoireV, bool ssd, string description, int qte, string capaciteSsd, string img,double prixReduc)
        {
            Nom = nom;
            Marque = marque;
            Prix = prix;
            NomProc = nomProc;
            NomCg = nomCg;
            Capacite = capacite;
            MemoireV = memoireV;
            Ssd = ssd;
            Description = description;
            Qte = qte;
            CapaciteSsd = capaciteSsd;
            Img = img;
            PrixReduc = prixReduc;

        }
        
        public Ordinateur(){}
        
        public Ordinateur(SqlDataReader reader)
        {
            Nom = reader[OrdinateurDao.FIELD_NOM].ToString();
            Marque = reader[OrdinateurDao.FIELD_MARQUE].ToString();
            Prix = Convert.ToDouble(reader[OrdinateurDao.FIELD_PRIX].ToString());
            NomProc = reader[OrdinateurDao.FIELD_NOMPROC].ToString();
            NomCg = reader[OrdinateurDao.FIELD_NOMCG].ToString();
            Capacite = reader[OrdinateurDao.FIELD_CAPACITE].ToString();
            MemoireV = Convert.ToInt32(reader[OrdinateurDao.FIELD_MEMOIREV].ToString());
            Ssd = Convert.ToBoolean(reader[OrdinateurDao.FIELD_SSD].ToString());
            Description = reader[OrdinateurDao.FIELD_DESCRIPTION].ToString();
            Qte = Convert.ToInt32(reader[OrdinateurDao.FIELD_QUANTITE].ToString());
            CapaciteSsd = reader[OrdinateurDao.FIELD_CAPACITE_SSD].ToString();
            Img = reader[OrdinateurDao.FIELD_IMG].ToString();
            PrixReduc = Convert.ToDouble(reader[OrdinateurDao.FIELD_PRIXREDUC].ToString());
        }
    }
}