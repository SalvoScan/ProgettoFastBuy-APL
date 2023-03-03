using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Modulo_C_sharp
{
    public partial class FormVisualizzazioneCarrello : Form
    {
        FormAccedi f1 = (FormAccedi)Program.GetForm1();
        List<Prodotto> prodottiCarrello = FormSceltaCategoria.Prodotti_carrello;

        // Tale flag serve per la gestione del Thread di notifica del tracciamento
        static ManualResetEvent flag = new ManualResetEvent(true);
        static ThreadNotificaTrack t = new ThreadNotificaTrack();
        static Thread NotificaTrack = new Thread(() => { t.Notify(); });

        LinkLabel linkLabel;
        float prezzoFinale;
        string str_final;
        static int codice_ordine;
        string codice;
        string categoria;
        string nome;
        string prezzo;
        string quantita;

        public static Thread GetThread()
        {
            return NotificaTrack;
        }

        public static ManualResetEvent GetFlag()
        {
            return flag;
        }

        public FormVisualizzazioneCarrello()
        {
            InitializeComponent();
        }

        private void FormVisualizzazioneCarrello_Closed(object sender, EventArgs e)
        {
            f1.Close();
            NotificaTrack.Abort();
        }

        private void FormVisualizzazioneCarrello_Load(object sender, EventArgs e)
        {

            codice_ordine = int.Parse(FormAccedi.getUserCodOrdine());
            MostraTabella();
        }

        //Nel momento in cui si clicca sul link per rimuovere un prodotto dal carrello,
        //parte tale funzione
        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel isLinkLabel = (LinkLabel)sender;
            int index = int.Parse(isLinkLabel.Name);

            prodottiCarrello.RemoveAt(index);
 
            for (int q = 0; q < prodottiCarrello.Count(); q++)
            {
                Console.WriteLine("Prod nel carrello: " + prodottiCarrello[q].Cod + " " + prodottiCarrello[q].Nome + " " + prodottiCarrello[q].Prezzo + " " + prodottiCarrello[q].Quantita);
            }
            
            MessageBox.Show("Prodotto rimosso");

            TabCarrello.Controls.Clear();
            prezzoFinale = 0;
            MostraTabella();

            if (prodottiCarrello.Count() == 0)
                B_CompletaOrdine.Hide();
        }

        public static int getCodOrdine()
        {
            return codice_ordine;
        }

        //Nel momento in cui viene premuto il bottone per completare l'ordine parte tale funzione
        private void B_CompletaOrdine_Click(object sender, EventArgs e)
        {
            codice_ordine = codice_ordine + 1;
            OrdineConListaProd ordine_confermato = new OrdineConListaProd(FormAccedi.getUser(), codice_ordine, prodottiCarrello, prezzoFinale);
            Console.WriteLine("Cod ordine: " + ordine_confermato.Cod_ordine);

            try
            {
                TcpClient tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");

                // Indirizzo IP usato per connettersi al Server C++
                tcpclnt.Connect("localhost", 8001);
                Console.WriteLine("Connected");

                Stream stm = tcpclnt.GetStream();

                // Concatenazione dei campi del numero di elementi nella lista, username
                // dell'utente loggato, codice dell'ordine e prezzo finale dell'ordine
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes("5" + ordine_confermato.Prodotti_ordinati.Count()+ "$" + ordine_confermato.User + "$" + ordine_confermato.Cod_ordine + "$" + ordine_confermato.Prezzo_finale);
                Console.WriteLine("Transmitting.....");

                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[100];
                int k = stm.Read(bb, 0, 100);
                char[] vec = new char[k];

                for (int i = 0; i < k; i++)
                {
                    Console.Write(Convert.ToChar(bb[i]));
                    vec[i] = Convert.ToChar(bb[i]);
                }

                str_final = getString(vec);
                Console.WriteLine(str_final);

                // Si mandano al Server C++ i prodotti contenuti all'interno della lista dell'ordine
                for (int i = 0; i < ordine_confermato.Prodotti_ordinati.Count(); i++)
                {
                    codice = ordine_confermato.Prodotti_ordinati[i].Cod;
                    categoria = ordine_confermato.Prodotti_ordinati[i].Categoria;
                    nome = ordine_confermato.Prodotti_ordinati[i].Nome;
                    prezzo = (ordine_confermato.Prodotti_ordinati[i].Prezzo).ToString();
                    quantita = (ordine_confermato.Prodotti_ordinati[i].Quantita).ToString();

                    Console.WriteLine(codice + categoria + nome + prezzo + quantita);

                    asen = new ASCIIEncoding();
                    ba = asen.GetBytes(codice + "$" + categoria + "$" + nome + "$" + prezzo + "$" + quantita);
                    Console.WriteLine("Transmitting.....");
                    stm.Write(ba, 0, ba.Length);

                    bb = new byte[100];
                    k = stm.Read(bb, 0, 100);
                    vec = new char[k];

                    for (int j = 0; j < k; j++)
                    {
                        Console.Write(Convert.ToChar(bb[j]));
                        vec[j] = Convert.ToChar(bb[j]);
                    }
                }

                bb = new byte[100];
                k = stm.Read(bb, 0, 100);
                vec = new char[k];
                for (int j = 0; j < k; j++)
                {
                    Console.Write(Convert.ToChar(bb[j]));
                    vec[j] = Convert.ToChar(bb[j]);
                }

                str_final = getString(vec);
                Console.WriteLine(str_final);
                MessageBox.Show(str_final);
                tcpclnt.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error..... " + ex.StackTrace);
            }

            // Se il Thread di notifica non è in esecuzione, si entra all'interno
            // di questo if
            if (!NotificaTrack.IsAlive)
            {
                Console.WriteLine("New Thread");
                NotificaTrack.Start();
            }

            // Se invece il Thread di notifica è in esecuzione, si entra all'interno
            // di questo else e si imposta il flag su segnalato
            else
            {
                Console.WriteLine("Resume Thread");
                flag.Set();
                Console.WriteLine("Fine Resume");
            }

            FormSceltaCategoria f4 = (FormSceltaCategoria)Program.GetForm4();
            f4.Show();
            TabCarrello.Controls.Clear();
            prodottiCarrello.Clear();
            prezzoFinale = 0;
            this.PrezzoFinaleLabel.Text = "Il prezzo finale é: " + prezzoFinale.ToString();
            this.Hide();
        }

        static string getString(char[] arr)
        {
            string s = new string(arr);
            return s;
        }

        // Usato quando si clicca sul tasto TornaIndietro
        private void B_TornaIndietro_Click(object sender, EventArgs e)
        {
            FormSceltaCategoria f4 = (FormSceltaCategoria)Program.GetForm4();
            f4.Show();
            TabCarrello.Controls.Clear();
            B_CompletaOrdine.Hide();
            this.Hide();
        }

        // Usato quando si clicca sul tasto AggiornaCarrello
        private void B_AggiornaCarrello_Click(object sender, EventArgs e)
        {
            if (prodottiCarrello.Count() == 0)
                MessageBox.Show("Il carrello è vuoto.");
            else
            {
                TabCarrello.Controls.Clear();
                prezzoFinale = 0;
                MostraTabella();
                B_CompletaOrdine.Show();
            }
        }

        // Funzione utilizzata per il corretto inserimento dei prodotti presenti nel carrello
        public void MostraTabella()
        {
            TabCarrello.Controls.Add(new Label() { Text = "Nome articolo", ForeColor = Color.Black }, 0, 0);
            TabCarrello.Controls.Add(new Label() { Text = "Prezzo totale", ForeColor = Color.Black }, 1, 0);
            TabCarrello.Controls.Add(new Label() { Text = "Quantità", ForeColor = Color.Black }, 2, 0);

            for (int m = 0; m < prodottiCarrello.Count; m++)
            {
                linkLabel = new LinkLabel
                {
                    Text = "Rimuovi dal carrello",
                    LinkColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))),
                    Name = (m).ToString(),
                };
                linkLabel.LinkClicked += LinkLabel_LinkClicked;

                TabCarrello.Controls.Add(new Label() { Text = prodottiCarrello[m].Nome }, 0, m + 1);
                TabCarrello.Controls.Add(new Label() { Text = prodottiCarrello[m].Prezzo.ToString() }, 1, m + 1);
                TabCarrello.Controls.Add(new Label() { Text = prodottiCarrello[m].Quantita.ToString() }, 2, m + 1);
                TabCarrello.Controls.Add(linkLabel, 3, m + 1);

                prezzoFinale += prodottiCarrello[m].Prezzo;
            }

            this.PrezzoFinaleLabel.Text = "Il prezzo finale é: " + prezzoFinale.ToString();
        }
    }
}