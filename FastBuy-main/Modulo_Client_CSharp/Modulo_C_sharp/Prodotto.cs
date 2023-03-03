namespace Modulo_C_sharp
{
    public class Prodotto
    {
        private string cod;
        private string categoria;
        private string nome;
        private float prezzo;
        private int quantita;

        public Prodotto(string cod, string categoria, string nome, float prezzo, int quantita)
        {
            Cod = cod;
            Categoria = categoria;
            Nome = nome;
            Prezzo = prezzo;
            Quantita = quantita;
        }

        public string Cod { get => cod; set => cod = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Nome { get => nome; set => nome = value; }
        public float Prezzo { get => prezzo; set => prezzo = value; }
        public int Quantita { get => quantita; set => quantita = value; }
    }
}
