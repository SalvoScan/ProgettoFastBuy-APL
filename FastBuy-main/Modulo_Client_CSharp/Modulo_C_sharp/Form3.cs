using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Modulo_C_sharp
{
    public partial class FormInserimentoProd : Form
    {
        private string codice;
        private string categoria;
        private string nome;
        private float prezzo;
        private int quantita;
        FormAccedi f1 = (FormAccedi)Program.GetForm1();

        public FormInserimentoProd()
        {
            InitializeComponent();
        }

        // Usato quando si clicca sul tasto Inserisci
        private void B_Inserisci_Click(object sender, EventArgs e)
        {
            String str = codice;
            String str1 = categoria;
            String str2 = nome;
            String str3 = prezzo.ToString();
            String str4 = quantita.ToString();

            if (str == null || str1 == null || str2 == null || str3 == null || str4 == null)
            {
                MessageBox.Show("Inserire campi mancanti");
            }

            else {
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
                    byte[] ba = asen.GetBytes("2" + str + "$" + str1 + "$" + str2 + "$" + str3 + "$" + str4);
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

                    string str_final = getString(vec);
                    MessageBox.Show(str_final);
                    tcpclnt.Close();
                }
                
                catch (Exception ex)
                {
                    Console.WriteLine("Error..... " + ex.StackTrace);
                }
            }
        }

        static string getString(char[] arr)
        {
            string s = new string(arr);
            return s;
        }

        private void CodiceText_TextChanged(object sender, EventArgs e)
        {
            string a = CodiceText.Text;
            codice = a;
        }

        private void CategoriaText_TextChanged(object sender, EventArgs e)
        {
            string b = CategoriaText.Text;
            categoria = b;
        }

        private void NomeText_TextChanged(object sender, EventArgs e)
        {
            string c = NomeText.Text;
            nome = c;
        }

        private void PrezzoText_TextChanged(object sender, EventArgs e)
        {
            string d = PrezzoText.Text;
            prezzo = float.Parse(d);
        }

        private void QuantitaText_TextChanged(object sender, EventArgs e)
        {
            string f = QuantitaText.Text;
            quantita = int.Parse(f);
        }

        private void FormInserimentoProd_Closed(object sender, EventArgs e)
        {
            f1.Close();
        }
    }
}
