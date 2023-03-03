using System.Collections.Generic;

namespace Modulo_C_sharp
{
    public class Ordine
    {
        protected string user;
        protected int cod_ordine;
        protected float prezzo_finale;

        public Ordine() { }

        public Ordine(string user, int cod_ordine, float prezzo_finale)
        {
            User = user;
            Cod_ordine = cod_ordine;
            Prezzo_finale = prezzo_finale;
        }

        public string User { get => user; set => user = value; }
        public int Cod_ordine { get => cod_ordine; set => cod_ordine = value; }
        public float Prezzo_finale { get => prezzo_finale; set => prezzo_finale = value; }
    }

    // Classe derivata da Ordine
    public class OrdineConListaProd : Ordine
    {
        protected List<Prodotto> prodotti_ordinati;

        public OrdineConListaProd(string user, int cod_ordine, List<Prodotto> prodotti_ordinati, float prezzo_finale)
        {
            User = user;
            Cod_ordine = cod_ordine;
            Prodotti_ordinati = prodotti_ordinati;
            Prezzo_finale = prezzo_finale;
        }

        public List<Prodotto> Prodotti_ordinati { get => prodotti_ordinati; set => prodotti_ordinati = value; }
    }
}
