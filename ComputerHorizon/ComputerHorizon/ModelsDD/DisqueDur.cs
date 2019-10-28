namespace ComputerHorizon.ModelsDD
{
    public class DisqueDur
    {
        public string nom { get; set; }
        public string marque { get; set; }
        public string capacite { get; set; }
        public bool ssd { get; set; }
        public double prix { get; set; }
        public bool interne { get; set; }
        public int quantite { get; set; }
        public string img { get; set; }

        public DisqueDur(string nom, string marque, string capacite, bool ssd, double prix, bool interne, int quantite, string img)
        {
            this.nom = nom;
            this.marque = marque;
            this.capacite = capacite;
            this.ssd = ssd;
            this.prix = prix;
            this.interne = interne;
            this.quantite = quantite;
            this.img = img;
        }
    }
}