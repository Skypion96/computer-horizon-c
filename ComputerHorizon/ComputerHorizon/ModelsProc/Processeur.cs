namespace ComputerHorizon.ModelsProc
{
    public class Processeur
    {
        public string nom { get; set; }
        public string marque { get; set; }
        public int nbCoeurs { get; set; }
        public string frequence { get; set; }
        public double prix { get; set; }
        public int quantite { get; set; }
        public string img { get; set; }

        public Processeur(string nom, string marque, int nbCoeurs, string frequence, double prix, int quantite, string img)
        {
            this.nom = nom;
            this.marque = marque;
            this.nbCoeurs = nbCoeurs;
            this.frequence = frequence;
            this.prix = prix;
            this.quantite = quantite;
            this.img = img;
        }
    }
}