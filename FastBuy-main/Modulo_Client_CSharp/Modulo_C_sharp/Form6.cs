using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Modulo_C_sharp
{
    public partial class FormVisualizzazioneOrdini : Form
    {
        FormAccedi f1 = (FormAccedi)Program.GetForm1();
        List<Ordine> lista_ordini = new List<Ordine>();
        static Thread NotificaTrack = FormVisualizzazioneCarrello.GetThread();

        string str_final;
        static int index = 0;
        static float prezzo_finale = 0;
        LinkLabel linkLabel;
        LinkLabel linkLabel1;

        public FormVisualizzazioneOrdini()
        {
            InitializeComponent();
        }

        private void FormVisualizzazioneOrdini_Closed(object sender, EventArgs e)
        {
            f1.Close();
            NotificaTrack.Abort();
        }

        private void FormVisualizzazioneOrdini_Load(object sender, EventArgs e)
        {

            VisualizzazioneOrdini();
            // Vengono inseriti e visualizzati dinamicamente i prodotti all'interno di una tabella 
            MostraTabella();
        }

        static string getString(char[] arr)
        {
            string s = new string(arr);
            return s;
        }

        public static int getIndex()
        {
            return index;
        }

        public static float getPrezzoFinale()
        {
            return prezzo_finale;
        }

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel isLinkLabel = (LinkLabel)sender;
            index = int.Parse(isLinkLabel.Name) + 1;
            // Console.WriteLine("VISUALIZZA PRODOTTI COD:  " + index);
            prezzo_finale = lista_ordini[index - 1].Prezzo_finale;
            FormVisualizzazioneProdottiOrdine f7 = (FormVisualizzazioneProdottiOrdine)Program.GetForm7();
            f7.Show();
            TabOrdini.Controls.Clear();
            this.Hide();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel isLinkLabel = (LinkLabel)sender;
            index = int.Parse(isLinkLabel.Name) + 1;
            // Console.WriteLine("TRACCIAMENTO ORDINI COD:  " + index);
            FormTracciamentoOrdine f8 = (FormTracciamentoOrdine)Program.GetForm8();
            f8.Show();
            TabOrdini.Controls.Clear();
            this.Hide();
        }

        // Usato quando si clicca sul tasto TornaIndietro
        private void B_TornaIndietro_Click(object sender, EventArgs e)
        {
            FormSceltaCategoria f4 = (FormSceltaCategoria)Program.GetForm4();
            f4.Show();
            TabOrdini.Controls.Clear();
            this.Hide();
        }

        // Usato quando si clicca sul tasto AggiornaListaOrdini
        private void B_AggiornaListaOrdini_Click(object sender, EventArgs e)
        {
            if (lista_ordini.Count() == 0)
                MessageBox.Show("Il carrello è vuoto.");
            else
            {
                TabOrdini.Controls.Clear();
                lista_ordini.Clear();
                VisualizzazioneOrdini();
                MostraTabella();
            }
        }

        public void MostraTabella()
        {
            TabOrdini.Controls.Add(new Label() { Text = "Codice ordine", ForeColor = Color.Black }, 0, 0);
            TabOrdini.Controls.Add(new Label() { Text = "Prezzo dell'ordine", ForeColor = Color.Black }, 1, 0);

            for (int m = 0; m < lista_ordini.Count; m++)
            {
                linkLabel = new LinkLabel
                {
                    Text = "Visualizza prodotti",
                    LinkColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))),
                    Name = (m).ToString(),
                };

                linkLabel1 = new LinkLabel
                {
                    Text = "Tracciamento",
                    LinkColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))),
                    Name = (m).ToString(),
                };

                linkLabel.LinkClicked += LinkLabel_LinkClicked;
                linkLabel1.LinkClicked += LinkLabel1_LinkClicked;

                TabOrdini.Controls.Add(new Label() { Text = lista_ordini[m].Cod_ordine.ToString() }, 0, m + 1);
                TabOrdini.Controls.Add(new Label() { Text = lista_ordini[m].Prezzo_finale.ToString() }, 1, m + 1);
                TabOrdini.Controls.Add(linkLabel, 2, m + 1);
                TabOrdini.Controls.Add(linkLabel1, 3, m + 1);
            }
        }

        public void VisualizzazioneOrdini()
        {
            string user = FormAccedi.getUser();
            int codOrdine;
            float prezzoFinaleOrdine;

            try
            {
                TcpClient tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");

                // Indirizzo IP usato per connettersi al Server Python (ThreadVisualizzaOrdini)
                tcpclnt.Connect("localhost", 8003);
                Console.WriteLine("Connected");

                Stream stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(user);
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

                int ordLength = int.Parse(str_final);

                // Si inseriscono i prodotti ricevuti dal server Python all'interno di una
                // lista di prodotti
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
                    var ord = str_final.Split('$');
                    codOrdine = int.Parse(ord[0]);
                    prezzoFinaleOrdine = float.Parse(ord[1], CultureInfo.InvariantCulture.NumberFormat);
                    Ordine ordine = new Ordine(user, codOrdine, prezzoFinaleOrdine);
                    lista_ordini.Add(ordine);

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