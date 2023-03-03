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
    public partial class FormSceltaCategoria : Form
    {
        FormAccedi f1 = (FormAccedi)Program.GetForm1();
        List<Prodotto> lista_prodotti = new List<Prodotto>();
        private static List<Prodotto> prodotti_carrello = new List<Prodotto>();
        static Thread NotificaTrack = FormVisualizzazioneCarrello.GetThread();

        int i;
        private int quantita;
        Button button;
        LinkLabel linkLabel;

        string str_final;

        public FormSceltaCategoria()
        {
            InitializeComponent();
        }

        public static List<Prodotto> Prodotti_carrello
        {
            set { prodotti_carrello = value; }
            get { return prodotti_carrello; }
        }

        private void FormSceltaCategoria_Closed(object sender, EventArgs e)
        {
            f1.Close();
            NotificaTrack.Abort();
        }

        private void FormSceltaCategoria_Load(object sender, EventArgs e)
        {
            TabProdotti.Hide();
            QuantitaLabel.Hide();
            NumQuantita.Hide();
            B_VisualizzaCarrello.Hide();

            try
            {
                TcpClient tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");

                // Indirizzo IP usato per connettersi al Server C++
                tcpclnt.Connect("localhost", 8001);
                Console.WriteLine("Connected");

                Stream stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes("3");
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
                tcpclnt.Close();  
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error..... " + ex.StackTrace);
            }


            // Caricamento dinamico dei bottoni delle categorie
            int top = 20;
            int left = 40;
            var repspl = str_final.Split('$');

            for (int i = 0; i < repspl.Length; i++)
                Console.WriteLine(repspl[i]);

            for (i = 0; i < repspl.Length; i++)
            {
                if (i == 5 || i == 10)
                {
                    top += 40;
                    left = 40;
                }

                button = new Button
                {
                    Left = left,
                    Top = top,
                    Text = repspl[i],
                    Name = i.ToString(),
                    BackColor = Color.OrangeRed,
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = SystemColors.ActiveCaptionText,
                    Size = new Size(100, 27),
                };

                left += 120;
                Console.WriteLine(left);
                button.Click += Button_Click;
                groupBox1.Controls.Add(button);
            }
        }

        static string getString(char[] arr)
        {
            string s = new string(arr);
            return s;
        }

        // Nel momento in cui viene premuto il bottone di una specifica categoria parte tale funzione
        private void Button_Click(object sender, EventArgs e)
        {
            Button isButton = (Button)sender;

            string codProdotto;
            string nomeProdotto;
            string categoriaProdotto;
            float prezzoProdotto;
            int quantitaProdotto;
            
            // Clear effettuate per permettere una corretta visualizzazione dei prodotti
            // quando si passa da una categoria ad un'altra
            TabProdotti.Controls.Clear();
            lista_prodotti.Clear();
            try
            {
                TcpClient tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");

                // Indirizzo IP usato per connettersi al Server C++
                tcpclnt.Connect("localhost", 8001);
                Console.WriteLine("Connected");

                Stream stm = tcpclnt.GetStream();

                // Concatenazione dei valori inseriti nei campi
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes("4" + isButton.Text);
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

                int prodLength = int.Parse(str_final);

                asen = new ASCIIEncoding();
                ba = asen.GetBytes("OK");
                Console.WriteLine("Transmitting.....");
                stm.Write(ba, 0, ba.Length);

                // Si inseriscono i prodotti ricevuti dal server all'interno di una lista di prodotti
                for (int i = 0; i < prodLength; i++)
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
                    var prod = str_final.Split('$');
                    codProdotto = prod[0];
                    categoriaProdotto = prod[1];
                    nomeProdotto = prod[2];
                    prezzoProdotto = float.Parse(prod[3], CultureInfo.InvariantCulture.NumberFormat);
                    quantitaProdotto = int.Parse(prod[4]);
                    Prodotto prodotto = new Prodotto(codProdotto, categoriaProdotto, nomeProdotto, prezzoProdotto, quantitaProdotto);
                    lista_prodotti.Add(prodotto);

                    asen = new ASCIIEncoding();
                    ba = asen.GetBytes("OK");
                    Console.WriteLine("Transmitting.....");
                    stm.Write(ba, 0, ba.Length);
                }

                bb = new byte[100];
                k = stm.Read(bb, 0, 100);
                vec = new char[k];

                tcpclnt.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error..... " + ex.StackTrace);
            }

            // Vengono inseriti e visualizzati dinamicamente i prodotti all'interno di una tabella 
            TabProdotti.Show();
            TabProdotti.Location = new Point(0 , groupBox1.Location.Y + groupBox1.Size.Height);
            TabProdotti.Controls.Add(new Label() { Text = "Nome articolo", ForeColor = Color.Black }, 0, 0);
            TabProdotti.Controls.Add(new Label() { Text = "Prezzo per articolo", ForeColor = Color.Black }, 1, 0);
            TabProdotti.Controls.Add(new Label() { Text = "Quantità disponibile", ForeColor = Color.Black }, 2, 0);
            
            for (int m = 0; m < lista_prodotti.Count; m++)
            {
                linkLabel = new LinkLabel
                {
                    Text = "Aggiungi al carrello",
                    LinkColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))),
                    Name = (m).ToString(),
                };

                linkLabel.LinkClicked += LinkLabel_LinkClicked;

                TabProdotti.Controls.Add(new Label() { Text = lista_prodotti[m].Nome }, 0, m + 1);
                TabProdotti.Controls.Add(new Label() { Text = lista_prodotti[m].Prezzo.ToString() }, 1, m + 1);
                TabProdotti.Controls.Add(new Label() { Text = lista_prodotti[m].Quantita.ToString()}, 2, m + 1);
                TabProdotti.Controls.Add(linkLabel, 3, m + 1);
            }

            // Vengono visualizzati i campi per il corretto inserimento della quantità
            // desiderata per il prodotto selezionato
            QuantitaLabel.Show();
            NumQuantita.Show();
        }

        // Nel momento in cui si clicca sul link per aggiungere il prodotto al carrello,
        // parte tale funzione
        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel isLinkLabel = (LinkLabel)sender;
            Prodotto prodotto_carrello;
            int index = int.Parse(isLinkLabel.Name);

            for(int m = 0; m < prodotti_carrello.Count(); m++)
            {
                if(prodotti_carrello[m].Cod.CompareTo(lista_prodotti[index].Cod) == 0)
                {
                    MessageBox.Show("Prodotto già inserito");
                    return;
                }
            }

            if (quantita > lista_prodotti[index].Quantita || quantita == 0)
            {
                Console.WriteLine(quantita);
                MessageBox.Show("Quantità non disponibile");
            }
 
            else
            {
                Console.WriteLine(quantita);
                float prezzoFinaleProd = lista_prodotti[index].Prezzo * quantita;
                Console.WriteLine(prezzoFinaleProd);
                
                // Dopo aver impostato la quantità e aver calcolato correttamente il prezzo del
                // prodotto desiderato, esso viene inserito all'interno di una lista di prodotti
                // del carrello
                prodotto_carrello = new Prodotto(lista_prodotti[index].Cod, lista_prodotti[index].Categoria, lista_prodotti[index].Nome, prezzoFinaleProd, quantita);
                prodotti_carrello.Add(prodotto_carrello);
                
                for(int q = 0; q < prodotti_carrello.Count(); q++)
                {
                    Console.WriteLine(prodotti_carrello[q].Cod + " " + prodotti_carrello[q].Nome + " " + prodotti_carrello[q].Prezzo + " " + prodotti_carrello[q].Quantita);
                }

                MessageBox.Show("Prodotto inserito nel carrello");
                B_VisualizzaCarrello.Show();
            }
        }

        private void NumQuantita_ValueChanged(object sender, EventArgs e)
        {
            int a = (int)NumQuantita.Value;
            quantita = a;
        }

        // Usato quando si clicca sul tasto VisualizzaCarrello
        private void B_VisualizzaCarrello_Click(object sender, EventArgs e)
        {
            FormVisualizzazioneCarrello f5 = (FormVisualizzazioneCarrello)Program.GetForm5();
            f5.Show();
            TabProdotti.Controls.Clear();
            this.Hide();
        }

        // Usato quando si clicca sul tasto VisualizzaOrdini
        private void B_VisualizzaOrdini_Click(object sender, EventArgs e)
        {
            FormVisualizzazioneOrdini f6 = (FormVisualizzazioneOrdini)Program.GetForm6();
            f6.Show();
            TabProdotti.Controls.Clear();
            this.Hide();
        }
    }
}