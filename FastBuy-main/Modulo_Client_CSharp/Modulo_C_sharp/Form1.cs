using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Modulo_C_sharp
{
    public partial class FormAccedi : Form
    {
        private static string user;
        private string pass;
        private static string user_cod_ordine;
        
        public FormAccedi()
        {
            InitializeComponent();
        }

        // Usato quando si clicca sul tasto Accedi
        private void B_Accedi_Click(object sender, EventArgs e)
        {
            String str = user;
            String str1 = pass;

            if (str == null || str1 == null)
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
                    byte[] ba = asen.GetBytes("0" + str + "$" + str1);
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

                    if (str_final.CompareTo("Benvenuto amministratore") == 0)
                    {
                        FormInserimentoProd f3 = (FormInserimentoProd)Program.GetForm3();
                        f3.Show();
                        this.Hide();
                    }
                    else if (str_final.CompareTo("Benvenuto cliente") == 0)
                    {
                        FormSceltaCategoria f4 = (FormSceltaCategoria)Program.GetForm4();
                        try
                        {
                            TcpClient tcpclnt1 = new TcpClient();
                            Console.WriteLine("Connecting.....");

                            // Indirizzo IP usato per connettersi al Server Python (ThreadCodOrdine)
                            // per restituire il massimo valore del codice ordine associato all'utente
                            tcpclnt1.Connect("localhost", 8002);
                            Console.WriteLine("Connected");

                            Stream stm1 = tcpclnt1.GetStream();

                            ASCIIEncoding asen1 = new ASCIIEncoding();
                            byte[] ba1 = asen1.GetBytes(str);
                            Console.WriteLine("Transmitting.....");

                            stm1.Write(ba1, 0, ba1.Length);

                            byte[] bb1 = new byte[100];
                            int k1 = stm1.Read(bb1, 0, 100);
                            char[] vec1 = new char[k1];

                            for (int i = 0; i < k1; i++)
                            {
                                Console.Write(Convert.ToChar(bb1[i]));
                                vec1[i] = Convert.ToChar(bb1[i]);
                            }
                            user_cod_ordine = getString(vec1);
                            Console.WriteLine("CODICE:  " + user_cod_ordine);

                            tcpclnt1.Close();
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine("Error..... " + ex.StackTrace);
                        }
                        
                        f4.Show();
                        this.Hide();
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error..... " + ex.StackTrace);
                }
            }
        }

        // Usato quando si clicca sul link Registrazione
        private void LinkRegistrazione_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegistrazione f2 = (FormRegistrazione)Program.GetForm2();   
            f2.Show();
            this.Hide();
        }

        static string getString(char[] arr)
        {
            string s = new string(arr);
            return s;
        }

        // Funzioni utilizzate per prelevare il testo dai rispettivi campi
        private void PasswordText_TextChanged(object sender, EventArgs e)
        {
            string a = PasswordText.Text;
            pass = a;
        }

        private void UsernameText_TextChanged(object sender, EventArgs e)
        {
            string b = UsernameText.Text;
            user = b;
        }

        public static string getUser()
        {
            return user;
        }

        public static string getUserCodOrdine()
        {
            return user_cod_ordine;
        }
    }
}