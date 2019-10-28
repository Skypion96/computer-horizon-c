namespace ComputerHorizon.ModelsOrdinateur
{
    public class Ordinateur
    {
        public string nom { get; set; }
        public string marque { get; set; }
        public double prix { get; set; }
        public string nomProc { get; set; }
        public string nomCg { get; set; }
        public string capacite { get; set; }
        public int memoireV { get; set; }
        public bool ssd { get; set; }
        public string description { get; set; }
        public int quantite { get; set; }
        public string capaciteSsd { get; set; }
        public string img { get; set; }

        public Ordinateur(string nom, string marque, double prix, string nomProc, string nomCg, string capacite, int memoireV, bool ssd, string description, int quantite, string capaciteSsd, string img)
        {
            this.nom = nom;
            this.marque = marque;
            this.prix = prix;
            this.nomProc = nomProc;
            this.nomCg = nomCg;
            this.capacite = capacite;
            this.memoireV = memoireV;
            this.ssd = ssd;
            this.description = description;
            this.quantite = quantite;
            this.capaciteSsd = capaciteSsd;
            this.img = img;
        }
    }
}