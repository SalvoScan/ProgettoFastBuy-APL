using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Modulo_C_sharp
{
    public partial class FormVisualizzazioneProdottiOrdine : Form
    {
        FormAccedi f1 = (FormAccedi)Program.GetForm1();
        List<Prodotto> lista_prodotti = new List<Prodotto>();
        
        static Thread NotificaTrack = FormVisualizzazioneCarrello.GetThread();
        string str_final;

        public FormVisualizzazioneProdottiOrdine()
        {
            InitializeComponent();
        }

        private void FormVisualizzazioneProdottiOrdine_Closed(object sender, EventArgs e)
        {
            f1.Close();
            NotificaTrack.Abort();
        }

        private void FormVisualizzazioneProdottiOrdine_Load(object sender, EventArgs e)
        {
            VisualizzazioneProdotti();
            // Vengono inseriti e visualizzati dinamicamente i prodotti all'interno di una tabella 
            MostraTabella();
        }

        static string getString(char[] arr)
        {
            string s = new string(arr);
            return s;
        }

        // Usato quando si clicca sul tasto TornaIndietro
        private void B_TornaIndietro_Click(object sender, EventArgs e)
        {
            FormVisualizzazioneOrdini f6 = (FormVisualizzazioneOrdini)Program.GetForm6();
            f6.Show();
            TabProdOrdine.Controls.Clear();
            this.PrezzoFinaleLabel.Hide();
            this.Hide();
        }

        // Usato quando si clicca sul tasto AggiornaProdottiOrdine
        private void B_AggiornaProdottiOrdine_Click(object sender, EventArgs e)
        {
            TabProdOrdine.Controls.Clear();
            lista_prodotti.Clear();
            VisualizzazioneProdotti();
            MostraTabella();
        }

        public void MostraTabella()
        {
            TabProdOrdine.Controls.Add(new Label() { Text = "Categoria", ForeColor = Color.Black }, 0, 0);
            TabProdOrdine.Controls.Add(new Label() { Text = "Nome", ForeColor = Color.Black }, 1, 0);
            TabProdOrdine.Controls.Add(new Label() { Text = "Prezzo", ForeColor = Color.Black }, 2, 0);
            TabProdOrdine.Controls.Add(new Label() { Text = "Quantita", ForeColor = Color.Black }, 3, 0);

            for (int m = 0; m < lista_prodotti.Count; m++)
            {
                TabProdOrdine.Controls.Add(new Label() { Text = lista_prodotti[m].Categoria }, 0, m + 1);
                TabProdOrdine.Controls.Add(new Label() { Text = lista_prodotti[m].Nome }, 1, m + 1);
                TabProdOrdine.Controls.Add(new Label() { Text = lista_prodotti[m].Prezzo.ToString() }, 2, m + 1);
                TabProdOrdine.Controls.Add(new Label() { Text = lista_prodotti[m].Quantita.ToString() }, 3, m + 1);
            }
            this.PrezzoFinaleLabel.Show();
            this.PrezzoFinaleLabel.Text = "Il prezzo finale é: " + FormVisualizzazioneOrdini.getPrezzoFinale().ToString();
        }

        public void VisualizzazioneProdotti()
        {
            string user = FormAccedi.getUser();
            int index = FormVisualizzazioneOrdini.getIndex();
            string cod_prodotto;
            string categoria;
            string nome;
            float prezzo;
            int quantita;

            try
            {
                TcpClient tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");

                // Indirizzo IP usato per connettersi al Server Python (ThreadVisualizzaProdotti)
                tcpclnt.Connect("localhost", 8004);
                Console.WriteLine("Connected");

                Stream stm = tcpclnt.GetStream();

                // Concatenazione dei valori inseriti nei campi
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(user + "$" + index);
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
                var v1 = str_final.Split('$');
                int ordLength = int.Parse(v1[0]);
                float prezzo_finale = float.Parse(v1[1]);

                // Si inseriscono i prodotti ricevuti dal server all'interno di una lista di prodotti
                for (int i = 0; i < ordLength; i++)
                {
                    bb = new byte[100];
                    k = stm.Read(bb, 0, 100);
                    vec = new char[k];

                    for (int j = 0; j < k; j++)
                    {
                        Console.Write(Convert.ToChar(bb[j]));
                        vec[j] = Convert.ToChar(bb[j]);
                    }

                    str_final = getString(vec);
                    // Console.WriteLine("STRINGA RICEVUTA:  " + str_final);
                    var prod = str_final.Split('$');
                    cod_prodotto = prod[0];
                    categoria = prod[1];
                    nome = prod[2];
                    prezzo = float.Parse(prod[3], CultureInfo.InvariantCulture.NumberFormat);
                    quantita = int.Parse(prod[4]);
                    Prodotto prodotto = new Prodotto(cod_prodotto, categoria, nome, prezzo, quantita);
                    lista_prodotti.Add(prodotto);

                    asen = new ASCIIEncoding();
                    ba = asen.GetBytes("OK");
                    Console.WriteLine("Transmitting.....");
                    stm.Write(ba, 0, ba.Length);
                }

                tcpclnt.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error..... " + ex.StackTrace);
            }
        }
    }
}