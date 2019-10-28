namespace ComputerHorizon.ModelsCG
{
    public class CarteGraphique
    {
        public string nom { get; set; }
        public string marque { get; set; }
        public double prix { get; set; }
        public string frequence { get; set; }
        public string memoireVideo { get; set; }
        public int quantite { get; set; }
        
        public string img { get; set; }

        public CarteGraphique(string nom, string marque, double prix, string frequence, string memoireVideo, int quantite,string img)
        {
            this.nom = nom;
            this.marque = marque;
            this.prix = prix;
            this.frequence = frequence;
            this.memoireVideo = memoireVideo;
            this.quantite = quantite;
            this.img = img;
        }
    }
}