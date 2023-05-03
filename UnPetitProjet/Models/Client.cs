namespace UnPetitProjet.Models
{
    public class Client
    {
        private int numero;
        private string nom;
        private string prenom;
        private string courriel;

        public Client(int numero, string nom, string prenom, string courriel)
        {
            this.numero = numero;
            this.nom = nom;
            this.prenom = prenom;
            this.courriel = courriel;
        }

        public int Numero { get => numero; set => numero = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Courriel { get => courriel; set => courriel = value; }
    }
}
